using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStore.Entities.Dtos.BikeModel;

namespace BikeStore.Entities.Dtos.BikeBrand
{
    public class BikeBrandViewDto
    {
        public string Id { get; set; } = "";
        public string BrandName { get; set; } = "";
        public string Location { get; set; } = "";
        public IEnumerable<BikeModelViewDto>? Models { get; set; }

        //extra property
        public int ModelCount => Models?.Count() ?? 0;

        public double AverageAskingPrice => Models?.Count() > 0 ? Models.Average(r => r.AskingPrice) : 0;

    }
}
