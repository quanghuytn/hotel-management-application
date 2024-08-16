using System;
using System.Collections.Generic;

namespace Assign1.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? CustomerId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public double? TotalPrice { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Room? Room { get; set; }
    }
}
