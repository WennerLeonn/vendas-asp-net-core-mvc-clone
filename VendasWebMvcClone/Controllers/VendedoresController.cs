using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvcClone.Models;
using VendasWebMvcClone.Servicos;

namespace VendasWebMvcClone.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorServico _vendedorServico;

        public VendedoresController(VendedorServico vendedorServico)
        {
            _vendedorServico = vendedorServico;
        }

        public IActionResult Index()
        {
            var list = _vendedorServico.FindALL();
            return View(list);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedor vendedor)
        {
            _vendedorServico.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}