using Dapper;
using Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorios
{
    public class WMS_USER_Repository : IWMS_USER_Repository
    {
        private readonly IConnectionFactory connection;

        public WMS_USER_Repository(IConnectionFactory connection)
        {
            this.connection = connection;
        }

        public async Task<WMS_USER> GetUsuario(WMS_USER usuario)
        {
            string sql = "select DESCRICAO_USER, SENHA  from [WMS_USER] where  " +
            " Upper([DESCRICAO_USER]) = Upper(@Name) AND [SENHA]= @Password";

            using (var connectionDb = connection.Connection())
            {
                connectionDb.Open();

                var result = await connectionDb.QueryFirstOrDefaultAsync<WMS_USER>(sql,
                    new
                    {
                        Name = usuario.DESCRICAO_USER,
                        Password = usuario.SENHA

                    });

                return result;
            }
        }
        public async Task<IEnumerable<WMS_USER>> GetUsuarios()
        {
            string sql = " SELECT [Id_USER], [DESCRICAO_USER], [SENHA] " +
                    " FROM [dbo].[WMS_USER] ";

            IList<WMS_USER> list = new List<WMS_USER>();

            using (var connectionDb = connection.Connection())
            {
                connectionDb.Open();

                var result = await connectionDb.QueryAsync<WMS_USER>(sql);

                if (result.Any())
                {
                    list = result.ToList();
                }
            }
            return list;
        }
    }
}
