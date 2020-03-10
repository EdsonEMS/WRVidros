using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloUsuario
    {
        private int id_usuario;
        public int IdUsuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }

        private String nome;
        public String Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        private int ativo;
        public int Ativo
        {
            get { return this.ativo; }
            set { this.ativo = value; }
        }
    }
}
