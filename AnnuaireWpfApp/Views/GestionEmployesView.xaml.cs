using System.Windows;
using System.Windows.Controls;
using AnnuaireModel.Entities;
using AnnuaireWpfApp.Infrastructure;

namespace AnnuaireWpfApp.Views
{
    public partial class GestionEmployesView : UserControl
    {
        private Employe? employeEnCours = null;
        private bool modeEdition = false;

        public GestionEmployesView()
        {
            InitializeComponent();
            ChargerDonnees();
        }

        private void ChargerDonnees()
        {
            ChargerEmployes();
            ChargerSites();
            ChargerServices();
        }

        private void ChargerEmployes()
        {
            var employes = ServiceLocator.EmployeService.GetAll();
            dgEmployes.ItemsSource = employes;
        }

        private void ChargerSites()
        {
            var sites = ServiceLocator.SiteService.GetAll();
            cboSite.ItemsSource = sites;
        }

        private void ChargerServices()
        {
            var services = ServiceLocator.ServiceService.GetAll();
            cboService.ItemsSource = services;
        }

        private void DgEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEmployes.SelectedItem is Employe employe)
            {
                AfficherFormulaireEdition(employe);
            }
        }

        private void BtnNouvelEmploye_Click(object sender, RoutedEventArgs e)
        {
            AfficherFormulaireCreation();
        }

        private void AfficherFormulaireCreation()
        {
            modeEdition = false;
            employeEnCours = null;

            txtTitreForm.Text = "Nouvel employé";
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtTelFixe.Text = string.Empty;
            txtTelPortable.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboSite.SelectedIndex = -1;
            cboService.SelectedIndex = -1;

            pnlFormulaire.Visibility = Visibility.Visible;
            btnSupprimer.Visibility = Visibility.Collapsed;

            txtNom.Focus();
        }

        private void AfficherFormulaireEdition(Employe employe)
        {
            modeEdition = true;
            employeEnCours = employe;

            txtTitreForm.Text = "Modifier l'employé";
            txtNom.Text = employe.Nom;
            txtPrenom.Text = employe.Prenom;
            txtTelFixe.Text = employe.TelephoneFixe;
            txtTelPortable.Text = employe.TelephonePortable;
            txtEmail.Text = employe.Email;
            cboSite.SelectedValue = employe.SiteId;
            cboService.SelectedValue = employe.ServiceId;

            pnlFormulaire.Visibility = Visibility.Visible;
            btnSupprimer.Visibility = Visibility.Visible;

            txtNom.Focus();
        }

        private void BtnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom est obligatoire.", "Validation", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Le prénom est obligatoire.", "Validation", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (cboSite.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un site.", "Validation", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (cboService.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un service.", "Validation", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (modeEdition && employeEnCours != null)
                {
                    employeEnCours.Nom = txtNom.Text.Trim();
                    employeEnCours.Prenom = txtPrenom.Text.Trim();
                    employeEnCours.TelephoneFixe = txtTelFixe.Text.Trim();
                    employeEnCours.TelephonePortable = txtTelPortable.Text.Trim();
                    employeEnCours.Email = txtEmail.Text.Trim();
                    employeEnCours.SiteId = (int)cboSite.SelectedValue;
                    employeEnCours.ServiceId = (int)cboService.SelectedValue;

                    ServiceLocator.EmployeService.Update(employeEnCours);
                    MessageBox.Show("Employé modifié avec succès.", "Succès", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    var nouvelEmploye = new Employe
                    {
                        Nom = txtNom.Text.Trim(),
                        Prenom = txtPrenom.Text.Trim(),
                        TelephoneFixe = txtTelFixe.Text.Trim(),
                        TelephonePortable = txtTelPortable.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        SiteId = (int)cboSite.SelectedValue,
                        ServiceId = (int)cboService.SelectedValue
                    };

                    ServiceLocator.EmployeService.Add(nouvelEmploye);
                    MessageBox.Show("Employé créé avec succès.", "Succès", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }

                ChargerEmployes();
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
            if (employeEnCours == null) return;

            var result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer l'employé '{employeEnCours.Prenom} {employeEnCours.Nom}' ?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    ServiceLocator.EmployeService.Delete(employeEnCours.Id);
                    MessageBox.Show("Employé supprimé avec succès.", "Succès", 
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    ChargerEmployes();
                    FermerFormulaire();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur", 
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
            dgEmployes.SelectedItem = null;
            employeEnCours = null;
        }
    }
}
