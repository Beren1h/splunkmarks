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
        },
        new QueryDefinition
        {
            Format = "index=&quot;{0}&quot; source=&quot;*internal*&quot; &quot;*ecs/prequal/submit*&quot; earliest={1} latest={2}",
            Display = "ECS submit"
        },
        new QueryDefinition
        {
            Format = "index=&quot;{0}&quot; source=&quot;*processor*&quot; &quot;*ECS submit failed*&quot; earliest={1} latest={2}",
            Display = "ECS failure"
        },
        new QueryDefinition
        {
            Format = "index=&quot;{0}&quot; source=&quot;*LeadService*&quot; &quot;LeadType=EasyShop Finance&quot; earliest={1} latest={2}",
            Display = "lead submit"
        }, 
        new QueryDefinition
        {
            Format = "index=&quot;{0}&quot; source=&quot;*internal*&quot; &quot;api/ecs/decision/ready; lead sent; application id=*&quot; earliest={1} latest={2}",
            Display = "decision ready (lead sent)"
        },
        new QueryDefinition
        {
            Format = "index=&quot;{0}&quot; source=&quot;*processor*&quot; &quot;message complete; message id=*; correlation id=*&quot; delivery count > 1 earliest={1} latest={2}",
            Display = "queue message processed >1 delivery attempt"
        },
        new QueryDefinition
        {
            Format = "index=&quot;{0}&quot; source=&quot;*internal*&quot; &quot;api/ecs/decision/ready; lead sent; application id=*&quot; earliest={1} latest={2} stats count by store",
            Display = "Kyle's Report"
        }
    };

    return request.CreateResponse(HttpStatusCode.OK, list);
}