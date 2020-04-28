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
    using MD.Accountella.DataTransferObjects;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/categories
        [HttpGet]
        public IEnumerable<EntityCategoryDto> Get()
        {
            return new List<EntityCategoryDto>();
        }

        // GET: api/categories/5
        [HttpGet("{id}", Name = "GetCategory")]
        public EntityCategoryDto Get(int id)
        {
            return new EntityCategoryDto();
        }

        // POST: api/categories
        [HttpPost]
        public void Post(EntityCategoryDto entityCategoryToAdd)
        {
        }

        // PUT: api/categories/5
        [HttpPut("{id}")]
        public void Put(string id, EntityCategoryDto entityCategoryToAlter)
        {
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
