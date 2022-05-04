using System;
using System.Collections.Generic;

#nullable disable

namespace Project2.Models
{
    public partial class Tool
    {
        public Tool()
        {
            Keys = new HashSet<Key>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsModified { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<Key> Keys { get; set; }
    }
}
