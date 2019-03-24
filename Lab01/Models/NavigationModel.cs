using Lab01.Views;
using Lab01.Windows;

namespace Lab01.Models
{
    class NavigationModel
    {
        private ContentWindow _contentWindow;
        private LoginView _loginView;

        public NavigationModel(ContentWindow contentWindow, Storage storage)
        {
            _contentWindow = contentWindow;
            _loginView = new LoginView(storage);
        }
        public void Navigate()
        {
            _contentWindow.ContentControl.Content = _loginView;
        }
    }
}
