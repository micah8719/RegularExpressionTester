using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using RegularExpressionTester.Commands;
using RegularExpressionTester.Extensibility;

namespace RegularExpressionTester.ViewModels
{
	public sealed class RegexViewModel : ViewModelBase<MainWindow>
	{
		private string _expression;
		private string _result;
		private string _testCase;

		private ICommand _submitExpressionCommand;

		public RegexViewModel() : base(new MainWindow())
		{
		}

		public string Expression
		{
			get { return _expression; }
			set { SetProperty(ref _expression, value); }
		}

		public string TestCase
		{
			get { return _testCase; }
			set { SetProperty(ref _testCase, value); }
		}

		public string Result
		{
			get { return _result; }
			set { SetProperty(ref _result, value); }
		}

		public ICommand SubmitExpressionCommand
			=> _submitExpressionCommand
			?? (_submitExpressionCommand = new RelayCommand(SubmitExpression, () => Expression != null && TestCase != null));

		private void SubmitExpression()
		{
			Result = string.Empty;

			var regex = new Regex(Expression);
			var matches = regex.Matches(TestCase);

			if (matches.Count == 0)
			{
				Result = "No matches";
				return;
			}

			foreach (Match match in matches)
			{
				var groupIndex = 0;

				foreach (Group group in match.Groups)
				{
					Result += $"Group [{regex.GroupNameFromNumber(groupIndex)}]: {group.Value}{Environment.NewLine}";
					groupIndex++;
				}

				Result += Environment.NewLine;
			}
		}
	}
}