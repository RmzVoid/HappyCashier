using System;
using System.Collections.Generic;

using NSubstitute;
using NUnit.Framework;

using HappyCashier.Domain.Models;
using HappyCashier.Presenter.Common;
using HappyCashier.Presenter.Views;
using HappyCashier.Domain.DataTransferObjects;
using HappyCashier.Presenter.Presenters;
using HappyCashier.Presenter.DataTransferObjects;

using GoodsModel = HappyCashier.Domain.DataTransferObjects.Goods;
using GoodsObject = HappyCashier.Presenter.DataTransferObjects.Goods;

namespace HappyCashier.Test
{
	[TestFixture]
	public class SalePresenterTests
	{
		[SetUp]
		public void SetUp()
		{
			_view = Substitute.For<ISaleView>();
			_model = Substitute.For<ISaleModel>();
			_controller = Substitute.For<IApplicationController>();

			_model.OpenSale(Arg.Any<int>())
				.Returns(x => 3);

			_model.GetGood(Arg.Any<string>())
				.ReturnsForAnyArgs(x => new GoodsModel() { Id = 1, Name = x.Arg<string>(), Price = 100 });

			var presenter = new SalePresenter(_controller, _view, _model);
			presenter.Run(new Account() { Id = 1, Name = "Витя" });
		}

		[Test]
		public void SalePresenter_OpenSale()
		{
			_view.Account.Returns(new Account() { Id = 1, Name = "Витя" });
			_view.OpenSaleRequested += Raise.Event<Action>();
			Assert.AreEqual(_view.Document.Id, 3);
			CollectionAssert.IsEmpty(_view.Document.Positions);
			Assert.AreEqual(_view.Document.Total, 0);
			Assert.IsNull(_view.Document.CloseTime);
		}

		[Test]
		public void AccountPresenter_CloseSale()
		{
			//_view.CloseSaleRequested += Raise.Event<Action>();
		}

		private ISaleView _view;
		private ISaleModel _model;
		private IApplicationController _controller;
	}
}
