using System.Net;
using System.Net.Http;
using System.Collections.Generic;

public class QueryDefinition
{
    public string Format { get; set; }
    public string Display { get; set; }
}

public static async Task<HttpResponseMessage> Run(HttpRequestMessage request, TraceWriter log)
{
    var list = new List<QueryDefinition>
    {
        new QueryDefinition
        {
            Format = "index=&quot;{0}&quot; source=&quot;*processor*&quot; &quot;message complete; message id=*; correlation id=*&quot; earliest={1} latest={2}",
            Display = "queue message processed"
        }
    };

    return request.CreateResponse(HttpStatusCode.OK, list);
}