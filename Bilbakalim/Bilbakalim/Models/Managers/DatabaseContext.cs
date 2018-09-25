using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bilbakalim.Models.Managers
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Sorular> Sorular { get; set; }
        public DbSet<Cevaplar> Cevaplar { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new VeritabaniOlusturucu());
        }
    }

    public class VeritabaniOlusturucu:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Sorular soru = new Sorular();
            soru.Soru = "En Sevdiğin Sayı";
            context.Sorular.Add(soru);
            context.SaveChanges();
        }
    }
}