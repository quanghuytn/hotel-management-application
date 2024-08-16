using Assign1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Assign1.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string? _Revenue;
        public string? Revenue { get => _Revenue; set { _Revenue = value; OnPropertyChanged(); } }


        public ICommand CustomerCommand { get; set; }
        public ICommand RoomCommand { get; set; }
        public ICommand BookingCommand { get; set; }
        public MainViewModel()
        {
            CustomerCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { CustomerWindow cw = new CustomerWindow(); cw.ShowDialog(); });
            RoomCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { RoomWindow rw = new RoomWindow(); rw.ShowDialog(); });
            BookingCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { 
                BookingWindow bw = new BookingWindow();
                var bvm = bw.DataContext as BookingViewModel;
                if (bvm != null)
                {
                    bvm.BookingUpdated += UpdateRevenue;
                }

                bw.ShowDialog(); 
            });

            UpdateRevenue();
        }

        public void UpdateRevenue()
        {
            double totalRevenue = DataProvider.ins.context.Bookings.Sum(b => b.TotalPrice ?? 0);
            Revenue = totalRevenue.ToString() + " đ";
        }
    }
}
