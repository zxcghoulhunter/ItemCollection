using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCollection.Models
{
    public class Image
    {
        [Key]
        [ForeignKey("Collection")]
        public int CollectionId { get; set; }
        public string Name { get; set; }
        [NotMapped]
        [DisplayName("Upload image")]
        public IFormFile ImageFile { get; set; }
        
        public Collection Collection { get; set; }
    }
}
