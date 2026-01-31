using System.Windows;
using AnnuaireModel;
using AnnuaireWpfApp.Infrastructure;

namespace AnnuaireWpfApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DatabaseInitializer.InitializeDatabase();

            ServiceLocator.Initialize();

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    System.Windows.Markup.XmlLanguage.GetLanguage("fr-FR")));
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // libérer les ressources de la base de données
            ServiceLocator.Dispose();
            base.OnExit(e);
        }
    }
}
