using Assign1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Assign1.ViewModel
{
    public class CustomerViewModel:BaseViewModel
    {
        private ObservableCollection<Customer> _List;
        public ObservableCollection<Customer> List { get => _List; set { _List = value; OnPropertyChanged(); } }

      

        private Customer? _SelectedItem;
        public Customer? SelectedItem { get => _SelectedItem; set { 
                _SelectedItem = value; 
                OnPropertyChanged(); 
                if(SelectedItem != null)
                {
                    CustomerId = SelectedItem.CustomerId.ToString();
                    Name = SelectedItem.Name;
                    Email = SelectedItem.Email;
                    Address = SelectedItem.Address;
                    PhoneNumber = SelectedItem.PhoneNumber;
                }
            } }
        private string? _CustomerId;
        public string? CustomerId { get => _CustomerId; set { _CustomerId = value; OnPropertyChanged(); } }

        private string? _Name;
        public string? Name { get => _Name; set { _Name = value;OnPropertyChanged(); } }
        private string? _Address;
        public string? Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string? _Email;
        public string? Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string? _PhoneNumber;
        public string? PhoneNumber { get => _PhoneNumber; set { _PhoneNumber = value; OnPropertyChanged(); } }


        public ICommand RegisterCustomerCommand { get; set; }
        public ICommand UpdateCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SearchCustomerCommand { get; set; }

        public CustomerViewModel() { 
            List = new ObservableCollection<Customer>(DataProvider.ins.context.Customers);
            
            RegisterCustomerCommand = new RelayCommand<Object>((p) => {
                if (string.IsNullOrWhiteSpace(CustomerId) || !int.TryParse(CustomerId, out _)) return false;
                if (!int.TryParse(PhoneNumber, out _)) return false;
                if (DataProvider.ins.context.Customers.Any(c => c.CustomerId == Convert.ToInt32(CustomerId))) return false;
                return true; 
            }, (p) => {
                var customer = new Customer()
                {
                    CustomerId = Convert.ToInt32(CustomerId),
                    Name = Name,
                    Email = Email,
                    Address = Address,
                    PhoneNumber = PhoneNumber
                };
                DataProvider.ins.context.Add(customer);
                DataProvider.ins.context.SaveChanges();
                MessageBox.Show("Đăng ký thành công!");
                List.Add(customer);
            });

            UpdateCustomerCommand = new RelayCommand<Object>((p) => {
                if (string.IsNullOrWhiteSpace(CustomerId) || !int.TryParse(CustomerId, out _)) return false;
                if (SelectedItem == null) return false;
                if (!int.TryParse(PhoneNumber, out _)) return false;
                return true; 
            }, (p) => {
                var customer = DataProvider.ins.context.Customers.SingleOrDefault(c => c.CustomerId == SelectedItem.CustomerId);
                if(customer != null)
                {
                    customer.Name = Name;
                    customer.Address = Address;
                    customer.PhoneNumber = PhoneNumber;
                    customer.Email = Email;
                }
                DataProvider.ins.context.SaveChanges();
                MessageBox.Show("Cập nhật thành công!");
                List = new ObservableCollection<Customer>(DataProvider.ins.context.Customers);
            });

            RefreshCommand = new RelayCommand<Object>((p) => { return true; }, (p) => {
                CustomerId = string.Empty;
                Name = string.Empty;
                Address = string.Empty;
                PhoneNumber = string.Empty;
                Email = string.Empty;
                SelectedItem = null;
                List = new ObservableCollection<Customer>(DataProvider.ins.context.Customers);
            });

            SearchCustomerCommand = new RelayCommand<Object>((p) => { return true; }, (p) => {
                List = new ObservableCollection<Customer>(DataProvider.ins.context.Customers.Where(c =>
                (string.IsNullOrEmpty(CustomerId) || c.CustomerId == Convert.ToInt32(CustomerId)) &&
                (string.IsNullOrEmpty(Name) || c.Name.ToLower().Contains(Name.ToLower())) &&
                (string.IsNullOrEmpty(Address) || c.Address.ToLower().Contains(Address.ToLower())) &&
                (string.IsNullOrEmpty(PhoneNumber) || c.PhoneNumber.ToLower().Contains(PhoneNumber.ToLower())) &&
                (string.IsNullOrEmpty(Email) || c.Email.ToLower().Contains(Email.ToLower()))
                ));
            });

            DeleteCustomerCommand = new RelayCommand<Object>((p) => { return true; }, (p) => {
                var customer = DataProvider.ins.context.Customers.FirstOrDefault(r => r.CustomerId == Convert.ToInt32(CustomerId));
                if (customer != null)
                {
                    DataProvider.ins.context.Customers.Remove(customer);
                    DataProvider.ins.context.SaveChanges();
                    SelectedItem = null;
                    List = new ObservableCollection<Customer>(DataProvider.ins.context.Customers);
                }
            });
        }
    }
}
