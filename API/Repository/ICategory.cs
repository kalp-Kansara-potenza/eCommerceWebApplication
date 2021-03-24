using eCommerceWebApplication.AppData;
using eCommerceWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.API.Repository
{
    public interface ICategory
    {
        #region Category

        Task<List<DBcategory>> Category();
        Task<List<DBcategory>> getcategoryorderby();
        Task<List<DBcategory>> getchildCategory(int? parent_category_id);
        Task<List<DBcategory>> getchildCategoryRecursion(int? parent_category_id);
        Task<DBcategory> findCategory(int category_id);
        Task addupdatecategory(DBcategory dbcategory);
        Task DeleteCategory(int category_id);

        #endregion

        #region SpecificationXcategory
        Task addupdatespecificationsXcategory(DBspecificationsXcategory dBspecificationsXcategory);
        Task<DBspecificationsXcategory> getspecificationsxcategorydata(int specificationsXcategory_id); 
        #endregion

        Task<List<DBspecificationtype>> getspecificationtypeonfeatureid(int featuretype_id);

    }
}
