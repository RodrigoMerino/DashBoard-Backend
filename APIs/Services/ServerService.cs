using APIs.Custom_entities;
using APIs.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs.Services
{
    public class ServerService : IServerService
    {
        private readonly DashBoardContext _Context;

        public ServerService( DashBoardContext context)
        {
            _Context = context;
        }

        public async Task<bool> ChangeServerStatus(int id,CustomServer message)
        {
           var servers = await _Context.Server.FindAsync(id);
            var server =await _Context.Server.FindAsync(message.id);
            // comment tratar de que el id de url y body mach
            if (servers == server)
            {
           
                if (message.PayLoad == "activated")
                {
                    server.IsOnline = true;
                    await _Context.SaveChangesAsync();

                }
                if (message.PayLoad == "deactivated")
                {
                    server.IsOnline = false;
                    await _Context.SaveChangesAsync();

                }
             

       }
          else
            {
                throw new Exception("are different");
           }

            return true;
        }

        public async Task<List<Server>> GetServers()
        {
            var servers = await _Context.Server.ToListAsync();
            return servers;

        }
    }
}
