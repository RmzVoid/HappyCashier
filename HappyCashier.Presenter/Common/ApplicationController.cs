using Microsoft.Practices.Unity;

namespace HappyCashier.Presenter.Common
{
	public class ApplicationController : IApplicationController
	{
		public ApplicationController()
		{
			_container = new UnityContainer();
			_container.RegisterInstance<IApplicationController>(this);
		}

		public IApplicationController RegisterType<TType, TImplementation>()
			where TImplementation : class, TType
		{
			_container.RegisterType<TType, TImplementation>();
			return this;
		}

		public IApplicationController RegisterType<TType>()
		{
			_container.RegisterType<TType>();
			return this;
		}

		public IApplicationController RegisterInstance<TInstance>(TInstance instance)
		{
			_container.RegisterInstance<TInstance>(instance);
			return this;
		}

		public void Run<TPresenter>()
			where TPresenter : class, IPresenter
		{
			if (!_container.IsRegistered<TPresenter>())
				_container.RegisterType<TPresenter>();

			_container.Resolve<TPresenter>().Run();
		}

		public void Run<TPresenter, TArgument>(TArgument argument)
			where TPresenter : class, IPresenter<TArgument>
		{
			if (!_container.IsRegistered<TPresenter>())
				_container.RegisterType<TPresenter>();

			_container.Resolve<TPresenter>().Run(argument);
		}

		private IUnityContainer _container;
	}
}
