using System.ComponentModel.DataAnnotations;

namespace InModeration.Backend.API.Resources
{
    public class SaveSiteRuleResource
    {
        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Site Id is required")]
        public int SiteId { get; set; }

        [Required(ErrorMessage = "Time is required")]
        public int Time { get; set; }

        [Required(ErrorMessage = "Points is required")]
        public int Points { get; set; }
    }
}
