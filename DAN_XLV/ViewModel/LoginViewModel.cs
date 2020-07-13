using DAN_XLV.Command;
using DAN_XLV.Model;
using DAN_XLV.View;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLV.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        Login login;

        private User _currentUser;
        public User currentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged("currentUser");
            }
        }

        public LoginViewModel(Login openLogin)
        {
            login = openLogin;
            currentUser = new User();
        }

        #region Commands
        private ICommand _loginBtn;
        public ICommand loginBtn
        {
            get
            {
                if (_loginBtn == null)
                {
                    _loginBtn = new RelayCommand(LoginExecute, CanLoginExecute);
                }
                return _loginBtn;
            }
        }

        private void LoginExecute(object obj)
        {
            currentUser.password = (obj as PasswordBox).Password;
            try
            {
                switch (currentUser.role)
                {
                    case "manager":
                        ManagerWindow man = new ManagerWindow();
                        login.Close();
                        man.ShowDialog();
                        break;
                    case "storekeeper":
                        StorekeeperWIndow keeper = new StorekeeperWIndow();
                        login.Close();
                        keeper.ShowDialog();
                        break;
                    case null:
                        MessageBox.Show("Invalid username or password. Try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLoginExecute(object obj)
        {
            return true;
        }
        #endregion


    }
}
