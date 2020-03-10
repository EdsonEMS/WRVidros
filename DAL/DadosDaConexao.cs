using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DadosDaConexao
    {
        public static String StringDaConexao
        {
            get
            {
                //return "Data Source=KBRSPNB010;Initial Catalog=bd_WRVidros;Integrated Security=True";
                return "Data Source=SAOWS001\\SQLEXPRESS;Initial Catalog=ControleDeEstoque;Persist Security Info=True;User ID=sa;Password=Masterkey1";
            }
        }
    }
}
