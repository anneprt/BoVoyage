using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Core.BusinessExceptions
{
	public class BusinessExceptions :Exception
	{
		public BusinessException(string message)
		   : base(message)
		{ }
	}
}
