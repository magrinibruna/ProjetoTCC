using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC5._0.GUI
{
    public partial class frmProfessor : MaterialSkin.Controls.MaterialForm
    {
        public frmProfessor()
        {
            InitializeComponent();

            pnlPerfil.Hide();
            pnlSugestao.Hide();
            pnlMensagem.Hide();
            pnlNotas.Hide();


        }

        string srtID = "";
        public void ID(string id)
        {
            srtID = id;
        }

                                                                  //Menus

        //Botão Menu Padrão
        private void btnMenuPadrao_Click(object sender, EventArgs e)
        {
            pnlPerfil.Hide();
            pnlSugestao.Hide();
            pnlMensagem.Hide();
            pnlNotas.Hide();
        }


        //Botão Menu Notas
        private void btnMenuTurma_Click(object sender, EventArgs e)
        {
            pnlSugestao.Hide();
            pnlPerfil.Hide();
            pnlMensagem.Hide();
            pnlNotas.Show();
            btnValidacao = "";
            QuantidadeTrabalho = 1;
            GUIConsultaMateriaComboBox();
            rb1Tri.Select();
            LimparCamposNota();
            

        }

        //Botão Menu Sugestões
        private void button1_Click(object sender, EventArgs e)
        {
            pnlSugestao.Show();
            pnlPerfil.Hide();
            pnlMensagem.Hide();
            pnlNotas.Hide();
            mtxtIDProf.Text = srtID;
            string DataSugestao = Convert.ToString(DateTime.Now);
            txtDataSugestao.Text = DataSugestao;
                
        }

        //Botão Menu Mensagens
        private void btnMenuMensagens_Click(object sender, EventArgs e)
        {
            pnlMensagem.Show();
            pnlSugestao.Hide();
            pnlPerfil.Hide();
            pnlNotas.Hide();
            rbProfessor.Select();
            pnlConsultaProfMensagem.Hide();
            pnlConsultaAlunoMensagem.Hide();
            txtDataMensagem.Text = Convert.ToString(DateTime.Now);
            GUIConsultaMensagem();
            GUIConsultaComboBoxProfessor(); 
        }

        //Botão Menu Perfil
        private void btnMenuPerfil_Click(object sender, EventArgs e)
        {
            GUIConsultarIDProfessor();
            GUIConsultaNomeRelacionamentoPerfilProf();
            pnlPerfil.Show();
            pnlMensagem.Hide();
            pnlSugestao.Hide();
            pnlNotas.Hide();
        }

                                                                //Cadastros

        //Botão Enviar Mensagem
        string ValidacaoAssuntoMensagem = "";
        private void btnEnviarMensagem_Click(object sender, EventArgs e)
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
                            objBLLMensagem.DAOCadastraMensagem(srtID, mtxtRMDestinarioMensagem.Text, txtDataMensagem.Text, ValidacaoAssuntoMensagem, txtMensagemMensagem.Text);
                            MessageBox.Show("Mensagem Enviada");
                            LimparCampoMensagem();
                            GUIConsultaMensagem();


                        }
                        else
                        {

                            BLL.BLLMensagem objBLLMensagem = new BLL.BLLMensagem();
                            objBLLMensagem.DAOCadastraMensagem(srtID, mtxtRMDestinarioMensagem.Text, txtDataMensagem.Text, txtAssuntoMensagem.Text, txtMensagemMensagem.Text);
                            MessageBox.Show("Mensagem Enviada");
                            LimparCampoMensagem();
                            GUIConsultaMensagem();

                        }
                    }
                }
            }
            else
            {
                if ((cbProfMensagem.Text == null) || (txtDataMensagem.Text == "") || (txtMensagemMensagem.Text == ""))
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
                            objBLLMensagem.DAOCadastraMensagem(srtID, ID, txtDataMensagem.Text, ValidacaoAssuntoMensagem, txtMensagemMensagem.Text);
                            MessageBox.Show("Mensagem Enviada");
                            LimparCamposConsultaMensagem();
                            GUIConsultaMensagem();


                        }
                        else
                        {

                            BLL.BLLMensagem objBLLMensagem = new BLL.BLLMensagem();
                            objBLLMensagem.DAOCadastraMensagem(srtID, ID, txtDataMensagem.Text, txtAssuntoMensagem.Text, txtMensagemMensagem.Text);
                            MessageBox.Show("Mensagem Enviada");
                            LimparCamposConsultaMensagem();
                            GUIConsultaMensagem();

                        }
                    }
                }
            }
        }

        //Botão Enviar Sugestão
        private void btnEnviarSugestao_Click(object sender, EventArgs e)
        {
            if (txtMensagemSugestao.Text == "")
            {
                MessageBox.Show("Preenchimento de Mensagem Inválido");
                txtMensagemSugestao.Focus();
            }
            else
            {
                BLL.BLLSugestao objBLLSugestao = new BLL.BLLSugestao();
                objBLLSugestao.BLLCadastroSugestao(srtID, txtDataSugestao.Text, txtMensagemSugestao.Text);
                MessageBox.Show("Sugestão Enviada");
                LimparCamposSugestao();
            }
        }

        //Botão Cadastrar Nota
        string IDNota = "";
        string btnValidacao = "";
        private void btnCadastrarRM_Click(object sender, EventArgs e)
        {
            if (mtxtRMNotas.Text == "")
            {
                MessageBox.Show("Selecione um Aluno");
                mtxtRMNotas.Focus();
            }
            else
            {

                if (rb1Tri.Checked == true)
                {
                    BLL.BLLNota objBLLNota = new BLL.BLLNota();

                    DataTable tNota = objBLLNota.BLLConsultaValidacaoNota1(mtxtRMNotas.Text, IDProfMate);
                    DataGridView dgvNota = new DataGridView();
                    dgvNota.DataSource = tNota;

                    if (tNota.Rows.Count == 0)
                    {
                        objBLLNota.BLLCadastraNota1(mtxtRMNotas.Text, IDProfMate);
                        DataTable tNotaCadastrada = objBLLNota.BLLConsultaValidacaoNota1(mtxtRMNotas.Text, IDProfMate);
                        DataGridView dgvNotaCadastrada = new DataGridView();
                        dgvNotaCadastrada.DataSource = tNotaCadastrada;

                        IDNota = tNotaCadastrada.Rows[0][0].ToString();

                        txtPAT.Text = "0";
                        txtPEM.Text = "0";
                        txtParticipacao.Text = "0";
                        txtTrabalho1.Text = "0";

                        txtPAT.Focus();
                        btnValidacao = "1";
                    }
                    else
                    {
                        string IDNotaBanco = tNota.Rows[0][0].ToString();
                        string PAT = tNota.Rows[0][3].ToString();
                        string PEM = tNota.Rows[0][4].ToString();
                        string Trabalho = tNota.Rows[0][5].ToString();
                        string Participacao = tNota.Rows[0][7].ToString();

                        IDNota = IDNotaBanco;
                        txtPAT.Text = PAT;
                        txtPEM.Text = PEM;
                        txtTrabalho1.Text = Trabalho;
                        txtParticipacao.Text = Participacao;

                        txtPAT.Focus();
                        btnValidacao = "1";

                    }

                }
                else if (rb2Tri.Checked == true)
                {
                    BLL.BLLNota objBLLNota = new BLL.BLLNota();

                    DataTable tNota = objBLLNota.BLLConsultaValidacaoNota2(mtxtRMNotas.Text, IDProfMate);
                    DataGridView dgvNota = new DataGridView();
                    dgvNota.DataSource = tNota;

                    if (tNota.Rows.Count == 0)
                    {
                        objBLLNota.BLLCadastraNota2(mtxtRMNotas.Text, IDProfMate);
                        DataTable tNotaCadastrada = objBLLNota.BLLConsultaValidacaoNota2(mtxtRMNotas.Text, IDProfMate);
                        DataGridView dgvNotaCadastrada = new DataGridView();
                        dgvNotaCadastrada.DataSource = tNotaCadastrada;

                        IDNota = tNotaCadastrada.Rows[0][0].ToString();

                        txtPAT.Text = "0";
                        txtPEM.Text = "0";
                        txtParticipacao.Text = "0";
                        txtTrabalho1.Text = "0";

                        txtPAT.Focus();
                        btnValidacao = "1";
                    }
                    else
                    {
                        string IDNotaBanco = tNota.Rows[0][0].ToString();
                        string PAT = tNota.Rows[0][3].ToString();
                        string PEM = tNota.Rows[0][4].ToString();
                        string Trabalho = tNota.Rows[0][5].ToString();
                        string Participacao = tNota.Rows[0][7].ToString();

                        IDNota = IDNotaBanco;
                        txtPAT.Text = PAT;
                        txtPEM.Text = PEM;
                        txtTrabalho1.Text = Trabalho;
                        txtParticipacao.Text = Participacao;

                        txtPAT.Focus();
                        btnValidacao = "1";
                    }

                }
                else if (rb3Tri.Checked == true)
                {

                    BLL.BLLNota objBLLNota = new BLL.BLLNota();

                    DataTable tNota = objBLLNota.BLLConsultaValidacaoNota3(mtxtRMNotas.Text, IDProfMate);
                    DataGridView dgvNota = new DataGridView();
                    dgvNota.DataSource = tNota;

                    if (tNota.Rows.Count == 0)
                    {
                        objBLLNota.BLLCadastraNota3(mtxtRMNotas.Text, IDProfMate);
                        DataTable tNotaCadastrada = objBLLNota.BLLConsultaValidacaoNota3(mtxtRMNotas.Text, IDProfMate);
                        DataGridView dgvNotaCadastrada = new DataGridView();
                        dgvNotaCadastrada.DataSource = tNotaCadastrada;

                        IDNota = tNotaCadastrada.Rows[0][0].ToString();

                        txtPAT.Text = "0";
                        txtPEM.Text = "0";
                        txtParticipacao.Text = "0";
                        txtTrabalho1.Text = "0";

                        txtPAT.Focus();
                        btnValidacao = "1";

                    }
                    else
                    {
                        string IDNotaBanco = tNota.Rows[0][0].ToString();
                        string PAT = tNota.Rows[0][3].ToString();
                        string PEM = tNota.Rows[0][4].ToString();
                        string Trabalho = tNota.Rows[0][5].ToString();
                        string Participacao = tNota.Rows[0][7].ToString();

                        IDNota = IDNotaBanco;
                        txtPAT.Text = PAT;
                        txtPEM.Text = PEM;
                        txtTrabalho1.Text = Trabalho;
                        txtParticipacao.Text = Participacao;

                        txtPAT.Focus();
                        btnValidacao = "1";
                    }

                }
                else
                {
                    MessageBox.Show("Selecione um Trimestre");
                }
            }
        }


        
                                                                //Consultas


        //Consulta de Aluno DoubleClick
         private void dgvConsultaAluno_DoubleClick(object sender, EventArgs e)
        {
             string RMAluno = dgvConsultaAluno.SelectedRows[0].Cells[0].Value.ToString();

            if (RMAluno == "")
            {
                MessageBox.Show("Selecione um Aluno");
            }
            else
            {

                BLL.BLLAluno objAluno = new BLL.BLLAluno();
                DataGridView dgv = new DataGridView();

                DataTable t = objAluno.BLLConsultaRMAluno(RMAluno);
                dgv.DataSource = t;

                //DataTable t = objAluno.BLLConsultarAlunoRM(Convert.ToDouble(mtxtRMAluno.Text));

                if (t.Rows.Count == 0)
                {
                    MessageBox.Show("Há Algo Errado!");

                }
                else
                {
                    string RM = t.Rows[0][0].ToString();
                    string Nome = t.Rows[0][1].ToString();
                    string CPF = t.Rows[0][2].ToString();
                    string Email = t.Rows[0][3].ToString();
                    string AI = t.Rows[0][4].ToString();
                    string DT = t.Rows[0][5].ToString();
                    string FKTurma = t.Rows[0][6].ToString();

                    BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
                    DataGridView dgvTurma = new DataGridView();
                    DataTable tTurma = objBLLTurma.BLLConsultaTurmaCodigo(FKTurma);

                    string Turma = tTurma.Rows[0][5].ToString();

                    if (AI == "A")
                    {
                        mtxtRMNotas.Text = RM;

                    }
                    else
                    {

                        MessageBox.Show("Alunx Não Cadastrx");

                    }


                }
            }

        }
        
       
        //Consultar Professor ID
        private void GUIConsultarIDProfessor()
        {
            BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
            DataTable tProf = objBLLFunc.BLLConsultaCodigoProfessor(srtID);
            DataGridView dgvProf = new DataGridView();
            dgvProf.DataSource = tProf;

            string NomeProf = tProf.Rows[0][1].ToString();
            string CPFProf = tProf.Rows[0][2].ToString();

            mtxtCodigoProfessor.Text = srtID;
            txtNomeProfessor.Text = NomeProf;
            mtxtCPFProfessor.Text = CPFProf;
            
        }

        //Consulta Professor Perfil
        private void GUIConsultaNomeRelacionamentoPerfilProf()
        {
            BLL.BLLProfessorMateria objBLLProfMate = new BLL.BLLProfessorMateria();
            DataTable tProfMate = objBLLProfMate.BLLConsultaNomeRelacionamentoPerfilProf(srtID);
            dgvProfessorPerfil.DataSource = tProfMate;
        }

        //Consulta de Matéria ComboBox
        private void GUIConsultaMateriaComboBox()
        {
            BLL.BLLProfessorMateria objBLLProfMate = new BLL.BLLProfessorMateria();
            cbMateria.DataSource = objBLLProfMate.BLLConsultaIDProfessor(srtID);
            cbMateria.DisplayMember = "NomeMateria";
            cbMateria.Text = null;

        }

        string IDProfMate = "";
        //Consulta de Turma ComboBox
        private void button4_Click(object sender, EventArgs e)
        {
            if (cbMateria.Text == "")
            {
                MessageBox.Show("Selecione uma Matéria");
            }
            else
            {
                BLL.BLLMateria objBLLMateria = new BLL.BLLMateria();
                DataTable tMateria = objBLLMateria.BLLConsultaNomeMateria(cbMateria.Text);
                DataGridView dgvMateria = new DataGridView();
                dgvMateria.DataSource = tMateria;
                string FKMateria = tMateria.Rows[0][0].ToString();

                BLL.BLLProfessorMateriaTurma objBLLProfMateTurma = new BLL.BLLProfessorMateriaTurma();
                IDProfMate = FKMateria + srtID;
                cbTurma.DataSource = objBLLProfMateTurma.BLLConsultaIDProfMateProfMateTurma(IDProfMate);
                cbTurma.DisplayMember = "NomeTurma";
                cbTurma.Text = null;
            }
        }

        //Consulta de Alunos de Uma Turma
        private void btnokTurma_Click(object sender, EventArgs e)
        {
            if (cbTurma.Text == "")
            {
                MessageBox.Show("Selecione uma Turma");
            }
            else
            {
                BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
                DataTable tTurma = objBLLTurma.BLLConsultaCompletoTurmaCurso(cbTurma.Text);
                DataGridView dgvTurma = new DataGridView();
                dgvTurma.DataSource = tTurma;

                string IDTurma = tTurma.Rows[0][0].ToString();

                BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
                dgvConsultaAluno.DataSource = objBLLAluno.BLLConsultaDGVIDAluno(IDTurma);
                btnValidacao = "";

            }

        }

        //Consulta de Mensagens
        private void GUIConsultaMensagem()
        {
            BLL.BLLMensagem objBLLMensagem = new BLL.BLLMensagem();
            DataTable tMensagem = objBLLMensagem.BLLConsultaMensagem(srtID);
            dgvMensagensMensagens.DataSource = tMensagem;

        }

        //Consulta de Professor ComboBox Nome
        public void GUIConsultaComboBoxProfessor()
        {
            BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();

            cbProfMensagem.DataSource = objBLLFunc.BLLConsultaComboBoxProfessor();
            cbProfMensagem.DisplayMember = "NomeFunc";
            cbProfMensagem.Text = null;
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

        //Consulta Mensagem ID Double Click
        private void dgvMensagensMensagens_DoubleClick(object sender, EventArgs e)
        {
            GUIConsultaIDMensagem();
        }

                                                                //Alterar

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string Trabalho = "";
            if (QuantidadeTrabalho == 1)
            {
                Trabalho = txtTrabalho1.Text;
            }
            else if (QuantidadeTrabalho == 2)
            {
                double Trabalho1 = Convert.ToDouble(txtTrabalho1.Text);
                double Trabalho2 = Convert.ToDouble(txtTrabalho2.Text);

                Trabalho = Convert.ToString((Trabalho1 + Trabalho2)/2);
            }
            else if (QuantidadeTrabalho == 3)
            {
                double Trabalho1 = Convert.ToDouble(txtTrabalho1.Text);
                double Trabalho2 = Convert.ToDouble(txtTrabalho2.Text);
                double Trabalho3 = Convert.ToDouble(txtTrabalho3.Text);

                Trabalho = Convert.ToString((Trabalho1 + Trabalho2 + Trabalho3) / 3);
            }
            else if (QuantidadeTrabalho == 4)
            {
                double Trabalho1 = Convert.ToDouble(txtTrabalho1.Text);
                double Trabalho2 = Convert.ToDouble(txtTrabalho2.Text);
                double Trabalho3 = Convert.ToDouble(txtTrabalho3.Text);
                double Trabalho4 = Convert.ToDouble(txtTrabalho4.Text);

                Trabalho = Convert.ToString((Trabalho1 + Trabalho2 + Trabalho3 + Trabalho4) / 4);
            }


            if (rb1Tri.Checked == true)
            {
                BLL.BLLNota objBLLNota = new BLL.BLLNota();
                objBLLNota.BLLAlteraNota1(IDNota, txtPAT.Text, txtPEM.Text, Trabalho, txtParticipacao.Text);
                MessageBox.Show("Notas Inseridas");
                LimparCamposNotaCadastro();
            }
            else if (rb2Tri.Checked == true)
            {
                BLL.BLLNota objBLLNota = new BLL.BLLNota();
                objBLLNota.BLLAlteraNota2(IDNota, txtPAT.Text, txtPEM.Text, Trabalho, txtParticipacao.Text);
                MessageBox.Show("Notas Inseridas");
                LimparCamposNotaCadastro();
            }
            else if (rb3Tri.Checked == true)
            {
                BLL.BLLNota objBLLNota = new BLL.BLLNota();
                objBLLNota.BLLAlteraNota3(IDNota, txtPAT.Text, txtPEM.Text, Trabalho, txtParticipacao.Text);
                MessageBox.Show("Notas Inseridas");
                LimparCamposNotaCadastro();
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
                LimparCamposConsultaMensagem();
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
                LimparCamposConsultaMensagem();
                txtCodigoMensagem.Text = "";

            }
        }


                                                                //Limpar

        //Limpar Campos Nota
        private void LimparCamposNota()
        {
            cbMateria.Text = null;
            cbTurma.Text = null;
            mtxtRMNotas.Text = "";
            txtPEM.Text = "";
            txtPAT.Text = "";
            txtParticipacao.Text = "";
            cbQtdTrabalho.Text = null;
            txtTrabalho1.Text = "";
            txtTrabalho2.Text = "";
            txtTrabalho2.Text = "";
            txtTrabalho2.Text = "";

            //Labels e TextBox
            lblTrabalho2.Hide();
            txtTrabalho2.Hide();
            lblTrabalho3.Hide();
            txtTrabalho3.Hide();
            lblTrabalho4.Hide();
            txtTrabalho4.Hide();

            BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
            string zero = "0";
            dgvConsultaAluno.DataSource = objBLLAluno.BLLConsultaDGVIDAluno(zero);
        }

        //Limpar Campos Nota Cadastro
        private void LimparCamposNotaCadastro()
        {
            mtxtRMNotas.Text = "";
            txtPEM.Text = "0";
            txtPAT.Text = "0";
            txtParticipacao.Text = "0";
            cbQtdTrabalho.Text = null;
            txtTrabalho1.Text = "0";
            txtTrabalho2.Text = "0";
            txtTrabalho3.Text = "";
            txtTrabalho4.Text = "";

            //Labels e TextBox
            lblTrabalho2.Hide();
            txtTrabalho2.Hide();
            lblTrabalho3.Hide();
            txtTrabalho3.Hide();
            lblTrabalho4.Hide();
            txtTrabalho4.Hide();

        }

        //Limpar Campos Sugestão
        private void LimparCamposSugestao()
        {
            txtMensagemSugestao.Text = "";
            txtMensagemSugestao.Focus();
            string DataSugestao = Convert.ToString(DateTime.Now);
            txtDataSugestao.Text = DataSugestao;
        }

        //Botão Limpar Sugestão
        private void btnLimparSugestao_Click(object sender, EventArgs e)
        {
            LimparCamposSugestao();
        }

        //Limpar Campos Mensagem
        private void LimparCamposConsultaMensagem()
        {

            txtDataProfMensagem.Text = "";
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

        //Botão Limpar Campos Mensagem Consulta Aluno
        private void btnLimparMensagemConsulta_Click(object sender, EventArgs e)
        {
            LimparCamposConsultaMensagem();
        }
        
        //Botão Limpar Campos Mensagem Consulta Professor
        private void button3_Click(object sender, EventArgs e)
        {
            LimparCamposConsultaMensagem();
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

        //Botão Limpar Mensagem
        private void btnLimparMensagem_Click(object sender, EventArgs e)
        {
            LimparCampoMensagem();
        }

                                                                //Outros

        //Quantidade de Trabalhos
        int QuantidadeTrabalho = 1;
        private void btnokQtdTrabalho_Click(object sender, EventArgs e)
        {

            if (cbQtdTrabalho.Text == "2")
            {
                lblTrabalho2.Show();
                txtTrabalho2.Show();
                txtTrabalho2.Text = "0";
                lblTrabalho3.Hide();
                txtTrabalho3.Hide();
                lblTrabalho4.Hide();
                txtTrabalho4.Hide();

                QuantidadeTrabalho = 2;
                cbQtdTrabalho.Text = null;

            }
            else if (cbQtdTrabalho.Text == "3")
            {
                lblTrabalho2.Show();
                txtTrabalho2.Show();
                txtTrabalho2.Text = "0";
                lblTrabalho3.Show();
                txtTrabalho3.Show();
                txtTrabalho3.Text = "0";
                lblTrabalho4.Hide();
                txtTrabalho4.Hide();

                QuantidadeTrabalho = 3;
                cbQtdTrabalho.Text = null;

            }
            else
            {
                lblTrabalho2.Show();
                txtTrabalho2.Show();
                txtTrabalho2.Text = "0";
                lblTrabalho3.Show();
                txtTrabalho3.Show();
                txtTrabalho3.Text = "0";
                lblTrabalho4.Show();
                txtTrabalho4.Show();
                txtTrabalho4.Text = "0";

                QuantidadeTrabalho = 4;
                cbQtdTrabalho.Text = null;

            }

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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

        private void cbMateria_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 objForm1 = new Form1();
            objForm1.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora1.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora2.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora3.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora4.Text = (DateTime.Now.ToString("HH:mm:ss"));

        }










       





 















    }
}
