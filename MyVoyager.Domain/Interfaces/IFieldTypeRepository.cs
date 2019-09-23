using MyVoyager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVoyager.Domain.Interfaces
{
	public interface IFieldTypeRepository
	{
		Task<FieldTypeDomain> Register(FieldTypeDomain field);

		Task<List<FieldTypeDomain>> List();
	}
}
