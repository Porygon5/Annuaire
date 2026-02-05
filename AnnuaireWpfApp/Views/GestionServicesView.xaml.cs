using System.Windows;
using System.Windows.Controls;
using AnnuaireModel.Entities;
using AnnuaireWpfApp.Infrastructure;

namespace AnnuaireWpfApp.Views
{
    public partial class GestionServicesView : UserControl
    {
        private Service? serviceEnCours = null;
        private bool modeEdition = false;

        public GestionServicesView()
        {
            InitializeComponent();
            ChargerServices();
        }

        private void ChargerServices()
        {
            var services = ServiceLocator.ServiceService.GetAll();
            dgServices.ItemsSource = services;
        }

        private void DgServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgServices.SelectedItem is Service service)
            {
                AfficherFormulaireEdition(service);
            }
        }

        private void BtnNouveauService_Click(object sender, RoutedEventArgs e)
        {
            AfficherFormulaireCreation();
        }

        private void AfficherFormulaireCreation()
        {
            modeEdition = false;
            serviceEnCours = null;

            txtTitreForm.Text = "Nouveau service";
            txtNom.Text = string.Empty;

            pnlFormulaire.Visibility = Visibility.Visible;
            btnSupprimer.Visibility = Visibility.Collapsed;

            txtNom.Focus();
        }

        private void AfficherFormulaireEdition(Service service)
        {
            modeEdition = true;
            serviceEnCours = service;

            txtTitreForm.Text = "Modifier le service";
            txtNom.Text = service.Nom;

            pnlFormulaire.Visibility = Visibility.Visible;
            btnSupprimer.Visibility = Visibility.Visible;

            txtNom.Focus();
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Veuillez saisir un nom de service.", "Validation", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (modeEdition && serviceEnCours != null)
                {
                    serviceEnCours.Nom = txtNom.Text.Trim();
                    ServiceLocator.ServiceService.Update(serviceEnCours);
                    MessageBox.Show("Service modifié avec succès.", "Succès", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    var nouveauService = new Service
                    {
                        Nom = txtNom.Text.Trim()
                    };
                    ServiceLocator.ServiceService.Add(nouveauService);
                    MessageBox.Show("Service créé avec succès.", "Succès", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }

                ChargerServices();
                FermerFormulaire();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement : {ex.Message}", "Erreur", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (serviceEnCours == null) return;

            var result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer le service '{serviceEnCours.Nom}' ?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    ServiceLocator.ServiceService.Delete(serviceEnCours.Id);
                    MessageBox.Show("Service supprimé avec succès.", "Succès", 
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    ChargerServices();
                    FermerFormulaire();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            FermerFormulaire();
        }

        private void FermerFormulaire()
        {
            pnlFormulaire.Visibility = Visibility.Collapsed;
            dgServices.SelectedItem = null;
            serviceEnCours = null;
        }
    }
}
