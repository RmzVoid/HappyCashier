using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyCashier.View.Dialogs
{
	interface INumberDialog<T>
	{
		T RequestUserValue();
	}
}
