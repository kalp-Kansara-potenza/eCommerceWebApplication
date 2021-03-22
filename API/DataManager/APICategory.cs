using Ecommerce.API.Repository;
using Ecommerce.AppData;
using Ecommerce.AppData.Context;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.DataManager
{
    public class APICategory : ICategory
    {
        private ecommerceContext ecomContext;

        public APICategory(ecommerceContext ecomContext)
        {
            this.ecomContext = ecomContext;
        }

        public async Task<List<DBcategory>> Category()
        {
            var cat = await ecomContext.DBCategory.Where(c=>c.parent_category_id == 0).ToListAsync();
            return cat;
        }

        public async Task<List<DBcategory>> getcategoryorderby()
        {
            return await ecomContext.DBCategory.OrderBy(c => c.category_name).ToListAsync();
        }

        public async Task<List<DBcategory>> getchildCategory(int? parent_category_id)
        {
            var catdata = await ecomContext.Set<DBcategory>().Where(pc => pc.parent_category_id == parent_category_id).ToListAsync();
            return catdata;
        }

        public async Task<List<DBcategory>> getchildCategoryRecursion(int? parent_category_id)
        {
            var catdata = await ecomContext.Set<DBcategory>().Where(pc => pc.category_id == parent_category_id).ToListAsync();
            return catdata;
        }

        public async Task<DBcategory> findCategory(int category_id)
        {
            var catdata = await ecomContext.Set<DBcategory>().FirstOrDefaultAsync(pc => pc.category_id == category_id);
            return catdata;
        }

        public async Task addupdatecategory(DBcategory dbcategory)
        {
            var cat = await findCategory(dbcategory.category_id);
            if (cat == null)
            {
                var catname = await ecomContext.DBCategory.Where(c => c.category_name == dbcategory.category_name).FirstOrDefaultAsync();
                if(catname == null)
                {
                    ecomContext.Add(dbcategory);
                    ecomContext.SaveChanges();
                }  
            }
            else
            {
                if(cat.category_name == dbcategory.category_name)
                {
                    cat.category_name = dbcategory.category_name;
                }
                cat.category_id = dbcategory.category_id;
                
                cat.thumbnail_image = dbcategory.thumbnail_image;
                cat.parent_category_id = dbcategory.parent_category_id;
                ecomContext.SaveChanges();
            }
        }

        public async Task DeleteCategory(int category_id)
        {
            var category = await ecomContext.DBCategory.Where(c => c.category_id == category_id).FirstOrDefaultAsync();
            ecomContext.DBCategory.Remove(category);
            ecomContext.SaveChanges();
        }

        public async Task addupdatespecificationsXcategory(DBspecificationsXcategory dBspecificationsXcategory)
        {
            var cat = await findCategory(dBspecificationsXcategory.category_id);
            dBspecificationsXcategory.category_id = cat.category_id;
            ecomContext.Add(dBspecificationsXcategory);
            ecomContext.SaveChanges();
        }

        public async Task<DBspecificationsXcategory> getspecificationsxcategorydata(int specificationsXcategory_id)
        {
            var specificationxcategory = await ecomContext.DBSpecificationsXCategories.FirstOrDefaultAsync(sc => sc.specificationsXcategory_id == specificationsXcategory_id);
            return specificationxcategory;
        }

        public async Task<List<DBspecificationtype>> getspecificationtypeonfeatureid(int featuretype_id)
        {
            List<DBspecificationtype> specificationtypelist = await ecomContext.Set<DBspecificationtype>().Where(st => st.featuretype_id == featuretype_id).OrderBy(st => st.specificationtype_name).ToListAsync();
            return specificationtypelist;
        }
    }
}
