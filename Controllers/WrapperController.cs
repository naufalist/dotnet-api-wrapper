using ApiWrapper.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Net;
using System.Text.Json;

namespace ApiWrapper.Controllers
{
    [Route("/")]
    [ApiController]
    public class WrapperController : ControllerBase
    {
        [HttpPost]
        public IActionResult Wrapper([FromBody] ApiContract apiContract)
        {
            try
            {
                Method httpMethod;

                switch (apiContract.Method.Trim().ToLower())
                {
                    case "get":
                        httpMethod = Method.Get;
                        break;
                    case "post":
                        httpMethod = Method.Post;
                        break;
                    case "put":
                        httpMethod = Method.Put;
                        break;
                    case "delete":
                        httpMethod = Method.Delete;
                        break;
                    default:
                        throw new Exception("INVALID_METHOD");
                }

                RestClient restClient = new RestClient(baseUrl: apiContract.Url.Base);

                RestRequest restRequest = new RestRequest(resource: apiContract.Url.Endpoint, method: httpMethod);

                if (apiContract.Data.Params.Query.Count > 0)
                {
                    foreach (var queryParam in apiContract.Data.Params.Query)
                    {
                        restRequest.AddQueryParameter(queryParam.Key, queryParam.Value);
                    }
                }

                if (apiContract.Data.Params.Route.Count > 0)
                {
                    foreach (var routeParam in apiContract.Data.Params.Route)
                    {
                        restRequest.AddUrlSegment(routeParam.Key, routeParam.Value);
                    }
                }

                if (apiContract.Data.Headers.Count > 0)
                {
                    foreach (var header in apiContract.Data.Headers)
                    {
                        restRequest.AddHeader(header.Key, header.Value);
                    }
                }

                if (apiContract.Data.Body != null)
                {
                    restRequest.AddJsonBody(apiContract.Data.Body);
                }

                RestResponse restResponse = restClient.Execute(restRequest);

                int httpResponseCode = (int)restResponse.StatusCode;
                JsonElement httpResponseObject = JsonSerializer.Deserialize<JsonElement>(restResponse.Content);

                return StatusCode(httpResponseCode, httpResponseObject);
            }
            catch (Exception exception)
            {
                return StatusCode(500, new ErrorResponse()
                {
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    Message = exception.Message
                });
            }
        }
    }
}
