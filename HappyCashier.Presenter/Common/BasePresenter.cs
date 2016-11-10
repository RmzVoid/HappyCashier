namespace HappyCashier.Presenter.Common
{
	public abstract class BasePresenter<TView> : IPresenter
		where TView : IView
	{
		protected BasePresenter(IApplicationController controller, TView view)
		{
			_view = view;
			_controller = controller;
		}

		#region IPresenter implementation

		public virtual void Run()
		{
			_view.ShowMe();
		}

		#endregion

		#region Private fields

		protected TView _view;
		protected IApplicationController _controller;

		#endregion
	}

	// accepts one argument in Run function
	public abstract class BasePresenter<TView, TArgument> : IPresenter<TArgument>
		where TView : IView
	{
		protected BasePresenter(IApplicationController controller, TView view)
		{
			_view = view;
			_controller = controller;
		}

		#region IPresenter declarations

		public abstract void Run(TArgument argument);

		#endregion

		#region Private fields

		protected TView _view;
		protected IApplicationController _controller;

		#endregion
	}
}
