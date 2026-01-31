using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnuaireModel.Context;
using AnnuaireModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnnuaireWpfApp.Services
{
    public class EmployeService
    {
        private readonly AnnuaireContext _context;

        public EmployeService(AnnuaireContext context)
        {
            _context = context;
        }

        // getall
        public List<Employe> GetAll()
        {
            return _context.Employes
                .Include(e => e.Site)
                .Include(e => e.Service)
                .ToList();
        }

        // getbyid
        public Employe? GetById(int id)
        {
            return _context.Employes
                .Include(e => e.Site)
                .Include(e => e.Service)
                .FirstOrDefault(e => e.Id == id);
        }

        // add
        public void Add(Employe employe)
        {
            _context.Employes.Add(employe);
            _context.SaveChanges();
        }

        // update
        public void Update(Employe employe)
        {
            _context.Employes.Update(employe);
            _context.SaveChanges();
        }

        // delete
        public bool Delete(int id)
        {
            var employe = _context.Employes.Find(id);
            if (employe == null) return false;

            _context.Employes.Remove(employe);
            _context.SaveChanges();
            return true;
        }

        // recherche par nom
        public List<Employe> GetByName(string searchTerm)
        {
            return _context.Employes
                .Include(e => e.Site)
                .Include(e => e.Service)
                .Where(e => e.Nom.Contains(searchTerm) || e.Prenom.Contains(searchTerm))
                .ToList();
        }

        // filtrer par site
        public List<Employe> GetBySite(int siteId)
        {
            return _context.Employes
                .Include(e => e.Site)
                .Include(e => e.Service)
                .Where(e => e.SiteId == siteId)
                .ToList();
        }

        // filtrer par service
        public List<Employe> GetByService(int serviceId)
        {
            return _context.Employes
                .Include(e => e.Site)
                .Include(e => e.Service)
                .Where(e => e.ServiceId == serviceId)
                .ToList();
        }
    }
}
