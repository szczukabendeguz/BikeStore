using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Entities.Dtos.BikeModel
{
    public class BikeModelViewDto
    {
        public string ModelName { get; set; } = "";
        public int FrontTravel { get; set; }
        public int BackTravel { get; set; }
        public int AskingPrice { get; set; }
        public string UserFullName { get; set; } = "";
    }
}
