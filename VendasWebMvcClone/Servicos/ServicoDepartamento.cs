using System;
using System.Linq;
using VendasWebMvcClone.Models;
using System.Collections.Generic;
namespace VendasWebMvcClone.Servicos
{
    public class ServicoDepartamento
    {
        private readonly VendasWebMvcCloneContext _context;

        public ServicoDepartamento(VendasWebMvcCloneContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Name).ToList();
        }
    }
}
