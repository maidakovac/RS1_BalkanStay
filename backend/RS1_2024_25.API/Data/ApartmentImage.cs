using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data
{
    public class ApartmentImage
    {
        public int ApartmentImageID { get; set; }

        [ForeignKey(nameof(Apartment))]
        public int ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }

        [ForeignKey(nameof(Image))]
        public int ImageID { get; set; }
        public Image? Image { get; set; }

    }
}
