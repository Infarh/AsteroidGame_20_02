
using System;
using System.Timers;
using MVVMTestApp.ViewModels.Base;

namespace MVVMTestApp.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private Timer _Timer;
        private DateTime _CurrentTime;

        public string Title { get; set; } = "Заголовок окна проекта MVVM";

        public DateTime CurrentTime
        {
            get => _CurrentTime;
            set
            {
                if (Equals(_CurrentTime, value)) return;
                _CurrentTime = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            _Timer = new Timer(100) { AutoReset = true };
            _Timer.Elapsed += OnTimerTick;
            _Timer.Start();
        }

        private void OnTimerTick(object Sender, ElapsedEventArgs E)
        {
            CurrentTime = DateTime.Now;
        }
    }
}
