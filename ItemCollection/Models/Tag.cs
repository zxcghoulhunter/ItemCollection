using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCollection.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string TagName { get; set; }
    }
}
