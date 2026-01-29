using AnnuaireModel.Context;
using AnnuaireModel.Entities;

namespace AnnuaireModel.Seed
{
    public static class DatabaseSeeder
    {
        public static void SeedData(AnnuaireContext context)
        {
            if (context.Sites.Any())
            {
                return;
            }

            var sites = new List<Site>
            {
                new Site { Id = 1, Ville = "Paris" },
                new Site { Id = 2, Ville = "Nantes" },
                new Site { Id = 3, Ville = "Toulouse" },
                new Site { Id = 4, Ville = "Nice" },
                new Site { Id = 5, Ville = "Lille" }
            };
            context.Sites.AddRange(sites);
            context.SaveChanges();

            var services = new List<Service>
            {
                new Service { Id = 1, Nom = "Direction" },
                new Service { Id = 2, Nom = "Comptabilite" },
                new Service { Id = 3, Nom = "Production" },
                new Service { Id = 4, Nom = "Accueil" },
                new Service { Id = 5, Nom = "Informatique" },
                new Service { Id = 6, Nom = "Commercial" },
                new Service { Id = 7, Nom = "Ressources Humaines" },
                new Service { Id = 8, Nom = "Qualite" },
                new Service { Id = 9, Nom = "Logistique" },
                new Service { Id = 10, Nom = "Maintenance" }
            };
            context.Services.AddRange(services);
            context.SaveChanges();

            var employes = new List<Employe>
            {
                new Employe { Nom = "Dupont", Prenom = "Jean", TelephoneFixe = "01.45.23.56.78", TelephonePortable = "06.12.34.56.78", Email = "jean.dupont@entreprise.fr", ServiceId = 1, SiteId = 1 },
                new Employe { Nom = "Martin", Prenom = "Sophie", TelephoneFixe = "01.45.23.56.79", TelephonePortable = "06.12.34.56.79", Email = "sophie.martin@entreprise.fr", ServiceId = 1, SiteId = 1 },
                new Employe { Nom = "Bernard", Prenom = "Claire", TelephoneFixe = "01.45.23.56.80", TelephonePortable = "06.12.34.56.80", Email = "claire.bernard@entreprise.fr", ServiceId = 2, SiteId = 1 },
                new Employe { Nom = "Petit", Prenom = "Marc", TelephoneFixe = "01.45.23.56.81", TelephonePortable = "06.12.34.56.81", Email = "marc.petit@entreprise.fr", ServiceId = 2, SiteId = 1 },
                new Employe { Nom = "Robert", Prenom = "Julie", TelephoneFixe = "01.45.23.56.82", TelephonePortable = "06.12.34.56.82", Email = "julie.robert@entreprise.fr", ServiceId = 2, SiteId = 1 },
                new Employe { Nom = "Richard", Prenom = "Thomas", TelephoneFixe = "01.45.23.56.83", TelephonePortable = "06.12.34.56.83", Email = "thomas.richard@entreprise.fr", ServiceId = 4, SiteId = 1 },
                new Employe { Nom = "Durand", Prenom = "Emma", TelephoneFixe = "01.45.23.56.84", TelephonePortable = "06.12.34.56.84", Email = "emma.durand@entreprise.fr", ServiceId = 5, SiteId = 1 },
                new Employe { Nom = "Dubois", Prenom = "Lucas", TelephoneFixe = "01.45.23.56.85", TelephonePortable = "06.12.34.56.85", Email = "lucas.dubois@entreprise.fr", ServiceId = 5, SiteId = 1 },
                new Employe { Nom = "Moreau", Prenom = "Marie", TelephoneFixe = "01.45.23.56.86", TelephonePortable = "06.12.34.56.86", Email = "marie.moreau@entreprise.fr", ServiceId = 6, SiteId = 1 },
                new Employe { Nom = "Laurent", Prenom = "Paul", TelephoneFixe = "01.45.23.56.87", TelephonePortable = "06.12.34.56.87", Email = "paul.laurent@entreprise.fr", ServiceId = 6, SiteId = 1 },
                new Employe { Nom = "Simon", Prenom = "Lea", TelephoneFixe = "01.45.23.56.88", TelephonePortable = "06.12.34.56.88", Email = "lea.simon@entreprise.fr", ServiceId = 6, SiteId = 1 },
                new Employe { Nom = "Michel", Prenom = "Hugo", TelephoneFixe = "01.45.23.56.89", TelephonePortable = "06.12.34.56.89", Email = "hugo.michel@entreprise.fr", ServiceId = 7, SiteId = 1 },
                new Employe { Nom = "Lefebvre", Prenom = "Camille", TelephoneFixe = "01.45.23.56.90", TelephonePortable = "06.12.34.56.90", Email = "camille.lefebvre@entreprise.fr", ServiceId = 7, SiteId = 1 },
                new Employe { Nom = "Leroy", Prenom = "Nathan", TelephoneFixe = "01.45.23.56.91", TelephonePortable = "06.12.34.56.91", Email = "nathan.leroy@entreprise.fr", ServiceId = 8, SiteId = 1 },
                new Employe { Nom = "Roux", Prenom = "Chloe", TelephoneFixe = "01.45.23.56.92", TelephonePortable = "06.12.34.56.92", Email = "chloe.roux@entreprise.fr", ServiceId = 9, SiteId = 1 },

                new Employe { Nom = "Fournier", Prenom = "Antoine", TelephoneFixe = "02.40.12.34.56", TelephonePortable = "06.23.45.67.89", Email = "antoine.fournier@entreprise.fr", ServiceId = 3, SiteId = 2 },
                new Employe { Nom = "Girard", Prenom = "Sarah", TelephoneFixe = "02.40.12.34.57", TelephonePortable = "06.23.45.67.90", Email = "sarah.girard@entreprise.fr", ServiceId = 3, SiteId = 2 },
                new Employe { Nom = "Bonnet", Prenom = "Alexandre", TelephoneFixe = "02.40.12.34.58", TelephonePortable = "06.23.45.67.91", Email = "alexandre.bonnet@entreprise.fr", ServiceId = 3, SiteId = 2 },
                new Employe { Nom = "Fontaine", Prenom = "Laura", TelephoneFixe = "02.40.12.34.59", TelephonePortable = "06.23.45.67.92", Email = "laura.fontaine@entreprise.fr", ServiceId = 3, SiteId = 2 },
                new Employe { Nom = "Rousseau", Prenom = "Maxime", TelephoneFixe = "02.40.12.34.60", TelephonePortable = "06.23.45.67.93", Email = "maxime.rousseau@entreprise.fr", ServiceId = 3, SiteId = 2 },
                new Employe { Nom = "Vincent", Prenom = "Manon", TelephoneFixe = "02.40.12.34.61", TelephonePortable = "06.23.45.67.94", Email = "manon.vincent@entreprise.fr", ServiceId = 8, SiteId = 2 },
                new Employe { Nom = "Muller", Prenom = "Julien", TelephoneFixe = "02.40.12.34.62", TelephonePortable = "06.23.45.67.95", Email = "julien.muller@entreprise.fr", ServiceId = 9, SiteId = 2 },
                new Employe { Nom = "Blanc", Prenom = "Lisa", TelephoneFixe = "02.40.12.34.63", TelephonePortable = "06.23.45.67.96", Email = "lisa.blanc@entreprise.fr", ServiceId = 9, SiteId = 2 },
                new Employe { Nom = "Gauthier", Prenom = "Theo", TelephoneFixe = "02.40.12.34.64", TelephonePortable = "06.23.45.67.97", Email = "theo.gauthier@entreprise.fr", ServiceId = 10, SiteId = 2 },
                new Employe { Nom = "Garcia", Prenom = "Lucie", TelephoneFixe = "02.40.12.34.65", TelephonePortable = "06.23.45.67.98", Email = "lucie.garcia@entreprise.fr", ServiceId = 4, SiteId = 2 },

                new Employe { Nom = "Perrin", Prenom = "Nicolas", TelephoneFixe = "05.61.23.45.67", TelephonePortable = "06.34.56.78.90", Email = "nicolas.perrin@entreprise.fr", ServiceId = 3, SiteId = 3 },
                new Employe { Nom = "Morel", Prenom = "Oceane", TelephoneFixe = "05.61.23.45.68", TelephonePortable = "06.34.56.78.91", Email = "oceane.morel@entreprise.fr", ServiceId = 3, SiteId = 3 },
                new Employe { Nom = "Faure", Prenom = "Guillaume", TelephoneFixe = "05.61.23.45.69", TelephonePortable = "06.34.56.78.92", Email = "guillaume.faure@entreprise.fr", ServiceId = 3, SiteId = 3 },
                new Employe { Nom = "Barbier", Prenom = "Ines", TelephoneFixe = "05.61.23.45.70", TelephonePortable = "06.34.56.78.93", Email = "ines.barbier@entreprise.fr", ServiceId = 3, SiteId = 3 },
                new Employe { Nom = "Martinez", Prenom = "Raphael", TelephoneFixe = "05.61.23.45.71", TelephonePortable = "06.34.56.78.94", Email = "raphael.martinez@entreprise.fr", ServiceId = 8, SiteId = 3 },
                new Employe { Nom = "David", Prenom = "Anais", TelephoneFixe = "05.61.23.45.72", TelephonePortable = "06.34.56.78.95", Email = "anais.david@entreprise.fr", ServiceId = 9, SiteId = 3 },
                new Employe { Nom = "Bertrand", Prenom = "Mathieu", TelephoneFixe = "05.61.23.45.73", TelephonePortable = "06.34.56.78.96", Email = "mathieu.bertrand@entreprise.fr", ServiceId = 10, SiteId = 3 },
                new Employe { Nom = "Renard", Prenom = "Jade", TelephoneFixe = "05.61.23.45.74", TelephonePortable = "06.34.56.78.97", Email = "jade.renard@entreprise.fr", ServiceId = 4, SiteId = 3 },

                new Employe { Nom = "Mercier", Prenom = "Clement", TelephoneFixe = "04.93.12.34.56", TelephonePortable = "06.45.67.89.01", Email = "clement.mercier@entreprise.fr", ServiceId = 3, SiteId = 4 },
                new Employe { Nom = "Denis", Prenom = "Eva", TelephoneFixe = "04.93.12.34.57", TelephonePortable = "06.45.67.89.02", Email = "eva.denis@entreprise.fr", ServiceId = 3, SiteId = 4 },
                new Employe { Nom = "Lemaire", Prenom = "Valentin", TelephoneFixe = "04.93.12.34.58", TelephonePortable = "06.45.67.89.03", Email = "valentin.lemaire@entreprise.fr", ServiceId = 3, SiteId = 4 },
                new Employe { Nom = "Roussel", Prenom = "Charlotte", TelephoneFixe = "04.93.12.34.59", TelephonePortable = "06.45.67.89.04", Email = "charlotte.roussel@entreprise.fr", ServiceId = 8, SiteId = 4 },
                new Employe { Nom = "Caron", Prenom = "Louis", TelephoneFixe = "04.93.12.34.60", TelephonePortable = "06.45.67.89.05", Email = "louis.caron@entreprise.fr", ServiceId = 9, SiteId = 4 },
                new Employe { Nom = "Arnaud", Prenom = "Alice", TelephoneFixe = "04.93.12.34.61", TelephonePortable = "06.45.67.89.06", Email = "alice.arnaud@entreprise.fr", ServiceId = 10, SiteId = 4 },
                new Employe { Nom = "Brun", Prenom = "Arthur", TelephoneFixe = "04.93.12.34.62", TelephonePortable = "06.45.67.89.07", Email = "arthur.brun@entreprise.fr", ServiceId = 4, SiteId = 4 },

                new Employe { Nom = "Chevalier", Prenom = "Gabriel", TelephoneFixe = "03.20.45.67.89", TelephonePortable = "06.56.78.90.12", Email = "gabriel.chevalier@entreprise.fr", ServiceId = 3, SiteId = 5 },
                new Employe { Nom = "Colin", Prenom = "Zoe", TelephoneFixe = "03.20.45.67.90", TelephonePortable = "06.56.78.90.13", Email = "zoe.colin@entreprise.fr", ServiceId = 3, SiteId = 5 },
                new Employe { Nom = "Bouvier", Prenom = "Tom", TelephoneFixe = "03.20.45.67.91", TelephonePortable = "06.56.78.90.14", Email = "tom.bouvier@entreprise.fr", ServiceId = 8, SiteId = 5 },
                new Employe { Nom = "Germain", Prenom = "Lola", TelephoneFixe = "03.20.45.67.92", TelephonePortable = "06.56.78.90.15", Email = "lola.germain@entreprise.fr", ServiceId = 9, SiteId = 5 },
                new Employe { Nom = "Philippe", Prenom = "Adam", TelephoneFixe = "03.20.45.67.93", TelephonePortable = "06.56.78.90.16", Email = "adam.philippe@entreprise.fr", ServiceId = 10, SiteId = 5 }
            };

            context.Employes.AddRange(employes);
            context.SaveChanges();
        }
    }
}
