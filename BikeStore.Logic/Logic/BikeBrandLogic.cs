using BikeStore.Data;
using BikeStore.Logic.Helpers;
using BikeStore.Entities;
using BikeStore.Entities.Dtos.BikeBrand;

namespace BikeStore.Logic.Logic
{
    public class BikeBrandLogic
    {
        Repository<BikeBrand> repo;
        DtoProvider dtoProvider;

        public BikeBrandLogic(Repository<BikeBrand> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }

        public void AddBikeBrand(BikeBrandCreateUpdateDto dto)
        {
            BikeBrand brand = dtoProvider.Mapper.Map<BikeBrand>(dto);

            // Only save if there is no brand with the same name
            if (repo.GetAll().FirstOrDefault(x => x.BrandName == brand.BrandName) == null)
            {
                repo.Create(brand);
            }
            else
            {
                throw new ArgumentException("A brand with this name already exists!");
            }
        }

        public IEnumerable<BikeBrandShortViewDto> GetAllBikeBrands()
        {
            return repo.GetAll().Select(x =>
                dtoProvider.Mapper.Map<BikeBrandShortViewDto>(x)
            );
        }

        public void DeleteBikeBrand(string id)
        {
            repo.DeleteById(id);
        }

        public void UpdateBikeBrand(string id, BikeBrandCreateUpdateDto dto)
        {
            var old = repo.FindById(id);
            dtoProvider.Mapper.Map(dto, old);
            repo.Update(old);
        }

        public BikeBrandViewDto GetBikeBrand(string id)
        {
            var model = repo.FindById(id);
            return dtoProvider.Mapper.Map<BikeBrandViewDto>(model);
        }
    }
}