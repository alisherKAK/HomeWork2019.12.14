using HomeWork2019._12._14.AbstractModels;
using System.Collections.Generic;

namespace HomeWork2019._12._14.Models
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public int LikeCount { get; set; }
        public virtual User User { get; set; }
    }
}
