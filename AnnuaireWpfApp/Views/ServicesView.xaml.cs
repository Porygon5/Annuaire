using System.Linq;
using System.Windows.Controls;
using AnnuaireModel.Entities;
using AnnuaireWpfApp.Infrastructure;

namespace AnnuaireWpfApp.Views
{
    public partial class ServicesView : UserControl
    {
        public ServicesView()
        {
            InitializeComponent();
            ChargerServices();
        }

        private void ChargerServices()
        {
            var services = ServiceLocator.ServiceService.GetAll();
            
            foreach (var service in services)
            {
                service.Employes = ServiceLocator.EmployeService.GetByService(service.Id);
            }
            
            lstServices.ItemsSource = services;
        }

        private void LstServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstServices.SelectedItem is Service service)
            {
                AfficherEmployesService(service);
            }
        }

        private void AfficherEmployesService(Service service)
        {
            txtTitreService.Text = $"Employés du service {service.Nom}";
            
            var employes = ServiceLocator.EmployeService.GetByService(service.Id);
            lstEmployesService.ItemsSource = employes;
        }
    }
}
