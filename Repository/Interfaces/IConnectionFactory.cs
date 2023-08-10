using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}
