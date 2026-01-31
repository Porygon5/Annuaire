using AnnuaireModel.Context;
using AnnuaireModel.Entities;

namespace AnnuaireWpfApp.Services
{
    public class SiteService
    {
        private readonly AnnuaireContext _context;

        public SiteService(AnnuaireContext context)
        {
            _context = context;
        }

        // récupérer les sites
        public List<Site> GetAll()
        {
            return _context.Sites.ToList();
        }

        // getbyid
        public Site? GetById(int id)
        {
            return _context.Sites.Find(id);
        }

        // ajouter un site
        public void Add(Site site)
        {
            _context.Sites.Add(site);
            _context.SaveChanges();
        }

        //update 
        public void Update(Site site)
        {
            _context.Sites.Update(site);
            _context.SaveChanges();
        }

        // supprimer un site
        public bool Delete(int id)
        {
            var site = _context.Sites.Find(id);
            if (site == null) return false;

            // on vérifie bien que le site n'ait pas d'employés
            bool hasEmployes = _context.Employes.Any(e => e.SiteId == id);

            if (hasEmployes)
            {
                throw new Exception("Impossible de supprimer : des employés sont affectés à ce site");
            }

            _context.Sites.Remove(site);
            _context.SaveChanges();

            return true;
        }
    }
}
