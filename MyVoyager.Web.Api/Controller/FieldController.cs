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
	public class FieldController : ControllerBase
	{
		private FieldRepository _fieldRepository;

		public FieldController()
		{
			_fieldRepository = new FieldRepository();
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var lista = await _fieldRepository.List();

			return Ok(lista);
		}

		[HttpPost]
		public async Task<IActionResult> Post(FieldViewModel field)
		{
			try
			{
				FieldDomain newField = new FieldDomain()
				{
					FieldName = field.FieldName,
					FieldType = field.FieldType,
					Required = field.Required,

				};

				var fieldReturn = _fieldRepository.RegisterAsync(newField);

				return Ok(fieldReturn);
			}
			catch (Exception ex)
			{
				return BadRequest(new { success = false, mensagem = ex.Message });
			}
		}
	}
}