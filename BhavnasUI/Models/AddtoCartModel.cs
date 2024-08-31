using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using BhavnasUI.data;

namespace BhavnasUI.Models
{
    public class AddtoCartModel
    {
        public decimal Total {  get; set; }
        public int Id { get; set; }
        public string CustomerIP { get; set; }
        public Nullable<long> ProductID { get; set; }
        public Nullable<long> Quantity { get; set; }
        public string Size { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Shipping { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> UpdationDate { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public Nullable<decimal> GrandTotal { get; set; }

        public string Save(AddtoCartModel model)
        {
            string Msg = "";
            BhavanasERPEntities db = new BhavanasERPEntities();
            if (model.Id == 0)
            {
                var Data = new tblAddtocart()
                {
                    Id = model.Id,
                    CustomerIP = model.CustomerIP,
                    ProductID = model.ProductID,
                    Quantity = model.Quantity,
                    Amount = model.Amount,
                    Shipping = model.Shipping,
                    GrandTotal = model.GrandTotal,
                    Size = model.Size
                    
                   
                };
                db.tblAddtocarts.Add(Data);
                db.SaveChanges();
                Msg = "Added Successfully";

                
            }
            else
            {
                //var Data = db.tblregistrations.Where(p => p.Id == model.Id).FirstOrDefault();
                //if (Data != null)
                //{
                //    Data.Id = model.Id;
                //    Data.Name = model.Name;
                //    Data.Address = model.Address;
                //    Data.Mobile = model.Mobile;
                //    db.SaveChanges();
                //    Msg = "Updated Successfully";
                //}


            }
            return Msg;


        }
       

        public List<AddtoCartModel> CartList()
        {
            List<AddtoCartModel> lst = new List<AddtoCartModel>();
            BhavanasERPEntities db = new BhavanasERPEntities();
            var sum = db.tblAddtocarts.Select(a => a.Amount).Sum();
            var data = (from p in db.tblProducts
                                   join a in db.tblAddtocarts on p.Id equals a.ProductID
                                   select new
                                   {
                                       a.Size,
                                       a.Shipping,
                                       p.Id,
                                       p.ProductName,
                                       p.ProductImage,
                                       a.Amount,
                                       a.Quantity,
                                       a.CustomerIP, a.ProductID
                                   });
            if (data != null)
            {
                foreach (var item in data)
                {
                    lst.Add(new AddtoCartModel()
                    {
                        Id = item.Id,
                        Amount = item.Amount,
                        Shipping=item.Shipping,
                        ProductID = item.ProductID,
                        Quantity = item.Quantity,
                        CustomerIP=item.CustomerIP,
                        ProductImage=item.ProductImage,
                        ProductName = item.ProductName,
                        Size = item.Size
                       
                    });
               
                }


            }
            return lst;
        }

    }
}