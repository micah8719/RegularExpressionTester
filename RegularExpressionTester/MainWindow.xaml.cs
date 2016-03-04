using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using RegularExpressionTester.Extensibility;

namespace RegularExpressionTester
{
	public partial class MainWindow : Window, IView
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Process.Start("http://regexlib.com/CheatSheet.aspx");
		}

		private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
		{
			if (Cursor != Cursors.Wait)
			{
				Mouse.OverrideCursor = Cursors.Hand;
			}
		}

		private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
		{
			if (Cursor != Cursors.Wait)
			{
				Mouse.OverrideCursor = Cursors.Arrow;
			}
		}
	}
}
