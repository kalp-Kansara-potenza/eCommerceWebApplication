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
    public class FeatureTypeController : Controller
    {
        private ecommerceContext ecomContext;

        public FeatureTypeController(ecommerceContext ecomContext)
        {
            this.ecomContext = ecomContext;
        }
        public IActionResult FeatureType()
        {
            List<FeatureType> featureTypes;
            if (User.FindFirst("rolename") == null)
            {
                return RedirectToAction("unauthorized", "account");
            }
            else
            {
                featureTypes = ecomContext.Set<DBfeaturetype>().ToList().Select(ft => new FeatureType
                {
                    featuretype_id = ft.featuretype_id,
                    featuretype_name = ft.featuretype_name
                }).ToList();
            }
            return View("FeatureType",featureTypes);
        }

        [HttpPost]
        public IActionResult addupdateFeatureType(FeatureType featureType)
        {
            if(ModelState.IsValid)
            {
                if(featureType.featuretype_id != 0)
                {
                    var featuretype = ecomContext.DBFeaturetypes.FirstOrDefault(ft=>ft.featuretype_name == featureType.featuretype_name);
                    if(featuretype.featuretype_name != featureType.featuretype_name)
                    {
                        featuretype.featuretype_name = featureType.featuretype_name;
                    }
                    ecomContext.SaveChanges();
                }
                else
                {
                    var featuretype = ecomContext.DBFeaturetypes.FirstOrDefault(ft => ft.featuretype_name == featureType.featuretype_name);
                    if(featuretype == null)
                    {
                        DBfeaturetype dBfeaturetype = new DBfeaturetype();
                        dBfeaturetype.featuretype_name = featureType.featuretype_name;
                        ecomContext.Add(dBfeaturetype);
                        ecomContext.SaveChanges();
                    }
                    else
                    {
                        List<string> err = new List<string>();
                        err.Add("Feature Type name is already existed");
                        return Json(new { success = false, errors = err });
                    }
                }
            }
            return Json(new { success = false, errors = ModelState.Values.SelectMany(ce => ce.Errors).Select(ce => ce.ErrorMessage).ToList() });
        }

        [HttpGet]
        public IActionResult editfeaturetype(int featuretype_id)
        {
            var featuretype = ecomContext.DBFeaturetypes.FirstOrDefault(ft => ft.featuretype_id == featuretype_id);
            return Json(featuretype);
        }

        [HttpGet]
        public IActionResult deleteSpecificationtype(int featuretype_id)
        {
            var featuretype = ecomContext.DBFeaturetypes.FirstOrDefault(ft => ft.featuretype_id == featuretype_id);
            ecomContext.Remove(featuretype);
            ecomContext.SaveChanges();
            return Json(featuretype);
        }
    }
}
