using eCommerceWebApplication.AppData;
using eCommerceWebApplication.Models;
using eCommerceWebApplication.Services.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Services
{
    public class categoryServices : IcategoryServices
    {
        private IConfiguration configuration { get; }
        public categoryServices(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public async Task<List<Category>> Category()
        {
            List<Category> catmodel;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["baseURL:baseAddress"]);
                using (var response = await client.GetAsync("APICategory/Category"))
                {
                    var readTask = await response.Content.ReadAsStringAsync();
                    catmodel = JsonConvert.DeserializeObject<List<Category>>(readTask);
                }
            }
            return catmodel;
        }

        public async Task<List<Category>> getcategoryorderby()
        {
            List<Category> catmodel;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["baseURL:baseAddress"]);
                using (var response = await client.GetAsync("APICategory/getCategoryOrderBy"))
                {
                    var readTask = await response.Content.ReadAsStringAsync();
                    catmodel = JsonConvert.DeserializeObject<List<Category>>(readTask);
                }
            }
            return catmodel;
        }

        
        public async Task<List<Category>> getChildCategory(int? parent_category_id)
        {
            List<Category> catmodel;
            Category cat = new Category(); 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["baseURL:baseAddress"]);
                using (var response = await client.GetAsync("APICategory/getchildCategory?parent_category_id=" + parent_category_id))
                {
                    var readTask = await response.Content.ReadAsStringAsync();
                    catmodel = JsonConvert.DeserializeObject<List<Category>>(readTask);
                    
                }
            }
            return catmodel;
        }

        public async Task<List<Category>> getChildCategoryRecursion(int? parent_category_id)
        {
            List<Category> catmodel;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["baseURL:baseAddress"]);
                using (var response = await client.GetAsync("APICateory/getchildCategoryRecursion?parent_category_id=" + parent_category_id))
                {
                    var readTask = await response.Content.ReadAsStringAsync();
                    catmodel = JsonConvert.DeserializeObject<List<Category>>(readTask);
                }
            }
            return catmodel;
        }

        public async Task<Category> getCategoryById(int category_id)
        {
            Category category = new Category();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["baseURL:baseAddress"]);
                using (var response = await client.GetAsync("APICategory/findCategory?category_id="+category_id))
                {
                    var readTask = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<Category>(readTask);
                }
            }
            return category;
        }

        //public async Task addspecificationsXcategory(int category_id,SpecificationxCategory specificationxCategory)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(configuration["baseURL:baseAddress"]);
        //        using (var response = await client.GetAsync("APICategory/addspecificationsXcategory?category_id="+category_id))
        //        {
        //            var readTask = await response.Content.ReadAsStringAsync();
                    
        //            specificationxCategory = JsonConvert.DeserializeObject<SpecificationxCategory>(readTask);
        //        }
        //    }
        //}

        public async Task addupdateCategory(Category category)
        {
            Category cat = new Category();
            if (category.specificationxCategories == null)
            {
                category.specificationxCategories = JsonConvert.DeserializeObject<List<SpecificationxCategory>>(category.stringdata);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["baseURL:baseAddress"]);
                using (var response = await client.GetAsync("APICategory/addupdateCategory"))
                {
                    var readTask = await response.Content.ReadAsStringAsync();
                    cat = JsonConvert.DeserializeObject<Category>(readTask);
                }

                

                foreach (var item in category.specificationxCategories)
                {
                    
                        using (var response = await client.GetAsync("APICategory/addspecificationsXcategory?category_id=" + cat.category_id))
                        {
                            var readTask = await response.Content.ReadAsStringAsync();
                            SpecificationxCategory specificationxCategory = new SpecificationxCategory(); 
                            specificationxCategory = JsonConvert.DeserializeObject<SpecificationxCategory>(readTask);
                        }
                    
                }
            }
        }
    }
}
