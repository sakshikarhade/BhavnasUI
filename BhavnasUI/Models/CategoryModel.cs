using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BhavnasUI.data;


namespace BhavnasUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDetails { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public List<CategoryModel> CategoryLST()
        {
            List<CategoryModel> lst = new List<CategoryModel>();
            BhavanasERPEntities db = new BhavanasERPEntities();
            var data = db.tblCategories.ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    lst.Add(new CategoryModel()
                    {
                        Id = item.Id,
                        CategoryName = item.CategoryName,
                        CategoryDetails = item.CategoryDetails,
                        CreatedBy = item.CreatedBy,
                        CreatedDate = item.CreatedDate,
                        IsAvailable = item.IsAvailable,
                        UpdatedBy = item.UpdatedBy,
                        UpdatedDate = item.UpdatedDate
                    });
                }

            }
            return lst;
        }

    }
}