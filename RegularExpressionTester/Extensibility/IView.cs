namespace RegularExpressionTester.Extensibility
{
	public interface IView
	{
		object DataContext { get; set; }
		void Show();
	}
}