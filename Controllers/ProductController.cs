using Ecommerce.AppData;
using Ecommerce.AppData.Context;
using Ecommerce.Models;
using Ecommerce.Models.Global;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private ecommerceContext ecomContext;
        public ProductController(ecommerceContext ecomContext)
        {
            this.ecomContext = ecomContext;
        }

        
        public IActionResult Product()
        {
            if (User.FindFirst("rolename") == null)
            {
                return RedirectToAction("unauthorized", "account");
            }
            else
            {
               
                var category = ecomContext.Set<DBcategory>().ToList();
                category.Insert(0, new DBcategory { category_id = 0, category_name = "Select Category" });
                ViewBag.categoryname = category;
                var productmodel = ecomContext.Set<DBproduct>().ToList().Select(p => new Product
                {
                    product_id = p.product_id,
                    prodcut_name = p.prodcut_name,
                    thumnail_image = p.thumnail_image,
                    category_name = p.DBcategory.category_name,
                    price = p.price,
                    total_quantity = p.total_quantity
                }).ToList();
                return View(productmodel);
            }
        }

        public IActionResult MyProduct()
        {
            if (User.FindFirst("rolename") == null)
            {
                return RedirectToAction("unauthorized", "account");
            }
            else
            {
                var claimsidentity = this.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = claimsidentity.Claims;
                int user_id = int.Parse(claimsidentity.FindFirst(ClaimTypes.Sid).Value);
                var category = ecomContext.Set<DBcategory>().ToList();
                category.Insert(0, new DBcategory { category_id = 0, category_name = "Select Category" });
                ViewBag.categoryname = category;
                var productmodel = ecomContext.Set<DBproduct>().ToList().Where(p => p.user_id == user_id).Select(p => new Product
                {
                    product_id = p.product_id,
                    prodcut_name = p.prodcut_name,
                    thumnail_image = p.thumnail_image,
                    category_name = p.DBcategory.category_name,
                    price = p.price,
                    total_quantity = p.total_quantity
                }).ToList();
                return View(productmodel);
            }
        }

        [HttpGet]
        public IActionResult getspecificationsoncategoryid(int category_id)
        {
            var joinquery = ecomContext.DBCategory.Where(c => c.category_id == category_id).Select(c => new Category
            {
                category_id = c.category_id,
                category_name = c.category_name,
                thumbnail_image = c.thumbnail_image,
                parent_category_id = c.parent_category_id
            }).FirstOrDefault();
            if (joinquery.parent_category_id > 0)
            {
                joinquery.featuretypelist = ecomContext.DBSpecificationsXCategories.Include(sc => sc.DBfeaturetype).Where(c => c.category_id == joinquery.parent_category_id).ToList();
                ViewBag.featurelist = joinquery.featuretypelist;
                joinquery.specificationtypelist = ecomContext.DBSpecificationsXCategories.Include(sc => sc.DBSpecificationtype).Where(c => c.category_id == joinquery.parent_category_id).ToList();
            }
            else
            {
                joinquery.featuretypelist = ecomContext.DBSpecificationsXCategories.Include(sc => sc.DBfeaturetype).Where(c => c.category_id == category_id).ToList();
                ViewBag.featurelist = joinquery.featuretypelist;
                joinquery.specificationtypelist = ecomContext.DBSpecificationsXCategories.Include(sc => sc.DBSpecificationtype).Where(c => c.category_id == category_id).ToList();
                //ViewBag.specificationtypelist = joinquery.specificationtypelist;
            }
            return Json(joinquery);
        }

        [Authorize(Roles = "Admin, Vendor")]
        [HttpGet]
        public IActionResult addupdateproduct(int id)
        {
            var category = ecomContext.Set<DBcategory>().ToList();
            category.Insert(0, new DBcategory { category_id = 0, category_name = "Select Category" });
            ViewBag.categoryname = category;

            //ecomContext.DBSpecificationsXCategories.Include(sc => sc.DBfeaturetype).Where(c => c.category_id == joinquery.parent_category_id).ToList();

            //List<DBfeaturetype> featurelist = ecomContext.Set<DBfeaturetype>().OrderBy(ft => ft.featuretype_name).ToList();
            //List<DBfeaturetype> featurelist = new List<DBfeaturetype>();
            //featurelist.Insert(0, new DBfeaturetype { featuretype_id = 0, featuretype_name = "Select Feature Type" });
            //ViewBag.featurelist = featurelist;
            ViewBag.product_id = id;

            if (id == 0)
            {
                return View("addupdateproduct");
            }
            else
            {
                var claimsidentity = this.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = claimsidentity.Claims;
                int user_id = int.Parse(claimsidentity.FindFirst(ClaimTypes.Sid).Value);

                
                var prod = ecomContext.DBProductxImages.Include(p => p.DBproduct).Where(p => p.product_id == id && p.DBproduct.user_id == user_id).Select(p => new Product
                {
                    product_id = p.product_id,
                    prodcut_name = p.DBproduct.prodcut_name,
                    thumnail_image = p.DBproduct.thumnail_image,
                    category_id = p.DBproduct.DBcategory.category_id,
                    price = p.DBproduct.price,
                    total_quantity = p.DBproduct.total_quantity,
                    user_id = p.DBproduct.user_id,
                    productximage_id = p.productximage_id,
                    multiplefiles = ecomContext.DBProductxImages.Where(pxi => pxi.product_id == id).ToList(),
                    specifications = ecomContext.DBSpecifications.Include(st => st.DBspecificationtype).Where(p=>p.product_id == id ).ToList()
            }).FirstOrDefault();

                ViewBag.specifications = prod.specifications;
                return View("addupdateproduct",prod);
            }
        }

        [Authorize(Roles = "Admin, Vendor")]
        [HttpPost]
        public IActionResult addupdateproduct(Product product)
        {
            if(product.specificationslist == null)
            {
                product.specificationslist = JsonConvert.DeserializeObject<List<Specification>>(product.stringdata);
            }
            
            
            var claimsidentity = this.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = claimsidentity.Claims;
            product.user_id = int.Parse(claimsidentity.FindFirst(ClaimTypes.Sid).Value);
            if (ModelState.IsValid)
            {
                if(product.product_id != 0)
                {
                    Guid g = Guid.NewGuid();
                    var prod = ecomContext.DBProduct.Where(p => p.product_id == product.product_id).FirstOrDefault();
                    if(prod.prodcut_name != product.prodcut_name)
                    {
                        prod.prodcut_name = product.prodcut_name;
                    }
                    if(product.file != null)
                    {
                        
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\image\\product", g + product.file.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            product.thumnail_image = g + product.file.FileName;
                            product.file.CopyTo(stream);
                        }
                    }
                    prod.thumnail_image = product.thumnail_image;
                    prod.category_id = product.category_id;
                    prod.price = product.price;
                    prod.total_quantity = product.total_quantity;
                    prod.user_id = product.user_id;
                    if (product.multiplefile != null)
                    {
                        foreach (var item in product.multiplefile)
                        {
                            if (item.Length > 0)
                            {
                                //Guid g = Guid.NewGuid();
                                var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\image\\productximages", g + item.FileName);
                                string filename = Path.Combine(item.FileName);
                                using (var stream = new FileStream(path1, FileMode.Create))
                                {
                                    product.product_images = g + item.FileName;
                                    item.CopyTo(stream);
                                }
                                DBproductximage dbprodximg = new DBproductximage();
                                dbprodximg.product_id = product.product_id;
                                dbprodximg.product_images = product.product_images;
                                ecomContext.Add(dbprodximg);
                                ecomContext.SaveChanges();
                            }
                        }
                    }
                    ecomContext.SaveChanges();
                }
                else
                {
                    Guid g = Guid.NewGuid();
                    
                    var prod = ecomContext.DBProduct.Where(p => p.prodcut_name == product.prodcut_name).FirstOrDefault();
                    if (prod == null)
                    {
                        //Guid g = Guid.NewGuid();
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\image\\product", g + product.file.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            product.thumnail_image = g + product.file.FileName;
                            product.file.CopyTo(stream);
                        }
                        DBproduct dbprod = new DBproduct();
                        dbprod.prodcut_name = product.prodcut_name;
                        dbprod.thumnail_image = product.thumnail_image;
                        dbprod.category_id = product.category_id;
                        dbprod.price = product.price;
                        dbprod.total_quantity = product.total_quantity;
                        dbprod.user_id = product.user_id;
                        ecomContext.Add(dbprod);
                        ecomContext.SaveChanges();
                        if (product.multiplefile != null)
                        {
                            foreach (var item in product.multiplefile)
                            {
                                if (item.Length > 0)
                                {
                                    //Guid g = Guid.NewGuid();
                                    var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\image\\productximages", g + item.FileName);
                                    string filename = Path.Combine(item.FileName);
                                    using (var stream = new FileStream(path1, FileMode.Create))
                                    {
                                        product.product_images = g + item.FileName;
                                        item.CopyTo(stream);
                                    }
                                    DBproductximage dbprodximg = new DBproductximage();
                                    dbprodximg.product_id = dbprod.product_id;
                                    dbprodximg.product_images = product.product_images;
                                    ecomContext.Add(dbprodximg);
                                    ecomContext.SaveChanges();
                                }
                            }
                        }
                        if(product.specificationslist != null)
                        {
                            foreach (var item in product.specificationslist)
                            {
                                DBspecification dbspecification = new DBspecification();
                                dbspecification.featuretype_id = item.featuretype_id;
                                dbspecification.specificationtype_id = item.specificationtype_id;
                                dbspecification.product_id = dbprod.product_id;
                                dbspecification.specification_description = item.specification_description;
                                ecomContext.Add(dbspecification);
                                ecomContext.SaveChanges();
                            }
                        }

                    }
                    else
                    {
                        List<string> err = new List<string>();
                        err.Add("Product name is already existed");
                        return Json(new { success = false, errors = err });
                    }
                }
                
            }
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(ce => ce.Errors).Select(ce => ce.ErrorMessage).ToList() });
            return RedirectToAction("MyProduct","Product");
        }

        [Authorize(Roles = "Admin,Vendor")]
        [HttpGet]
        public IActionResult editproduct(int product_id)
        {
            var product = ecomContext.DBProduct.Where(p => p.product_id == product_id).FirstOrDefault();
            //var product = ecomContext.DBProductxImages.Include(p => p.DBproduct).Where(p => p.product_id == id).ToList();
            return new JsonResult(product);
        }

        [Authorize(Roles = "Admin, Vendor")]
        [HttpGet]
        public IActionResult deleteproduct(int product_id)
        {
            var product = ecomContext.DBProduct.Where(p => p.product_id == product_id).First();
            ecomContext.DBProduct.Remove(product);
            ecomContext.SaveChanges();
            return new JsonResult(product);
        }

        [Authorize(Roles = "Admin,Vendor")]
        [HttpPost]
        
        public IActionResult multiplefileupload(productximage productximage)
        {
            if (productximage.multiplefile != null)
            {
                foreach (var item in productximage.multiplefile)
                {
                    if(item.Length > 0)
                    {
                        Guid g = Guid.NewGuid();
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\image\\productximages", g + item.FileName);
                        string filename = Path.Combine(item.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            productximage.product_images = g + item.FileName;
                            item.CopyTo(stream);
                        }
                        DBproductximage dbprodximg = new DBproductximage();
                        dbprodximg.product_id = productximage.product_id;
                        dbprodximg.product_images = productximage.product_images;
                        ecomContext.Add(dbprodximg);
                        ecomContext.SaveChanges();
                    }
                }
                
                
            }
            return View("Product");
        }

        [HttpGet]
        public IActionResult multiplefiledisplay(int product_id)
        {
            var prodximg = ecomContext.DBProductxImages.Where(pxi=>pxi.product_id == product_id).ToList();
            return Json(prodximg);
        }
    
        [HttpGet]
        public IActionResult editproductximage(int productximage_id)
        {
            var prodximg = ecomContext.DBProductxImages.Where(pxi => pxi.productximage_id == productximage_id).FirstOrDefault();
            return new JsonResult(prodximg);
        }

        [HttpGet]
        public IActionResult deleteproductximage(int productximage_id)
        {
            var prodximg = ecomContext.DBProductxImages.Where(pxi => pxi.productximage_id == productximage_id).FirstOrDefault();
            ecomContext.DBProductxImages.Remove(prodximg);
            ecomContext.SaveChanges();
            return new JsonResult(prodximg);
        }

        [HttpPost]
        public IActionResult updateproductximage(productximage productximage)
        {
            var prodximg = ecomContext.DBProductxImages.Where(p => p.productximage_id == productximage.productximage_id).FirstOrDefault();
            if (productximage.file != null)
            {
                Guid g = Guid.NewGuid();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\image\\productximages", g + productximage.file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    prodximg.product_images = g + productximage.file.FileName;
                    productximage.file.CopyTo(stream);
                }
            }
            prodximg.productximage_id = productximage.productximage_id;
            
            ecomContext.SaveChanges();
            return new JsonResult(prodximg);
        }

        [HttpGet]
        public IActionResult getfeaturetype()
        {
            List<FeatureType> feturetypelist = ecomContext.Set<DBfeaturetype>().OrderBy(ft=>ft.featuretype_name).Select(ft=> new FeatureType { 
                featuretype_id = ft.featuretype_id,
                featuretype_name = ft.featuretype_name
            }).ToList();
            return Json(feturetypelist);
        }

        [HttpGet]
        public IActionResult getspecificationtypeonfeatureid(int featuretype_id)
        {
            List<DBspecificationtype> specificationtypelist = ecomContext.Set<DBspecificationtype>().Where(st => st.featuretype_id == featuretype_id).OrderBy(st => st.specificationtype_name).ToList();
            ViewBag.specificationtypelist = specificationtypelist;
            return Json(specificationtypelist);
        }

        [HttpPost]
        public IActionResult addupdatespecifications(Specification specification)
        {
            if(ModelState.IsValid)
            {
                if (specification.specification_id != 0)
                {
                    var specifications = ecomContext.DBSpecifications.FirstOrDefault(s => s.specification_id == specification.specification_id);
                    if(specifications.specificationtype_id != specification.specificationtype_id && specification.featuretype_id != specification.featuretype_id)
                    {
                        specifications.featuretype_id = specification.featuretype_id;
                        specifications.specificationtype_id = specification.specificationtype_id;
                    }
                    specifications.product_id = specification.product_id;
                    specifications.specification_description = specification.specification_description;
                    ecomContext.SaveChanges();
                }
                else
                {
                    var specifications= ecomContext.DBSpecifications.FirstOrDefault(s=>s.featuretype_id == specification.featuretype_id && s.specificationtype_id == specification.specificationtype_id);
                    if(specifications == null)
                    {
                        DBspecification dBspecification = new DBspecification();
                        
                        dBspecification.featuretype_id = specification.featuretype_id;
                        dBspecification.specificationtype_id = specification.specificationtype_id;
                        dBspecification.product_id = specification.product_id;
                        dBspecification.specification_description = specification.specification_description;
                        ecomContext.Add(dBspecification);
                        ecomContext.SaveChanges();
                    }
                    else
                    {
                        List<string> err = new List<string>();
                        err.Add("Specification is already existed");
                        return Json(new { success = false, errors = err });
                    }
                }
            }
            return Json(new { success = false, errors = ModelState.Values.SelectMany(ce => ce.Errors).Select(ce => ce.ErrorMessage).ToList() });
        }

        [HttpGet]
        public IActionResult editspecification(int specification_id)
        {
            var specification = ecomContext.DBSpecifications.Where(s=>s.specification_id == specification_id).FirstOrDefault();
            return new JsonResult(specification);
        }

        [HttpGet]
        public IActionResult deletespecification(int specification_id)
        {
            var specifications = ecomContext.DBSpecifications.Where(s => s.specification_id == specification_id).FirstOrDefault();
            ecomContext.Remove(specifications);
            ecomContext.SaveChanges();
            return new JsonResult(specifications);
        }

        [HttpPost]
        public IActionResult addspecificationsinlist(Specification specification)
        {
            Product p = new Product();
            List<Specification> specificationlist = new List<Specification>();
            specificationlist.Add(new Specification { 
                featuretype_id = specification.featuretype_id ,
                featuretype_name = specification.featuretype_name,
                specificationtype_id = specification.specificationtype_id ,
                specificationtype_name = specification.specificationtype_name,
                specification_description = specification.specification_description 
            });
            //TempData["datalist"] = specification;
            //TempData.Keep();
            //specificationlist = TempData["datalist"] as List<Specification>;
            
            //p.specificationslist.Add(specification);
            return Json(specificationlist);
        }
    }

}
