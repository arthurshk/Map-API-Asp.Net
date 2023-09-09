using System.ComponentModel.DataAnnotations;

namespace Scaffold2.Models
{
    public class CalendarModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        [StringLength(500)]
        public string? eventTitle { get; set; }
        public DateTime? eventDate { get; set; }
        public string? eventDescription { get; set; }
    }
}
