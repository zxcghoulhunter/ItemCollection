using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ItemCollection.Models;
using Microsoft.AspNetCore.Identity;

namespace ItemCollection.Areas.Identity.Data
{
    public class ItemCollectionUser : IdentityUser
    {
        [PersonalData]
        public bool isEnglish { get; set; } = false;
        [PersonalData]
        public bool BlackTheme { get; set; } = false;
        [PersonalData]
        public List<Collection> Collections { get; set; } = new List<Collection>();
        [PersonalData]
        public bool isAdmin { get; set; }
    }
}
