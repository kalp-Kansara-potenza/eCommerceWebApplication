using Ecommerce.AppData;
using Ecommerce.AppData.Context;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class SpecificationtypeController : Controller
    {
        private ecommerceContext ecomContext;

        public SpecificationtypeController(ecommerceContext ecomContext)
        {
            this.ecomContext = ecomContext;
        }

        public IActionResult SpecificationType()
        {
            List<SpecificationType> specifictype;

            if (User.FindFirst("rolename") == null)
            {
                return RedirectToAction("unauthorized", "account");
            }
            else
            {
                List<DBfeaturetype> lists = ecomContext.Set<DBfeaturetype>().OrderBy(ft => ft.featuretype_name).ToList();
                lists.Insert(0, new DBfeaturetype { featuretype_id= 0, featuretype_name= "Select Feature Type" });
                ViewBag.featuretypeList = lists;
                specifictype = ecomContext.Set<DBspecificationtype>().ToList().Select(st => new SpecificationType
                {
                    specificationtype_id = st.specificationtype_Id,
                    featuretype_name = st.DBfeaturetype.featuretype_name,
                    specificationtype_name = st.specificationtype_name
                }).ToList();
            }
            return View("SpecificationType", specifictype);
        }

        [HttpPost]
        public IActionResult addupdateSpecificationType(SpecificationType specificationtype)
        {
            if(ModelState.IsValid)
            {
                if (specificationtype.specificationtype_id != 0)
                {
                    var specifictype = ecomContext.DBSpecificationtypes.FirstOrDefault(st => st.specificationtype_name == specificationtype.specificationtype_name);
                    if (specifictype.specificationtype_name != specificationtype.specificationtype_name)
                    {
                        specifictype.specificationtype_name = specificationtype.specificationtype_name;
                    }
                    specifictype.featuretype_id = specificationtype.featuretype_id;
                    ecomContext.SaveChanges();
                }
                else
                {
                    var specifictype = ecomContext.DBSpecificationtypes.FirstOrDefault(st => st.specificationtype_name == specificationtype.specificationtype_name);
                    if (specifictype == null)
                    {
                        DBspecificationtype dBspecificationtype = new DBspecificationtype();
                        dBspecificationtype.specificationtype_name = specificationtype.specificationtype_name;
                        dBspecificationtype.featuretype_id = specificationtype.featuretype_id;
                        ecomContext.Add(dBspecificationtype);
                        ecomContext.SaveChanges();
                    }
                    else
                    {
                        List<string> err = new List<string>();
                        err.Add("Specification Type name is already existed");
                        return Json(new { success = false, errors = err });
                    }
                }
            }
            return Json(new { success = false, errors = ModelState.Values.SelectMany(ce => ce.Errors).Select(ce => ce.ErrorMessage).ToList() });
        }

        [HttpGet]
        public IActionResult editspecificationtype(int specificationtype_id)
        {
            var specifictype = ecomContext.DBSpecificationtypes.FirstOrDefault(st=>st.specificationtype_Id == specificationtype_id);
            return Json(specifictype);
        }

        [HttpGet]
        public IActionResult deleteSpecificationtype(int specificationtype_id)
        {
            var specifictype = ecomContext.DBSpecificationtypes.FirstOrDefault(st => st.specificationtype_Id == specificationtype_id);
            ecomContext.Remove(specifictype);
            ecomContext.SaveChanges();
            return Json(specifictype);
        }
    }
}
