using Domain;
using Microsoft.Extensions.Caching.Memory;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class WMS_USER_Service : IWMS_USER_Service
    {
        private readonly IMemoryCache memoryCache;
        private readonly IWMS_USER_Repository repository;

        public WMS_USER_Service(IWMS_USER_Repository repository, IMemoryCache memoryCache)
        {
            this.repository = repository;
            this.memoryCache = memoryCache;
        }

        public async Task<IEnumerable<WMS_USER>> GetUsuarios()
        {
            return await repository.GetUsuarios();
        }

        public async Task<WMS_USER> GetUsuario(WMS_USER usuario)
        {
            return await repository.GetUsuario(usuario);
        }
    }
}
