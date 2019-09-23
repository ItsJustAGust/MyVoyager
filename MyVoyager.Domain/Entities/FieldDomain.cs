using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyVoyager.Domain.Entities
{
	public class FieldDomain
	{
		[JsonProperty(PropertyName = "id")]
		public Guid Id { get; set; }

		[JsonProperty(PropertyName = "fieldName")]
		public string FieldName { get; set; }

		[JsonProperty(PropertyName = "required")]
		public bool Required { get; set; }

		[JsonProperty(PropertyName = "fieldType")]
		public List<FieldTypeDomain> FieldType { get; set; }

	}
}

