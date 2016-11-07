using System;
using System.Collections.Generic;
using System.Linq;

using HappyCashier.Domain.DatabaseLayer;
using HappyCashier.Domain.DataTransferObjects;
using HappyCashier.Domain.Entities;

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
					DateTime = DateTime.Now,
					SaleItems = new List<SaleItem>()
				};

			_context.Sale.Add(sale);
			_context.SaveChanges();

			return sale.Id;
		}

		public void CloseSale(SaleDto saleToClose)
		{
			Sale sale = _context.Sale.Find(saleToClose.Id);

			if (sale == null)
				throw new NullReferenceException("sale is null");

			sale.DateTime = DateTime.Now;

			foreach (var item in saleToClose.Items)
				sale.SaleItems.Add(new SaleItem()
				{
					Sale = sale,
					Good = new Good() { Id = item.Id},
					Price = item.Price,
					Amount = item.Amount
				});

			_context.SaveChanges();
		}

		public GoodDto GetGood(string name)
		{
			Good good = _context.Good.Where(g => g.Name == name).FirstOrDefault();

			if(good == null)
				return null;

			return new GoodDto() { Id = good.Id, Name = good.Name, Price = good.Price };
		}

		private DatabaseContext _context;
	}
}
