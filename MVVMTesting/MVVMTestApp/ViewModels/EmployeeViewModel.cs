using System;
using MVVMTestApp.ViewModels.Base;

namespace MVVMTestApp.ViewModels
{
    class EmployeeViewModel : ViewModel
    {
        private string _Name;

        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        private string _SurName;

        public string SurName
        {
            get => _SurName;
            set => Set(ref _SurName, value);
        }

        private string _Patronymic;

        public string Patronymic
        {
            get => _Patronymic;
            set => Set(ref _Patronymic, value);
        }

        private DateTime _Birthday;

        public DateTime Birthday
        {
            get => _Birthday;
            set
            {
                if(Set(ref _Birthday, value)) 
                    OnPropertyChanged(nameof(Age));
            }
        }

        private DepartamentViewModel _Departament;

        public DepartamentViewModel Departament
        {
            get => _Departament;
            set => Set(ref _Departament, value);
        }

        public int Age => (int)Math.Floor((DateTime.Now - Birthday).TotalDays / 365);
    }
}
