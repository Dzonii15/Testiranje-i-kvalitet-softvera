namespace TaskManagement.Model.Dto.Request
{
    public class DeleteTaskFromProjectRequestDto
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
    }
}
