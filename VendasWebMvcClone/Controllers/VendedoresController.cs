using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvcClone.Models;
using VendasWebMvcClone.Models.ViewModels;
using VendasWebMvcClone.Servicos;
using VendasWebMvcClone.Servicos.Exceptions;

namespace VendasWebMvcClone.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorServico _vendedorServico;
        private readonly ServicoDepartamento _servicoDepartamento;

        public VendedoresController(VendedorServico vendedorServico, ServicoDepartamento servicoDepartamento)
        {
            _vendedorServico = vendedorServico;
            _servicoDepartamento = servicoDepartamento;
        }

        public IActionResult Index()
        {
            var list = _vendedorServico.FindALL();
            return View(list);
        }

        public IActionResult Criar()
        {
            var departamentos = _servicoDepartamento.FindAll();
            var viewModel = new ModeloFormularioVendedor { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedor vendedor)
        {
            _vendedorServico.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorServico.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            _vendedorServico.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorServico.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Editar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _vendedorServico.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            List<Departamento> departamentos = _servicoDepartamento.FindAll();
            ModeloFormularioVendedor viewModel = new ModeloFormularioVendedor { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Vendedor vendedor)
        {
            if(id != vendedor.Id)
            {
                return BadRequest();
            }
            try
            {
                _vendedorServico.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}