using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TCC5._0
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey100, Primary.BlueGrey200, Primary.BlueGrey300, Accent.LightBlue100, TextShade.WHITE);
            pnlAlteraSenha.Hide();

        }

        string ValidacaoNH = "";

        public void GUIConsultaLogin()
        {

            BLL.BLLLogin objBLLLogin = new BLL.BLLLogin();
            DataTable t = objBLLLogin.BLLConsultaLogin(txtUsuario.Text);

            DataGridView dgv = new DataGridView();

            dgv.DataSource = t;

            if ((txtUsuario.Text == "") || (txtSenha.Text == ""))
            {

                MessageBox.Show("Preenchimento de Campos Incorretos");

            }
            else
            {

                if (t.Rows.Count == 0)
                {

                    MessageBox.Show("Usuario Inexistente!");
                    txtUsuario.Text = "";
                    txtSenha.Text = "";
                    txtUsuario.Focus();

                }
                else
                {
                    //o primeiro [] sempre contém 0
                    //o segundo [] indica a posição no banco de dados (o 0 conta)
                    string Usuario = t.Rows[0][1].ToString();
                    string Senha = t.Rows[0][2].ToString();
                    int NHLogin = Convert.ToInt16(t.Rows[0][3].ToString());

                    if (NHLogin == 1)
                    {

                        if ((txtUsuario.Text == Usuario) && (txtSenha.Text == Senha))
                        {
                            GUI.frmTatico objfrmTatico = new GUI.frmTatico();
                            objfrmTatico.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Senha Incorreta");
                            txtSenha.Text = "";
                            txtSenha.Focus();
                        }


                    }
                    else if (NHLogin == 2)
                    {

                        if ((txtUsuario.Text == Usuario) && (txtSenha.Text == Senha))
                        {
                            if (txtSenha.Text == "abcdef")
                            {
                                ValidacaoNH = "2";
                                cbMostraSenha.Hide();
                                pnlAlteraSenha.Show();
                                txtAlteraSenha.Focus();
                            }
                            else
                            {
                                GUI.frmProfessor objfrmProfessor = new GUI.frmProfessor();
                                objfrmProfessor.ID(txtUsuario.Text);
                                objfrmProfessor.Show();
                                this.Hide();
                            }

                        }
                        else
                        {

                            MessageBox.Show("Senha Incorreta");
                            txtSenha.Text = "";
                            txtSenha.Focus();

                        }


                    }
                    else
                    {
                       
                        if ((txtUsuario.Text == Usuario) && (txtSenha.Text == Senha))
                        {
                            if (Senha == "123456")
                            {
                                ValidacaoNH = "3";
                                cbMostraSenha.Hide();
                                pnlAlteraSenha.Show();
                                txtAlteraSenha.Focus();
                            }
                            else
                            {

                                GUI.frmOperacional objForm = new GUI.frmOperacional();
                                objForm.RM(txtUsuario.Text);
                                objForm.Show();
                                this.Hide();
                            }
                        }
                        else
                        {

                            MessageBox.Show("Senha Incorreta");
                            txtSenha.Text = "";
                            txtSenha.Focus();

                        }


                    }
                }
            }
        }

        private void btnEntra_Click(object sender, EventArgs e)
        {
            GUIConsultaLogin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            GUI.frmTatico objForm = new GUI.frmTatico();
            objForm.Show();
            this.Hide();
        }

        private void btnAlteraSenha_Click(object sender, EventArgs e)
        {
            if (ValidacaoNH == "3")
            {
                if (txtAlteraSenha.Text == "")
                {
                    MessageBox.Show("Digite Uma Senha");
                    txtAlteraSenha.Focus();
                }
                else
                {

                    if (txtAlteraSenha.Text == "123456")
                    {
                        MessageBox.Show("Senha Padrão, Altere a Senha");
                        txtAlteraSenha.Text = "";
                        txtAlteraSenha.Focus();
                    }
                    else
                    {
                        BLL.BLLLogin objBLLLogin = new BLL.BLLLogin();
                        objBLLLogin.BLLAlteraSenha(txtUsuario.Text, txtAlteraSenha.Text);
                        MessageBox.Show("Senha Alterada! Logue Novamente");
                        txtSenha.Text = "";
                        txtSenha.Focus();
                        txtAlteraSenha.Text = "";
                        pnlAlteraSenha.Hide();
                        cbMostraSenha.Show();
                    }
                }
            }
            else
            {
                if (txtAlteraSenha.Text == "")
                {
                    MessageBox.Show("Digite Uma Senha");
                    txtAlteraSenha.Focus();
                }
                else
                {

                    if (txtAlteraSenha.Text == "abcdef")
                    {
                        MessageBox.Show("Senha Padrão, Altere a Senha");
                        txtAlteraSenha.Text = "";
                        txtAlteraSenha.Focus();
                    }
                    else
                    {
                        BLL.BLLLogin objBLLLogin = new BLL.BLLLogin();
                        objBLLLogin.BLLAlteraSenha(txtUsuario.Text, txtAlteraSenha.Text);
                        MessageBox.Show("Senha Alterada! Logue Novamente");
                        txtSenha.Text = "";
                        txtSenha.Focus();
                        txtAlteraSenha.Text = "";
                        pnlAlteraSenha.Hide();
                        cbMostraSenha.Show();
                    }
                }
            }
        }

        private void cbMostraSenhaAlteraSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbMostraSenhaAlteraSenha.Checked)
            {
                this.txtAlteraSenha.PasswordChar = '\0';

            }
            else
            {
                this.txtAlteraSenha.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cbMostraSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbMostraSenha.Checked)
            {
                this.txtSenha.PasswordChar = '\0';
            }
            else
            {
                this.txtSenha.PasswordChar = '*';
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GUIConsultaLogin();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = (DateTime.Now.ToString("HH:mm:ss"));
        }

 

    }
}
