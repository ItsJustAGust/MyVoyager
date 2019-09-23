using MyVoyager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVoyager.Domain.Interfaces
{
	public interface IFieldRepository
	{
		Task<FieldDomain> RegisterAsync(FieldDomain field);

		Task<List<FieldDomain>> List();
	}
}
