using System.Net.Http;
using System.Threading.Tasks;

namespace Rush.Api.Core.Client.Interfaces
{
    public interface IServiceClient
    {
        Task<T> DeleteAsync<T>(string endpoint);
        Task<T> PostAsync<T>(string endpoint, HttpContent postContent);
        Task<T> PutAsync<T>(string endpoint, HttpContent putContent);
        Task<T> GetAsync<T>(string endpoint);
    }
}
