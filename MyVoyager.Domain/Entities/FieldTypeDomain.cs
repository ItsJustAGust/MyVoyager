using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyVoyager.Domain.Entities
{
	public class FieldTypeDomain
	{

		[JsonProperty(PropertyName = "id")]
		public Guid Id { get; set; }

		[JsonProperty(PropertyName = "fieldTypeName")]
		public string Name { get; set; }

	}
}
