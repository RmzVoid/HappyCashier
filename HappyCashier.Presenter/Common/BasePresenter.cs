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

		public void Run()
		{
			_view.ShowMe();
		}

		protected TView _view;
		protected IApplicationController _controller;
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

		public abstract void Run(TArgument argument);

		protected TView _view;
		protected IApplicationController _controller;
	}
}
