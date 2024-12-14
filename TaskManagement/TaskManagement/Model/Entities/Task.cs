using TaskManagement.Model.Abstractions.Validation;

namespace TaskManagement.Model.Entities
{
    public class Task : ValidatableBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }


        public Project Project { get; set; }

        public Task(string title, string? description)
        {
            Title = title;
            Description = description;
        }

        public override void Validate()
        {
        }

        public void UpdateTask(string title, string? description)
        {
            Title = title;
            Description = description;
        }
    }
}
