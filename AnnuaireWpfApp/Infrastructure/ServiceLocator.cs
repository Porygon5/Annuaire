using AnnuaireModel.Context;
using AnnuaireWpfApp.Services;
using Microsoft.EntityFrameworkCore;

namespace AnnuaireWpfApp.Infrastructure
{
    public static class ServiceLocator
    {
        private static AnnuaireContext? _context;
        private static SiteService? _siteService;
        private static ServiceService? _serviceService;
        private static EmployeService? _employeService;

        public static void Initialize()
        {
            // configuration pour SQLite
            var optionsBuilder = new DbContextOptionsBuilder<AnnuaireContext>();
            optionsBuilder.UseSqlite("Data Source=AnnuaireEntreprise.db");
            
            _context = new AnnuaireContext(optionsBuilder.Options);
            _siteService = new SiteService(_context);
            _serviceService = new ServiceService(_context);
            _employeService = new EmployeService(_context);
        }

        public static AnnuaireContext Context
        {
            get
            {
                if (_context == null)
                    throw new InvalidOperationException("ServiceLocator pas initialisé");
                return _context;
            }
        }

        public static SiteService SiteService
        {
            get
            {
                if (_siteService == null)
                    throw new InvalidOperationException("ServiceLocator pas initialisé");
                return _siteService;
            }
        }

        public static ServiceService ServiceService
        {
            get
            {
                if (_serviceService == null)
                    throw new InvalidOperationException("ServiceLocator pas initialisé");
                return _serviceService;
            }
        }

        public static EmployeService EmployeService
        {
            get
            {
                if (_employeService == null)
                    throw new InvalidOperationException("ServiceLocator pas initialisé");
                return _employeService;
            }
        }

        // fermer la connexion à la base de données
        public static void Dispose()
        {
            _context?.Dispose();
        }
    }
}
