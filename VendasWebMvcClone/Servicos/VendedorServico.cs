using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvcClone.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMvcClone.Servicos
{
    public class VendedorServico
    {
        private readonly VendasWebMvcCloneContext _context;

        public VendedorServico(VendasWebMvcCloneContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindALL()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }
    }
}
