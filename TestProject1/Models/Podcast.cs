
using System.ComponentModel.DataAnnotations;
using TestProject1.Models;

namespace Shared.Models
{
    public class Podcast
    {
        [Key]
        public int PodcastId { get; set; }
        public string? Name { get; set; }


        public string? Id { get; set; }
        public ApplicationUser User { get; set; }
    }
}
