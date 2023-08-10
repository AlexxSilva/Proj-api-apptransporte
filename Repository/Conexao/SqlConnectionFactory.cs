using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Conexao
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        IConfiguration _configuration;
        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection Connection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").
                GetSection("DefaultConnection").Value;
            return new SqlConnection(connection);
        }
    }
}
