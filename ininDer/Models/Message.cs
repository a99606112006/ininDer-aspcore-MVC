using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ininDer.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? ChatroomId { get; set; }
        public string Content { get; set; }
        public DateTime? PostTime { get; set; }
    }
}
