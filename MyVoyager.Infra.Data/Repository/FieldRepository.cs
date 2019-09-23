
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using MyVoyager.Domain.Entities;
using MyVoyager.Domain.Interfaces;

namespace MyVoyager.Infra.Data.Repository
{
	public class FieldRepository : IFieldRepository
	{
		public string Endpoint = @"https://localhost:8081";
		public string Key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
		public string DatabaseId = "VoyagerDB";
		public string CollectionId = "Fields";
		public DocumentClient DocumentClient;

		public FieldRepository()
		{
			this.DocumentClient = new DocumentClient(new Uri(Endpoint), Key);

			DocumentClient.CreateDatabaseIfNotExistsAsync(new Microsoft.Azure.Documents.Database() { Id = DatabaseId }).Wait();
			DocumentClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseId),
																	new Microsoft.Azure.Documents.DocumentCollection() { Id = CollectionId },
																	new RequestOptions() { OfferThroughput = 1000 }).Wait();
		}

		public async Task<FieldDomain> Register(FieldDomain field)
		{
			try
			{
				using (DocumentClient documentClient = new DocumentClient(new Uri(Endpoint), Key))
				{

					var document1 = await documentClient.CreateDocumentAsync("dbs/VoyagerDB/colls/Fields", field);
					return field;
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}


		public async Task<List<FieldDomain>> List()
		{
			try
			{

				var documents = this.DocumentClient.CreateDocumentQuery<FieldDomain>
							(UriFactory.CreateDocumentCollectionUri(
							 DatabaseId, CollectionId),
							 new FeedOptions { MaxItemCount = -1 })
							.AsDocumentQuery();

				List<FieldDomain> result = new List<FieldDomain>();

				while (documents.HasMoreResults)
					result.AddRange(await documents.ExecuteNextAsync<FieldDomain>());

				return result;

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
