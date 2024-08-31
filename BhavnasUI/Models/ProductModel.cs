using BhavnasUI.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BhavnasUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> MFGDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Size { get; set; }
        public string Unit { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<decimal> Shipping { get; set; }


        public List<ProductModel> ProductLST()
        {
            List<ProductModel> lst = new List<ProductModel>();
            BhavanasERPEntities db = new BhavanasERPEntities();
            var data = db.tblProducts.ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    lst.Add(new ProductModel()
                    {
                        Id = item.Id,
                        ProductName = item.ProductName,
                        ProductImage = item.ProductImage,
                        Amount = item.Amount,
                        CategoryId = item.CategoryId,
                        CreatedBy = item.CreatedBy,
                        CreatedDate = item.CreatedDate,
                        Description = item.Description,
                        ExpiryDate = item.ExpiryDate,
                        IsActive = item.IsActive,
                        MFGDate = item.MFGDate,
                        Size = item.Size,
                        Unit = item.Unit,
                        UpdatedBy = item.UpdatedBy,
                        UpdatedDate = item.UpdatedDate,
                        Shipping= item.Shipping
                    });
                }


            }
            return lst;
        }

        public List<ProductModel> SearchEmpList(int Id)
        {
            List<ProductModel> lst = new List<ProductModel>();
            BhavanasERPEntities db = new BhavanasERPEntities();
            var data = db.tblProducts.Where(p => p.CategoryId == Id).ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    lst.Add(new ProductModel()
                    {
                        Id = item.Id,
                        ProductName = item.ProductName,
                        ProductImage = item.ProductImage,
                        Amount = item.Amount,
                        CategoryId = item.CategoryId,
                        CreatedBy = item.CreatedBy,
                        CreatedDate = item.CreatedDate,
                        Description = item.Description,
                        ExpiryDate = item.ExpiryDate,
                        IsActive = item.IsActive,
                        MFGDate = item.MFGDate,
                        Size = item.Size,
                        Unit = item.Unit,
                        UpdatedBy = item.UpdatedBy,
                        UpdatedDate = item.UpdatedDate
                    });
                }


            }
            return lst;
        }

        public ProductModel ProductDetailsList(int Id)
        {
            ProductModel model = new ProductModel();
            BhavanasERPEntities db = new BhavanasERPEntities();
            var data = db.tblProducts.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {

                model.Id = data.Id;
                model.ProductName = data.ProductName;
                model.ProductImage = data.ProductImage;
                model.Amount = data.Amount;
                model.CategoryId = data.CategoryId;
                model.CreatedBy = data.CreatedBy;
                model.CreatedDate = data.CreatedDate;
                model.Description = data.Description;
                model.ExpiryDate = data.ExpiryDate;
                model.IsActive = data.IsActive;
                model.MFGDate = data.MFGDate;
                model.Size = data.Size;
                model.Unit = data.Unit;
                model.UpdatedBy = data.UpdatedBy;
                model.UpdatedDate = data.UpdatedDate;
                model.Shipping=data.Shipping; 
            }
            return model;
        }
    }
}