using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStore.Entities.Helpers;

namespace BikeStore.Entities
{
    public class BikeModel : IIdEntity
    {
        public BikeModel() { }

        public BikeModel(string brandId, string modelName, int frontTravel, int backTravel, int askingPrice, string userId)
        {
            Id = Guid.NewGuid().ToString();
            BrandId = brandId; 
            ModelName = modelName;
            FrontTravel = frontTravel;
            BackTravel = backTravel;
            AskingPrice = askingPrice;
            UserId = userId;
        }

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [StringLength(50)]
        public string BrandId { get; set; }

        [NotMapped]
        public virtual BikeBrand? Brand { get; set; }

        [StringLength(200)]
        public string ModelName { get; set; }

        [Range(0, 210)]
        public int FrontTravel { get; set; }

        [Range(0, 210)]
        public int BackTravel { get; set; }

        public int AskingPrice { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }
    }
}
