using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace eTickets.Models
{
    /// <summary>
    /// abstract class BaseModel for Data models
    /// </summary>
    /// <typeparam name="TEntity">Data Model class</typeparam>
    public class BaseModel<TEntity>
    {
        private readonly string? baseController;
        private readonly IHttpClientFactory httpClientFactory;

        //ToDo: Change Web API path here
        private const string BASE_PATH = @"https://localhost:7053/api/";

        /// <summary>
        /// Constructor requires a Depenance Injection 
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public BaseModel(IHttpClientFactory httpClientFactory)
        {
            // Assumes the API web Controller is Named like the Data Model
            this.baseController = typeof(TEntity).Name.Replace("Model", "");
            this.httpClientFactory = httpClientFactory;
        }


        /// <summary>
        /// Gets one and only one TEntity based on Key int Id
        /// </summary>
        /// <param name="id">Key int Id</param>
        /// <returns>TEntity</returns>
        public async Task<TEntity> GetByIdAsync(int id)
        {
            //https://localhost:7053/api/Band/5
            //Builds the endpoint path
            string server = Path.Combine(BASE_PATH, baseController, id.ToString());

            //gets the httpClient from the Factory
            var httpClient = httpClientFactory.CreateClient(baseController);

            //Set the endpoint in the client
            httpClient.BaseAddress = new Uri(server);
            TEntity? entity = default(TEntity);
            try
            {
                //Makes the Call to the Web Api
                var httpResponseMessage = await httpClient.GetAsync(server);

                // Checks the Response
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    // Gets the Json String from the Response
                    var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();

                    // converts the Json to the TEntity
                    entity = JsonConvert.DeserializeObject<TEntity>(jsonString);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

        /// <summary>
        /// Gets all of the TEntities for the given table
        /// </summary>
        /// <returns>a list of TEntity</returns>
        public async Task<List<TEntity>> GetAllAsync()
        {
            // Use the get method with out any parameters
            return await GetMethodListAsync(string.Empty);
        }

        /// <summary>
        /// Gets a paged list with a sort column 
        /// </summary>
        /// <param name="pageIndex">The page number to get, starts with 1</param>
        /// <param name="pageSize">the size of the page</param>
        /// <param name="orderByColumn">Order of the list</param>
        /// <returns>a list of TEntity</returns>
        public async Task<List<TEntity>> GetAllPageAsync(int pageIndex, int pageSize, string orderByColumn = "Id")
        {
            ///Builds the Param string
            string param = $"GetPage?pageIndex={pageIndex}&pageSize={pageSize}&orderByColumn={orderByColumn}";
            //https://localhost:7053/api/Band/GetPage?pageIndex=1&pageSize=20&orderByColumn=FullName

            //calls the get method
            return await GetMethodListAsync(param);
        }

        /// <summary>
        /// Get a list based on page and search string
        /// </summary>
        /// <param name="pageIndex">The page number to get, starts with 1</param>
        /// <param name="pageSize">the size of the page</param>
        /// <param name="orderByColumn">Order of the list</param>
        /// <param name="keyColumn">Search Key column</param>
        /// <param name="searchText">Search Text</param>
        /// <returns>a list of TEntity</returns>
        public async Task<List<TEntity>> GetSearchEntityAsync(int pageIndex, int pageSize, string orderByColumn, string keyColumn, string searchText)
        {
            //https://localhost:7053/api/Band/GetSearchPage?pageIndex=1&pageSize=20&orderByColumn=FullName&keyColumn=FullName&searchText=Ladies
            string param = $"GetSearchPage?pageIndex={pageIndex}&pageSize={pageSize}&orderByColumn={orderByColumn}&keyColumn={keyColumn}&searchText={searchText}";
            return await GetMethodListAsync(param);
        }


        private async Task<List<TEntity>> GetMethodListAsync(string param)
        {
            string server = Path.Combine(BASE_PATH, baseController, param);
            var httpClient = httpClientFactory.CreateClient(baseController);
            httpClient.BaseAddress = new Uri(server);
            List<TEntity> list = new();
            try
            {
                var httpResponseMessage = await httpClient.GetAsync(server);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<TEntity>>(jsonString);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            string server = Path.Combine(BASE_PATH, baseController);
            var httpClient = httpClientFactory.CreateClient(baseController);
            httpClient.BaseAddress = new Uri(server);

            try
            {
                var httpResponseMessage = await httpClient.PostAsJsonAsync(server, entity);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                    entity = JsonConvert.DeserializeObject<TEntity>(jsonString);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return entity;
        }


        public async Task<bool> DeleteByIdAsync(int id)
        {
            string server = Path.Combine(BASE_PATH, baseController, $"{id}");
            var httpClient = httpClientFactory.CreateClient(baseController);
            httpClient.BaseAddress = new Uri(server);
            bool retValue = false;
            try
            {
                var httpResponseMessage = await httpClient.DeleteAsync(server);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    retValue = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return retValue;
        }


        public async Task<TEntity> UpdateAsync(int id, TEntity entity)
        {
            string server = Path.Combine(BASE_PATH, baseController, $"{id}");
            var httpClient = httpClientFactory.CreateClient(baseController);
            httpClient.BaseAddress = new Uri(server);
            try
            {
                var tooDo = new StringContent(
                    entity.ToString(),
                    Encoding.UTF8,
                    Application.Json);

                var httpResponseMessage = await httpClient.PutAsync(server,tooDo);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    //retValue = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }
    }
}
