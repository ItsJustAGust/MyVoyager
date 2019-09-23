using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyVoyager.Domain.Entities;
using MyVoyager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyVoyager.Infra.Data.Repository
{
	public class FieldTypeRepository : IFieldTypeRepository
	{
		public string Endpoint = @"https://localhost:8081";
		public string Key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
		public string DatabaseId = "VoyagerDB";
		public string CollectionId = "FieldTypes";
		public DocumentClient DocumentClient;

		public FieldTypeRepository()
		{
			this.DocumentClient = new DocumentClient(new Uri(Endpoint), Key);

			DocumentClient.CreateDatabaseIfNotExistsAsync(new Microsoft.Azure.Documents.Database() { Id = DatabaseId }).Wait();
			DocumentClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseId),
																	new Microsoft.Azure.Documents.DocumentCollection() { Id = CollectionId },
																	new RequestOptions() { OfferThroughput = 1000 }).Wait();
		}

		public Task<List<FieldTypeDomain>> List()
		{
			throw new NotImplementedException();
		}

		public async Task<FieldTypeDomain> Register(FieldTypeDomain field)
		{
			try
			{
				using (DocumentClient documentClient = new DocumentClient(new Uri(Endpoint), Key))
				{

					var document1 = await documentClient.CreateDocumentAsync("dbs/VoyagerDB/colls/FieldTypes", field);
					return field;

				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

	}
}
