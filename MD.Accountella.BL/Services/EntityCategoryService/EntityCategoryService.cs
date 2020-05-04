
/// <summary>
/// Author: Meghnath Das
/// Description: Delivers navigation menu related services
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL
{
    using System.Collections.Generic;
    using AutoMapper;
    using MD.Accountella.DataTransferObjects;
    using MD.Accountella.DL;
    using MD.Accountella.DomainObjects;

    internal class EntityCategoryService : IEntityCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IEntityCategoryRepository _repository;
        public EntityCategoryService(IEntityCategoryRepository entityCategoryRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = entityCategoryRepository;
        }

        public EntityCategoryDto AddCategories(EntityCategoryDto catgToAdd)
        {
            var addedCatg = _repository.AddCategory(_mapper.Map<EntityCategory>(catgToAdd));
            return _mapper.Map<EntityCategoryDto>(addedCatg);
        }

        public ICollection<EntityCategoryDto> GetCategories(string id)
        {
            var catgs = _repository.GetCategories(id);
            return _mapper.Map<ICollection<EntityCategoryDto>>(catgs);
        }

        public void RemoveCategory(string id)
        {
            _repository.RemoveCategory(id);
        }

        public void UpdateCategory(string id, EntityCategoryDto catgToUpdate)
        {
            _repository.UpdateCategory(id, _mapper.Map<EntityCategory>(catgToUpdate));
        }
    }
}
