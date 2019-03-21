using Lab01.Manager;
using Lab01.Models;
using Lab01.Windows;
using System.Windows;

namespace Lab01 {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            Storage storage = new Storage();

            ContentWindow contentWindow = new ContentWindow();
            NavigationModel navigationModel = new NavigationModel(contentWindow, storage);
            NavigationManager.Instance.Initialize(navigationModel);
            contentWindow.Show();
            navigationModel.Navigate();
        }
    }
}