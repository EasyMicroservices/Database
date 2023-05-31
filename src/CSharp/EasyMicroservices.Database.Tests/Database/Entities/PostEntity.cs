using EasyMicroservices.Database.Tests.Database.Interfaces;

namespace EasyMicroservices.Database.Tests.Database.Entities
{
    public class PostEntity : IPost
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
