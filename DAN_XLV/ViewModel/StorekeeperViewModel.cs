using DAN_XLV.Command;
using DAN_XLV.Service;
using DAN_XLV.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLV.ViewModel
{
    class StorekeeperViewModel:ViewModelBase
    {
        StorekeeperWIndow storekeeper;

        #region Property
        private List<tblProduct> _productsList;
        public List<tblProduct> productsList
        {
            get
            {
                return _productsList;
            }
            set
            {
                _productsList = value;
                OnPropertyChanged("productsList");
            }
        }

        private tblProduct _currentProduct;
        public tblProduct currentProduct
        {
            get
            {
                return _currentProduct;
            }
            set
            {
                _currentProduct = value;
                OnPropertyChanged("currentProduct");
            }
        }

        #endregion
        #region CONSTRUCTOR
        public StorekeeperViewModel(StorekeeperWIndow open)
        {
            storekeeper = open;
            productsList = Service.Service.GetOnlyNotStored();
        }
        #endregion

        #region STORE
        //open window for editing user's data
        private ICommand _storeThisProduct;
        public ICommand storeThisProduct
        {
            get
            {
                if (_storeThisProduct == null)
                {
                    _storeThisProduct = new RelayCommand(param => EditThisProductExecute(), param => CanEditThisProductExecute());
                }
                return _storeThisProduct;
            }
        }

        private void EditThisProductExecute()
        {
            try
            {
                if (currentProduct != null)
                {
                    string text = Service.Service.StoreProduct(currentProduct);
                    if (text != null)
                    {
                        MessageBox.Show(text);
                    }
                    else
                    {
                        MessageBox.Show("Product has been successfully stored.");
                        productsList = Service.Service.GetOnlyNotStored();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanEditThisProductExecute()
        {
            return true;
        }
        #endregion

        #region LOGOUT
        //logout
        private ICommand _close;
        public ICommand close
        {
            get
            {
                if (_close == null)
                {
                    _close = new Command.RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return _close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                Login login = new Login();
                storekeeper.Close();
                login.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
