using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using ApiPelisAWSAnita.Repositories;
using ApiPelisAWSAnita.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ApiPelisAWSAnita;

public class Functions
{
    private RepositoryPelis repo;

    public Functions(RepositoryPelis repo)
    {
        this.repo = repo;
    }
    
    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/")]
    public async Task<IHttpResult> Get(ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'GetPelis' Request");

        List<Peli> peliculas = await this.repo.GetPelisAsync();

        return HttpResults.Ok(peliculas);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/find/{actor}")]
    public async Task<IHttpResult> FindActor
        (string actor, ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'FindActor' Request");
        List<Peli> pelisActor = await
            this.repo.GetPelisActorAsync(actor);
        return HttpResults.Ok(pelisActor);
    }
}
