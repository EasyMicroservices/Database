using EasyMicroservices.Database.Tests.Database.Interfaces;

namespace EasyMicroservices.Database.Tests.Database.Entities
{
    public class UserEntity : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
