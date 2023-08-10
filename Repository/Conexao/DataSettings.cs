using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Conexao
{
    public class DataSettings : IDataSettings
    {
        public string DefaultConnection { get; set; }
    }
}
