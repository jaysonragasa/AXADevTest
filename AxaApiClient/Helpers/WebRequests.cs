using AXADevTest.APIClient;
using AXADevTest.APIClient.DTOModels;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AXADevTest.Helpers
{
    public class ClientWebRequests<T> where T : BaseResponse, new()
    {
        const int MAX_RETRY = 3;

        public async Task<T> PostAsync(string url, object payload, string token = null)
        {
            return await SubmitAsync(HttpMethod.Post, url, payload, token);
        }

        private async Task<T> SubmitAsync(HttpMethod method, string url, object payload, string token = null)
        {
            var result = new T();

            using (var client = new HttpClient())
            {
                using (var resp = await (new Func<Task<HttpResponseMessage>>(async () =>
                {
                    if (!string.IsNullOrEmpty(token))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    if (!string.IsNullOrEmpty(APIClientConfiguration.AxaApiKey))
                        client.DefaultRequestHeaders.Add("x-axa-api-key", APIClientConfiguration.AxaApiKey);

                    HttpResponseMessage respMsg = null;

                    for (int retry = 0; retry < MAX_RETRY; retry++)
                    {
                        try
                        {
                            using (var content = new JsonContent(payload))
                            {
                                if (method == HttpMethod.Post)
                                {
                                    respMsg = await client.PostAsync(url, content);
                                }
                                else if (method == HttpMethod.Put)
                                {
                                    respMsg = await client.PutAsync(url, content);
                                }
                                else if (method == HttpMethod.Delete)
                                {
                                    respMsg = await client.DeleteAsync(url);
                                }
                            }

                            if (respMsg != null) break;
                        }
                        catch (HttpRequestException ex)
                        {
                            if (ex.Message.Contains("connection attempt failed"))
                            {
                                respMsg = await Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.BadGateway)
                                {
                                    Content = new StringContent(ex.Message)
                                });
                            }
                            else
                            {
                                respMsg = await Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable)
                                {
                                    Content = new StringContent(ex.Message)
                                });
                            }
                        }
                        catch(Exception ex)
                        {
                            Debug.WriteLine("ERROR: " + ex.Message);
                        }

                        Debug.WriteLine($"#{retry} Retrying conection.");
                    }

                    return respMsg;
                })).Invoke())
                {
                    if (resp != null)
                    {
                        var content = await resp.Content.ReadAsStringAsync();
                        content = content.TrimStart().TrimEnd();

                        if (content.StartsWith("{") && content.EndsWith("}"))
                        {
                            var dsresp = JsonConvert.DeserializeObject<T>(content);

                            if (!resp.IsSuccessStatusCode)
                            {
                                result.Result = resp.StatusCode;
                                result.Payload = content;
                                result.Message = dsresp.Message;
                                // log here why
                                Debug.WriteLine($"return bad result status={resp.StatusCode}");
                            }
                            else
                            {
                                result.Result = resp.StatusCode;
                                result.Payload = content;
                                result.Message = dsresp.Message;
                            }
                        }
                        else
                        {
                            // not JSON.
                            result = new T
                            {
                                Result = resp.StatusCode,
                                Message = content
                            };
                        }
                    }
                    else
                    {
                        result = new T
                        {
                            Result = System.Net.HttpStatusCode.InternalServerError,
                            Message = "Unknown Error"
                        };
                    }
                };
            }

            return result;
        }

        public class JsonContent : StringContent
        {
            public JsonContent(object model) : base(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
            {

            }
        }
    }
}
