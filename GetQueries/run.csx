using System.Net;
using System.Net.Http;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage request, TraceWriter log)
{
    return request.CreateResponse(HttpStatusCode.OK);
}