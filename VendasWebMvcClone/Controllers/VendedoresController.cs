using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public async Task<IActionResult> Index()
        {
            var list = await _vendedorServico.FindALLAsync();
            return View(list);
        }

        public async Task<IActionResult> Criar()
        {
            var departamentos = await _servicoDepartamento.FindAllAsync();
            var viewModel = new ModeloFormularioVendedor { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _servicoDepartamento.FindAllAsync();
                var viewModel = new ModeloFormularioVendedor { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            await _vendedorServico.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorServico.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id)
        {
            await _vendedorServico.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorServico.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorServico.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Departamento> departamentos = await _servicoDepartamento.FindAllAsync();
            ModeloFormularioVendedor viewModel = new ModeloFormularioVendedor { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _servicoDepartamento.FindAllAsync();
                var viewModel = new ModeloFormularioVendedor { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            if(id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não incompativel" });
            }
            try
            {
               await _vendedorServico.UpdateAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}