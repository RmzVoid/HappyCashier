using System;
using System.Collections.Generic;
using System.Linq;

using HappyCashier.Domain.DatabaseLayer;
using HappyCashier.Domain.DataTransferObjects;
using HappyCashier.Domain.Entities;

using GoodsObject = HappyCashier.Domain.DataTransferObjects.Goods;
using GoodsModel = HappyCashier.Domain.Entities.Goods;

namespace HappyCashier.Domain.DataSources
{
	public class DatabaseSaleDataSource : ISaleDataSource
	{
		public DatabaseSaleDataSource(DatabaseContext context)
		{
			_context = context;
		}

		public int OpenSale(int accountId)
		{
			Account account = _context.Account.Find(accountId);

			if (account == null)
				throw new NullReferenceException("account is null");
			
			Sale sale = new Sale()
				{
					Account = account,
					SaleItems = new List<SaleItem>()
				};

			_context.Sale.Add(sale);
			_context.SaveChanges();

			return sale.Id;
		}

		public void CloseSale(Document saleToClose)
		{
			Sale sale = _context.Sale.Find(saleToClose.Id);

			if (sale == null)
				throw new NullReferenceException("sale is null");

			sale.DateTimeOpen = saleToClose.DateTimeOpen;
			sale.DateTimeClose = saleToClose.DateTimeClose;

			foreach (var item in saleToClose.Positions)
			{
				GoodsModel goods = _context.Goods.Find(item.Id);

				sale.SaleItems.Add(new SaleItem()
				{
					Goods = goods,
					Price = item.Price,
					Quantity = item.Quantity
				});

				goods.Quantity -= item.Quantity;
			}

			_context.SaveChanges();
		}

		public GoodsObject GetGood(string name)
		{
			GoodsModel good = _context.Goods.Where(g => g.Name == name).FirstOrDefault();

			if(good == null)
				return null;

			return new GoodsObject() { Id = good.Id, Name = good.Name, Price = good.Price };
		}

		private DatabaseContext _context;
	}
}
