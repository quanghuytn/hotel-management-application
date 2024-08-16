using System;
using System.Collections.Generic;

namespace Assign1.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RoomId { get; set; }
        public string? RoomType { get; set; }
        public string? Status { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
