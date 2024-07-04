using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestorMVC.Controllers
{
    public class GestorDeComprasController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarFaturas")]
        public IActionResult ListarFaturas()
        {
            return View();
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