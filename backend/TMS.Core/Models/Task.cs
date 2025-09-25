using System.ComponentModel.DataAnnotations;

namespace TMS.Core.Models
{
    public enum TaskStatus
    {
        TODO,
        IN_PROGRESS,
        DONE

    }


    public class Task
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public TaskStatus Status { get; set; }

        [Required]
        public string Priority { get; set; }

        
        public Guid AssigneeId { get; set; }
        public Guid CreatorId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
