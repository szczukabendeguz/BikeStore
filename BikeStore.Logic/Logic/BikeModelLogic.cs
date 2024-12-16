using BikeStore.Data;
using BikeStore.Logic.Helpers;
using BikeStore.Entities;
using BikeStore.Entities.Dtos.BikeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Logic.Logic
{
    public class BikeModelLogic
    {
        Repository<BikeModel> repo;
        DtoProvider dtoProvider;

        public BikeModelLogic(Repository<BikeModel> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }

        public void AddBikeModel(BikeModelCreateDto dto, string userId)
        {
            var model = dtoProvider.Mapper.Map<BikeModel>(dto);
            model.UserId = userId;
            repo.Create(model);
        }

        public IEnumerable<BikeModelViewDto> GetBikeModelsByBrandId(string brandId)
        {
            var bikeModels = repo.GetAll()
                                 .Where(bm => bm.BrandId == brandId)
                                 .ToList();

            var bikeModelDtos = bikeModels.Select(bm => dtoProvider.Mapper.Map<BikeModelViewDto>(bm))
                                          .ToList();

            return bikeModelDtos;
        }

        public IEnumerable<BikeModelViewDto> GetAllBikeModelsInAscendingPriceOrder()
        {
            var bikeModels = repo.GetAll()
                                 .OrderBy(bm => bm.AskingPrice)
                                 .ToList();

            var bikeModelDtos = bikeModels.Select(bm => dtoProvider.Mapper.Map<BikeModelViewDto>(bm))
                                          .ToList();

            return bikeModelDtos;
        }
    }
}
