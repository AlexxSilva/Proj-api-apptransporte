using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IWMS_USER_Repository
    {
        Task<IEnumerable<WMS_USER>> GetUsuarios();
        public  Task<WMS_USER> GetUsuario(WMS_USER usuario);
    }
}
