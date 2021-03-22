
using Ecommerce.API.DataManager;
using Ecommerce.API.Repository;
using Ecommerce.AppData;
using Ecommerce.AppData.Context;
using Ecommerce.Models;
using Ecommerce.Services;
using Ecommerce.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class categoryController : Controller
    {
        //public ViewResult category() => View(User.Claims);
        private ecommerceContext ecomContext;
        //private IConfiguration configuration;
        public List<Category> catmodel;
        public IcategoryServices icategoryServices;
        private IConfiguration configuration { get; }

        public categoryController(ecommerceContext ecomContext, IConfiguration _configuration, IcategoryServices _icategoryServices)
        {
            this.ecomContext = ecomContext;
            configuration = _configuration;
            icategoryServices = _icategoryServices;
        }
        [HttpGet]
        public async Task<IActionResult> category()
        {
            var catmodel = await icategoryServices.Category();

            List<Category> lists = await icategoryServices.getcategoryorderby();
            lists.Insert(0, new Category { category_id = 0, category_name = "Select Category" });
            ViewBag.categoryname = lists;
            return View("category", catmodel);
        }

        [HttpGet]
        public async Task<IActionResult> getchildCategory(int? parent_category_id)
        {
            
            var catdata = await icategoryServices.getChildCategory(parent_category_id);
            Category category = new Category();
            category.categories = await icategoryServices.getChildCategoryRecursion(parent_category_id);
            return PartialView(catdata);
        }

        [HttpGet]
        public async Task<List<Category>> getchildrecursive(int? parent_category_id)
        {
            var catdata = await icategoryServices.getChildCategoryRecursion(parent_category_id);
            return catdata;
        }

        [HttpGet]
        public async Task<IActionResult> addupdatecategory(int id)
        {
            List<Category> lists = await icategoryServices.getcategoryorderby();
            lists.Insert(0, new Category { category_id = 0, category_name = "Select Category" });
            ViewBag.categoryname = lists;

            List<DBfeaturetype> featurelist = ecomContext.Set<DBfeaturetype>().OrderBy(ft => ft.featuretype_name).ToList();
            featurelist.Insert(0, new DBfeaturetype { featuretype_id = 0, featuretype_name = "Select Feature Type" });
            ViewBag.featurelist = featurelist;
            ViewBag.category_id = id;

            if (id == 0)
            {
                return View("addupdatecategory");
            }
            else
            {
                var joinquery = ecomContext.DBCategory.Where(c => c.category_id == id).Select(c=>new Category{
                    category_id = c.category_id,
                    category_name = c.category_name,
                    thumbnail_image = c.thumbnail_image,
                    parent_category_id = c.parent_category_id
                }).FirstOrDefault();
                if(joinquery.parent_category_id > 0)
                {
                    joinquery.featuretypelist = ecomContext.DBSpecificationsXCategories.Include(sc => sc.DBfeaturetype).Where(c => c.category_id == joinquery.parent_category_id).ToList();
                    joinquery.specificationtypelist = ecomContext.DBSpecificationsXCategories.Include(sc => sc.DBSpecificationtype).Where(c => c.category_id == joinquery.parent_category_id).ToList();
                }
                else
                {
                    joinquery.featuretypelist = ecomContext.DBSpecificationsXCategories.Include(sc => sc.DBfeaturetype).Where(c => c.category_id == id).ToList();
                    joinquery.specificationtypelist = ecomContext.DBSpecificationsXCategories.Include(sc => sc.DBSpecificationtype).Where(c => c.category_id == id).ToList();
                }
                

                return View("addupdatecategory", joinquery);
            }
            
        }

        [HttpGet]
        public IActionResult getspecificationsxcategorydata(int specificationsXcategory_id)
        {
            var specificationxcategory = ecomContext.DBSpecificationsXCategories.FirstOrDefault(sc=>sc.specificationsXcategory_id == specificationsXcategory_id);
            return new JsonResult(specificationxcategory);
        }

        [HttpGet]
        public IActionResult getspecificationtypeonfeatureid(int featuretype_id)
        {
            List<DBspecificationtype> specificationtypelist = ecomContext.Set<DBspecificationtype>().Where(st => st.featuretype_id == featuretype_id).OrderBy(st => st.specificationtype_name).ToList();
            ViewBag.specificationtypelist = specificationtypelist;
            return Json(specificationtypelist);
        }

        
        [HttpPost]
        public async Task<IActionResult> addupdatecategory(Category category)
        {
            
            if (ModelState.IsValid)
            {
                if (category.category_id != 0)
                {
                    if(category.parent_category_id == 0)
                    {
                        if (category.file != null)
                        {
                            Guid g = Guid.NewGuid();
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\image\\category", g + category.file.FileName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                category.thumbnail_image = g + category.file.FileName;
                                category.file.CopyTo(stream);
                            }
                        }
                        await icategoryServices.addupdateCategory(category);
                    }   
                }
                else
                {
                    //var catname = ecomContext.DBCategory.Where(c => c.category_name == category.category_name).FirstOrDefault();
                    //if (catname == null)
                    //{
                    //    Guid g = Guid.NewGuid();
                    //    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\image\\category", g + category.file.FileName);
                    //    using (var stream = new FileStream(path, FileMode.Create))
                    //    {
                    //        category.thumbnail_image = g + category.file.FileName;
                    //        category.file.CopyTo(stream);
                    //    }
                        await icategoryServices.addupdateCategory(category);
                    //}
                    //else
                    //{
                    //    List<string> err = new List<string>();
                    //    err.Add("Category name is already existed");
                    //    return Json(new { success = false, errors = err });
                    //}


                }
            }
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(ce => ce.Errors).Select(ce => ce.ErrorMessage).ToList() });
            return RedirectToAction("Category","category");
        }

            
        [HttpGet]
        public IActionResult editCategory(long category_id)
        {
            var category = ecomContext.DBCategory.Where(c => c.category_id == category_id).First();
            return new JsonResult(category);
        }

           
        [HttpGet]
        public IActionResult deleteCategory(long category_id)
        {
            var category = ecomContext.DBCategory.Where(c => c.category_id == category_id).First();
            ecomContext.DBCategory.Remove(category);
            ecomContext.SaveChanges();
            return new JsonResult(category);
        }

        [HttpPost]
        public IActionResult addupdatespecificationsxcategory(SpecificationxCategory specificationxcategory)
        {
            if(ModelState.IsValid)
            {
                if(specificationxcategory.specificationsXcategory_id != 0)
                {
                    var specificationxcategories = ecomContext.DBSpecificationsXCategories.FirstOrDefault(sc=>sc.specificationsXcategory_id == specificationxcategory.specificationsXcategory_id);
                    if (specificationxcategories.specificationtype_id != specificationxcategory.specificationtype_id && specificationxcategories.featuretype_id != specificationxcategory.featuretype_id)
                    {
                        specificationxcategories.featuretype_id = specificationxcategory.featuretype_id;
                        specificationxcategories.specificationtype_id = specificationxcategory.specificationtype_id;
                    }
                    ecomContext.SaveChanges();
                }
                else
                {
                    var specificationxcategories = ecomContext.DBSpecificationsXCategories.FirstOrDefault(sc => sc.specificationsXcategory_id == specificationxcategory.specificationsXcategory_id);
                    if(specificationxcategories == null)
                    {
                        DBspecificationsXcategory dBspecificationsXcategory = new DBspecificationsXcategory();
                        
                        dBspecificationsXcategory.featuretype_id = specificationxcategory.featuretype_id;
                        dBspecificationsXcategory.specificationtype_id = specificationxcategory.specificationtype_id;
                        dBspecificationsXcategory.category_id = specificationxcategory.category_id;
                        ecomContext.Add(dBspecificationsXcategory);
                        ecomContext.SaveChanges();
                    }
                    else
                    {
                        List<string> err = new List<string>();
                        err.Add("Specification of category is already existed");
                        return Json(new { success = false, errors = err });
                    }
                }

            }
            return Json(new { success = false, errors = ModelState.Values.SelectMany(ce => ce.Errors).Select(ce => ce.ErrorMessage).ToList() });
        }

        [HttpGet]
        public IActionResult removespecificationsxcategory(int specificationsXcategory_id)
        {
            var specificationxcategory = ecomContext.DBSpecificationsXCategories.FirstOrDefault(sc => sc.specificationsXcategory_id == specificationsXcategory_id); ;
            ecomContext.Remove(specificationxcategory);
            ecomContext.SaveChanges();
            return Json(specificationxcategory);
        }
    }
}
