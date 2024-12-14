namespace TaskManagement.Model.Dto.Request
{
    public class UpdateTaskFromProjectRequestDto
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
