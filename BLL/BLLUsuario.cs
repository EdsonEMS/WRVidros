using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLUsuario
    {
        private DALConexao conexao;
        public BLLUsuario(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloUsuario modelo)
        {
            if (modelo.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do usuário é obrigatório");
            }
            //modelo.Nome = modelo.Nome.ToUpper();

            DALUsuario DALobj = new DALUsuario(conexao);
            DALobj.Incluir(modelo);
        }

        public void Alterar(ModeloUsuario modelo)
        {
            if (modelo.IdUsuario <= 0)
            {
                throw new Exception("O código do usuário é obrigatório");
            }

            if (modelo.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do usuário é obrigatório");
            }
            //modelo.Nome = modelo.Nome.ToUpper();

            DALUsuario DALobj = new DALUsuario(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALUsuario DALobj = new DALUsuario(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(String valor)
        {
            DALUsuario DALobj = new DALUsuario(conexao);
            return DALobj.Localizar(valor);
        }

        public ModeloUsuario CarregaModeloUsuario(int codigo)
        {
            DALUsuario DALobj = new DALUsuario(conexao);
            return DALobj.CarregaModeloUsuario(codigo);
        }
    }
}
