
using System;
using System.Timers;

namespace MVVMTestApp.ViewModels
{
    class MainWindowViewModel
    {
        private Timer _Timer;

        public string Title { get; set; } = "Заголовок окна проекта MVVM";

        public DateTime CurrentTime { get; set; }

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
