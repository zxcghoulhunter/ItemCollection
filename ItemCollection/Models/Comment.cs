using ItemCollection.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCollection.Models
{
    public class Comment
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string Date { get; set; }
        public int ItemId { get; set; }
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public ItemCollectionUser User { get; set; }
    }
}
