using System.ComponentModel;
using System.Runtime.CompilerServices;
using RegularExpressionTester.Annotations;

namespace RegularExpressionTester.Extensibility
{
	public abstract class ViewModelBase<TView> : INotifyPropertyChanged
		where TView : IView
	{
		protected readonly TView View;

		protected ViewModelBase(TView view)
		{
			View = view;
			View.DataContext = this;
		}

		public void Show()
		{
			View.Show();
		}

		protected bool SetProperty<TProperty>(ref TProperty storage, TProperty value,
			[CallerMemberName] string propertyName = null)
		{
			if (Equals(storage, value))
			{
				return false;
			}

			storage = value;
			OnPropertyChanged(propertyName);

			return true;
		}


		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}