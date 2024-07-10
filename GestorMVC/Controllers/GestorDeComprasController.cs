using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestorMVC.Context;
using GestorMVC.Migrations;
using GestorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestorMVC.Controllers
{
    public class GestorDeComprasController(ComprasContext context) : Controller
    {
        private readonly ComprasContext _context = context;

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarFaturas")]
        public IActionResult ListarFaturas()
        {
            var faturas = _context.Faturas.ToList();
            return View(faturas);
        }

        [HttpPost]
        public IActionResult DeletarFatura(int id)
        {
            var faturaBanco = _context.Faturas.Find(id);
            
            if (faturaBanco == null)
            {
                return NotFound();
            }

            _context.Faturas.Remove(faturaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(ListarFaturas));
        
        }

        public IActionResult EditarFatura(int id)
        {
            var faturaBanco = _context.Faturas.Find(id);
            return View(faturaBanco);
        }

        [HttpPost]
        public IActionResult EditarFatura(Fatura fatura)
        {
            var faturaBanco = _context.Faturas.Find(fatura.Id);

            if (faturaBanco == null)
            {
                return NotFound();
            }

            faturaBanco.TotalCompra = fatura.TotalCompra;
            faturaBanco.TipoPagamento = fatura.TipoPagamento;
            faturaBanco.DataCompra = fatura.DataCompra;
            faturaBanco.Estado = fatura.Estado;
            faturaBanco.Recebedor = fatura.Recebedor;
            faturaBanco.Parcelas = fatura.Parcelas;

            _context.Faturas.Update(faturaBanco);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(ListarFaturas));
        }

        [HttpGet("CriarFatura")]
        public IActionResult CriarFatura()
        {
            return View();
        }

        [HttpPost("CriarFatura")]
        public IActionResult CriarFatura(Fatura fatura)
        {
            _context.Faturas.Add(fatura);
            _context.SaveChanges();
            return RedirectToAction(nameof(ListarFaturas));
        }

        [HttpGet("DetalhesFatura")]
        public IActionResult DetalhesFatura(int id)
        {
            var faturaBanco = _context.Faturas.Find(id);
            return View(faturaBanco);
        }

        [HttpGet("AdicionarProduto/{id?}")]
        public IActionResult AdicionarProduto(int? id)
        {
            if (id.HasValue)
            {
                ViewBag.Id = id.Value;
            }

            return View();
        }


        [HttpPost("AdicionarProdutoPost")]
        public IActionResult AdicionarProdutoPost(Produto produto)
        {
            _context.Produtos.Add(produto);

            var faturaBanco = _context.Faturas.Find(produto.FaturaId);
            faturaBanco.TotalCompra += produto.Preco * produto.Quantidade;

            _context.SaveChanges();
            return RedirectToAction("ProdutosFatura", new { id = produto.FaturaId });
        }

        [HttpPost]
        public IActionResult DeletarProduto(int id)
        {
            var produtoBanco = _context.Produtos.Find(id);

            if (produtoBanco == null)
            {
                return NotFound();
            }

            var faturaId = produtoBanco.FaturaId;

            _context.Produtos.Remove(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction("ProdutosFatura", new { id = faturaId });
        }



        [HttpGet("ProdutosFatura")]
        public IActionResult ProdutosFatura(int id)
        {
            var faturaBanco = _context.Faturas.Find(id);
            ViewBag.FaturaId = id;
            ViewBag.DataFatura = faturaBanco.DataCompra;
            ViewBag.Recebedor = faturaBanco.Recebedor;

            var produtos = _context.Produtos.Where(p => p.FaturaId == id).ToList();

            return View(produtos);   
        }

        [HttpGet("TodosOsProdutos")]
        public IActionResult TodosOsProdutos()
        {
            return View();
        }

        [HttpGet("EditarProduto/{id}")]
        public IActionResult EditarProduto(int id)
        {
            var produtoBanco = _context.Produtos.Find(id);
            if (produtoBanco == null)
            {
                return NotFound(); 
            }
            return View(produtoBanco);
        }

        [HttpPost("EditarProdutoPost")]
        public IActionResult EditarProdutoPost(Produto produto)
        {
            if (produto == null || produto.Id <= 0)
            {
                return NotFound();
            }

            var produtoBanco = _context.Produtos.Find(produto.Id);
            var faturaBanco = _context.Faturas.Find(produto.FaturaId);

            if (produtoBanco == null || faturaBanco == null)
            {
                return NotFound();
            }

            faturaBanco.TotalCompra -= produtoBanco.Preco * produtoBanco.Quantidade;

            produtoBanco.Nome = produto.Nome;
            produtoBanco.FaturaId = produto.FaturaId;
            produtoBanco.Preco = produto.Preco;
            produtoBanco.Quantidade = produto.Quantidade;
            produtoBanco.Categoria = produto.Categoria;
            produtoBanco.Validade = produto.Validade;

            faturaBanco.TotalCompra += produto.Preco * produto.Quantidade;

            _context.Faturas.Update(faturaBanco);
            _context.Produtos.Update(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction("ProdutosFatura", new { id = produto.FaturaId });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}