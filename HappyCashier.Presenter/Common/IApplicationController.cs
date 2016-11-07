namespace HappyCashier.Presenter.Common
{
	public interface IApplicationController
	{
		IApplicationController RegisterType<TType, TImplementation>()
			where TImplementation : class, TType;

		IApplicationController RegisterType<TType>();

		IApplicationController RegisterInstance<TInstance>(TInstance instance);

		void Run<TPresenter>()
			where TPresenter : class, IPresenter;

		void Run<TPresenter, TArgument>(TArgument argument)
			where TPresenter : class, IPresenter<TArgument>;
	}
}
