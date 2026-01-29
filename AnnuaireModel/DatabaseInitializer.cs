using Microsoft.EntityFrameworkCore;
using AnnuaireModel.Context;
using AnnuaireModel.Seed;
using System.Diagnostics;

namespace AnnuaireModel
{
    public class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<AnnuaireContext>();
                optionsBuilder.UseSqlite("Data Source=AnnuaireEntreprise.db");

                using (var context = new AnnuaireContext(optionsBuilder.Options))
                {
                    Debug.WriteLine("Creation de la base de donnees...");
                    context.Database.EnsureCreated();

                    Debug.WriteLine("Base de donnees creee avec succes");
                    Debug.WriteLine("");

                    Debug.WriteLine("Insertion des donnees de test...");
                    DatabaseSeeder.SeedData(context);

                    Debug.WriteLine("Donnees de test inserees avec succes");
                    Debug.WriteLine("");
                    Debug.WriteLine("Base de donnees prete");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERREUR : {ex.Message}");
                Debug.WriteLine($"Details : {ex.InnerException?.Message}");
            }
        }
    }
}
