using TMS.Core.Authentication;
using TMS.Core.Models;


namespace TMS.Core.DB
{
    public class Class1
    {

    }

    public  class DataGenerator
    { 

        public static  List<User> GenerateUser()
        {
            var users = new List<User>();
            users.Add(new User()
            {
                Id = Guid.NewGuid(),
                Name = "admin",
                Email = "admin@tms.com",
                Password = "admin@123",
                Role = UserRoles.Admin,
                CreatedAt = DateTime.Now,
                
            });

            users.Add(new User()
            {
                Id = Guid.NewGuid(),
                Name = "admin2",
                Email = "admin2@tms.com",
                Password = "admin@123",
                Role = UserRoles.Admin,
                CreatedAt = DateTime.Now,

            });

            users.Add(new User()
            {
                Id = Guid.NewGuid(),
                Name = "user",
                Email = "user@tms.com",
                Password = "user@123",
                Role = UserRoles.User,
                CreatedAt = DateTime.Now,

            });

            users.Add(new User()
            {
                Id = Guid.NewGuid(),
                Name = "user2",
                Email = "user2@tms.com",
                Password = "user@123",
                Role = UserRoles.User,
                CreatedAt = DateTime.Now,

            });

            users.Add(new User()
            {
                Id = Guid.NewGuid(),
                Name = "user3",
                Email = "user3@tms.com",
                Password = "user@123",
                Role = UserRoles.User,
                CreatedAt = DateTime.Now,

            });

            return users;
        }

        public static List<Models.Task> GenerateTasks(List<User>  users)
        {
            var tasks = new List<Models.Task>();


            for (int i = 0; i < 10; i++)
            {
                User currentUser = users[Random.Shared.Next(users.Count)];
               
                tasks.Add(new Models.Task()
                {
                    Id = Guid.NewGuid(),
                    Title =  $"Task_{i}",
                    Description = $"Welcome Task Management System {i}",
                    Priority = "High",
                    Status = Models.TaskStatus.TODO,
                    CreatedAt = DateTime.Now,
                    AssigneeId = currentUser.Id,
                    CreatorId = currentUser.Id,
                    UpdatedAt = DateTime.Now,
                });

            }

            return tasks;
        }

    }
}
