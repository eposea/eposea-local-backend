using System;
using System.Collections.Generic;
using System.Text;

namespace EposeaLocalBackend.Data.Models.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Item> Items { get;}
    }
}
