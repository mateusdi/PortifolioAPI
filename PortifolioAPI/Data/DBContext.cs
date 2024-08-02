﻿using Microsoft.EntityFrameworkCore;
using PortifolioAPI.Model;

namespace PortifolioAPI.Data
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
