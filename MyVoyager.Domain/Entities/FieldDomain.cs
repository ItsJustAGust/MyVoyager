using System;
using Nest;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVoyager.Domain.Entities
{
	public class FieldDomain
	{
		public FieldDomain()
		{
			if (string.IsNullOrEmpty(this.Id))
				this.Id = Guid.NewGuid().ToString();

			//if (this.CreatedDate == DateTime.MinValue)
			//	this.CreatedDate = DateTime.Now;
		}

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "fieldName")]
		public string FieldName { get; set; }

		[JsonProperty(PropertyName = "required")]
		public bool Required { get; set; }

		[JsonProperty(PropertyName = "fieldType")]
		public List<FieldTypeDomain> FieldType { get; set; }

	}
}

