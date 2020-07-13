using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLV.Service
{
    class Service
    {
        #region GET LISTS
        public static List<tblProduct> GetAllProducts()
        {
            try
            {
                using (dbWarehouseEntities context = new dbWarehouseEntities())
                {
                    List<tblProduct> list = new List<tblProduct>();
                    list = (from x in context.tblProducts select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        //return only not stored products
        public static List<tblProduct> GetOnlyNotStored()
        {
            List<tblProduct> list = GetAllProducts();
            return list.Where(s => s.stored == false).ToList();
        }


        public static List<vwStoredProduct> GetViewOfAllStoredProducts()
        {
            try
            {
                using (dbWarehouseEntities context = new dbWarehouseEntities())
                {
                    List<vwStoredProduct> list = new List<vwStoredProduct>();
                    list = (from x in context.vwStoredProducts select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }

        }
        #endregion

        #region DELETE PRODUCT

        public static void DeleteProduct(tblProduct product)
        {
            try
            {
                using (dbWarehouseEntities context = new dbWarehouseEntities())
                {
                    tblProduct productToDelete = (from u in context.tblProducts where u.productId == product.productId select u).First();
                    context.tblProducts.Remove(productToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
        #endregion

        #region STORE PRODUCT
        public static string StoreProduct(tblProduct product)
        {
            try
            {
                using (dbWarehouseEntities context = new dbWarehouseEntities())
                {
                    tblProduct productToStore = (from u in context.tblProducts where u.productId == product.productId select u).First();
                    //count all products
                    List<vwStoredProduct> view = GetViewOfAllStoredProducts();
                    int counter = 0;
                    foreach(vwStoredProduct v in view)
                    {
                        counter += v.quantity;
                    }
                    //check quanitity
                    if(productToStore.stored == false)
                    {
                        if(counter + productToStore.quantity <= 100)
                        {
                            //change stored status
                            productToStore.stored = true;
                            context.SaveChanges();

                            //add to stored product table
                            tblStoredProduct sp = new tblStoredProduct();
                            sp.productId = productToStore.productId;
                            context.tblStoredProducts.Add(sp);
                            context.SaveChanges();
                            return null;
                        }
                        else
                        {
                            return "There is not enough space for that product";
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD or EDIT
        public static tblProduct AddOrEditProduct(tblProduct product)
        {
            try
            {
                using (dbWarehouseEntities context = new dbWarehouseEntities())
                {
                    if ( product.productId == 0)
                    {
                        //add into tblProduct
                        tblProduct newProduct = new tblProduct();
                        newProduct.productName = product.productName;
                        newProduct.price = product.price;
                        newProduct.quantity = product.quantity;
                        newProduct.code = product.code;
                        newProduct.stored = false;
                        context.tblProducts.Add(newProduct);
                        context.SaveChanges();
                        product.productId = newProduct.productId;
                        return product;
                    }
                    else
                    {
                        tblProduct productToEdit = (from x in context.tblProducts where x.productId == product.productId select x).FirstOrDefault();
                        productToEdit.productName = product.productName;
                        productToEdit.price = product.price;
                        productToEdit.quantity = product.quantity;
                        productToEdit.code = product.code;
                        context.SaveChanges();
                        return product;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion


    }
}
