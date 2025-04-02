﻿using ControleVendas.Models;
using ControleVendas.Repositories;

namespace ControleVendas.Services
{
    public class ServiceVenda
    {
        private AppDbContext _context;
        public RepositoryVenda RptVenda { get; set; }
        public RepositoryVendedor RptVendedor { get; set; }
        public ServiceVenda(AppDbContext context)
        {
            _context = context;
            RptVenda = new RepositoryVenda(_context);
            RptVendedor = new RepositoryVendedor(_context);
        }
    }
}
