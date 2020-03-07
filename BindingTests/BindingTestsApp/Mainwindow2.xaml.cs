using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingTestsApp
{
    public partial class MainWindow2
    {
        public MainWindow2()
        {
            InitializeComponent();

            var horizontal_binding = new Binding();
            horizontal_binding.ElementName = "HorizontalSlider";
            horizontal_binding.Path = new PropertyPath("Value");

            HorizontalValue.SetBinding(TextBlock.TextProperty, horizontal_binding);

            var vertival_binding = new Binding();
            vertival_binding.ElementName = "VerticalSlider";
            vertival_binding.Path = new PropertyPath("Value");

            VerticalValue.SetBinding(TextBlock.TextProperty, vertival_binding);
        }
    }
}
