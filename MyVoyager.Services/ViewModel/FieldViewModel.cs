using MyVoyager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyVoyager.Services.ViewModel
{
	public class FieldViewModel
	{

		public string FieldName { get; set; }

		public List<FieldTypeDomain> FieldType { get; set; }

		public bool Required { get; set; }
	}
}
