using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IWMS_USER_Service
    {
        Task<IEnumerable<WMS_USER>> GetUsuarios();
        Task<WMS_USER> GetUsuario(WMS_USER usuario);
    }
}
