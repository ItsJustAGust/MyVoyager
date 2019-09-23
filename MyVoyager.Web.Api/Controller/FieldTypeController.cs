using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyVoyager.Domain.Entities;
using MyVoyager.Infra.Data.Repository;
using MyVoyager.Services.ViewModel;

namespace MyVoyager.Web.Api.Controller
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class FieldTypeController : ControllerBase
    {
		private FieldTypeRepository _fieldTypeRepository;

		public FieldTypeController()
		{
			_fieldTypeRepository = new FieldTypeRepository();
		}

		[HttpPost]
		public async Task<IActionResult> Post(FieldTypeViewModel fieldType)
		{
			try
			{
				FieldTypeDomain newFieldType = new FieldTypeDomain()
				{
					Name = fieldType.FieldTypeName

				};

				var fieldTypeReturn = _fieldTypeRepository.Register(newFieldType);


				return Ok(fieldTypeReturn);
			}
			catch (Exception ex)
			{
				return BadRequest(new { success = false, mensagem = ex.Message });
			}
		}
	}
}