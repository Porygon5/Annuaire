using AnnuaireModel.Context;
using AnnuaireModel.Entities;

namespace AnnuaireWpfApp.Services
{
    public class ServiceService
    {
        private readonly AnnuaireContext _context;

        public ServiceService(AnnuaireContext context)
        {
            _context = context;
        }

        // récupérer les services
        public List<Service> GetAll()
        {
            return _context.Services.ToList();
        }

        // getbyid
        public Service? GetById(int id)
        {
            return _context.Services.Find(id);
        }

        // ajouter un service
        public void Add(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        //update 
        public void Update(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        // supprimer un service
        public bool Delete(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null) return false;

            // on vérifie bien que le service n'ait pas d'employés
            bool hasEmployes = _context.Employes.Any(e => e.ServiceId == id);

            if (hasEmployes)
            {
                throw new Exception("Impossible de supprimer : des employés sont affectés à ce service");
            }

            _context.Services.Remove(service);
            _context.SaveChanges();

            return true;
        }
    }
}
