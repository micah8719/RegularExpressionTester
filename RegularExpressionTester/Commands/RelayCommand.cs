using System;
using System.Windows.Input;

namespace RegularExpressionTester.Commands
{
	public class RelayCommand<T> : ICommand
	{
		private readonly Func<T, bool> _canExecute;
		private readonly Action<T> _execute;

		public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
		{
			_canExecute = canExecute;
			_execute = execute;
		}

		public RelayCommand(Action<T> execute) : this(execute, _ => true)
		{
		}

		public bool CanExecute(T parameter)
		{
			return _canExecute(parameter);
		}

		public void Execute(T parameter)
		{
			_execute(parameter);
			OnCanExecuteChanged();
		}

		bool ICommand.CanExecute(object parameter)
		{
			return CanExecute((T) parameter);
		}

		void ICommand.Execute(object parameter)
		{
			Execute((T) parameter);
		}

		event EventHandler ICommand.CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
				CommandManager.RequerySuggested += CanExecuteChanged;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
				CommandManager.RequerySuggested -= CanExecuteChanged;
			}
		}

		public event EventHandler CanExecuteChanged;

		protected virtual void OnCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
	}

	public sealed class RelayCommand : RelayCommand<object>
	{
		public RelayCommand(Action execute, Func<bool> canExecute) : base(_ => execute(), _ => canExecute())
		{
		}

		public RelayCommand(Action execute) : this(execute, () => true)
		{
		}
	}
}