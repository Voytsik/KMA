using Lab01.Models;
using Lab01.ViewModels;
using System.Windows.Controls;

namespace Lab01.Views {
    public partial class LoginView : UserControl {
        private LoginViewModel _viewModel;

        public LoginView(Storage storage) {
            InitializeComponent();
            _viewModel = new LoginViewModel(storage);
            DataContext = _viewModel;
        }
    }
}