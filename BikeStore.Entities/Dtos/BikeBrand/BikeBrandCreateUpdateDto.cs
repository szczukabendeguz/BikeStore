using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Entities.Dtos.BikeBrand
{
    public class BikeBrandCreateUpdateDto
    {
        public required string BrandName { get; set; } = "";

        public required string Location { get; set; } = "";
    }
}
