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
    public partial class frmTatico : MaterialSkin.Controls.MaterialForm
    {
        public frmTatico()
        {
            InitializeComponent();
            //pnlPadrao.Show();
            pnlAluno.Hide();
            pnlTurma.Hide();
            pnlLixeira.Hide();
            pnlProfessorMateria.Hide();
            pnlRelacionamento.Hide();
            pnlNotas.Hide();
            pnlSugestao.Hide();
            pnlHorarios.Hide();

        }

                    //Sumário:
                //Menus
                //Cadastros
                //Consultas
                //Alterações
                //Exclusões
                //Limpar
                //Outros
                //Foto


                                                   //Lembrente

        //Metódos     //Cadastro //Consulta //Alteração //Desativar //Ativar //Exclusão P //Limpar   //Validação  //Outros
        //----------------------------------------------------------------------------------------------------------------
        //Alunos    //    X     //     X    //    X    //   X     //   x    //    X      //    X    //          // Foto
        //Cursos    //    X     //     X    //    X    //   X     //   x    //    X      //    X    //          //    
        //Turmas    //    X     //     X    //    X    //   X     //   x    //    X      //    X    //          //
        //Materias  //    X     //     X    //    X    //   X     //   X    //    X      //    X    //          //
        //Professor //    X     //     X    //    X    //   X     //   X    //    X      //    X    //          //
        //Prof+Mat  //    X     //          //         //         //        //           //    X    //          //
        //PrfMatTur //    X     //          //         //         //        //           //    X    //          //
        //Notas     //          //          //         //         //        //           //         //          //

                                               //A Fazer e Observações

        //Validação Exclusão Não Está Funcionando!!!!!!!!!!!!!!!!!!!
        //Se O Aluno/Turma/Curso Já Estiver Cadastraddo, Fazer Verificação
        //No DGV Aluno, Sair Nome Completo da Turma (INF2FM) com Inner Join
        //No DGV Turma, Sair Nome do Curso
        //fazer horário
        //usar tabcontrol para menu adm

                                                            //Menus

        private void btnMenuAluno_Click(object sender, EventArgs e)
        {

            pnlAluno.Hide();
            pnlTurma.Hide();
            pnlLixeira.Hide();
            pnlRelacionamento.Hide();
            pnlNotas.Hide();
            pnlSugestao.Hide();
            pnlHorarios.Hide();

        }

        //Botão Menu Aluno
        private void button1_Click(object sender, EventArgs e)
        {

            pnlAluno.Show();
            pnlTurma.Hide();
            pnlRelacionamento.Hide();
            pnlNotas.Hide();
            pnlLixeira.Hide();
            pnlHorarios.Hide();
            pnlSugestao.Hide();
            pnlProfessorMateria.Hide();
            GUIConsultaAlunoAtivo();
            GUIBuscarTurma();
            cbTurmaAluno.Text = "";
            LimparCamposAlunos();

            // pnlPadrao.Hide();

        }

        //Botão Menu Turma
        private void btnMenuTurma_Click(object sender, EventArgs e)
        {
            
            pnlTurma.Show();
            pnlAluno.Hide();
            pnlLixeira.Hide();
            pnlRelacionamento.Hide();
            pnlNotas.Hide();
            pnlHorarios.Hide();
            pnlSugestao.Hide();
            pnlProfessorMateria.Hide();
            GUIConsultaCursoAtivoCB();
            GUIConsultaTurmaAtivo();
            GUIConsultaCursoAtivo();
            LimparCamposTurma();
            LimparCamposCurso();
            


        }
        
        //Botão Menu Professor e Matérias
        private void btnMenuMaterias_Click(object sender, EventArgs e)
        {
            pnlTurma.Hide();
            pnlNotas.Hide();
            pnlProfessorMateria.Show();
            pnlAluno.Hide();
            pnlHorarios.Hide();
            pnlLixeira.Hide();
            pnlSugestao.Hide();
            pnlRelacionamento.Hide();
            GUIConsultaCursoAtivocbCursoMateria();
            GUIConsultaAtivoMateria();
            GUIConsultaAtivoProfessor();
            LimparCamposProfessor();
                  
        }

        //Botão Menu Relacionamentos
        private void btnMenuProfessor_Click(object sender, EventArgs e)
        {
            pnlAluno.Hide();
            pnlLixeira.Hide();
            pnlRelacionamento.Show();
            pnlProfessorMateria.Hide();
            pnlNotas.Hide();
            pnlHorarios.Hide();
            pnlSugestao.Hide();
            pnlTurma.Hide();
            GUIConsultaDGVProfMate();
            GUIBuscarTurmaRel();
            GUIConsultaNomeRelacionamentoProfMate();
            GUIConsultaComboBoxMateria();
            GUIConsultaDGVProfMateTurma();
            GUIConsultaComboBoxProfessor();
            
        }
        
        //Botão Menu Nota
        private void btnMenuNota_Click(object sender, EventArgs e)
        {
            pnlTurma.Hide();
            pnlNotas.Show();
            pnlProfessorMateria.Hide();
            pnlAluno.Hide();
            pnlHorarios.Hide();
            pnlLixeira.Hide();
            pnlSugestao.Hide();
            pnlRelacionamento.Hide();
            GUIConsultaAtivoAlunoNota();
            
        }

        //Botão Menu Sugestao
        private void button1_Click_1(object sender, EventArgs e)
        {
            pnlTurma.Hide();
            pnlAluno.Hide();
            pnlNotas.Hide();
            pnlHorarios.Hide();
            pnlAlunoSugestao.Hide();
            pnlProfSugestao.Hide();
            pnlSugestao.Show();
            labelSugestao.Show();
            pnlProfessorMateria.Hide();
            pnlLixeira.Hide();
            LimparCamposSugestao();
            GUIConsultaSugestao();
        }



        //Botão Menu Lixeira
        private void btnMenuLixeira_Click(object sender, EventArgs e)
        {
            pnlTurma.Hide();
            pnlAluno.Hide();
            pnlHorarios.Hide();
            pnlNotas.Hide();
            pnlSugestao.Hide();
            pnlProfessorMateria.Hide();
            pnlLixeira.Show();
            GUIConsultaInativoProfessor();
            GUIConsultaAlunoInativo();
            GUIConsultaTurmaInativo();
            GUIConsultaCursoInativo();
            GUIConsultaInativoMateria();

        }

        //Botão Menu Horários
        private void btnMenuHorarios_Click(object sender, EventArgs e)
        {
            pnlTurma.Hide();
            pnlAluno.Hide();
            pnlHorarios.Show();
            pnlNotas.Hide();
            pnlSugestao.Hide();
            GUIConsultaCursoHorarioConsultaCB();
            pnlProfessorMateria.Hide();
            LimparCamposHorarioConsulta();
            pnlLixeira.Hide();
            GUIConsultaCursoHorarioCB();
        }




                                                            //Cadastros

        //Cadastro de Aluno
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if ((mtxtRMAluno.Text == "") || (txtNomeAluno.Text == "") || (mtxtCPFAluno.Text == "") || (mtxtDTAluno.Text == "") || (cbTurmaAluno.Text == null) || (txtEmailAluno.Text == ""))
            {
                MessageBox.Show("Preenchimento de Campos Incorreto");
            }
            else
            {

                BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();

                DataTable tAlunoRM = objBLLAluno.BLLConsultaRMAluno(mtxtRMAluno.Text);
                DataGridView dgvAlunoRM = new DataGridView();
                dgvAlunoRM.DataSource = tAlunoRM;

                DataTable tAlunoCPF = objBLLAluno.BLLConsultaCPFAluno(mtxtCPFAluno.Text);
                DataGridView dgvAlunoCPF = new DataGridView();
                dgvAlunoCPF.DataSource = tAlunoCPF;

                if ((tAlunoRM.Rows.Count == 0) && tAlunoCPF.Rows.Count == 0) 
                {
                    if (txtDiretorio.Text == "")
                    {
                        MessageBox.Show("Selecione uma Imagem");
                    }
                    else
                    {
                        BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
                        BLL.BLLLogin objBLLLogin = new BLL.BLLLogin();

                        DataTable t = objBLLTurma.BLLConsultaCompletoTurmaCurso(cbTurmaAluno.Text);

                        DataGridView dgv = new DataGridView();
                        dgv.DataSource = t;

                        string IDTurma = t.Rows[0][0].ToString();

                        objBLLAluno.BLLCadastraAluno(mtxtRMAluno.Text, txtNomeAluno.Text, mtxtCPFAluno.Text, txtEmailAluno.Text, "A", mtxtDTAluno.Text, IDTurma);
                        objBLLLogin.BLLCadastroLogin(mtxtRMAluno.Text, "123456", "3");


                        GUICadastraFoto();
                        //Foto();
                        MessageBox.Show("Aluno Cadastrado!");
                        LimparCamposAlunos();
                        GUIConsultaAlunoAtivo();
                    }


                }
                else if ((tAlunoRM.Rows.Count == 0) && (tAlunoCPF.Rows.Count != 0))
                {
                    string RMAluno = tAlunoCPF.Rows[0][0].ToString();
                    MessageBox.Show("CPF Já Cadastrado no Aluno de RM " + RMAluno);
                    mtxtCPFAluno.Focus();
                }
                else
                {
                    MessageBox.Show("RM Já Cadastrado");
                    mtxtRMAluno.Focus();
                }
            }
        }


        //Botão de Cadastro de Turma
        private void btnTurmaCadastroTurma_Click(object sender, EventArgs e)
        {

            if (cbTurmaCurso.Text == "")
            {
                MessageBox.Show("Código de Turma Não Inserido");

            }
            else
            {

                BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
                DataTable t = objBLLCurso.BLLConsultaNomeCurso(cbTurmaCurso.Text);
                DataGridView dgv = new DataGridView();
                dgv.DataSource = t;

                string IDCurso = t.Rows[0][0].ToString();
                string Abreviatura = t.Rows[0][2].ToString();

                BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();

                if (cbTurmaAno.Text == "1º")
                {

                    if (cbTurmaPeriodo.Text == "Manhã")
                    {

                        string CompletoTurma = Abreviatura + "1" + cbTurmaNome.Text + "M";

                     
                        objBLLTurma.BLLCadastroTurma(IDCurso, "1", cbTurmaNome.Text, "M", CompletoTurma, "A");
                        MessageBox.Show("Turma Cadastrada!");



                    }
                    else
                    {

                        string CompletoTurma = Abreviatura + "1" + cbTurmaNome.Text + "T";

                        objBLLTurma.BLLCadastroTurma(IDCurso, "1", cbTurmaNome.Text, "T", CompletoTurma, "A");
                        MessageBox.Show("Turma Cadastrada!");

                    }

                }
                else if (cbTurmaAno.Text == "2º")
                {

                    if (cbTurmaPeriodo.Text == "Manhã")
                    {

                        string CompletoTurma = Abreviatura + "2" + cbTurmaNome.Text + "M";

                        objBLLTurma.BLLCadastroTurma(IDCurso, "2", cbTurmaNome.Text, "M", CompletoTurma, "A");
                        MessageBox.Show("Turma Cadastrada!");



                    }
                    else
                    {

                        string CompletoTurma = Abreviatura + "2" + cbTurmaNome.Text + "T";

                        objBLLTurma.BLLCadastroTurma(IDCurso, "2", cbTurmaNome.Text, "T", CompletoTurma, "A");
                        MessageBox.Show("Turma Cadastrada!");

                    }

                }
                else
                {

                    if (cbTurmaPeriodo.Text == "Manhã")
                    {

                        string CompletoTurma = Abreviatura + "3" + cbTurmaNome.Text + "M";

                        objBLLTurma.BLLCadastroTurma(IDCurso, "3", cbTurmaNome.Text, "M", CompletoTurma, "A");
                        MessageBox.Show("Turma Cadastrada!");



                    }
                    else
                    {

                        string CompletoTurma = Abreviatura + "3" + cbTurmaNome.Text + "T";

                        objBLLTurma.BLLCadastroTurma(IDCurso, "3", cbTurmaNome.Text, "T", CompletoTurma, "A");
                        MessageBox.Show("Turma Cadastrada!");

                    }

                }
            }

            GUIConsultaTurmaAtivo();
            LimparCamposTurma();

        }

        //Botão Cadastro Curso
        private void btnTurmaCadastroCurso_Click(object sender, EventArgs e)
        {
            
            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
            DataTable t = objBLLCurso.BLLConsultaNomeCurso(txtTurmaNomeCurso.Text);
            DataGridView dgv = new DataGridView();

            dgv.DataSource = t;

            if (t.Rows.Count == 0)
            {

                if ((txtTurmaNomeCurso.Text == "") || (mtxtTurmaAbreviaturaCurso.Text == ""))
                {
                    MessageBox.Show("Preencha Os Campos Corretamente");
                }
                else
                {
                    objBLLCurso.BLLCadastraCurso(txtTurmaNomeCurso.Text, mtxtTurmaAbreviaturaCurso.Text.ToUpper(), "A");
                    MessageBox.Show("Curso Cadastrado!");
                    GUIConsultaCursoAtivo();
                    GUIConsultaCursoAtivoCB();
                   
                    DataTable tCurso = objBLLCurso.BLLConsultaNomeCurso(txtTurmaNomeCurso.Text);
                    DataGridView dgvCurso = new DataGridView();
                    dgvCurso.DataSource = tCurso;
                    string IDCurso = tCurso.Rows[0][0].ToString();

                    BLL.BLLFoto objBLLFoto = new BLL.BLLFoto();
                    objBLLFoto.BLLCadastraHorarioFoto("x", IDCurso);

                    LimparCamposCurso();

                }
            }
            else
            {
                MessageBox.Show("Curso Já Cadastrado");
                LimparCamposCurso();
                txtTurmaNomeCurso.Focus();
            }
        }

        //Botão Cadastro Matéria
        private void button6_Click(object sender, EventArgs e)
        {
            BLL.BLLMateria objBLLMateria = new BLL.BLLMateria();

            if ((txtNomeMateria.Text == "") || (cbQuantidadeDeAulas.Text == null))
            {
                MessageBox.Show("Preencha Os Campos Corretamente");
            }
            else
            {
                BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
                DataTable t = objBLLCurso.BLLConsultaNomeCurso(cbCursoMateria.Text);
                DataGridView dgv = new DataGridView();
                dgv.DataSource = t;
                string FKCursoMateria = t.Rows[0][0].ToString();
                
                objBLLMateria.BLLCadastraMateria(txtNomeMateria.Text, cbQuantidadeDeAulas.Text, FKCursoMateria, "A");
                MessageBox.Show("Matéria Cadastrada");
                LimparCamposMateria();
                GUIConsultaAtivoMateria();
                GUIConsultaComboBoxMateria();
                
            }
        }

        //Botão Cadastra Professor
        private void button11_Click(object sender, EventArgs e)
        {

            BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
            BLL.BLLLogin objBLLLogin = new BLL.BLLLogin();

            if ((mtxtCodigoProfessor.Text == "") || (txtNomeProfessor.Text == "") || (mtxtCPFProfessor.Text == ""))
            {
                MessageBox.Show("Preencha Os Campos Corretamente");
            }
            else
            {
                objBLLFunc.BLLCadastraProfessor(mtxtCodigoProfessor.Text, txtNomeProfessor.Text, mtxtCPFProfessor.Text, "A");
                objBLLLogin.BLLCadastroLogin(mtxtCodigoProfessor.Text, "abcdef", "2");
                MessageBox.Show("Professor Cadastrado");
                LimparCamposProfessor();
                GUIConsultaAtivoProfessor();
            }


        }

        //Botão Cadastro Relacionamento Professor Matéria
        private void button5_Click(object sender, EventArgs e)
        {
            if ((cbRelProfessor.Text == "") || (cbRelMateria.Text == ""))
            {
                MessageBox.Show("Preenchimento Incorreto de Campos");
            }
            else
            {
                BLL.BLLProfessorMateria objBLLProfMate = new BLL.BLLProfessorMateria();
                BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
                BLL.BLLMateria objBLLMateria = new BLL.BLLMateria();

                DataTable tProfessor = objBLLFunc.BLLConsultaNomeProfessor(cbRelProfessor.Text);
                DataTable tMateria = objBLLMateria.BLLConsultaNomeMateria(cbRelMateria.Text);

                DataGridView dgvProfessor = new DataGridView();
                dgvProfessor.DataSource = tProfessor;
                DataGridView dgvMateria = new DataGridView();
                dgvMateria.DataSource = tMateria;

                string FKProfessor = tProfessor.Rows[0][0].ToString();
                string FKMateria = tMateria.Rows[0][0].ToString();

                string CBProfessor = cbRelProfessor.Text;
                string CBMateria = cbRelMateria.Text;
                string NomeRelacionamento = CBProfessor + " - " + CBMateria;

                string IDProfMate = FKMateria + FKProfessor;

                objBLLProfMate.BLLCadastroProfMate(IDProfMate, cbRelMateria.Text, NomeRelacionamento, FKMateria, FKProfessor);
                MessageBox.Show("Professor e Matéria Relacionados!");
                LimparCamposRelProfMat();
                GUIConsultaNomeRelacionamentoProfMate();
                GUIConsultaDGVProfMate();

            }

        }

        //Botão Cadastro Relacionamento Professor, Matéria e Turma
        private void btnRelTurma_Click(object sender, EventArgs e)
        {

            if ((cbRelProfMate.Text == "") || (cbRelTurma.Text == "")) 
            {
                MessageBox.Show("Preenchimento Incorreto de Campos");
            }
            else
            {
                BLL.BLLProfessorMateriaTurma objBLLProfMateTurma = new BLL.BLLProfessorMateriaTurma();
                BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
                BLL.BLLProfessorMateria objBLLProfMate = new BLL.BLLProfessorMateria();

                DataTable tTurma = objBLLTurma.BLLConsultaCompletoTurmaCurso(cbRelTurma.Text);
                DataTable tProfMate = objBLLProfMate.BLLConsultaNomeRelacionamentoProfMate(cbRelProfMate.Text);

                DataGridView dgvTurma = new DataGridView();
                dgvTurma.DataSource = tTurma;
                DataGridView dgvProfMate = new DataGridView();
                dgvProfessor.DataSource = tProfMate;

                string FKIDTurma = tTurma.Rows[0][0].ToString();
                string FKIDProfMate = tProfMate.Rows[0][0].ToString();
                string IDProfMateTurma = FKIDProfMate + FKIDTurma;

                objBLLProfMateTurma.BLLCadastroProfMateTurma(IDProfMateTurma, FKIDProfMate, FKIDTurma, cbRelTurma.Text);
                MessageBox.Show("Professor, Matéria e Turmas Relacionados com Sucesso");
                LimparCamposRelProfMateTurma();
                GUIConsultaDGVProfMateTurma();

            }

        }

        //Cadastrar Foto
        private void GUICadastraFoto()
        {
            BLL.BLLFoto objBLLFoto = new BLL.BLLFoto();
            objBLLFoto.BLLCadastraAlunoFoto(txtDiretorio.Text, mtxtRMAluno.Text);

        }

        //Botão Insere Foto Horário
        private void btnInserirFotoHorario_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|AllFiles(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                string foto = dialog.FileName.ToString();
                txtDiretorioHorario.Text = foto;
                pbHorarios.ImageLocation = foto;


            }
        }

        //Botão Cadastra Foto Horário
        private void btnCadastrarHorario_Click(object sender, EventArgs e)
        {
            if ((txtDiretorioHorario.Text == "") || (cbCursoHorario.Text == ""))
            {
                MessageBox.Show("Preenchimento de Campos Incorreto");
            }
            else
            {
                BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
                DataTable tCurso = objBLLCurso.BLLConsultaNomeCurso(cbCursoHorario.Text);
                DataGridView dgvCurso = new DataGridView();
                dgvCurso.DataSource = tCurso;
                string IDCurso = tCurso.Rows[0][0].ToString();

                BLL.BLLFoto objBLLFoto = new BLL.BLLFoto();
                objBLLFoto.BLLAlteraHorarioFoto(txtDiretorioHorario.Text, IDCurso);
                MessageBox.Show("Horário Cadastrado!");
                LimparCamposHorario();

            }
        }

                                                               //Consultas

        //Consulta de Aluno Ativo
        private void GUIConsultaAlunoAtivo()
        {
            BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
            objBLLAluno.BLLConsultaAtivoAluno(dgvConsultaAluno);
        }

        private void GUIExcluiAlunoInativo()
        {

            string RMAluno = dgvConsultaAluno.SelectedRows[0].Cells[0].Value.ToString();

            if ((RMAluno != "") && (mtxtRMAluno.Text != "") && (RMAluno == mtxtRMAluno.Text))
            {

                BLL.BLLAluno objAluno = new BLL.BLLAluno();
                objAluno.BLLDesativaAluno(mtxtRMAluno.Text, "I");
                MessageBox.Show("Excluido");

            }
            else if ((RMAluno != "") && (mtxtRMAluno.Text != "") && (RMAluno != mtxtRMAluno.Text))
            {

                BLL.BLLAluno objAluno = new BLL.BLLAluno();
                objAluno.BLLDesativaAluno(mtxtRMAluno.Text, "I");
                MessageBox.Show("Excluido");

            }
            else if ((RMAluno != "") && (mtxtRMAluno.Text == ""))
            {

                BLL.BLLAluno objAluno = new BLL.BLLAluno();
                objAluno.BLLDesativaAluno(RMAluno, "I");
                MessageBox.Show("Excluido");

            }
            else if ((RMAluno == "") && (mtxtRMAluno.Text == ""))
            {

                MessageBox.Show("Nenhum Aluno Selecionado!");

            }

        }

        //Consulta de Aluno Inativo
        private void GUIConsultaAlunoInativo()
        {

            BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
            objBLLAluno.BLLConsultaInativoAluno(dgvLixeiraAluno);
        }

        //Consulta de Aluno RM
        private void GUIConsultaAlunoRM()
        {

            BLL.BLLAluno objAluno = new BLL.BLLAluno();
            DataGridView dgv = new DataGridView();

            DataTable t = objAluno.BLLConsultaRMAluno(mtxtRMAluno.Text);
            dgv.DataSource = t;

            //DataTable t = objAluno.BLLConsultarAlunoRM(Convert.ToDouble(mtxtRMAluno.Text));

            if (t.Rows.Count == 0)
            {
                MessageBox.Show("Há Algo Errado!");

            }
            else
            {
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

                BLL.BLLFoto objBLLFoto = new BLL.BLLFoto();
                DataGridView dgvFoto = new DataGridView();
                DataTable tFoto = objBLLFoto.BLLConsultaRMFoto(mtxtRMAluno.Text);
                dgvFoto.DataSource = tFoto;

                string Diretorio = tFoto.Rows[0][0].ToString();

                if (AI == "A")
                {
                    txtNomeAluno.Text = Nome;
                    mtxtCPFAluno.Text = CPF;
                    txtEmailAluno.Text = Email;
                    mtxtDTAluno.Text = DT;
                    cbTurmaAluno.Text = Turma;
                    txtDiretorio.Text = Diretorio;
                    pbFotoAluno.Image = new System.Drawing.Bitmap(txtDiretorio.Text);
                }
                else
                {

                    MessageBox.Show("Alunx Não Cadastrx");

                }


            }
        }

        //Botão Consulta de Aluno RM
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            GUIConsultaAlunoRM();
        }

        //Consulta de Aluno RM DoubleClick
        private void dgvConsultaAluno_MouseDoubleClick(object sender, MouseEventArgs e)
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

                    BLL.BLLFoto objBLLFoto = new BLL.BLLFoto();
                    DataGridView dgvFoto = new DataGridView();
                    DataTable tFoto = objBLLFoto.BLLConsultaRMFoto(RMAluno);
                    dgvFoto.DataSource = tFoto;

                    string Diretorio = tFoto.Rows[0][0].ToString();


                    if (AI == "A")
                    {
                        mtxtRMAluno.Text = RM;
                        txtNomeAluno.Text = Nome;
                        mtxtCPFAluno.Text = CPF;
                        txtEmailAluno.Text = Email;
                        mtxtDTAluno.Text = DT;
                        cbTurmaAluno.Text = Turma;
                        txtDiretorio.Text = Diretorio;
                        pbFotoAluno.Image = new System.Drawing.Bitmap(txtDiretorio.Text);

                    }
                    else
                    {

                        MessageBox.Show("Alunx Não Cadastrx");

                    }


                }
            }

        }

        //Consulta de Turma ComboBox CompletoTurma
        public void GUIBuscarTurma()
        {

            BLL.BLLTurma objTurma = new BLL.BLLTurma();

            cbTurmaAluno.DataSource = objTurma.BLLBuscaTurma();
            cbTurmaAluno.DisplayMember = "CompletoTurma";
            cbTurmaAluno.Text = "";

            //cbTurmaAluno.Text = "";

        }

        //Consulta de Turma Relacionamento
        public void GUIBuscarTurmaRel()
        {

            BLL.BLLTurma objTurma = new BLL.BLLTurma();

            cbRelTurma.DataSource = objTurma.BLLBuscaTurma();
            cbRelTurma.DisplayMember = "CompletoTurma";
            cbRelTurma.Text = "";

            //cbTurmaAluno.Text = "";

        }

        //Consulta de Turma Ativa
        private void GUIConsultaTurmaAtivo()
        {

            BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();

            objBLLTurma.BLLConsultaAtivoTurma(dgvTurmaTurma);

        }

        //Consulta de Turma Inativa
        private void GUIConsultaTurmaInativo()
        {

            BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
            objBLLTurma.BLLConsultaInativoTurma(dgvLixeiraTurma);

        }

        //Consulta de Turma Codigo
        private void GUIConsultaTurmaCodigo()
        {

            BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
            DataGridView dgv = new DataGridView();

            string TurmaCodigo = dgvTurmaTurma.SelectedRows[0].Cells[0].Value.ToString();

            if (TurmaCodigo == "")
            {
                MessageBox.Show("Nenhuma Turma Selecionada!");
            }
            else
            {



                DataTable t = objBLLTurma.BLLConsultaTurmaCodigo(TurmaCodigo);
                dgv.DataSource = t;

                string ValidacaoAnoTurma = "";
                string ValidacaoPeriodoTurma = "";

                if (t.Rows.Count == 0)
                {
                    MessageBox.Show("Há Algo Errado!");

                }
                else
                {


                    string ID = t.Rows[0][0].ToString();
                    string FKCursoTurma = t.Rows[0][1].ToString();
                    string AnoTurma = t.Rows[0][2].ToString();
                    string NomeTurma = t.Rows[0][3].ToString();
                    string PeriodoTurma = t.Rows[0][4].ToString();
                    string AI = t.Rows[0][6].ToString();


                    BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
                    DataTable tCurso = objBLLCurso.BLLConsultaIDCurso(FKCursoTurma);
                    DataGridView dgvCurso = new DataGridView();
                    dgv.DataSource = tCurso;

                    string NomeCurso = tCurso.Rows[0][1].ToString();

                    // Validação de Ano
                    if (AnoTurma == "1")
                    {
                        ValidacaoAnoTurma = "1º";
                    }
                    else if (AnoTurma == "2")
                    {
                        ValidacaoAnoTurma = "2º";
                    }
                    else if (AnoTurma == "3")
                    {
                        ValidacaoAnoTurma = "3º";
                    }
                    else
                    {
                        MessageBox.Show("Ano Não Cadastrado");
                    }

                    // Validação de Período
                    if (PeriodoTurma == "M")
                    {
                        ValidacaoPeriodoTurma = "Manhã";
                    }
                    else if (PeriodoTurma == "T")
                    {
                        ValidacaoPeriodoTurma = "Tarde";
                    }

                    if (AI == "A")
                    {
                        txtTurmaCodigo.Text = ID;
                        cbTurmaCurso.Text = NomeCurso;
                        cbTurmaAno.Text = ValidacaoAnoTurma;
                        cbTurmaNome.Text = NomeTurma;
                        cbTurmaPeriodo.Text = ValidacaoPeriodoTurma;

                    }
                    else
                    {

                        MessageBox.Show("Alunx Não Cadastrx");

                    }


                }
            }
        }

        //Botão Consulta Turma Codigo DoubleClick
        private void dgvTurmaTurma_DoubleClick(object sender, EventArgs e)
        {
            GUIConsultaTurmaCodigo();
        }

        //Consulta de Curso Ativo
        private void GUIConsultaCursoAtivo()
        {
            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
            objBLLCurso.BLLConsultaAtivoCurso(dgvCursoCurso);

        }

        private void GUIConsultaCursoInativo()
        {
            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
            objBLLCurso.BLLConsultaInativoCurso(dgvLixeiraCurso);
        }

        //Consulta de Curso Ativo ComboBox NomeCurso
        private void GUIConsultaCursoAtivoCB()
        {

            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();

            cbTurmaCurso.DataSource = objBLLCurso.BLLConsultaAtivoComboBoxCurso();
            cbTurmaCurso.DisplayMember = "NomeCurso";
            cbTurmaCurso.Text = null;


        }

        //Consulta de Curso Ativo ComboBox NomeCurso Horario
        private void GUIConsultaCursoHorarioCB()
        {

            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();

            cbCursoHorario.DataSource = objBLLCurso.BLLConsultaAtivoComboBoxCurso();
            cbCursoHorario.DisplayMember = "NomeCurso";
            cbCursoHorario.Text = null;


        }

        //Consulta de Curso Ativo ComboBox NomeCurso Horario
        private void GUIConsultaCursoHorarioConsultaCB()
        {

            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();

            cbCursoHorarioConsulta.DataSource = objBLLCurso.BLLConsultaAtivoComboBoxCurso();
            cbCursoHorarioConsulta.DisplayMember = "NomeCurso";
            cbCursoHorarioConsulta.Text = null;


        }



        //Consulta de Curso Ativo ComboBox NomeCurso cbCursoMateria
        private void GUIConsultaCursoAtivocbCursoMateria()
        {

            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();

            cbCursoMateria.DataSource = objBLLCurso.BLLConsultaAtivoComboBoxCurso();
            cbCursoMateria.DisplayMember = "NomeCurso";
            cbCursoMateria.Text = null;

        }

        //Botão Consulta de Curso DoubleClick
        private void dgvCursoCurso_DoubleClick(object sender, EventArgs e)
        {

            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
            DataGridView dgv = new DataGridView();

            string CursoCodigo = dgvCursoCurso.SelectedRows[0].Cells[0].Value.ToString();
            if (CursoCodigo == "")
            {
                MessageBox.Show("Nenhum Curso Selecionado");
            }
            else
            {

                DataTable t = objBLLCurso.BLLConsultaIDCurso(CursoCodigo);
                dgv.DataSource = t;

                if (t.Rows.Count == 0)
                {
                    MessageBox.Show("Curso Não Encontrado");
                }
                else
                {

                    string IDCurso = t.Rows[0][0].ToString();
                    string NomeCurso = t.Rows[0][1].ToString();
                    string AbreviaturaCurso = t.Rows[0][2].ToString();

                    txtCursoCodigo.Text = IDCurso;
                    txtTurmaNomeCurso.Text = NomeCurso;
                    mtxtTurmaAbreviaturaCurso.Text = AbreviaturaCurso;

                }
            }
            

        }
        
        //Botão Consulta Professor
        private void button10_Click(object sender, EventArgs e)
        {
            BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
            DataGridView dgv = new DataGridView();

            if (mtxtCodigoProfessor.Text == "")
            {
                MessageBox.Show("Digite o Código do Professor");
                mtxtCodigoProfessor.Focus();

            }
            else
            {
                DataTable t = objBLLFunc.BLLConsultaCodigoProfessor(mtxtCodigoProfessor.Text);

                dgv.DataSource = t;

                if (t.Rows.Count == 0)
                {
                    MessageBox.Show("Professor Não Cadastrado");
                    mtxtCodigoProfessor.Text = "";
                    mtxtCodigoProfessor.Focus();
                }
                else
                {
                    string Nome = t.Rows[0][1].ToString();
                    string CPF = t.Rows[0][2].ToString();
                    string AI = t.Rows[0][3].ToString();

                    if (AI == "I")
                    {
                        MessageBox.Show("Professor Inativo");
                        mtxtCodigoProfessor.Text = "";
                        mtxtCodigoProfessor.Focus();
                    }
                    else
                    {
                        txtNomeProfessor.Text = Nome;
                        mtxtCPFProfessor.Text = CPF;
                    }

                }

            }

        }

        //Consulta Ativo Professor
        private void GUIConsultaAtivoProfessor()
        {
            BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
            objBLLFunc.BLLConsultaAtivoProfessor(dgvProfessor);
        }

        //Consulta Inativo Professor
        private void GUIConsultaInativoProfessor()
        {
            BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
            objBLLFunc.BLLConsultaInativoProfessor(dgvLixeiraProfessor);
        }

        //Botão Consulta de Professor Double Click
        private void dgvProfessor_DoubleClick(object sender, EventArgs e)
        {
            string ID = dgvProfessor.SelectedRows[0].Cells[0].Value.ToString();

            if (ID == "")
            {
                MessageBox.Show("Selecione um Professor");
            }
            else
            {

                BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
                DataTable t = objBLLFunc.BLLConsultaCodigoProfessor(ID);
                DataGridView dgv = new DataGridView();
                dgv.DataSource = t;

                if (t.Rows.Count == 0)
                {
                    MessageBox.Show("Funcionário Não Encontrado");
                }
                else
                {
                    string IDBanco = t.Rows[0][0].ToString();
                    string Nome = t.Rows[0][1].ToString();
                    string CPF = t.Rows[0][2].ToString();

                    mtxtCodigoProfessor.Text = IDBanco;
                    txtNomeProfessor.Text = Nome;
                    mtxtCPFProfessor.Text = CPF;

                }
            }
        }

        //Consulta Ativo Materia
        public void GUIConsultaAtivoMateria()
        {
            BLL.BLLMateria objBLLMateria = new BLL.BLLMateria();
            objBLLMateria.BLLConsultaAtivoMateria(dgvMateria);
        }

        //Consulta Inativo Materia
        public void GUIConsultaInativoMateria()
        {
            BLL.BLLMateria objBLLMateria = new BLL.BLLMateria();
            objBLLMateria.BLLConsultaInativoMateria(dgvLixeiraMateria);
        }

        //Consulta Codigo Materia DoubleClick
        private void dgvMateria_DoubleClick(object sender, EventArgs e)
        {
            string ID = dgvMateria.SelectedRows[0].Cells[0].Value.ToString();

            if (ID == "")
            {
                MessageBox.Show("Selecione Uma Matéria");
            }
            else
            {
                BLL.BLLMateria objBLLMateria = new BLL.BLLMateria();
                DataTable t = objBLLMateria.BLLConsultaCodigoMateria(ID);
                DataGridView dgv = new DataGridView();
                dgv.DataSource = t;

                if (t.Rows.Count == 0)
                {
                    MessageBox.Show("Materia Não Encontrada");
                }
                else
                {
                    string IDBanco = t.Rows[0][0].ToString();
                    string Nome = t.Rows[0][1].ToString();
                    string Quantidade = t.Rows[0][2].ToString();
                    string FKCurso = t.Rows[0][3].ToString();
                    string AI = t.Rows[0][4].ToString();

                    BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
                    DataTable tCurso = objBLLCurso.BLLConsultaIDCurso(FKCurso);
                    DataGridView dgvCurso = new DataGridView();
                    dgvCurso.DataSource = tCurso;
                    string NomeCurso = tCurso.Rows[0][1].ToString();

                    txtCodigoMateria.Text = IDBanco;
                    txtNomeMateria.Text = Nome;
                    cbQuantidadeDeAulas.Text = Quantidade;
                    cbCursoMateria.Text = NomeCurso;

                }

            }
        }


        //Consulta de Materia ComboBox Nome
        public void GUIConsultaComboBoxMateria()
        {

            BLL.BLLMateria objBLLMateria = new BLL.BLLMateria();

            cbRelMateria.DataSource = objBLLMateria.BLLConsultaComboBoxMateria();
            cbRelMateria.DisplayMember = "NomeMateria";
            cbRelMateria.Text = null;
        }

        //Consulta de Professor ComboBox Nome
        public void GUIConsultaComboBoxProfessor()
        {
            BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();

            cbRelProfessor.DataSource = objBLLFunc.BLLConsultaComboBoxProfessor();
            cbRelProfessor.DisplayMember = "NomeFunc";
            cbRelProfessor.Text = null;
        }

        //Consulta Prof Materia
        private void GUIConsultaNomeRelacionamentoProfMate()
        {
            BLL.BLLProfessorMateria objBLLProfMate = new BLL.BLLProfessorMateria();

            cbRelProfMate.DataSource = objBLLProfMate.BLLConsultaProfMate();
            cbRelProfMate.DisplayMember = "NomeRelacionamento";
            cbRelProfMate.Text = "";

        }

        //Consulta de Aluno Ativo Nota
        private void GUIConsultaAtivoAlunoNota()
        {
            BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
            objBLLAluno.BLLConsultaAtivoAluno(dgvAlunoNota);
        }

        //Consulta de Sugestão
        private void GUIConsultaSugestao()
        {
            BLL.BLLSugestao objBLLSugestao = new BLL.BLLSugestao();
            objBLLSugestao.BLLConsultaSugestao(dataGridView1);
        }

        //Consulta de Sugestão ID
        private void GUIConsultaIDSugestao()
        {
            string IDSugestao = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            BLL.BLLSugestao objBLLSugestao = new BLL.BLLSugestao();
            DataTable tSugestao = objBLLSugestao.BLLConsultaIDSugestao(IDSugestao);
            DataGridView dgvSugestao = new DataGridView();
            dgvSugestao.DataSource = tSugestao;

            if (tSugestao.Rows.Count == 0)
            {
                MessageBox.Show("Sugestão Não Encontrada");
            }
            else
            {
                string FKSugestao = tSugestao.Rows[0][1].ToString();
                string Data = tSugestao.Rows[0][2].ToString();
                string Mensagem = tSugestao.Rows[0][3].ToString();

                BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
                DataTable tAluno = objBLLAluno.BLLConsultaRMAluno(FKSugestao);
                DataGridView dgvAluno = new DataGridView();
                dgvAluno.DataSource = tAluno;

                if (tAluno.Rows.Count == 0)
                {
                    BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
                    DataTable tProf = objBLLFunc.BLLConsultaCodigoProfessor(FKSugestao);
                    DataGridView dgvProf = new DataGridView();
                    dgvProf.DataSource = tProf;

                    string NomeProfessor = tProf.Rows[0][1].ToString();

                    labelSugestao.Hide();
                    pnlAlunoSugestao.Hide();
                    pnlProfSugestao.Show();
                    txtNomeProfSugestao.Text = NomeProfessor;
                    txtDataProfSugestao.Text = Data;
                    txtMensagemProfSugestao.Text = Mensagem;


                    //MessageBox.Show("Aluno Não Encontrado");
                }
                else
                {
                    string Nome = tAluno.Rows[0][1].ToString();
                    string FKIDTurma = tAluno.Rows[0][6].ToString();

                    BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
                    DataTable tTurma = objBLLTurma.BLLConsultaTurmaCodigo(FKIDTurma);
                    DataGridView dgvTurma = new DataGridView();
                    dgvTurma.DataSource = tTurma;

                    if (tTurma.Rows.Count == 0)
                    {
                        MessageBox.Show("Turma Não Encontrada");
                    }
                    else
                    {
                        string CompletoTurma = tTurma.Rows[0][5].ToString();

                        labelSugestao.Hide();
                        pnlAlunoSugestao.Show();
                        pnlProfSugestao.Hide();
                        txtRMSugestao.Text = FKSugestao;
                        txtNomeSugestao.Text = Nome;
                        txtTurmaSugestao.Text = CompletoTurma;
                        txtDataSugestao.Text = Data;
                        txtMensagemSugestao.Text = Mensagem;

                    }


                }

            }


        }

        //Botão Consulta Sugestão Double Click
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            GUIConsultaIDSugestao();
        }

        //Consulta Prof Mate
        private void GUIConsultaDGVProfMate()
        {
            BLL.BLLProfessorMateria objBLLProfMate = new BLL.BLLProfessorMateria();
            objBLLProfMate.BLLConsultaDGVProfMate(dgvProfMate);
        }

        //Consulta Professor Matéria Turma
        private void GUIConsultaDGVProfMateTurma()
        {
            BLL.BLLProfessorMateriaTurma objBLLProfMateTurma = new BLL.BLLProfessorMateriaTurma();
            objBLLProfMateTurma.BLLConsultaViewProfMateTurma(dgvProfMateTurma);
        }


        //Botão Consulta de Foto Horário
        private void btnConsultarHorario_Click(object sender, EventArgs e)
        {
            if (cbCursoHorarioConsulta.Text == "")
            {
                MessageBox.Show("Selecione um Curso");
            }
            else
            {

                BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
                DataTable tCurso = objBLLCurso.BLLConsultaNomeCurso(cbCursoHorarioConsulta.Text);
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
                    cbCursoHorarioConsulta.Text = null;
                }
                else
                {

                    string Diretorio = tFoto.Rows[0][0].ToString();
                    txtDiretorioHorarioConsulta.Text = Diretorio;
                    pbConsultaHorarios.Image = new System.Drawing.Bitmap(txtDiretorioHorarioConsulta.Text);
                }
            }

        }



                                                         //Alterar

        //Alteração do Aluno
        public void GUIAlteraAluno()
        {
            BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
            DataTable t = objBLLTurma.BLLConsultaCompletoTurmaCurso(cbTurmaAluno.Text);

            DataGridView dgv = new DataGridView();
            dgv.DataSource = t;

            string IDTurma = t.Rows[0][0].ToString();

            if (mtxtRMAluno.Text == "")
            {

                MessageBox.Show("Aluno Não Encontrado");

            }
            else
            {
                BLL.BLLAluno objAluno = new BLL.BLLAluno();

                objAluno.BLLAlteraAluno(mtxtRMAluno.Text, txtNomeAluno.Text, mtxtCPFAluno.Text, txtEmailAluno.Text, mtxtDTAluno.Text, IDTurma);
                MessageBox.Show("Dados Atualizados");
                LimparCamposAlunos();

            }
        }

        //Botão Alteração de Aluno
        private void btnAltera_Click(object sender, EventArgs e)
        {
            GUIAlteraAluno();
            GUIConsultaAlunoAtivo();
        }

        //Altera Ativo/Inativo Aluno Para Ativo
        private void GUIAtivaAluno()
        {

            DAO.Aluno objAluno = new DAO.Aluno();
            string RMAluno = dgvLixeiraAluno.SelectedRows[0].Cells[0].Value.ToString();
            //string RMAluno = objAluno.RMAlunoConsulta;

            BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
            objBLLAluno.BLLAtivaAluno(RMAluno, "A");
            MessageBox.Show("Ativado");

        }

        //Botão Altera Ativo/Inativo Aluno Para Ativo
        private void btnLixeiraAtivaAluno_Click(object sender, EventArgs e)
        {
            GUIAtivaAluno();
            GUIConsultaAlunoInativo();

        }

        //Botão Altera Ativo/Inativo Aluno Para Inativo 
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            GUIExcluiAlunoInativo();
            GUIConsultaAlunoAtivo();
            LimparCamposAlunos();
        }

        //Alteração de Turma
        private void GUIAlteraTurma()
        {

            BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
            DataGridView dgv = new DataGridView();

            string CompletoTurma = "";
            string TurmaAno = "";
            string TurmaPeriodo = "";

            //Validação de Ano
            if (cbTurmaAno.Text == "1º")
            {
                TurmaAno = "1";
            }
            else if (cbTurmaAno.Text == "2º")
            {
                TurmaAno = "2";
            }
            else if (cbTurmaAno.Text == "3º")
            {
                TurmaAno = "3";
            }
            else
            {
                MessageBox.Show("Ano Em Formato Inválido");
            }

            //Validação de Periodo
            if (cbTurmaPeriodo.Text == "Manhã")
            {
                TurmaPeriodo = "M";
            }
            else if (cbTurmaPeriodo.Text == "Tarde")
            {
                TurmaPeriodo = "T";
            }
            else
            {
                MessageBox.Show("Ano Em Formato Inválido");
            }
            
            DataTable t = objBLLCurso.BLLConsultaNomeCurso(cbTurmaCurso.Text);
            dgv.DataSource = t;

            if(t.Rows.Count == 0){

                MessageBox.Show("Curso Não Encontrado");
                
            } 
            else 
            {

            string IDCurso = t.Rows[0][0].ToString();
            string AbreviaturaCurso = t.Rows[0][2].ToString();

            CompletoTurma = AbreviaturaCurso + TurmaAno + cbTurmaNome.Text + TurmaPeriodo;


            objBLLTurma.BLLAlteraTurma(txtTurmaCodigo.Text, IDCurso, TurmaAno, cbTurmaNome.Text, TurmaPeriodo, CompletoTurma, "A");

            MessageBox.Show("Turma Alterada!");
            
            }

        }

        //Botão Altera Turma
        private void btnTurmaAlteraTurma_Click(object sender, EventArgs e)
        {
            GUIAlteraTurma();
            GUIConsultaTurmaAtivo();
            LimparCamposTurma();
        }

        //Botão Altera Ativo/Inativo Turma Para Ativo
        private void btnLixeiraAtivaTurma_Click(object sender, EventArgs e)
        {

            string CodigoTurma = dgvLixeiraTurma.SelectedRows[0].Cells[0].Value.ToString();

            BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
            objBLLTurma.BLLAtivaTurma(CodigoTurma, "A");
            MessageBox.Show("Turma Ativada");
            GUIConsultaTurmaInativo();

        }


        //Botão Altera Ativo/Inativo Turma Para Inativo
        private void btnTurmaExcluiTurma_Click(object sender, EventArgs e)
        {

            if (txtTurmaCodigo.Text == "")
            {

                MessageBox.Show("Código de Turma Não Inserido");

            }
            else
            {


                BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
                objBLLTurma.BLLDesativaTurma(txtTurmaCodigo.Text, "I");
                GUIConsultaTurmaAtivo();
                LimparCamposTurma();

            }

        }

        //Altera Curso
        private void GUIAlteraCurso()
        {
            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();

            if (txtCursoCodigo.Text == "")
            {
                MessageBox.Show("Selecione um Curso");
            }
            else
            {
                objBLLCurso.BLLAlteraCurso(txtCursoCodigo.Text, txtTurmaNomeCurso.Text, mtxtTurmaAbreviaturaCurso.Text.ToUpper());
                MessageBox.Show("Curso Alterado");
                GUIConsultaCursoAtivo();
            }
        }

        //Botão Altera Curso
        private void btnTurmaAlteraCurso_Click(object sender, EventArgs e)
        {
            GUIAlteraCurso();
            GUIConsultaCursoAtivoCB();
        }
        //Altera Ativo/Inativo Curso Para Ativo
        public void GUIAtivaCurso()
        {
            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
            BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
            DataGridView dgv = new DataGridView();

            string IDCurso = dgvLixeiraCurso.SelectedRows[0].Cells[0].Value.ToString();

            //DataTable t = objBLLCurso.BLLConsultaIDCompletoCurso(IDCurso);
            objBLLCurso.BLLAtivaCurso(IDCurso);
            //dgv.DataSource = t;

            //string Data = t.Rows[0][4].ToString();

            //objBLLTurma.BLLAtivaDataDeExclusaoTurma(IDCurso, Data);



            MessageBox.Show("Curso Ativado");
            GUIConsultaCursoInativo();
            GUIConsultaTurmaInativo();
            

        }

        //Botão Altera Ativo/Inativo Curso Para Ativo
        private void btnLixeiraAtivaCurso_Click(object sender, EventArgs e)
        {
            GUIAtivaCurso();
        }

        //Altera Ativo/Inativo Curso Para Inativo
        private void BLLDesativaCurso()
        {
            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
            BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();

            if (txtCursoCodigo.Text == "")
            {
                MessageBox.Show("Selecione Um Curso");
            }
            else
            {
                string DataDeExclusao = Convert.ToString(DateTime.Now);

                objBLLCurso.BLLDesativaDataDeExclusaoCurso(txtCursoCodigo.Text);
                objBLLCurso.BLLAlteraDataDeExclusaoCurso(txtCursoCodigo.Text, DataDeExclusao);
                objBLLTurma.BLLDesativaDataDeExclusaoTurma(txtCursoCodigo.Text);
                objBLLTurma.BLLAlteraDataDeExclusaoTurma(txtCursoCodigo.Text, DataDeExclusao);


                MessageBox.Show("Curso Excluido");

                GUIConsultaCursoAtivo();
                GUIConsultaTurmaAtivo();
                LimparCamposCurso();

            }
        }

        //Botão Altera Ativo/Inativo Curso Para Inativo
        private void btnTurmaExcluiCurso_Click(object sender, EventArgs e)
        {
            BLLDesativaCurso();
            GUIConsultaCursoAtivoCB();
        }

        //Botão Desativa Professor
        private void btnDesativaProfessor_Click(object sender, EventArgs e)
        {
            if (mtxtCodigoProfessor.Text == "")
            {
                MessageBox.Show("Digite o Código do Professor");
                mtxtCodigoProfessor.Focus();
            }
            else
            {
                BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
                objBLLFunc.BLLDesativaProfessor(mtxtCodigoProfessor.Text);
                MessageBox.Show("Professor Desativado");
                GUIConsultaAtivoProfessor();
                LimparCamposProfessor();

            }
        }

        //Botão Ativa Professor
        private void btnLixeiraAtivaProfessor_Click(object sender, EventArgs e)
        {
            string ID = dgvLixeiraProfessor.SelectedRows[0].Cells[0].Value.ToString();
            if (ID == "")
            {
                MessageBox.Show("Selecione um Professor");
            }
            else
            {
                BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
                objBLLFunc.BLLAtivaProfessor(ID);
                MessageBox.Show("Professor Ativado");
                GUIConsultaInativoProfessor();
            }
        }

        //Botão Altera Professor
        private void btnAlteraProfessor_Click(object sender, EventArgs e)
        {
            if (mtxtCodigoProfessor.Text == "")
            {
                MessageBox.Show("Digite o Código do Professor");
                mtxtCodigoProfessor.Focus();
            }
            else
            {
                BLL.BLLFuncionario objFunc = new BLL.BLLFuncionario();
                objFunc.BLLAlteraProfessor(mtxtCodigoProfessor.Text, txtNomeProfessor.Text, mtxtCPFProfessor.Text);
                MessageBox.Show("Professor Alterado");
                GUIConsultaAtivoProfessor();
                LimparCamposProfessor();
            }
        }

        //Botão Altera Para Inativo Materia
        private void button4_Click(object sender, EventArgs e)
        {
            if (txtCodigoMateria.Text == "")
            {
                MessageBox.Show("Código da Matéria Não Encontrado");
            }
            else
            {
                BLL.BLLMateria objBLLMateria = new BLL.BLLMateria();
                objBLLMateria.BLLDesativaMateria(txtCodigoMateria.Text);
                MessageBox.Show("Matéria Excluida");
                GUIConsultaAtivoMateria();
                LimparCamposMateria();
                GUIConsultaComboBoxMateria();
            }
        }

        //Botão Altera Para Ativo Materia
        private void btnLixeiraAtivaMateria_Click(object sender, EventArgs e)
        {
            string ID = dgvLixeiraMateria.SelectedRows[0].Cells[0].Value.ToString();

            if (ID == "")
            {
                MessageBox.Show("Selecione uma Matéria");
            }
            else
            {
                BLL.BLLMateria objBLLMateria = new BLL.BLLMateria();
                objBLLMateria.BLLAtivaMateria(ID);
                MessageBox.Show("Materia Ativada");
                GUIConsultaInativoMateria();
            }
        }

        //Botão Altera Materia
        private void button2_Click(object sender, EventArgs e)
        {
            if(txtCodigoMateria.Text == "")
            {
                MessageBox.Show("Selecione uma Matéria");
            }
            else
            {
                
                BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
                DataTable t = objBLLCurso.BLLConsultaNomeCurso(cbCursoMateria.Text);
                DataGridView dgv = new DataGridView();
                dgv.DataSource = t;

                if(t.Rows.Count == 0)
                {
                    MessageBox.Show("Máteria Não Encontrada");
                }
                else
                {
                string FK = t.Rows[0][0].ToString();
                BLL.BLLMateria objBLLMateria = new BLL.BLLMateria();
                objBLLMateria.BLLAlteraMateria(txtCodigoMateria.Text, txtNomeMateria.Text, cbQuantidadeDeAulas.Text, FK, "A");
                MessageBox.Show("Máteria Alterada");
                GUIConsultaAtivoMateria();
                LimparCamposMateria();
                GUIConsultaComboBoxMateria();

                }
            }
        }


                                                            //Excluir


        //Exclusão Aluno 
        private void GUIExcluiAluno()
        {
            DAO.Aluno objAluno = new DAO.Aluno();
            string RMAluno = dgvLixeiraAluno.SelectedRows[0].Cells[0].Value.ToString();

            if (RMAluno == "")
            {
                MessageBox.Show("Selecione um Aluno");
            }
            else
            {



                DialogResult confirm = MessageBox.Show("Deseja Continuar? O Aluno Será Excluido PERMANENTEMENTE!", "Excluir Permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (confirm.ToString().ToUpper() == "YES")
                {

                    BLL.BLLAluno objBLLAluno = new BLL.BLLAluno();
                    objBLLAluno.BLLExcluiAluno(RMAluno);

                }
            }

        }

        //Botão de Exclusão Aluno
        private void btnLixeiraExcluiAluno_Click(object sender, EventArgs e)
        {

            GUIExcluiAluno();
            GUIConsultaAlunoInativo();

        }

        //Exclusão Turma
        private void GUIExcluiTurma()
        {

            BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();
            string Codigo = dgvLixeiraTurma.SelectedRows[0].Cells[0].Value.ToString();

            if (Codigo == "")
            {
                MessageBox.Show("Selecione uma Turma");
            }
            else
            {

                DialogResult confirm = MessageBox.Show("Deseja Continuar? A Turma Será Excluida PERMANENTEMENTE!", "Excluir Permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (confirm.ToString().ToUpper() == "YES")
                {

                    objBLLTurma.BLLExcluiTurma(Codigo);
                    GUIConsultaTurmaInativo();

                }

            }
        }

        //Botão Exclusão Turma
        private void btnLixeiraExcluiTurma_Click(object sender, EventArgs e)
        {

            GUIExcluiTurma();

        }

        //Exclusão Curso
        private void GUIExcluiCurso()
        {
            BLL.BLLCurso objBLLCurso = new BLL.BLLCurso();
            BLL.BLLTurma objBLLTurma = new BLL.BLLTurma();

            string ID = dgvLixeiraCurso.SelectedRows[0].Cells[0].Value.ToString();

            if (ID == "")
            {
                MessageBox.Show("Selecione um Curso");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Deseja Continuar? O Curso Será Excluido PERMANENTEMENTE!", "Excluir Permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (confirm.ToString().ToUpper() == "YES")
                {
                    objBLLTurma.BLLExcluiCursoTurma(ID);
                    objBLLCurso.DAOExcluiCurso(ID);
                    GUIConsultaCursoInativo();
                    GUIConsultaTurmaInativo();
                }
            }
        }

        //Botão Exclusão Curso
        private void btnLixeiraExcluiCurso_Click(object sender, EventArgs e)
        {
            GUIExcluiCurso();
        }

        //Botão Exclusão Professor
        private void btnLixeiraExcluiProfessor_Click(object sender, EventArgs e)
        {
            BLL.BLLFuncionario objBLLFunc = new BLL.BLLFuncionario();
            string ID = dgvLixeiraProfessor.SelectedRows[0].Cells[0].Value.ToString();

            if (ID == "")
            {
                MessageBox.Show("Selecione um Professor");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Deseja Continuar? O Professor Será Excluido PERMANENTEMENTE!", "Excluir Permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (confirm.ToString().ToUpper() == "YES")
                {
                    objBLLFunc.DAOExcluiProfessor(ID);
                    GUIConsultaInativoProfessor();
                }
            }
        }

        //Botão Exclusão Mateira
        private void btnLixeiraExcluiMateria_Click(object sender, EventArgs e)
        {
            BLL.BLLMateria objBLLMateria = new BLL.BLLMateria();
            string ID = dgvLixeiraMateria.SelectedRows[0].Cells[0].Value.ToString();

            if (ID == "")
            {
                MessageBox.Show("Selecione uma Matéria");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Deseja Continuar? A Matéria Será Excluido PERMANENTEMENTE!", "Excluir Permanentemente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
               
                if (confirm.ToString().ToUpper() == "YES")
                {
                   objBLLMateria.BLLExcluiMateria(ID);
                   GUIConsultaInativoMateria();
                   MessageBox.Show("Materia Excluida");
                }
            }
        }

       
                                                            //Limpar

        //Limpar Campos Aluno
        private void LimparCamposAlunos()
        {
            mtxtRMAluno.Text = "";
            txtNomeAluno.Text = "";
            mtxtCPFAluno.Text = "";
            mtxtDTAluno.Text = "";
            txtEmailAluno.Text = "";
            cbTurmaAluno.Text = null;
            txtDiretorio.Text = "";
            pbFotoAluno.Image = null;


        }

        //Botão Limpar Campos do Aluno
        private void btnLimpar_Click(object sender, EventArgs e)
        {

            LimparCamposAlunos();

        }

        //Limpar Campos Turma
        private void LimparCamposTurma()
        {

            txtTurmaCodigo.Text = "";
            cbTurmaCurso.Text = null;
            cbTurmaAno.Text = null;
            cbTurmaNome.Text = null;
            cbTurmaPeriodo.Text = null;


        }


        //Botão Limpar Campos Turmas
        private void btnTurmaLimpaTurma_Click(object sender, EventArgs e)
        {
            LimparCamposTurma();
        }

        //Limpar Campos Curso
        private void LimparCamposCurso()
        {

            txtCursoCodigo.Text = "";
            txtTurmaNomeCurso.Text = "";
            mtxtTurmaAbreviaturaCurso.Text = "";

        }

        //Botão Limpar Campos Curso
        private void btnTurmaLimpaCurso_Click(object sender, EventArgs e)
        {
            LimparCamposCurso();
        }

        //Limpar Campos Professor
        private void LimparCamposProfessor()
        {
            mtxtCodigoProfessor.Text = "";
            txtNomeProfessor.Text = "";
            mtxtCPFProfessor.Text = "";

        }

        //Botão Limpar Campos Professor
        private void button8_Click(object sender, EventArgs e)
        {
            LimparCamposProfessor();
        }

        private void LimparCamposMateria()
        {
            txtCodigoMateria.Text = "";
            txtNomeMateria.Text = "";
            cbQuantidadeDeAulas.Text = null;
            cbCursoMateria.Text = null;
        }

        //Botão Limpar Campos Matérias
        private void button3_Click(object sender, EventArgs e)
        {
            LimparCamposMateria();
        }

        //Limpar Campos Relacionamento Professor e Materia
        private void LimparCamposRelProfMat()
        {
            cbRelMateria.Text = null;
            cbRelProfessor.Text = null;
        }

        //Botão Limpar Campos Relacionamento Prof e Mate
        private void btnLimparRelProMate_Click(object sender, EventArgs e)
        {
            LimparCamposRelProfMat();
        }

        //Limpar Campos Relacionamento Prof Mate e Turma
        private void LimparCamposRelProfMateTurma()
        {
            cbRelProfMate.Text = null;
            cbRelTurma.Text = null;
        }


        //Botão Limpar Campos Relacionamentos Prof, Mate e Turma
        private void btnLimparRelProfMateTurma_Click(object sender, EventArgs e)
        {
            LimparCamposRelProfMateTurma();
        }

        //Limpar Campos Sugestão
        private void LimparCamposSugestao()
        {
            txtRMSugestao.Text = "";
            txtNomeSugestao.Text = "";
            txtTurmaSugestao.Text = "";
            txtDataSugestao.Text = "";
            txtMensagemSugestao.Text = "";
            txtNomeProfSugestao.Text = "";
            txtDataProfSugestao.Text = "";
            txtMensagemProfSugestao.Text = "";
        }

        //Botão Limpar Campos Sugestão Aluno
        private void button12_Click(object sender, EventArgs e)
        {
            LimparCamposSugestao();
        }

        //Botão Limpar Campos Sugestão Professor
        private void btnLimparProfSugestao_Click(object sender, EventArgs e)
        {
            LimparCamposSugestao();
        }

        //Limpar Campos Horários
        private void LimparCamposHorario()
        {
            cbCursoHorario.Text = null;
            pbHorarios.Image = null;
            txtDiretorioHorario.Text = "";
        }

        //Limpar Campos Horários Consulta
        private void LimparCamposHorarioConsulta()
        {
            cbCursoHorarioConsulta.Text = null;
            pbConsultaHorarios.Image = null;
            txtDiretorioHorarioConsulta.Text = "";
        }

        //Botão Limpar Campos Horários Consulta
        private void btnLimparHorario_Click(object sender, EventArgs e)
        {
            LimparCamposHorarioConsulta();
        }

                                                           //Outros

        //Sair
        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 objForm1 = new Form1();
            objForm1.Show();
            this.Hide();
        }

        private void pnlTurma_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPreenche_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1 objForm = new Form1();
            objForm.Show();
            this.Hide();

        }

        private void dgvLixeiraAluno_DoubleClick(object sender, EventArgs e)
        {

            //DAO.Aluno objAluno = new DAO.Aluno();
            //objAluno.RMAlunoConsulta = dgvLixeiraAluno.SelectedRows[0].Cells[0].Value.ToString();

        }

        private void btnTurmaConsultaTurma_Click(object sender, EventArgs e)
        {

        }

        private void txtTurmaAbreviaturaCurso_TextChanged(object sender, EventArgs e)
        {

        }



                                                                //Foto

        //Pesquisa de Foto
        private void btnInsereFoto_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|AllFiles(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                string foto = dialog.FileName.ToString();
                txtDiretorio.Text = foto;
                pbFotoAluno.ImageLocation = foto;


            }

        }



        //Cadastro de Foto
        private void Foto()
        {

            byte[] FotoByte = null;

            FileStream fstream = new FileStream(this.txtDiretorio.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);

            FotoByte = br.ReadBytes((int)fstream.Length);


            string sintax = "INSERT INTO TCC.TBAlunoFoto(Foto, FKRMAluno)" +
                "VALUES(:Foto, :FKRMAluno)";
            string connectionCOM = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LOCALHOST)(PORT=1521)))(CONNECT_DATA=(SID=xe)));User ID=SYS;Password=123456; DBA Privilege=SYSDBA;";
            OracleConnection Conexao = new OracleConnection(connectionCOM);
            OracleCommand Comando = new OracleCommand(sintax, Conexao);

            OracleDataReader dr;

            try
            {

                Conexao.Open();
                Comando.Parameters.Add(new OracleParameter("@Foto", FotoByte));
                Comando.Parameters.Add(new OracleParameter("@FKRMAluno", mtxtRMAluno.Text));

                dr = Comando.ExecuteReader();
                MessageBox.Show("Imagem Inserida!");

            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {

                Conexao.Close();

            }


        }

        //Consulta de Foto
        private void BuscaFoto(int FK)
        {
            string connectionCOM = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LOCALHOST)(PORT=1521)))(CONNECT_DATA=(SID=xe)));User ID=SYS;Password=123456; DBA Privilege=SYSDBA;";
            OracleConnection Conexao = new OracleConnection(connectionCOM);
            OracleCommand Comando = new OracleCommand("SELECT FOTO FROM tcc.tbAlunoFoto WHERE FKRMAluno = " + FK, Conexao);

            OracleDataReader meu_dr;

            try
            {
                Conexao.Open();

                meu_dr = Comando.ExecuteReader();
                byte[] imagem = (byte[])(meu_dr["Foto"]);

                if (imagem == null)
                {
                    pbFotoAluno.Image = null;
                }
                else
                {
                    MemoryStream mstrem = new MemoryStream(imagem);
                    pbFotoAluno.Image = System.Drawing.Image.FromStream(mstrem);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sairToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form1 objForm1 = new Form1();
            objForm1.Show();
            this.Hide();
        }

        private void sairToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form1 objForm1 = new Form1();
            objForm1.Show();
            this.Hide();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora1.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora9.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora3.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora4.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora5.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora6.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora7.Text = (DateTime.Now.ToString("HH:mm:ss"));
            lblHora8.Text = (DateTime.Now.ToString("HH:mm:ss"));

        }

        private void pnlProfessorMateria_Paint(object sender, PaintEventArgs e)
        {

        }
















      






    

































    }
}

