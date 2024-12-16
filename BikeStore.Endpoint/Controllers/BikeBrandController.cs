using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BikeStore.Data;
using BikeStore.Entities;
using BikeStore.Entities.Dtos.BikeBrand;
using BikeStore.Entities.Helpers;
using BikeStore.Logic.Logic;

namespace BikeStore.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeBrandController : ControllerBase
    {
        BikeBrandLogic logic;

        public BikeBrandController(BikeBrandLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        [Authorize]
        public void AddBikeBrand(BikeBrandCreateUpdateDto dto)
        {
            logic.AddBikeBrand(dto);
        }

        [HttpGet]
        public IEnumerable<BikeBrandShortViewDto> GetAllBikeBrands()
        {
            return logic.GetAllBikeBrands();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteBikeBrand(string id)
        {
            logic.DeleteBikeBrand(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public void UpdateBikeBrand(string id, [FromBody] BikeBrandCreateUpdateDto dto)
        {
            logic.UpdateBikeBrand(id, dto);
        }

        [HttpGet("{id}")]
        public BikeBrandViewDto GetBikeBrand(string id)
        {
            return logic.GetBikeBrand(id);
        }
    }
}
