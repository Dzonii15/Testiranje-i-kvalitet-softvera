using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Model.Dto.Request
{
    public record CreateTaskForProjectRequestDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public string TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
    }
}
