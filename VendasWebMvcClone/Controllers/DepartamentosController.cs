using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvcClone.Models;

namespace VendasWebMvcClone.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> list = new List<Departamento>();
            list.Add(new Departamento { Id = 1, Name = "Eletronicos" });
            list.Add(new Departamento { Id = 2, Name = "Modas" });

            return View(list);
        }
    }
}