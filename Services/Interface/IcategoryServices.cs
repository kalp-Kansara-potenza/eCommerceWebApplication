using eCommerceWebApplication.AppData;
using eCommerceWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Services.Interface
{
    public interface IcategoryServices
    {
        public Task<List<Category>> Category();
        public Task<List<Category>> getcategoryorderby();
        public Task<List<Category>> getChildCategory(int? parent_category_id);
        public Task<List<Category>> getChildCategoryRecursion(int? parent_category_id);
        public Task<Category> getCategoryById(int category_id);
        //public Task addspecificationsXcategory(int category_id, SpecificationxCategory specificationxCategory);
        public Task addupdateCategory(Category category);
    }
}
