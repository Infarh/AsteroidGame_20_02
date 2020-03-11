using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using MVVMTestApp.ViewModels.Base;

namespace MVVMTestApp.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Заголовок окна проекта MVVM";

        public string Title
        {
            get => _Title;
            //set
            //{
            //    if (Equals(_Title, value)) return;
            //    _Title = value;
            //    OnPropertyChanged(nameof(Title));
            //}
            set => Set(ref _Title, value);
        }

        private ObservableCollection<EmployeeViewModel> _Employees = new ObservableCollection<EmployeeViewModel>();

        public ObservableCollection<EmployeeViewModel> Employees
        {
            get => _Employees;
            set => Set(ref _Employees, value);
        }

        private EmployeeViewModel _SelectedEmployee;

        public EmployeeViewModel SelectedEmployee
        {
            get => _SelectedEmployee;
            set => Set(ref _SelectedEmployee, value);
        }

        public MainWindowViewModel()
        {
            var rnd = new Random();
            foreach (var employee in Enumerable.Range(1, 100).Select(i => new EmployeeViewModel
            {
                Name = $"Имя {i}",
                SurName = $"Фамилия {i}",
                Patronymic = $"Отчество {i}",
                Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(365 * rnd.Next(18, 50)))
            }))
                _Employees.Add(employee);
        }

    }
}
