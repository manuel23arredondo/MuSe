namespace MuSe.Common
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class ApiService
    {
        public async Task<Response> GetListAsync<T>(
           string urlBase,
           string servicePrefix,
           string controller)
        {
            try
            {
                // Crear una instancia HTTPClient para comunicarse, se crea un objeto y 
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                // Se realiza una interpolación de cadenas
                var url = $"{servicePrefix}{controller}";
                // Del cliente que se creó se genera una respuesta, obtenemos una respuesta de manera asincrona y le pasa el url
                var response = await client.GetAsync(url);
                // Leer la respuesta en forma de cadena y lo regresa a la variable
                var result = await response.Content.ReadAsStringAsync();

                // Si la respuesta tuvo problemas se lleva a cabo: 
                if (!response.IsSuccessStatusCode)
                {
                    // Se genera una respuesta que dice que no fue satisfactoria la respuesta y manda un mensaje con el resultado
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                // Deserializa el objeto y lo convierte en una lista genérica
                var list = JsonConvert.DeserializeObject<List<T>>(result);
                // Creo una respuesta, le digo que fue exitosa y regresa la lista de objetos
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        // La diferencia con el anterior es que en este sobrecarga otros métodos.

        public async Task<Response> GetListAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };

                //
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

                var url = $"{servicePrefix}{controller}";
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> GetTokenAsync(
            string urlBase,
            string servicePrefix, 
            string controller, 
            TokenRequest request)
        {
            try
            {
                // Regresa un request y lo serializa por medio de un objeto JSON
                var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                // 
                var token = JsonConvert.DeserializeObject<TokenResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = token
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        // El Response es porque regresa el objeto que ya fue creado, para saber qué es lo que se está enviandon y qué es lo que estamos recibiendo
        //generico model
        public async Task<Response> PostAsync<T>(
            string urlBase, 
            string servicePrefix, 
            string controller, 
            T model, 
            string tokenType, 
            string accessToken)
        {
            try
            {//serializar el body
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                //consumirlo de forma segura
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                var url = $"{servicePrefix}{controller}";
                //realiza el post
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var obj = JsonConvert.DeserializeObject<T>(answer);
                return new Response
                {
                    IsSuccess = true,
                    Result = obj,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> PutAsync<T>(
            string urlBase, 
            string servicePrefix, 
            string controller, 
            int id, 
            T model, 
            string tokenType, 
            string accessToken)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                var url = $"{servicePrefix}{controller}/{id}";
                var response = await client.PutAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var obj = JsonConvert.DeserializeObject<T>(answer);
                return new Response
                {
                    IsSuccess = true,
                    Result = obj,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> DeleteAsync(
            string urlBase, 
            string servicePrefix, 
            string controller, 
            int id, 
            string tokenType, 
            string accessToken)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                var url = $"{servicePrefix}{controller}/{id}";
                var response = await client.DeleteAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                return new Response
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }

        }
    }
}