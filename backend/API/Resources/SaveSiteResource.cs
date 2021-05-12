using System.ComponentModel.DataAnnotations;

namespace InModeration.Backend.API.Resources
{
    public class SaveSiteResource
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Domain is required")]
        [MaxLength(200, ErrorMessage = "Max domain length is 200")]
        [Url(ErrorMessage = "Domain must be a URL")]
        public string Domain { get; set; }
    }
}
