using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMTestApp.ViewModels.Base;

namespace MVVMTestApp.ViewModels
{
    class DepartamentViewModel : ViewModel
    {
        #region Name : string - Название

        /// <summary>Название</summary>
        private string _Name;

        /// <summary>Название</summary>
        public string Name { get => _Name; set => Set(ref _Name, value); }

        #endregion
    }
}
