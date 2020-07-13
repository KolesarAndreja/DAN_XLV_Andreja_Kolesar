using DAN_XLV.Command;
using DAN_XLV.Service;
using DAN_XLV.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLV.ViewModel
{
    class ManagerViewModel:ViewModelBase
    {
        ManagerWindow managerWindow;
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
        private bool _isDeletedProduct;
        public bool isDeletedProduct
        {
            get
            {
                return _isDeletedProduct;
            }
            set
            {
                _isDeletedProduct = value;
            }
        }
        #endregion

        #region CONSTRUCTOR
        public ManagerViewModel(ManagerWindow open)
        {
            managerWindow = open;
            productsList = Service.Service.GetAllProducts();
        }
        #endregion

        #region DELETE
        //delete product
        private ICommand _deleteThisProduct;
        public ICommand deleteThisProduct
        {
            get
            {
                if (_deleteThisProduct == null)
                {
                    _deleteThisProduct = new Command.RelayCommand(param => DeleteThisProductExecute(), param => CanDeleteThisProductExecute());

                }
                return _deleteThisProduct;
            }
        }

        private void DeleteThisProductExecute()
        {
            MessageBoxResult result = MessageBox.Show("Do you realy want to delete this product?", "Delete Product", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Service.Service.DeleteProduct(currentProduct);
                //string content2 = "User  " + viewUser.fullname + " with id " + viewUser.userID + " has been deleted.";
                //LogIntoFile.getInstance().PrintActionIntoFile(content2);
                isDeletedProduct = true;
                productsList = Service.Service.GetAllProducts();
            }
        }
        private bool CanDeleteThisProductExecute()
        {
            return true;
            //if (!currentProduct.stored)
            //{
            //    return true;
            //}
            //else
            //{
            //    MessageBox.Show("You cannot delete stored product.");
            //    return false;
            //}
            
        }
        #endregion

        #region EDIT
        //open window for editing user's data
        private ICommand _editThisProduct;
        public ICommand editThisProduct
        {
            get
            {
                if (_editThisProduct == null)
                {
                    _editThisProduct = new RelayCommand(param => EditThisProductExecute(), param => CanEditThisProductExecute());
                }
                return _editThisProduct;
            }
        }

        private void EditThisProductExecute()
        {
            try
            {
                if (currentProduct != null)
                {
                    AddWindow open = new AddWindow(currentProduct);
                    AddProductViewModel editProduct = new AddProductViewModel(open);
                    open.ShowDialog();

                    if ((open.DataContext as AddProductViewModel).isUpdated== true)
                    {
                        productsList = Service.Service.GetAllProducts();
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

        #region ADD PRODUCT
        private ICommand _addProduct;
        public ICommand addProduct
        {
            get
            {
                if (_addProduct == null)
                {
                    _addProduct = new RelayCommand(param => AddProductExecute(), param => CanAddProductExecute());
                }
                return _addProduct;
            }
        }
        private void AddProductExecute()
        {
            try
            {
                AddWindow add = new AddWindow();
                add.ShowDialog();
                if ((add.DataContext as AddProductViewModel).isUpdated == true)
                {
                    productsList = Service.Service.GetAllProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddProductExecute()
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
                managerWindow.Close();
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
