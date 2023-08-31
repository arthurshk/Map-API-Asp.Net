using System.ComponentModel.DataAnnotations;

namespace Scaffold2.Models
{
    public class MapMarker
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        [StringLength(500)]
        public string? title { get; set; }
        [MaxLength(20)]
        [StringLength(20)]
        public string? lat { get; set; }
        [MaxLength(20)]
        [StringLength(20)]
        public string? lng { get; set; }
    }
}
