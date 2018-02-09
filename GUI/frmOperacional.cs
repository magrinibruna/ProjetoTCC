using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Oracle.DataAccess.Client;

namespace TCC5._0.GUI
{
    public partial class frmOperacional : MaterialSkin.Controls.MaterialForm
    {
        public frmOperacional()
        {
            InitializeComponent();
            pnlMensagem.Hide();
            pnlSugestao.Hide();
            pnlHorarios.Hide();
            pnlPerfil.Hide();
            pnlNotas.Hide();
        }

                         //Sumário:
                      //Menus
                      //Cadastros
                      //Consultas
                      //Alterações
                      //Exclusões
                      //Limpar
                      //Outros

        //enviar valor 0 quando for enviado pra professor pro fkrmaluno, assim, quando consultar, não dá erro


        string srtRM = "";
        int csrtRM;
        public void RM(string RM)
        {
            srtRM = RM;
            csrtRM = Convert.ToInt32(srtRM);
        }

                                                               //Menus

        //Botão Menu Pagina Inicial
        private void btnMenuPadrao_Click(object sender, EventArgs e)
        {
            pnlMensagem.Hide();
            pnlSugestao.Hide();
            pnlPerfil.Hide();
            pnlHorarios.Hide();
            pnlNotas.Hide();
        }

        //Botão Menu Sugestões
        private void button1_Click(object sender, EventArgs e)
        {
            pnlSugestao.Show();
            pnlMensagem.Hide();
            pnlHorarios.Hide();
            pnlNotas.Hide();
            pnlPerfil.Hide();
            LimparCamposSugestao();
            string DataSugestao = Convert.ToString(DateTime.Now);
            txtDataSugestao.Text = DataSugestao;
            txtRMSugestao.Text = srtRM;


        }

        //Botão Menu Mensagem
        private void btnMenuMensagens_Click(object sender, EventArgs e)
        {
            pnlMensagem.Show();
            pnlSugestao.Hide();
            pnlNotas.Hide();
            pnlHorarios.Hide();
            pnlPerfil.Hide();
            pnlConsultaAlunoMensagem.Hide();
            pnlConsultaProfMensagem.Hide();
            labelMensagem.Show();
            rbProfessor.Select();
            GUIConsultaMensagem();
            GUIConsultaComboBoxProfessor();
            LimparCampoConsultaMensagem();
            LimparCampoMensagem();

            string DataMensagem = Convert.ToString(DateTime.Now);
            txtDataMensagem.Text = DataMensagem;
        }

        //Botão Menu Perfil
        private void btnMenuPerfil_Click(object sender, EventArgs e)
        {
            pnlPerfil.Show();
            pnlMensagem.Hide();
            pnlSugestao.Hide();
            pnlNotas.Hide();
            pnlHorarios.Hide();
            GUIConsultaRMAluno(srtRM);
        }

        //Botão Menu Nota
        private void btnMenuTurma_Click(object sender, EventArgs e)
        {
            pnlPerfil.Hide();
            pnlMensagem.Hide();
            pnlSugestao.Hide();
            pnlNotas.Show();
            pnlHorarios.Hide();
            GUIConsultaNota();
        }

        //Botão Menu Horário
        private void btnMenuHorario_Click(object sender, EventArgs e)
        {
            pnlPerfil.Hide();
            pnlMensagem.Hide();
            pnlSugestao.Hide();
            pnlNotas.Hide();
            pnlHorarios.Show();
            LimparCamposHorarios();
            GUIConsultaCursoHorarioCB();
        }


        //Botão Menu Lixeira
        private void btnMenuLixeira_Click(object sender, EventArgs e)
        {

        }
                                                       //Cadastros

        //Botão Enviar Sugestão
        private void btnEnviarSugestao_Click(object sender, EventArgs e)
        {
            if ((txtRMSugestao.Text == "") || (txtDataSugestao.Text == "") || (txtMensagemSugestao.Text == ""))
            {
                MessageBox.Show("Preenchimento de Campos Incorretos");
            }
            else
            {
                BLL.BLLSugestao objBLLSugestao = new BLL.BLLSugestao();
                objBLLSugestao.BLLCadastroSugestao(txtRMSugestao.Text, txtDataSugestao.Text, txtMensagemSugestao.Text);
                MessageBox.Show("Sugestão Enviada Com Sucesso!");
                LimparCamposSugestao();
            }
        }

        //Botão Enviar Mensagem
        string ValidacaoAssuntoMensagem = "";
        private void btnEnviarMensagem_Click_1(object sender, EventArgs e)
        {
            if (rbAluno.Checked == true) 
            {
                if ((mtxtRMDestinarioMensagem.Text == "") || (txtDataMensagem.Text == "") || (txtMensagemMensagem.Text == ""))
                {
                    MessageBox.Show("Preenchimento de Campos Incorreto");
                }
                else
                {
                        BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
                        DataTable tAluno = objBLLAluno.BLLConsultaRMAluno(mtxtRMDestinarioMensagem.Text);
                        DataGridView dgvAluno = new DataGridView();
                        dgvAluno.DataSource = tAluno;

                        if (tAluno.Rows.Count == 0)
                        {
                            MessageBox.Show("Aluno Destinário Não Existe");
                            LimparCampoMensagem();
                            mtxtRMDestinarioMensagem.Focus();
                        }
                        else
                        {

                            if (txtAssuntoMensagem.Text == "")
                            {
                                ValidacaoAssuntoMensagem = "Sem Assunto";
                                BLL.BLLMensagem objBLLMensagem = new BLL.BLLMensagem();
                                objBLLMensagem.DAOCadastraMensagem(srtRM, mtxtRMDestinarioMensagem.Text, txtDataMensagem.Text, ValidacaoAssuntoMensagem, txtMensagemMensagem.Text);
                                MessageBox.Show("Mensagem Enviada");
                                LimparCampoMensagem();
                                GUIConsultaMensagem();


                            }
                            else
                            {

                                BLL.BLLMensagem objBLLMensagem = new BLL.BLLMensagem();
                                objBLLMensagem.DAOCadastraMensagem(srtRM, mtxtRMDestinarioMensagem.Text, txtDataMensagem.Text, txtAssuntoMensagem.Text, txtMensagemMensagem.Text);
                                MessageBox.Show("Mensagem Enviada");
                                LimparCampoMensagem();
                                GUIConsultaMensagem();

                            }
                        }
                }
            }
            else
            {
                if((cbProfMensagem.Text == null) || (txtDataMensagem.Text == "") || (txtMensagemMensagem.Text == ""))
                {
                    MessageBox.Show("Preenchimento de Campos Incorreto");
                }
                else
                {
                    {
                        BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
                        DataTable tProf = objBLLFunc.BLLConsultaNomeProfessor(cbProfMensagem.Text);
                        DataGridView dgvProf = new DataGridView();
                        dgvProf.DataSource = tProf;

                        string ID = tProf.Rows[0][0].ToString();

                        if (txtAssuntoMensagem.Text == "")
                        {
                            ValidacaoAssuntoMensagem = "Sem Assunto";
                            BLL.BLLMensagem objBLLMensagem = new BLL.BLLMensagem();
                            objBLLMensagem.DAOCadastraMensagem(srtRM, ID, txtDataMensagem.Text, ValidacaoAssuntoMensagem, txtMensagemMensagem.Text);
                            MessageBox.Show("Mensagem Enviada");
                            LimparCampoMensagem();
                            GUIConsultaMensagem();


                        }
                        else
                        {

                            BLL.BLLMensagem objBLLMensagem = new BLL.BLLMensagem();
                            objBLLMensagem.DAOCadastraMensagem(srtRM, ID, txtDataMensagem.Text, txtAssuntoMensagem.Text, txtMensagemMensagem.Text);
                            MessageBox.Show("Mensagem Enviada");
                            LimparCampoMensagem();
                            GUIConsultaMensagem();

                        }
                    }
                }
            }
        }
                                                       //Consultas

        //Consulta Mensagem 
        private void GUIConsultaMensagem()
        {
            BLL.BLLMensagem objBLLMensagem = new BLL.BLLMensagem();
            DataGridView dgv = new DataGridView();
            dgvMensagensMensagens.DataSource = objBLLMensagem.BLLConsultaMensagem(srtRM);
     
        }

        //Consulta Mensagem ID
        private void GUIConsultaIDMensagem()
        {
            string IDMensagem = dgvMensagensMensagens.SelectedRows[0].Cells[0].Value.ToString();

            BLL.BLLMensagem objBLLMensagem = new BLL.BLLMensagem();
            DataTable tMensagem = objBLLMensagem.BLLConsultaIDMensagem(IDMensagem);
            DataGridView dgvMensagem = new DataGridView();
            dgvMensagem.DataSource = tMensagem;

            if (tMensagem.Rows.Count == 0)
            {
                MessageBox.Show("Mensagem Não Encontrada!");
            }
            else
            {
                string FKEnvia = tMensagem.Rows[0][1].ToString();
                string Data = tMensagem.Rows[0][2].ToString();
                string Assunto = tMensagem.Rows[0][3].ToString();
                string Mensagem = tMensagem.Rows[0][4].ToString();

                BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
                DataTable tAluno = objBLLAluno.BLLConsultaRMAluno(FKEnvia);
                DataGridView dgvAluno = new DataGridView();
                dgvAluno.DataSource = tAluno;

                if (tAluno.Rows.Count == 0)
                {
                    BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
                    DataTable tProf = objBLLFunc.BLLConsultaCodigoProfessor(FKEnvia);
                    DataGridView dgvProf = new DataGridView();
                    dgvProf.DataSource = tProf;

                    if (tProf.Rows.Count == 0)
                    {
                        MessageBox.Show("Destinário Inexistente");
                    }
                    else
                    {
                        string NomeProfessor = tProf.Rows[0][1].ToString();

                        pnlConsultaProfMensagem.Show();
                        pnlConsultaAlunoMensagem.Hide();
                        labelMensagem.Hide();

                        txtCodigoMensagem.Text = IDMensagem;
                        txtDataProfMensagem.Text = Data;
                        txtNomeProfMensagem.Text = NomeProfessor;
                        txtProfAssuntoMensagem.Text = Assunto;
                        txtMensagemProfMensagem.Text = Mensagem;


                    }

                }
                else
                {
                    string NomeAluno = tAluno.Rows[0][1].ToString();
                    string FKTurma = tAluno.Rows[0][6].ToString();

                    BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
                    DataTable tTurma = objBLLTurma.BLLConsultaTurmaCodigo(FKTurma);
                    DataGridView dgvTurma = new DataGridView();
                    dgvTurma.DataSource = tTurma;

                    if (tTurma.Rows.Count == 0)
                    {
                        MessageBox.Show("Turma Inexistente");
                    }
                    else
                    {
                        string NomeCompleto = tTurma.Rows[0][5].ToString();

                        pnlConsultaAlunoMensagem.Show();
                        pnlConsultaProfMensagem.Hide();
                        labelMensagem.Hide();

                        txtCodigoMensagem.Text = IDMensagem;
                        txtDataConsultaMensagem.Text = Data;
                        txtRMConsultaMensagem.Text = FKEnvia;
                        txtTurmaConsultaMensagem.Text = NomeCompleto;
                        txtNomeConsultaMensagem.Text = NomeAluno;
                        txtAssuntoConsultaMnesagem.Text = Assunto;
                        txtMensagemConsultaMensagem.Text = Mensagem;
                    }

                }

            }
        }

        //Botão Consulta ID Mensagem DoubleClick
        private void dgvMensagensMensagens_DoubleClick(object sender, EventArgs e)
        {
            GUIConsultaIDMensagem();
        }

        //Consulta de Foto
        private void BuscaFoto(int FK)
        {
            string connectionCOM = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LOCALHOST)(PORT=1521)))(CONNECT_DATA=(SID=xe)));User ID=SYS;Password=123456; DBA Privilege=SYSDBA;";
            OracleConnection Conexao = new OracleConnection(connectionCOM);
            OracleCommand Comando = new OracleCommand("SELECT * FROM tcc.tbAlunoFoto WHERE FKRMAluno = " + FK, Conexao);

            OracleDataReader meu_dr;

            try
            {
                Conexao.Open();

                meu_dr = Comando.ExecuteReader();
                byte[] imagem = (byte[])(meu_dr["Foto"]);

                if (imagem == null)
                {
                    pbPerfil.Image = null;
                }
                else
                {
                    MemoryStream mstrem = new MemoryStream(imagem);
                    pbPerfil.Image = System.Drawing.Image.FromStream(mstrem);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        //Consulta Aluno RM
        private void GUIConsultaRMAluno(string RM)
        {
            BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
            DataTable tAluno = objBLLAluno.BLLConsultaRMAluno(RM);
            DataGridView dgvAluno = new DataGridView();
            dgvAluno.DataSource = tAluno;

            string Nome = tAluno.Rows[0][1].ToString();
            string CPF = tAluno.Rows[0][2].ToString();
            string Email = tAluno.Rows[0][3].ToString();
            string AI = tAluno.Rows[0][4].ToString();
            string DT = tAluno.Rows[0][5].ToString();
            string FKTurma = tAluno.Rows[0][6].ToString();

            BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
            DataGridView dgvTurma = new DataGridView();
            DataTable tTurma = objBLLTurma.BLLConsultaTurmaCodigo(FKTurma);

            string Turma = tTurma.Rows[0][5].ToString();

            BLL.BLLFoto objBLLFoto = new BLL.BLLFoto();
            DataGridView dgvFoto = new DataGridView();
            DataTable tFoto = objBLLFoto.BLLConsultaRMFoto(RM);
            dgvFoto.DataSource = tFoto;

            if (tFoto.Rows.Count == 0)
            {
                mtxtRMAluno.Text = srtRM;
                txtNomeAluno.Text = Nome;
                mtxtCPFAluno.Text = CPF;
                txtEmailAluno.Text = Email;
                mtxtDTAluno.Text = DT;
                txtTurmaAluno.Text = Turma;
            }
            else
            {
                string Diretorio = tFoto.Rows[0][0].ToString();


                mtxtRMAluno.Text = srtRM;
                txtNomeAluno.Text = Nome;
                mtxtCPFAluno.Text = CPF;
                txtEmailAluno.Text = Email;
                mtxtDTAluno.Text = DT;
                txtTurmaAluno.Text = Turma;
                txtDiretorio.Text = Diretorio;
                pbPerfil.Image = new System.Drawing.Bitmap(txtDiretorio.Text);
            }


        }

        //Consulta de Professor ComboBox Nome
        public void GUIConsultaComboBoxProfessor()
        {
            BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();

            cbProfMensagem.DataSource = objBLLFunc.BLLConsultaComboBoxProfessor();
            cbProfMensagem.DisplayMember = "NomeFunc";
            cbProfMensagem.Text = null;
        }

        //Consulta Nota
        private void GUIConsultaNota()
        {
            BLL.BLLNota objBLLNota = new BLL.BLLNota();
            DataTable t = objBLLNota.BLLConsultaRMNota(srtRM);
            dgvNota.DataSource = t;
        }

        //Consulta de Curso Ativo ComboBox NomeCurso Horario
        private void GUIConsultaCursoHorarioCB()
        {

            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();

            cbCursoHorario.DataSource = objBLLCurso.BLLConsultaAtivoComboBoxCurso();
            cbCursoHorario.DisplayMember = "NomeCurso";
            cbCursoHorario.Text = null;


        }

        //Botão Consultar Horário
        private void btnConsultarHorario_Click(object sender, EventArgs e)
        {
            if (cbCursoHorario.Text == "")
            {
                MessageBox.Show("Selecione um Curso");
            }
            else
            {

                BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
                DataTable tCurso = objBLLCurso.BLLConsultaNomeCurso(cbCursoHorario.Text);
                DataGridView dgvCurso = new DataGridView();
                dgvCurso.DataSource = tCurso;
                string IDCurso = tCurso.Rows[0][0].ToString();


                BLL.BLLFoto objBLLFoto = new BLL.BLLFoto();
                DataTable tFoto = objBLLFoto.BLLConsultaHorarioFoto(IDCurso);
                DataGridView dgvFoto = new DataGridView();
                dgvFoto.DataSource = tFoto;

                if (tFoto.Rows.Count == 0)
                {
                    MessageBox.Show("Curso Não Possui Hórário Cadastrado");
                    cbCursoHorario.Text = null;
                }
                else
                {

                    string Diretorio = tFoto.Rows[0][0].ToString();
                    if (Diretorio == "x")
                    {
                        MessageBox.Show("Não Há Horário Cadastrado :[");
                    }
                    else
                    {
                        txtDiretorioHorario.Text = Diretorio;
                        pbHorarios.Image = new System.Drawing.Bitmap(txtDiretorioHorario.Text);
                    }
                }
            }
        }



                                                       //Alterar

        //Botão Alterar Email Aluno
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtEmailAluno.Enabled == false)
            {
                txtEmailAluno.Enabled = true;
                txtEmailAluno.Focus();
            }
            else
            {
                BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
                objBLLAluno.BLLAlteraAlunoAluno(srtRM, txtEmailAluno.Text);
                MessageBox.Show("Email Alterado");

                DataTable tAluno = objBLLAluno.BLLConsultaRMAluno(srtRM);
                DataGridView dgvAluno = new DataGridView();
                dgvAluno.DataSource = tAluno;
                string Email = tAluno.Rows[0][3].ToString();
                txtEmailAluno.Enabled = false;
            }

        }

        //Botão Alterar Senha Aluno
        private void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            if ((txtSenhaAntigaPerfil.Enabled == false) && (txtNovaSenhaPerfil.Enabled == false) && (txtNovaSenha2Perfil.Enabled == false))
            {
                txtSenhaAntigaPerfil.Enabled = true;
                txtNovaSenhaPerfil.Enabled = true;
                txtNovaSenha2Perfil.Enabled = true;
                txtSenhaAntigaPerfil.Focus();

            }
            else
            {
                if ((txtSenhaAntigaPerfil.Text != "") || (txtNovaSenhaPerfil.Text != "") || (txtNovaSenha2Perfil.Text != ""))
                {
                    BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
                    BLL.BLLLogin objBLLLogin = new BLL.BLLLogin();

                    DataTable tLogin = objBLLLogin.BLLConsultaLogin(srtRM);
                    DataGridView dgvLogin = new DataGridView();
                    dgvLogin.DataSource = tLogin;

                    string Senha = tLogin.Rows[0][2].ToString();
                    if (txtSenhaAntigaPerfil.Text != Senha)
                    {
                        MessageBox.Show("Senha Antiga Incorreta");
                        txtSenhaAntigaPerfil.Text = "";
                        txtSenhaAntigaPerfil.Focus();
                    }
                    else
                    {
                        if (txtNovaSenhaPerfil.Text == txtNovaSenha2Perfil.Text)
                        {
                            objBLLLogin.BLLAlteraSenha(srtRM, txtNovaSenhaPerfil.Text);
                            MessageBox.Show("Senha Alterada!");
                            txtSenhaAntigaPerfil.Text = "";
                            txtNovaSenhaPerfil.Text = "";
                            txtNovaSenha2Perfil.Text = "";
                            txtSenhaAntigaPerfil.Enabled = false;
                            txtNovaSenhaPerfil.Enabled = false;
                            txtNovaSenha2Perfil.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Novas Senhas Não Combinam!");
                            txtNovaSenhaPerfil.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Preenchimento de Campos Incorreto!");
                }

            }
        }

                                                      //Excluir

        //Botão Excluir Mensagem Aluno
        private void btnExcluirMensagemConsulta_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Deseja Continuar? A Mensagem Será Excluida PERMANENTEMENTE!", "Excluir Permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (confirm.ToString().ToUpper() == "YES")
            {
                BLL.BLLMensagem objBLLMensagem = new BLL.BLLMensagem();
                objBLLMensagem.BLLDeletaMensagem(txtCodigoMensagem.Text);
                MessageBox.Show("Mensagem Deletada Com Sucesso!");
                GUIConsultaMensagem();
                LimparCampoConsultaMensagem();
                txtCodigoMensagem.Text = "";

            }
           
        }

        //Botão Excluir Mensagem Professor
        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Deseja Continuar? A Mensagem Será Excluida PERMANENTEMENTE!", "Excluir Permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (confirm.ToString().ToUpper() == "YES")
            {
                BLL.BLLMensagem objBLLMensagem = new BLL.BLLMensagem();
                objBLLMensagem.BLLDeletaMensagem(txtCodigoMensagem.Text);
                MessageBox.Show("Mensagem Deletada Com Sucesso!");
                GUIConsultaMensagem();
                LimparCampoConsultaMensagem();
                txtCodigoMensagem.Text = "";

            }
           
        }
                                                       //Limpar

        //Limpar Campos Sugestão
        private void LimparCamposSugestao()
        {
            txtRMSugestao.Text = srtRM;
            txtDataSugestao.Text = Convert.ToString(DateTime.Now);
            txtMensagemSugestao.Text = "";
            cbProfMensagem.Text = null;
        }

        //Botão Limpar Campos Sugestão
        private void btnLimparSugestao_Click(object sender, EventArgs e)
        {
            LimparCamposSugestao();
        }

        //Limpar Campos Mensagem
        private void LimparCampoMensagem()
        {
            mtxtRMDestinarioMensagem.Text = "";
            cbProfMensagem.Text = null;
            txtDataMensagem.Text = Convert.ToString(DateTime.Now);
            txtAssuntoMensagem.Text = "";
            txtMensagemMensagem.Text = "";
        }

        //Botão Limpar Campos Mensagem
        private void btnLimparMensagem_Click(object sender, EventArgs e)
        {
            LimparCampoMensagem();
        }


        //Limpar Campos Mensagem Consulta
        private void LimparCampoConsultaMensagem()
        {
            txtDataProfMensagem.Text = Convert.ToString(DateTime.Now);
            txtNomeProfMensagem.Text = "";
            txtProfAssuntoMensagem.Text = "";
            txtMensagemProfMensagem.Text = "";
            txtDataConsultaMensagem.Text = "";
            txtRMConsultaMensagem.Text = "";
            txtTurmaConsultaMensagem.Text = "";
            txtNomeConsultaMensagem.Text = "";
            txtAssuntoConsultaMnesagem.Text = "";
            txtMensagemConsultaMensagem.Text = "";
        }

        //Botão Limpar Campos Mensagem Consulta
        private void btnLimparMensagemConsulta_Click(object sender, EventArgs e)
        {
            LimparCampoConsultaMensagem();
        }


        //Limpar Camois Mensagem Consulta Professor
        private void button3_Click(object sender, EventArgs e)
        {
            LimparCampoConsultaMensagem();
        }

        //Limpar Campos Horários
        private void LimparCamposHorarios()
        {
            cbCursoHorario.Text = null;
            pbHorarios.Image = null;
            txtDiretorioHorario.Text = "";
        }
              
                                                        //Outros
        //Botão Sair
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 objForm1 = new Form1();
            objForm1.Show();
            this.Hide();
        }

        //CheckBox Senha Antiga Perfil
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.txtSenhaAntigaPerfil.PasswordChar = '\0';
            }
            else
            {
                this.txtSenhaAntigaPerfil.PasswordChar = '*';
            }
        }

        //CheckBox Nova Senha Perfil
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                this.txtNovaSenhaPerfil.PasswordChar = '\0';
            }
            else
            {
                this.txtNovaSenhaPerfil.PasswordChar = '*';
            }
        }

        //CheckBox Nova Senha 2 Perfil
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox3.Checked)
            {
                this.txtNovaSenha2Perfil.PasswordChar = '\0';
            }
            else
            {
                this.txtNovaSenha2Perfil.PasswordChar = '*';
            }
        }

        //RadioButton Professor Mensagem
        private void rbProfessor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProfessor.Checked == true)
            {
                mtxtRMDestinarioMensagem.Hide();
                cbProfMensagem.Show();
                cbProfMensagem.Text = null;
            }
        }

        //RadioButton Aluno Mensagem
        private void rbAluno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAluno.Checked == true)
            {
                mtxtRMDestinarioMensagem.Show();
                cbProfMensagem.Hide();
            }
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 objForm1 = new Form1();
            objForm1.Show();
            this.Hide();
        }

        private void pnlHorarios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora2.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora3.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora4.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora5.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora6.Text = (DateTime.Now.ToString("HH:mm:ss"));

        }
































        

        
    }
}
