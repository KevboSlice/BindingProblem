using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SampleMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SampleMobile.ViewModels
{
   public partial class MainPageViewModel : ObservableObject
   {
      private IConnectivity connect;

      [ObservableProperty]
      private bool isRefreshing;
      [ObservableProperty]
      private bool isBusy;

      public ObservableCollection<EmployeeModel> EmployeeList { get; set; } = new();

      public MainPageViewModel(IConnectivity connect)
      {
         this.connect = connect;
         GetEmployees();
      }

      [ICommand]
      public async void GetEmployees()
      {
         if (IsBusy) { return; }

         if (connect.NetworkAccess != NetworkAccess.Internet)
         {
            await Shell.Current.DisplayAlert("No connectivity!", $"Please check internet and try again.", "OK");
            return;
         }

         isBusy = true;

         var tmpList = new ObservableCollection<EmployeeModel>();
         tmpList.Add(new EmployeeModel()
         {
            Name = "Tom Thumb",
            Department = "IT",
            Title = "Developer"
         });
         EmployeeList = tmpList;
         OnPropertyChanged("EmployeeList");

         //this will fail just the same as above if you try to modify the list directly
         //EmployeeList.Add(new EmployeeModel()
         //{
         //   Name = "Tom Thumb",
         //   Department = "IT",
         //   Title = "Developer"
         //});

         isBusy = false;
         IsRefreshing = false;
      }
   }
}
