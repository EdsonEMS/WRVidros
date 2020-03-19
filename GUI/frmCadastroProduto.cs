using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelo;
using GUI;
using DAL;

namespace GUI
{
    public partial class frmCadastroProduto : GUI.frmModeloCadastro
    {
        public string foto = "";
        public frmCadastroProduto()
        {            
            InitializeComponent();
            if (txtDescricao.Enabled == true)
            {
                txtDescricao.Focus();
            }
        }

        public void LimaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtValorPago.Clear();
            txtValorVenda.Clear();
            txtQtde.Clear();
            this.foto = "";
            picFoto.Image = null;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
            if (txtNome.Enabled == true)
            {
                txtNome.Focus();
            }            
        }

        private void frmCadastroProduto_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            //combo da categoria
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCategoria bll = new BLLCategoria(cx);
            cboCategoria.DataSource = bll.Localizar("");
            cboCategoria.DisplayMember = "cat_nome";
            cboCategoria.ValueMember = "cat_cod";
            try
            {
                //combo da subcategoria
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cboSubCategoria.DataSource = sbll.LocalizarPorCategoria((int)cboCategoria.SelectedValue);
                cboSubCategoria.DisplayMember = "scat_nome";
                cboSubCategoria.ValueMember = "scat_cod";
            }
            catch 
            {
                //MessageBox.Show("Cadastre uma categoria");
            }
            //combo und medida
            BLLUnidadeDeMedida ubll = new BLLUnidadeDeMedida(cx);
            cboUnd.DataSource = ubll.Localizar("");
            cboUnd.DisplayMember = "umed_nome";
            cboUnd.ValueMember = "umed_cod";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimaTela();
            this.alteraBotoes(1);
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorPago.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            if (txtValorPago.Text.Contains(".") == false)
            {
                txtValorPago.Text += ".00";
            }
            else
            {
                if (txtValorPago.Text.IndexOf(".") == txtValorPago.Text.Length - 2)
                {
                    txtValorPago.Text += "0";
                }
                if (txtValorPago.Text.IndexOf(".") == txtValorPago.Text.Length - 1)
                {
                    txtValorPago.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtValorPago.Text);
            }
            catch
            {
                txtValorPago.Text = "0.00";
            }
        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorVenda.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            if (txtValorVenda.Text.Contains(".") == false)
            {
                txtValorVenda.Text += ".00";
            }
            else
            {
                if (txtValorVenda.Text.IndexOf(".") == txtValorVenda.Text.Length - 2)
                {
                    txtValorVenda.Text += "0";
                }
                if (txtValorVenda.Text.IndexOf(".") == txtValorVenda.Text.Length - 1)
                {
                    txtValorVenda.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtValorVenda.Text);
            }
            catch
            {
                txtValorVenda.Text = "0.00";
            }
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtQtde.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        private void txtQtde_Leave(object sender, EventArgs e)
        {
            if (txtQtde.Text.Contains(".") == false)
            {
                txtQtde.Text += ".00";
            }
            else
            {
                if (txtQtde.Text.IndexOf(".") == txtQtde.Text.Length - 2)
                {
                    txtQtde.Text += "0";
                }
                if (txtQtde.Text.IndexOf(".") == txtQtde.Text.Length - 1)
                {
                    txtQtde.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtQtde.Text);
            }
            catch
            {
                txtQtde.Text = "0.00";
            }
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //combo da categoria
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            try
            {
                //combo da subcategoria
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cboSubCategoria.Text = "";
                cboSubCategoria.DataSource = sbll.LocalizarPorCategoria((int)cboCategoria.SelectedValue);
                cboSubCategoria.DisplayMember = "scat_nome";
                cboSubCategoria.ValueMember = "scat_cod";
            }
            catch
            {
                //MessageBox.Show("Cadastre uma categoria");
            }
        }

        private void btLoFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.ShowDialog();
            if (!string.IsNullOrEmpty(od.FileName))
            {
                this.foto = od.FileName;
                picFoto.Load(this.foto);
            }
        }

        private void btRmFoto_Click(object sender, EventArgs e)
        {
            this.foto = "";
            picFoto.Image = null;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.alteraBotoes(2);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja exluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    //obj para exckuir os dados no banco
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLProduto bll = new BLLProduto(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.LimaTela();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro esta sendo utilizado em outro local.");
                this.alteraBotoes(3);
            }
        }

        private void btnLoFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.ShowDialog();
            if (!string.IsNullOrEmpty(od.FileName))
            {
                try
                {
                    this.foto = od.FileName;
                    picFoto.Load(this.foto);
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Imagem inválida!");
                }
            }
        }

        private void btnRmFoto_Click(object sender, EventArgs e)
        {
            this.foto = "";
            picFoto.Image = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura dos dados
                ModeloProduto modelo = new ModeloProduto();
                modelo.ProNome = txtNome.Text;
                modelo.ProDescricao = txtDescricao.Text;
                modelo.ProValorPago = Convert.ToDouble(txtValorPago.Text);
                modelo.ProValorVenda = Convert.ToDouble(txtValorVenda.Text);
                modelo.ProQtde = Convert.ToDouble(txtQtde.Text);
                modelo.UmedCod = Convert.ToInt32(cboUnd.SelectedValue);
                modelo.CatCod = Convert.ToInt32(cboCategoria.SelectedValue);
                modelo.ScatCod = Convert.ToInt32(cboSubCategoria.SelectedValue);

                modelo.CarregaImagem(this.foto);

                //obj para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLProduto bll = new BLLProduto(cx);

                if (this.operacao == "inserir")
                {
                    //cadastrar uma categoria
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado: Código " + modelo.ProCod.ToString());
                }
                else
                {
                    //alterar uma categoria
                    modelo.ProCod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado");
                }
                this.LimaTela();
                this.alteraBotoes(1);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            /*
            frmConsultaCategoria f = new frmConsultaCategoria();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLCategoria bll = new BLLCategoria(cx);
                ModeloCategoria modelo = bll.CarregaModeloCategoria(f.codigo);
                txtCodigo.Text = modelo.CatCod.ToString();
                txtNome.Text = modelo.CatNome;
                this.alteraBotoes(3);
            }
            else
            {
                this.LimaTela();
                this.alteraBotoes(1);
            }
            f.Dispose();
            */
        }
    }
}
