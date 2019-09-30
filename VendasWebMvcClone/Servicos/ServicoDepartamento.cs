using System;
using System.Linq;
using VendasWebMvcClone.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMvcClone.Servicos
{
    public class ServicoDepartamento
    {
        private readonly VendasWebMvcCloneContext _context;

        public ServicoDepartamento(VendasWebMvcCloneContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
