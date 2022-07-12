using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ininDer.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public string Q { get; set; }
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string Ca { get; set; }
        public string ImageName { get; set; }
        public string UserId { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

    }
}
