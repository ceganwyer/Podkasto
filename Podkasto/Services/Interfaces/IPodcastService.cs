using System.Threading.Tasks;

namespace Podkasto.Services.Interfaces
{
    public interface IPodcastService
    {
        Task AddSubscriptionAsync();
    }
}