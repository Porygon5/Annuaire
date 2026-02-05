using System.Windows;
using System.Windows.Controls;
using AnnuaireModel.Entities;
using AnnuaireWpfApp.Infrastructure;

namespace AnnuaireWpfApp.Views
{
    public partial class GestionSitesView : UserControl
    {
        private Site? siteEnCours = null;
        private bool modeEdition = false;

        public GestionSitesView()
        {
            InitializeComponent();
            ChargerSites();
        }

        private void ChargerSites()
        {
            var sites = ServiceLocator.SiteService.GetAll();
            dgSites.ItemsSource = sites;
        }

        private void DgSites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgSites.SelectedItem is Site site)
            {
                AfficherFormulaireEdition(site);
            }
        }

        private void BtnNouveauSite_Click(object sender, RoutedEventArgs e)
        {
            AfficherFormulaireCreation();
        }

        private void AfficherFormulaireCreation()
        {
            modeEdition = false;
            siteEnCours = null;

            txtTitreForm.Text = "Nouveau site";
            txtVille.Text = string.Empty;

            pnlFormulaire.Visibility = Visibility.Visible;
            btnSupprimer.Visibility = Visibility.Collapsed;

            txtVille.Focus();
        }

        private void AfficherFormulaireEdition(Site site)
        {
            modeEdition = true;
            siteEnCours = site;

            txtTitreForm.Text = "Modifier le site";
            txtVille.Text = site.Ville;

            pnlFormulaire.Visibility = Visibility.Visible;
            btnSupprimer.Visibility = Visibility.Visible;

            txtVille.Focus();
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVille.Text))
            {
                MessageBox.Show("Veuillez saisir une ville.", "Validation", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (modeEdition && siteEnCours != null)
                {
                    siteEnCours.Ville = txtVille.Text.Trim();
                    ServiceLocator.SiteService.Update(siteEnCours);
                    MessageBox.Show("Site modifié avec succès.", "Succès", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    var nouveauSite = new Site
                    {
                        Ville = txtVille.Text.Trim()
                    };
                    ServiceLocator.SiteService.Add(nouveauSite);
                    MessageBox.Show("Site créé avec succès.", "Succès", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }

                ChargerSites();
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
            if (siteEnCours == null) return;

            var result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer le site '{siteEnCours.Ville}' ?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    ServiceLocator.SiteService.Delete(siteEnCours.Id);
                    MessageBox.Show("Site supprimé avec succès.", "Succès", 
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    ChargerSites();
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
            dgSites.SelectedItem = null;
            siteEnCours = null;
        }
    }
}
