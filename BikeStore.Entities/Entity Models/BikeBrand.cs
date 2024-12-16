using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BikeStore.Entities.Helpers;

namespace BikeStore.Entities
{
    public class BikeBrand : IIdEntity
    {
        public BikeBrand(string brandName, string location)
        {
            Id = Guid.NewGuid().ToString();
            BrandName = brandName;
            Location = location;
        }

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [StringLength(200)]
        public string BrandName { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [NotMapped]
        public virtual ICollection<BikeModel>? Models { get; set; }

    }
}
