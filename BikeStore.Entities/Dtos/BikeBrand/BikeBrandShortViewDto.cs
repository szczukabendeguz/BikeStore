using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Entities.Dtos.BikeBrand
{
    public class BikeBrandShortViewDto
    {
        public string Id { get; set; } = "";

        public string BrandName { get; set; } = "";

        public string Location { get; set; } = "";

        public double AverageAskingPrice { get; set; } = 0;
    }
}
