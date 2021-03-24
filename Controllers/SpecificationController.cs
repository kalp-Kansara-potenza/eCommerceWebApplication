using eCommerceWebApplication.AppData;
using eCommerceWebApplication.AppData.Context;
using eCommerceWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebApplication.Controllers
{
    public class SpecificationController : Controller
    {
        private ecommerceContext ecomContext;
        
        public SpecificationController(ecommerceContext ecomContext)
        {
            this.ecomContext = ecomContext;
        }
        public IActionResult Specification()
        {
            List<Specification> specification;
            if (User.FindFirst("rolename") == null)
            {
                return RedirectToAction("unauthorized", "account");
            }
            else
            {
                List<DBfeaturetype> featurelist = ecomContext.Set<DBfeaturetype>().OrderBy(ft => ft.featuretype_name).ToList();
                featurelist.Insert(0,new DBfeaturetype { featuretype_id=0,featuretype_name="Select Feature Type"});
                ViewBag.featurelist = featurelist;
                specification = ecomContext.Set<DBspecification>().ToList().Select(s => new Specification
                {
                    featuretype_name = s.DBfeaturetype.featuretype_name,
                    specificationtype_name = s.DBspecificationtype.specificationtype_name,
                    specification_description = s.specification_description
                }).ToList();
            }
            return View("Specification",specification);
        }

        [HttpGet]
        public IActionResult getspecificationtypeonfeatureid(int featuretype_id)
        {
            List<DBspecificationtype> specificationtypelist = ecomContext.Set<DBspecificationtype>().Where(st=>st.featuretype_id == featuretype_id).OrderBy(st => st.specificationtype_name).ToList();
            
            return Json(specificationtypelist);
        }
    }
}
