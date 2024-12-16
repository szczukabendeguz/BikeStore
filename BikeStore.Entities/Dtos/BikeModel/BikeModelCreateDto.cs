using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Entities.Dtos.BikeModel
{
    public class BikeModelCreateDto
    {
        public required string BrandId { get; set; } = "";

        [MinLength(1)]
        [MaxLength(200)]
        public required string ModelName { get; set; } = "";

        [Range(0, 210)]
        public required int FrontTravel { get; set; }

        [Range(0, 210)]
        public required int BackTravel { get; set; }

        public required int AskingPrice { get; set; }
    }
}
