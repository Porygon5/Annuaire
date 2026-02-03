using System.Linq;
using System.Windows.Controls;
using AnnuaireModel.Entities;
using AnnuaireWpfApp.Infrastructure;

namespace AnnuaireWpfApp.Views
{
    public partial class SitesView : UserControl
    {
        public SitesView()
        {
            InitializeComponent();
            ChargerSites();
        }

        private void ChargerSites()
        {
            var sites = ServiceLocator.SiteService.GetAll();
            
            foreach (var site in sites)
            {
                site.Employes = ServiceLocator.EmployeService.GetBySite(site.Id);
            }
            
            lstSites.ItemsSource = sites;
        }

        private void LstSites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSites.SelectedItem is Site site)
            {
                AfficherEmployesSite(site);
            }
        }

        private void AfficherEmployesSite(Site site)
        {
            txtTitreSite.Text = $"Employés du site de {site.Ville}";
            
            var employes = ServiceLocator.EmployeService.GetBySite(site.Id);
            lstEmployesSite.ItemsSource = employes;
        }
    }
}
