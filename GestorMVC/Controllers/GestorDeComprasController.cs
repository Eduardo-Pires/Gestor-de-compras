using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestorMVC.Context;
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
            _context.Faturas.Remove(faturaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(ListarFaturas));
        
        }


        [HttpGet("CriarFatura")]
        public IActionResult CriarFatura()
        {
            return View();
        }

        [HttpGet("AdicionarProduto")]
        public IActionResult AdicionarProduto()
        {
            return View();
        }

        [HttpGet("ProdutosFatura")]
        public IActionResult ProdutosFatura()
        {
            return View();   
        }

        [HttpGet("TodosOsProdutos")]
        public IActionResult TodosOsProdutos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}