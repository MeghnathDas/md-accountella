/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.WebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MD.Accountella.BL;
    using MD.Accountella.DataTransferObjects;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MD.Accountella.Core.RestConcerns;

    [Route(RoutePrefix + "categories")]
    [ApiController]
    public class CategoryController : AccountellaControllerBase
    {
        private readonly IEntityCategoryService _categoryService;
        public CategoryController(IEntityCategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        // GET: api/categories
        [HttpGet]
        public ICollection<EntityCategoryDto> Get()
        {
            return _categoryService.GetCategories(null);
        }

        // GET: api/categories/5
        [HttpGet("{id}", Name = "GetCategory")]
        public EntityCategoryDto Get(string id)
        {
            return _categoryService.GetCategories(id).FirstOrDefault();
        }

        //// GET: api/categories?entity=
        //[HttpGet("{id}", Name = "GetCategoryByFeature")]
        //public EntityCategoryDto Get(string id)
        //{
        //    return _categoryService.GetCategories(id).FirstOrDefault();
        //}

        // POST: api/categories
        [HttpPost]
        public EntityCategoryDto Post(EntityCategoryDto entityCategoryToAdd)
        {
            return _categoryService.AddCategories(entityCategoryToAdd);
        }

        // PUT: api/categories/5
        [HttpPut("{id}")]
        public void Put(string id, EntityCategoryDto entityCategoryToAlter)
        {
            _categoryService.UpdateCategory(id, entityCategoryToAlter);
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _categoryService.RemoveCategory(id);
        }
    }
}
