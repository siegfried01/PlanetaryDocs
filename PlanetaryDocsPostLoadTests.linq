<Query Kind="Program">
  <Reference Relative="..\..\Source\Repos\EF\PlanetaryDocsSiegFork\PlanetaryDocs\bin\Debug\net6.0\PlanetaryDocs.DataAccess.dll">c:\Users\shein\Source\Repos\EF\PlanetaryDocsSiegFork\PlanetaryDocs\bin\Debug\net6.0\PlanetaryDocs.DataAccess.dll</Reference>
  <Reference Relative="..\..\Source\Repos\EF\PlanetaryDocsSiegFork\PlanetaryDocs\bin\Debug\net6.0\PlanetaryDocs.dll">c:\Users\shein\Source\Repos\EF\PlanetaryDocsSiegFork\PlanetaryDocs\bin\Debug\net6.0\PlanetaryDocs.dll</Reference>
  <Reference Relative="..\..\Source\Repos\EF\PlanetaryDocsSiegFork\PlanetaryDocs\bin\Debug\net6.0\PlanetaryDocs.Domain.dll">c:\Users\shein\Source\Repos\EF\PlanetaryDocsSiegFork\PlanetaryDocs\bin\Debug\net6.0\PlanetaryDocs.Domain.dll</Reference>
  <Reference Relative="..\..\Source\Repos\EF\PlanetaryDocsSiegFork\PlanetaryDocsLoader\bin\Debug\net6.0\PlanetaryDocsLoader.dll">c:\Users\shein\Source\Repos\EF\PlanetaryDocsSiegFork\PlanetaryDocsLoader\bin\Debug\net6.0\PlanetaryDocsLoader.dll</Reference>
  <Namespace>Microsoft.EntityFrameworkCore</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>PlanetaryDocs.DataAccess</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>PlanetaryDocs.Domain</Namespace>
</Query>

async void Main()
{
	var sc = new ServiceCollection();
	var endPoint = new System.Text.RegularExpressions.Regex("\\\\").Replace(Environment.GetEnvironmentVariable("COSMOS_ENDPOINT"), "/");
	var accessKey = Environment.GetEnvironmentVariable("COSMOS_ACCOUNTKEY");
	sc.AddDbContextFactory<DocsContext>(
		options => options.UseCosmos(
			endPoint, accessKey, nameof(DocsContext)));
	sc.AddSingleton<IDocumentService, DocumentService>();
	var sp = sc.BuildServiceProvider().CreateScope().ServiceProvider;
	var factory = sp.GetRequiredService<IDbContextFactory<DocsContext>>();
	var service = sp.GetRequiredService<IDocumentService>();

	using (var context = factory.CreateDbContext())
	{
		//var docsList = await context.Documents.ToListAsync();docsList.Dump();
		//var tags = await context.Tags.ToListAsync(); tags.Dump();
		//(await context.Authors.ToListAsync()).Dump();
		//(await context.Audits.ToListAsync()).Dump();
	}
}
