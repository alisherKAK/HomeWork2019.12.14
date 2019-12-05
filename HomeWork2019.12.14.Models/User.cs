using HomeWork2019._12._14.AbstractModels;
using System.Collections.Generic;

namespace HomeWork2019._12._14.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual IList<Post> Posts { get; set; } = new List<Post>();
    }
}
