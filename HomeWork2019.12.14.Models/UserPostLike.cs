using HomeWork2019._12._14.AbstractModels;

namespace HomeWork2019._12._14.Models
{
    public class UserPostLike : IEntity
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
