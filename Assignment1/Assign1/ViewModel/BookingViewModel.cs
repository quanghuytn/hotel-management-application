using Assign1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Assign1.ViewModel
{
    public class BookingViewModel : BaseViewModel
    {
        private ObservableCollection<Booking> _List;
        public ObservableCollection<Booking> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<int> _RoomIds;
        public ObservableCollection<int> RoomIds { get => _RoomIds; set { _RoomIds = value; OnPropertyChanged(); } }

        private ObservableCollection<int> _CustomerIds;
        public ObservableCollection<int> CustomerIds { get => _CustomerIds; set { _CustomerIds = value; OnPropertyChanged(); } }

        private Booking? _SelectedItem;
        public Booking? SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    BookingId = SelectedItem.BookingId.ToString();
                    CustomerId = SelectedItem.CustomerId.ToString();
                    RoomId = SelectedItem.RoomId.ToString();
                    CheckInDate = SelectedItem.CheckInDate;
                    CheckOutDate = SelectedItem.CheckOutDate;
                    TotalPrice = SelectedItem.TotalPrice.ToString();
                }
            }
        }
        private string? _BookingId;
        public string? BookingId { get => _BookingId; set { _BookingId = value; OnPropertyChanged(); } }
        private string? _RoomId;
        public string? RoomId { get => _RoomId; set { _RoomId = value; OnPropertyChanged(); CalculateTotalPrice(); } }


        private string? _CustomerId;
        public string? CustomerId { get => _CustomerId; set { _CustomerId = value; OnPropertyChanged(); } }

        private DateTime? _CheckInDate;
        public DateTime? CheckInDate { get => _CheckInDate; set { _CheckInDate = value; OnPropertyChanged(); CalculateTotalPrice(); FilterAvailableRooms(); } }
        private DateTime? _CheckOutDate;
        public DateTime? CheckOutDate { get => _CheckOutDate; set { _CheckOutDate = value; OnPropertyChanged(); CalculateTotalPrice(); FilterAvailableRooms(); } }
        private string? _TotalPrice;
        public string? TotalPrice { get => _TotalPrice; set { 
                
                _TotalPrice = value; 
                OnPropertyChanged(); 
            } }


        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public event Action? BookingUpdated;

        public BookingViewModel()
        {
            
            List = new ObservableCollection<Booking>(DataProvider.ins.context.Bookings);
            RoomIds = new ObservableCollection<int>(DataProvider.ins.context.Rooms.Select(r => r.RoomId));
            CustomerIds = new ObservableCollection<int>(DataProvider.ins.context.Customers.Select(c => c.CustomerId));


            CreateCommand = new RelayCommand<Object>((p) => {
                
                if (!DataProvider.ins.context.Customers.Any(c => c.CustomerId == Convert.ToInt32(CustomerId)) || !DataProvider.ins.context.Rooms.Any(r => r.RoomId == Convert.ToInt32(RoomId)) 
                || DataProvider.ins.context.Bookings.Any(c => c.BookingId == Convert.ToInt32(BookingId))) return false;
                if (string.IsNullOrWhiteSpace(BookingId) || string.IsNullOrWhiteSpace(RoomId) || CheckInDate == null || CheckOutDate == null) return false;
                return true;
            }, (p) => {
                if (IsRoomAvailable(Convert.ToInt32(RoomId), CheckInDate, CheckOutDate))
                {
                    var booking = new Booking()
                    {
                        BookingId = Convert.ToInt32(BookingId),
                        CustomerId = Convert.ToInt32(CustomerId),
                        RoomId = Convert.ToInt32(RoomId),
                        CheckInDate = CheckInDate,
                        CheckOutDate = CheckOutDate,
                        TotalPrice = double.Parse(TotalPrice)
                    };
                    DataProvider.ins.context.Add(booking);
                    DataProvider.ins.context.SaveChanges();
                    MessageBox.Show("Đặt phòng thành công!");
                    List.Add(booking);
                }
                else
                {
                    MessageBox.Show("Phòng không còn trống trong thời gian này");
                }
                
            });

            UpdateCommand = new RelayCommand<Object>((p) => {
                if (!DataProvider.ins.context.Customers.Any(c => c.CustomerId == Convert.ToInt32(CustomerId)) || !DataProvider.ins.context.Rooms.Any(r => r.RoomId == Convert.ToInt32(RoomId))
                ) return false;
                if (string.IsNullOrWhiteSpace(CustomerId) || !int.TryParse(CustomerId, out _)) return false;
                if (SelectedItem == null) return false;
                return true;
            }, (p) => {
                var booking = DataProvider.ins.context.Bookings.SingleOrDefault(c => c.BookingId == SelectedItem.BookingId);
                if (booking != null)
                {
                    booking.RoomId = Convert.ToInt32(RoomId);
                    booking.CheckInDate = CheckInDate;
                    booking.CheckOutDate = CheckOutDate;
                    booking.TotalPrice = double.Parse(TotalPrice);
                }
                DataProvider.ins.context.SaveChanges();
                MessageBox.Show("Cập nhật thành công!");
                List = new ObservableCollection<Booking>(DataProvider.ins.context.Bookings);
                BookingUpdated?.Invoke();
            });

            RefreshCommand = new RelayCommand<Object>((p) => { return true; }, (p) => {
                BookingId = string.Empty;
                BookingId = string.Empty;
                RoomId = string.Empty;
                CheckInDate = null;
                CheckOutDate = null;
                TotalPrice = string.Empty;
                SelectedItem = null;
                List = new ObservableCollection<Booking>(DataProvider.ins.context.Bookings);
            });

            SearchCommand = new RelayCommand<Object>((p) => { return true; }, (p) => {
                List = new ObservableCollection<Booking>(DataProvider.ins.context.Bookings.Where(b =>
                    (string.IsNullOrEmpty(CustomerId) || b.CustomerId == Convert.ToInt32(CustomerId)) &&
                    (string.IsNullOrEmpty(RoomId) || b.CustomerId == Convert.ToInt32(RoomId)) &&
                    (string.IsNullOrEmpty(CustomerId) || b.CustomerId == Convert.ToInt32(CustomerId)) &&
                    (!CheckInDate.HasValue || b.CheckInDate <= CheckInDate) &&
                    (!CheckInDate.HasValue || b.CheckOutDate >= CheckOutDate)
                ));
            });

            CancelCommand = new RelayCommand<Object>((p) => { return true; }, (p) => {
                var booking = DataProvider.ins.context.Bookings.FirstOrDefault(r => r.BookingId == Convert.ToInt32(BookingId));
                if (booking != null)
                {
                    DataProvider.ins.context.Bookings.Remove(booking);
                    DataProvider.ins.context.SaveChanges();
                    SelectedItem = null;
                    MessageBox.Show("Hủy thành công!");
                    List = new ObservableCollection<Booking>(DataProvider.ins.context.Bookings);
                }
            });
        }

        public bool IsRoomAvailable(int? roomId, DateTime? checkInDate, DateTime? checkOutDate)
        {
            return !DataProvider.ins.context.Bookings.Any(b =>
                b.RoomId == roomId &&
                b.CheckInDate < checkOutDate && // Existing booking's check-in date is before the new check-out date
                b.CheckOutDate > checkInDate    // Existing booking's check-out date is after the new check-in date
            );
        }

        private void CalculateTotalPrice()
        {
            try
            {
                if (CheckInDate.HasValue && CheckOutDate.HasValue && DataProvider.ins.context.Rooms.Any(r => r.RoomId == Convert.ToInt32(RoomId)))
                {
                    var room = DataProvider.ins.context.Rooms.SingleOrDefault(r => r.RoomId == Convert.ToInt32(RoomId));
                    TimeSpan? stayDuration = CheckOutDate - CheckInDate;
                    if (stayDuration.HasValue && stayDuration.Value.TotalDays > 0)
                    {
                        TotalPrice = stayDuration.Value.TotalDays * room.Price.GetValueOrDefault(0) + "";
                    }
                    else
                    {
                        TotalPrice = string.Empty;
                    }
                }
                else
                {
                    TotalPrice = string.Empty;
                }
            }
            catch(Exception ex)
            {
            }
            
        }

        private void FilterAvailableRooms()
        {
            if (CheckInDate == null || CheckOutDate == null)
                return;

            // Query to get available rooms for the selected date range
            var availableRooms = DataProvider.ins.context.Rooms
                .Where(room => !DataProvider.ins.context.Bookings.Any(booking =>
                    booking.RoomId == room.RoomId &&
                    booking.CheckInDate < CheckOutDate &&
                    booking.CheckOutDate > CheckInDate))
                .Select(room => room.RoomId)
                .ToList();

            // Update the RoomIds collection
            RoomIds.Clear();
            foreach (var roomId in availableRooms)
            {
                RoomIds.Add(roomId);
            }
        }
    }
}
