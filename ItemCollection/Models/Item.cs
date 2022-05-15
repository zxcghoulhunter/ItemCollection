using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCollection.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public string Name { get; set; }
        [ForeignKey("CollectionId")]
        public Collection Collection { get; set; }
        [NotMapped]
        public string Tags { get; set; }
        public List<Tag> ItemTags { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public int IntFieldOne { get; set; }
        public int IntFieldTwo { get; set; }
        public int IntFieldThree { get; set; }
        public string StringFieldOne { get; set; }
        public string StringFieldTwo { get; set; }
        public string StringFieldThree { get; set; }
        public bool BoolFieldOne { get; set; }
        public bool BoolFieldTwo { get; set; }
        public bool BoolFieldThree { get; set; }
    }
}
