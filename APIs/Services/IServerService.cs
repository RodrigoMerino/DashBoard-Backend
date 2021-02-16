using APIs.Custom_entities;
using APIs.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIs.Services
{
    public interface IServerService
    {
        Task<List <Server>> GetServers();
        Task<bool> ChangeServerStatus(int id,CustomServer message);
    }
}