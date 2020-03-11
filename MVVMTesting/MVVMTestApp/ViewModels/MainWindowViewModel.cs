using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows.Input;
using MVVMTestApp.Infrastructure.Commands;
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

        private ObservableCollection<DepartamentViewModel> _Departaments;

        public ObservableCollection<DepartamentViewModel> Departaments
        {
            get => _Departaments;
            set => Set(ref _Departaments, value);
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

        #region Команды

        public ICommand CreateNewEmployeeCommand { get; }

        private void OnCreateNewEmployeeCommandExecuted(object parameter)
        {
            var new_employe = new EmployeeViewModel
            {
                Name = "NewEmployeName"
            };

            _Employees.Insert(0, new_employe);
            SelectedEmployee = new_employe;
        }

        public ICommand RemoveEmployeeCommand { get; }

        private void OnRemoveEmployeeCommandExecuted(object paramater)
        {
            if (!(paramater is EmployeeViewModel employee)) return;
            _Employees.Remove(employee);
            if (ReferenceEquals(_SelectedEmployee, employee))
                SelectedEmployee = null;
        }

        private static bool CanRemoveEmployeeCommandExecute(object parameter) => parameter is EmployeeViewModel;

        #endregion

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

            _Departaments = new ObservableCollection<DepartamentViewModel>(
                Enumerable.Range(1, 10).Select(i => new DepartamentViewModel { Name = $"Отдел {i}" }));

            #region Команды

            CreateNewEmployeeCommand = new LambdaCommand(OnCreateNewEmployeeCommandExecuted);
            RemoveEmployeeCommand = new LambdaCommand(OnRemoveEmployeeCommandExecuted, CanRemoveEmployeeCommandExecute);

            #endregion
        }

    }
}
