using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AnnuaireModel.Entities;
using AnnuaireWpfApp.Infrastructure;

namespace AnnuaireWpfApp.Views
{
    public partial class EmployesView : UserControl
    {
        public EmployesView()
        {
            InitializeComponent();
            ChargerEmployes();
        }

        // charger tous les employés
        private void ChargerEmployes()
        {
            var employes = ServiceLocator.EmployeService.GetAll();
            lstEmployes.ItemsSource = employes;
        }

        // recherche par nom (insensible à la casse)
        private void TxtRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTerm = txtRecherche.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                ChargerEmployes();
            }
            else
            {
                // recherche insensible à la casse
                var employes = ServiceLocator.EmployeService.GetAll();
                var resultats = employes.Where(emp => 
                    emp.Nom.ToLower().Contains(searchTerm.ToLower()) ||
                    emp.Prenom.ToLower().Contains(searchTerm.ToLower())
                ).ToList();
                
                lstEmployes.ItemsSource = resultats;
            }
        }

        // afficher les détails
        private void LstEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstEmployes.SelectedItem is Employe employe)
            {
                AfficherDetails(employe);
            }
        }

        // remplir la fiche employé
        private void AfficherDetails(Employe employe)
        {
            pnlDetails.Visibility = Visibility.Visible;
            txtNom.Text = employe.Nom;
            txtPrenom.Text = employe.Prenom;
            txtTelFixe.Text = employe.TelephoneFixe ?? "-";
            txtTelPortable.Text = employe.TelephonePortable ?? "-";
            txtEmail.Text = employe.Email ?? "-";
            txtService.Text = employe.Service?.Nom ?? "-";
            txtSite.Text = employe.Site?.Ville ?? "-";
        }
    }
}
