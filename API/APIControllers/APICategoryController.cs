using Ecommerce.API.Repository;
using Ecommerce.AppData;
using Ecommerce.AppData.Context;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.APIControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APICategoryController : Controller
    {
        private ICategory iCategory;
        private ecommerceContext ecomContext;

        public APICategoryController(ICategory _iCategory, ecommerceContext _ecomContext) 
        {
            iCategory = _iCategory;
            ecomContext = _ecomContext;
        }

        #region Display Category
        [HttpGet("Category")]
        public async Task<IActionResult> Category()
        {
            var categories = await iCategory.Category();
            return Ok(categories);
        }
        #endregion

        #region Display category order By
        [HttpGet("getCategoryOrderBy")]
        public async Task<IActionResult> getCategoryOrderBy()
        {
            var categories = await iCategory.Category();
            return Ok(categories);
        }
        #endregion

        #region Get Child Category
        [HttpGet("getchildCategory")]
        public async Task<IActionResult> getchildCategory(int? parent_category_id)
        {
            var categories = await iCategory.getchildCategory(parent_category_id);
            return Ok(categories);
        }
        #endregion

        #region Get Child Category recursion
        [HttpGet("getchildCategoryRecursion")]
        public async Task<IActionResult> getchildCategoryRecursion(int? parent_category_id)
        {
            var categories = await iCategory.getchildCategoryRecursion(parent_category_id);
            return Ok(categories);
        }
        #endregion

        #region Find Category by category Id
        [HttpGet("findCategory/{category_id}")]
        public async Task<IActionResult> findCategory(int category_id)
        {
            var categories = await iCategory.findCategory(category_id);
            return Ok(categories);
        }
        #endregion

        #region Add and edit category
        [HttpPost("addupdateCategory")]
        public async Task<IActionResult> addupdateCategory(Category category)
        {
            try
            {
                Guid g = Guid.NewGuid();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\image\\category", g + category.file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    category.thumbnail_image = g + category.file.FileName;
                    category.file.CopyTo(stream);
                }
                DBcategory cat = new DBcategory();
                cat.category_id = category.category_id;
                cat.category_name = category.category_name;
                cat.thumbnail_image = category.thumbnail_image;
                cat.parent_category_id = category.parent_category_id;

                await iCategory.addupdatecategory(cat);
                DBspecificationsXcategory dBspecificationsXcategory = new DBspecificationsXcategory();
                dBspecificationsXcategory.category_id = category.category_id;
                await iCategory.addupdatespecificationsXcategory(dBspecificationsXcategory);
                return Ok("Category Added Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
        #endregion

        #region Delete Category
        [HttpGet("DeleteCategory/{category_id}")]
        public async Task<IActionResult> DeleteCategory(int category_id)
        {
            await iCategory.DeleteCategory(category_id);
            return Ok("Category Remove Successfully");
        }
        #endregion

        #region add Specifications
        [HttpPost("addspecificationsXcategory")]
        public async Task<IActionResult> addspecificationsXcategory(DBspecificationsXcategory dBspecificationsXcategory)
        {
            try
            {
                await iCategory.addupdatespecificationsXcategory(dBspecificationsXcategory);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        #endregion

        #region get Specification data
        [HttpGet("getspecificationsxcategorydata/{specificationsXcategory_id}")]
        public async Task<IActionResult> getspecificationsxcategorydata(int specificationsXcategory_id)
        {
            var specificationxcategory = await iCategory.getspecificationsxcategorydata(specificationsXcategory_id);
            return Ok(specificationxcategory);
        }
        #endregion

        #region get specificationtype on featureid
        [HttpGet("getspecificationtypeonfeatureid/{featuretype_id}")]
        public async Task<IActionResult> getspecificationtypeonfeatureid(int featuretype_id)
        {
            var specificationlist = await iCategory.getspecificationtypeonfeatureid(featuretype_id);
            return Ok(specificationlist);
        }
        #endregion
    }
}
