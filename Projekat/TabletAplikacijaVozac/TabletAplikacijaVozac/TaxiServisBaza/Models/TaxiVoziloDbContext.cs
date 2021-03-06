﻿using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.Data.Sqlite;



namespace TabletAplikacijaVozac.TaxiServisBaza.Models
{
    class TaxiVoziloDbContext : TaxiVozilo
    {
        public DbSet<TaxiVozilo> TaxiVozila { get; set; }
        protected  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "TaxiServisBaza.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path,
               databaseFilePath);
            }
            catch (InvalidOperationException) { }
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
    }
}
