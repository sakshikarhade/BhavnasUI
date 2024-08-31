using BhavnasUI.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BhavnasUI.Models
{
    public class CheckoutModel 
    {
        public int Id { get; set; }
        public int CustomerOrderId { get; set; }
        public int ProductId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string TransactionMode { get; set; }
        public string Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        


        string session= "192.168.29.149";

        public string Save(CheckoutModel model)
        {
            string Msg = "";
            BhavanasERPEntities db = new BhavanasERPEntities();
            if (model.Id == 0)
            {


                var data = db.tblAddtocarts.Where(temp => temp.CustomerIP ==session).ToList();

                if (data != null)
                {
                    foreach (var item in data)
                    {

                        var Data = new tblCustomerOrderDetail()
                        {

                          
                            CustomerOrderId=1,
                            ProductId = Convert.ToInt32(item.ProductID),
                            OrderDate=global::System.DateTime.Now,
                            DeliveryDate =model.DeliveryDate,
                            TransactionMode = "test",
                            Quantity =Convert.ToString(item.Quantity),
                            Amount = item.Amount,
                            Discount=10,
                            TotalAmount = item.GrandTotal,
                            IsActive=true,
                            CreatedBy = 1,
                            CreatedDate = global::System.DateTime.Now,
                            UpdatedBy=1,
                            UpdatedDate=global::System.DateTime.Now


                        };
                        db.tblCustomerOrderDetails.Add(Data);
                        db.SaveChanges();
                      
                    }
                    var OrderData = new tblCustomerOrder()
                    {
                        OrderDate=DateTime.Now,
                        DeliveryDate=model.DeliveryDate,
                        TransactionMode = "test",
                        Amount= model.Amount,
                        Discount = 10,
                        TotalAmount = model.Amount,
                        IsActive = true,
                        CreatedBy = 1,
                        CreatedDate = global::System.DateTime.Now,
                        UpdatedBy = 1,
                        UpdatedDate = global::System.DateTime.Now


                    };
                    db.tblCustomerOrders.Add(OrderData);
                    db.SaveChanges();
                    Msg = "Saved Successfully";
                    DeleteCart();
                }
            
            }
            else
            {

            }
         
            return Msg;

        }
        public string DeleteCart()
        {
            string msg = "Deleted Successfully";
            BhavanasERPEntities db = new BhavanasERPEntities();
            var Record = db.tblAddtocarts.Where(p => p.CustomerIP == session).FirstOrDefault();
            if (Record != null)
            {
                db.tblAddtocarts.Remove(Record);
            }
            db.SaveChanges();
            return msg;
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
                            a.CustomerIP,
                            a.ProductID
                        });
            if (data != null)
            {
                foreach (var item in data)
                {
                    lst.Add(new AddtoCartModel()
                    {
                        Id = item.Id,
                        Amount = item.Amount,
                        Shipping = item.Shipping,
                        ProductID = item.ProductID,
                        Quantity = item.Quantity,
                        CustomerIP = item.CustomerIP,
                        ProductImage = item.ProductImage,
                        ProductName = item.ProductName,
                        Size = item.Size

                    });

                }



            }
            return lst;
        }
    }
  


}