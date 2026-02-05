using System.Windows;
using System.Windows.Input;

namespace AnnuaireWpfApp.Views
{
    public partial class MainWindow : Window
    {
        private bool isAdminMode = false;

        public MainWindow()
        {
            InitializeComponent();
            AfficherEmployes();
        }

        // gestion du mode admin via Ctrl+Shift+A
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A && 
                Keyboard.Modifiers == (ModifierKeys.Control | ModifierKeys.Shift))
            {
                if (!isAdminMode)
                {
                    DemanderMotDePasse();
                }
            }
        }

        // demander le mot de passe admin
        private void DemanderMotDePasse()
        {
            var dialog = new Window
            {
                Title = "Accès Administration",
                Width = 350,
                Height = 180,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                ResizeMode = ResizeMode.NoResize
            };

            var stack = new System.Windows.Controls.StackPanel
            {
                Margin = new Thickness(20)
            };

            stack.Children.Add(new System.Windows.Controls.TextBlock
            {
                Text = "Mot de passe administrateur :",
                Margin = new Thickness(0, 0, 0, 10)
            });

            var passwordBox = new System.Windows.Controls.PasswordBox
            {
                Margin = new Thickness(0, 0, 0, 15),
                Padding = new Thickness(5)
            };
            stack.Children.Add(passwordBox);

            var btnPanel = new System.Windows.Controls.StackPanel
            {
                Orientation = System.Windows.Controls.Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var btnOk = new System.Windows.Controls.Button
            {
                Content = "Valider",
                Width = 100,
                Height = 30,
                Margin = new Thickness(5)
            };

            var btnAnnuler = new System.Windows.Controls.Button
            {
                Content = "Annuler",
                Width = 100,
                Height = 30,
                Margin = new Thickness(5)
            };

            btnOk.Click += (s, e) =>
            {
                if (passwordBox.Password == "admin")
                {
                    ActiverModeAdmin();
                    dialog.Close();
                }
                else
                {
                    MessageBox.Show("Mot de passe incorrect", "Erreur", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            };

            btnAnnuler.Click += (s, e) => dialog.Close();

            btnPanel.Children.Add(btnOk);
            btnPanel.Children.Add(btnAnnuler);
            stack.Children.Add(btnPanel);

            dialog.Content = stack;
            dialog.ShowDialog();
        }

        // activer le mode admin
        private void ActiverModeAdmin()
        {
            isAdminMode = true;
            pnlAdmin.Visibility = Visibility.Visible;
            txtModeActuel.Text = "Mode : Administrateur";
            MessageBox.Show("Mode administrateur activé", "Succès", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // navigation menu visiteur
        private void BtnEmployes_Click(object sender, RoutedEventArgs e)
        {
            txtTitre.Text = "Employés";
            AfficherEmployes();
        }

        private void BtnSites_Click(object sender, RoutedEventArgs e)
        {
            txtTitre.Text = "Sites";
            AfficherSites();
        }

        private void BtnServices_Click(object sender, RoutedEventArgs e)
        {
            txtTitre.Text = "Services";
            AfficherServices();
        }

        // navigation menu admin
        private void BtnGestionEmployes_Click(object sender, RoutedEventArgs e)
        {
            txtTitre.Text = "Gestion des Employés";
            AfficherGestionEmployes();
        }

        private void BtnGestionSites_Click(object sender, RoutedEventArgs e)
        {
            txtTitre.Text = "Gestion des Sites";
            AfficherGestionSites();
        }

        private void BtnGestionServices_Click(object sender, RoutedEventArgs e)
        {
            txtTitre.Text = "Gestion des Services";
            AfficherGestionServices();
        }

        // affichage des vues
        private void AfficherEmployes()
        {
            contentGrid.Children.Clear();
            contentGrid.Children.Add(new EmployesView());
        }

        private void AfficherSites()
        {
            contentGrid.Children.Clear();
            contentGrid.Children.Add(new SitesView());
        }

        private void AfficherServices()
        {
            contentGrid.Children.Clear();
            contentGrid.Children.Add(new ServicesView());
        }

        private void AfficherGestionEmployes()
        {
            contentGrid.Children.Clear();
            contentGrid.Children.Add(new GestionEmployesView());
        }

        private void AfficherGestionSites()
        {
            contentGrid.Children.Clear();
            contentGrid.Children.Add(new GestionSitesView());
        }

        private void AfficherGestionServices()
        {
            contentGrid.Children.Clear();
            contentGrid.Children.Add(new GestionServicesView());
        }
    }
}
