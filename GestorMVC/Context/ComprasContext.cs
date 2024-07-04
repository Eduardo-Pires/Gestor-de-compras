using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestorMVC.Models;

namespace GestorMVC.Context
{
    public class ComprasContext : DbContext
    {
        public ComprasContext(DbContextOptions<ComprasContext> options) : base(options)
        {

        }

        public DbSet<Fatura> Faturas { get; set;}
        public DbSet<Produto> Produtos { get; set; }
    }
}