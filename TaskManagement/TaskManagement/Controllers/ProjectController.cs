using Microsoft.AspNetCore.Mvc;
using TaskManagement.Model.Dto.Request;
using TaskManagement.Service;

namespace TaskManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        [HttpPost("/{projectId}/addTask")]
        public async Task<IActionResult> AddTaskToProject([FromBody] CreateTaskForProjectRequestDto request)
        {
            await projectService.AddTaskToProject(request.ProjectId, request.UserId, request.TaskTitle, request.TaskDescription);
            return Created();
        }

        [HttpDelete("/{projectId}/deleteTask/{taskId}")]
        public async Task<IActionResult> DeleteTaskFromProject([FromBody] DeleteTaskFromProjectRequestDto request)
        {
            await projectService.DeleteTaskFromProject(request.ProjectId, request.UserId, request.TaskId);
            return Ok();
        }

        [HttpPut("/{projectId}/updateTask/{taskId}")]
        public async Task<IActionResult> UpdateTaskFromProject([FromBody] UpdateTaskFromProjectRequestDto request)
        {
            await projectService.UpdateTaskFromProject(request.ProjectId, request.UserId, request.TaskId, request.Title, request.Description);
            return Ok();
        }
    }
}
