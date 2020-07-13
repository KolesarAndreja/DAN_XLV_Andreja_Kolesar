using DAN_XLV.Command;
using DAN_XLV.Service;
using DAN_XLV.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLV.ViewModel
{
    class AddProductViewModel:ViewModelBase
    {
        AddWindow addProduct;
        private tblProduct _newProduct;
        public tblProduct newProduct
        {
            get
            {
                return _newProduct;
            }
            set
            {
                _newProduct = value;
                OnPropertyChanged("newProduct");
            }
        }

        public AddProductViewModel(AddWindow open)
        {
            addProduct = open;
            newProduct = new tblProduct();
        }

        public AddProductViewModel(AddWindow open, tblProduct editProduct)
        {
            addProduct = open;
            newProduct = editProduct;
        }

        private bool _isUpdated;
        public bool isUpdated
        {
            get
            {
                return _isUpdated;
            }
            set
            {
                _isUpdated = value;
            }
        }

        public LogIntoFile logAction;
        #region Commands

        private ICommand _save;
        public ICommand save
        {
            get
            {
                if (_save == null)
                {
                    _save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return _save;
            }
        }

        private void SaveExecute()
        {
            try
            {
                bool adding = false ;
                //adding
                if (newProduct.productId == 0)
                {
                    adding = true;
                }
                Service.Service.AddOrEditProduct(newProduct);
                if (adding)
                {
                    string content = String.Format("Manager has added product with id " + newProduct.productId);
                    logAction = new LogIntoFile(content);
                }
                isUpdated = true;
                addProduct.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(newProduct.productName) || newProduct.price<= 0 || newProduct.quantity<= 0|| newProduct.code == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }

        private ICommand _close;
        public ICommand close
        {
            get
            {
                if (_close == null)
                {
                    _close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return _close;
            }
        }


        private void CloseExecute()
        {
            try
            {
                addProduct.Close();
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
