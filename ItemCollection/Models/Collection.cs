using ItemCollection.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCollection.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Topic{ get; set; }
        public Image Image { get; set; } = new Image();
        public List<Item> ItemList { get; set; } = new List<Item>();
        public string Owner { get; set; }
        public string? StringFieldOneName { get; set; }
        public string? StringFieldTwoName { get; set; }
        public string? StringFieldThreeName { get; set; }
        public string? IntFieldOneName { get; set; }
        public string? IntFieldTwoName { get; set; }
        public string? IntFieldThreeName { get; set; }
        public string? BoolFieldOneName { get; set; }
        public string? BoolFieldTwoName { get; set; }
        public string? BoolFieldThreeName { get; set; }
    }
}
