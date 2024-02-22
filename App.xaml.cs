using System.Configuration;
using System.Data;
using System.Windows;

namespace CalculatorMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Views.CalculatorView view = new Views.CalculatorView();
            view.Show();
        }
    }

}
