using System.Windows;
using RegularExpressionTester.ViewModels;

namespace RegularExpressionTester
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			Startup += App_Startup;
		}

		private void App_Startup(object sender, StartupEventArgs e)
		{
			var viewModel = new RegexViewModel();

			viewModel.Show();
		}
	}
}
