using System.Net;
using System.Net.Http;
using System.Collections.Generic;

public class QueryDefinition
{
    public string Id { get; set; }
    public string Format { get; set; }
}

public static async Task<HttpResponseMessage> Run(HttpRequestMessage request, TraceWriter log)
{
    var q0 = new QueryDefinition
    {
        Id = "q0",
        Format = "\"*processor*\" \"message complete; message id = *; correlation id = *\" earliest={1} latest={2}"
    };

    var list = new List<QueryDefinition>
    {
        q0
    };

    return request.CreateResponse(HttpStatusCode.OK, list);
}