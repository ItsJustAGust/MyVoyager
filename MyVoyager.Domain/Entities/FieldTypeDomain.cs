using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVoyager.Domain.Entities
{
	public class FieldTypeDomain
	{
		public FieldTypeDomain()
		{
			if (string.IsNullOrEmpty(this.Id))
				this.Id = Guid.NewGuid().ToString();

			//if (this.CreatedDate == DateTime.MinValue)
			//	this.CreatedDate = DateTime.Now;
		}
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "fieldTypeName")]
		public string Name { get; set; }

	}
}
