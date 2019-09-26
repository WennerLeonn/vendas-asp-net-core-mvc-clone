﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvcClone.Models;

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
    }
}