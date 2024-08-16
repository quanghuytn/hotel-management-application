using Assign1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Assign1.ViewModel
{
    class RoomViewModel:BaseViewModel
    {
        private ObservableCollection<Room> _List;
        public ObservableCollection<Room> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Room? _SelectedItem;
        public Room? SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    RoomId = Convert.ToString(SelectedItem.RoomId);
                    Status = SelectedItem.Status;
                    RoomType = SelectedItem.RoomType;
                    Price = Convert.ToString(SelectedItem.Price);
                }
            }
        }


        private string _SearchType;
        public string SearchType { get => _SearchType; set { _SearchType = value; OnPropertyChanged(); } }
        private string _SearchStatus;
        public string SearchStatus { get => _SearchStatus; set { _SearchStatus = value; OnPropertyChanged(); } }
        private string _FromPrice;
        public string FromPrice { get => _FromPrice; set { _FromPrice = value; OnPropertyChanged(); } }
        private string _ToPrice;
        public string ToPrice { get => _ToPrice; set { _ToPrice = value; OnPropertyChanged(); } }



        private string _RoomId;
        public string RoomId { get => _RoomId; set { _RoomId = value; OnPropertyChanged(); } }

        private string? _RoomType;
        public string? RoomType { get => _RoomType; set { _RoomType = value; OnPropertyChanged(); } }

        private string? _Status;
        public string? Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

        private string? _Price;


        public string? Price { get => _Price; set {
                if (string.IsNullOrWhiteSpace(value)) _Price = null;
                else _Price = value; 
                OnPropertyChanged();
            } }

        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public RoomViewModel()
        {
            List = new ObservableCollection<Room>(DataProvider.ins.context.Rooms);

            AddCommand = new RelayCommand<Object>((p) => {
                if (string.IsNullOrWhiteSpace(RoomType)) return false;
                if (string.IsNullOrWhiteSpace(Price)|| !double.TryParse(Price, out _)) return false;
                if (DataProvider.ins.context.Rooms.Any(c => c.RoomId == Convert.ToInt32(RoomId))) return false;
                return true; 
            }, (p) => {
                var room = new Room()
                {
                    RoomId = Convert.ToInt32(RoomId),
                    RoomType = RoomType,
                    Price= Convert.ToDouble(Price),
                    Status=Status
                };
                DataProvider.ins.context.Add(room);
                DataProvider.ins.context.SaveChanges();
                MessageBox.Show("Thêm thành công!");
                List.Add(room);
            });

            UpdateCommand = new RelayCommand<Object>((p) => {
                if (SelectedItem == null || !double.TryParse(Price, out _)) return false;
                if (DataProvider.ins.context.Rooms.Any(c => c.RoomId == Convert.ToInt32(RoomId))) return false;
                return true;
            }, (p) => {
                var room = DataProvider.ins.context.Rooms.SingleOrDefault(c => c.RoomId == SelectedItem.RoomId);
                if (room != null)
                {
                    room.RoomId = Convert.ToInt32(RoomId);
                    room.RoomType = RoomType;
                    room.Status = Status;
                    room.Price = Convert.ToDouble(Price);
                }
                DataProvider.ins.context.SaveChanges();
                MessageBox.Show("Cập nhật thành công!");
                List = new ObservableCollection<Room>(DataProvider.ins.context.Rooms);
            });

            SearchCommand = new RelayCommand<Object>((p) => { return true; }, (p) => {
                List = new ObservableCollection<Room>(DataProvider.ins.context.Rooms.Where(r => 
                (string.IsNullOrEmpty(SearchStatus) || r.Status.ToLower().Contains(SearchStatus.ToLower())) &&
                (string.IsNullOrEmpty(SearchType) || r.RoomType.ToLower().Contains(SearchType.ToLower())) &&
                (string.IsNullOrEmpty(FromPrice) || r.Price >= Convert.ToDouble(FromPrice)) &&
                (string.IsNullOrEmpty(ToPrice) || r.Price <= Convert.ToDouble(ToPrice))
                ));
            });

            RefreshCommand = new RelayCommand<Object>((p) => { return true; }, (p) => {
                RoomId = string.Empty;
                RoomType = string.Empty;
                Status = string.Empty;
                Price = string.Empty;
                SelectedItem = null;
                List = new ObservableCollection<Room>(DataProvider.ins.context.Rooms);
            });

            DeleteCommand = new RelayCommand<Object>((p) => { return true; }, (p) => {
                var room = DataProvider.ins.context.Rooms.FirstOrDefault(r => r.RoomId == Convert.ToInt32(RoomId));
                if(room != null)
                {
                    DataProvider.ins.context.Rooms.Remove(room);
                    DataProvider.ins.context.SaveChanges();
                    SelectedItem = null;
                    List = new ObservableCollection<Room>(DataProvider.ins.context.Rooms);
                }
            });
        }
    }
}
