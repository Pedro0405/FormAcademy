using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace csharp_Sqlite
{
    public class DalHelper
    {
        private static SQLiteConnection sqliteConnection;
        public DalHelper()
        { }
        public DataTable Cliente = new DataTable();



        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=c:\\dados\\academy.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static void CriarBancoSQLite()
        {
            try
            {
                SQLiteConnection.CreateFile(@"c:\dados\adacemy.sqlite");
            }
            catch
            {
                throw;
            }
        }

        //  TABELA DE USUARIOS


        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Usuarios(id int, Nome Varchar(50), email VarChar(80), telefone Varchar(16), acesso int, cpf Varchar(15), username Varchar(30), senha Varchar(20))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetUsuarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT id, Nome, email, telefone, cpf, acesso FROM Usuarios";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Add(string nome, string email, string telefone, int acesso, string cpf, string username, string senha, int salario)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Usuarios(Nome, email, telefone, acesso, cpf, username, senha, salario) values (@nome, @email, @telefone, @acesso, @cpf, @username, @senha, @salario)";

                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@acesso", acesso);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    cmd.Parameters.AddWithValue("@salario", salario);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static void Delete(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Usuarios Where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static void Update(int id, string nome, string email, string telefone, int acesso, string cpf)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != 0)
                    {
                        cmd.CommandText = "UPDATE Usuarios SET Nome=@Nome, email=@Email, telefone=@telefone, acesso=@acesso, cpf=@cpf WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@telefone", telefone);
                        cmd.Parameters.AddWithValue("@acesso", acesso);
                        cmd.Parameters.AddWithValue("@cpf", cpf);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable obterusuario(string username, string senha)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuarios WHERE username = '" + username + "' and senha = '" + senha + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        public static DataTable SelectForID(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuarios WHERE id = '" + id + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        public static DataTable SelectFornNome(string nome)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuarios WHERE Nome = '" + nome + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }


        // TABELA DE CLIENTES



        public static void CriarTabelaClientes()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Clientes(id int, Nome Varchar(50), email VarChar(80), telefone Varchar(16), cpf Varchar(15), plano Varchar(10), pago int)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable ObterClientes()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddClientes(string nome, string email, string telefone, string cpf, string plano, int pago, string datavalidade, int idTurma, int acrescimo, int idTurma2)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Clientes(Nome, email, telefone, cpf, plano, pago, datavalidade, idTurma, acrescimo, idTurma2) values (@nome, @email, @telefone, @cpf, @plano, @pago, @datavalidade, @idTurma, @acrescimo, @idTurma2)";

                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@plano", plano);
                    cmd.Parameters.AddWithValue("@pago", pago);
                    cmd.Parameters.AddWithValue("@datavalidade", datavalidade);
                    cmd.Parameters.AddWithValue("@idTurma", idTurma);
                    cmd.Parameters.AddWithValue("@acrescimo", acrescimo);
                    cmd.Parameters.AddWithValue("@idTurma2", idTurma2);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void DeleteCliente(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Clientes Where id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static void UpdateClientes(int id, string nome, string email, string telefone, string plano, string cpf, string datavalidade)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != 0)
                    {
                        cmd.CommandText = "UPDATE Clientes SET Nome=@Nome, email=@Email, telefone=@telefone, plano=@plano, cpf=@cpf, datavalidade = @datavalidade WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@telefone", telefone);
                        cmd.Parameters.AddWithValue("@plano", plano);
                        cmd.Parameters.AddWithValue("@cpf", cpf);
                        cmd.Parameters.AddWithValue("@datavalidade", datavalidade);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable SelectClientePorNome(string nome)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes WHERE Nome = '" + nome + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        public static DataTable SelectClienteForID(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes WHERE id = '" + id + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }




        public static void Efetuarpag(int id, int pago)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != 0)
                    {
                        cmd.CommandText = "UPDATE Clientes SET pago=@pago WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@pago", pago);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ObterDataPAg(int id, int mespagamento)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != 0)
                    {
                        cmd.CommandText = "UPDATE Clientes SET mespagamento=@mespagamento WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@mespagamento", mespagamento);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        public static DataTable PopularComboBovNomeCliente()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT Nome FROM Clientes";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable SelectClientePorCPF(string cpf)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes WHERE cpf = '" + cpf +  "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }



        // Horarios

        public static DataTable ObterHorarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Horarios";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddHorario(string horario)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Horarios(horario) values (@horario)";

                    cmd.Parameters.AddWithValue("@horario", horario);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void DeleteHoprario(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Horarios Where id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static void UpdateHorario(int id, string horario)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != 0)
                    {
                        cmd.CommandText = "UPDATE Horarios SET horario=@horario WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@horario", horario);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        //Professores


        public static DataTable ObterProffesores()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Professores";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddProfessores(string nome, string email, string telefone, int salario)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Professores (Nome, email, telefone, salario) values (@Nome, @email, @telefone, @salario)";

                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@salario", salario);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void DeleteProfessores(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Professores Where id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static void UpdateProfessores(int id, string nome, string email, string telefone, int salario)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != 0)
                    {
                        cmd.CommandText = "UPDATE Professores SET Nome=@Nome, email=@email, telefone=@telefone, salario=@salario WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@telefone", telefone);
                        cmd.Parameters.AddWithValue("@salario", salario);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        //Turmas
        public static DataTable SelectIDForDescricaoTurma(string descricao)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT id FROM Turmas WHERE descricao = '" + descricao + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        public static DataTable ObterTudoTurma()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Turmas";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ObterTurma()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT\r\nTBT.id as \"ID Turma\",\r\ntbt.descricao as \"Descrição\",\r\ntbp.Nome as \"Professor\",\r\ntbh.horario as \"horario\",\r\ntbt.MaximoAlunos as \"Max. alunos\",\r\ntbt.status as \"Status\"\r\n FROM\r\n Turmas as tbt\r\ninner join\r\nHorarios as tbh on tbh.id = tbt.idHorario,\r\nProfessores as tbp on tbp.id = tbt.idProfessor";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddTurmas(string descricao, int idProfessor, int idHorario, int MaximoAlunos, string status, int valor, int quantidadeAlunos)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Turmas(descricao, idProfessor, idHorario, MaximoAlunos, status, valor, QuantidadeAlunos) values (@descricao, @idProfessor, @idHorario, @MaximoAlunos, @status, @valor, @QuantidadeAlunos)";

                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@idProfessor", idProfessor);
                    cmd.Parameters.AddWithValue("@idHorario", idHorario);
                    cmd.Parameters.AddWithValue("@MaximoAlunos", MaximoAlunos);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@valor", valor);
                    cmd.Parameters.AddWithValue("@QuantidadeAlunos", quantidadeAlunos);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void DeleteTurmas(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Turmas Where id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static void UpdateTurmas(int id, string descricao, int idProfessor, int idHorario, int MaximoAlunos, string status)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != 0)
                    {
                        cmd.CommandText = "UPDATE Turmas SET descricao = @descricao, idProfessor=@idProfessor, idHorario=@idHorario, MaximoAlunos=@MaximoAlunos, status=@status WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@descricao", descricao);
                        cmd.Parameters.AddWithValue("@idProfessor", idProfessor);
                        cmd.Parameters.AddWithValue("@idHorario", idHorario);
                        cmd.Parameters.AddWithValue("@MaximoAlunos", MaximoAlunos);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable PopularComboBoxbrofessor()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT id, Nome FROM Professores";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable PopularComboBoxbroHorario()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT id, horario FROM Horarios";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable PopularComboBoxIdTurmas()
        {


            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT id FROM Turmas";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public static DataTable PopularComboBoxIdDescricaoTurmas()
        {


            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT id, descricao FROM Turmas";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public static DataTable SelectTurmasForID(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT\r\nTBT.id as \"ID Turma\",\r\ntbt.descricao as \"Descrição\",\r\ntbp.Nome as \"Professor\",\r\ntbh.horario as \"horario\",\r\ntbt.MaximoAlunos as \"Max. alunos\",\r\ntbt.status as \"Status\"\r\n FROM\r\n Turmas as tbt\r\ninner join\r\nHorarios as tbh on tbh.id = tbt.idHorario,\r\nProfessores as tbp on tbp.id = tbt.idProfessor WHERE tbt.id = '" + id + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        public static DataTable SelectTudoTurmasForID(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Turmas WHERE id = '" + id + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        public static DataTable RetornaSomaPaga()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {



                    cmd.CommandText = "SELECT SUM(plano) AS total FROM Clientes;";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

        }

        public static DataTable RetornaSomaPagaAcrescimo()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {



                    cmd.CommandText = "SELECT SUM(acrescimo) AS total FROM Clientes;";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

        }
        public static DataTable RetornaSomaPagaSalario()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {



                    cmd.CommandText = "SELECT SUM(salario) AS total FROM Professores;";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

        }
        public static DataTable RetornaSomaPagaSalarioUsers()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {



                    cmd.CommandText = "SELECT SUM(salario) AS total FROM Usuarios;";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }


            public static DataTable RetornaSomaPagaOurtosLucros()
            {
                SQLiteDataAdapter da = null;
                DataTable dt = new DataTable();
                try
                {
                    using (var cmd = DbConnection().CreateCommand())
                    {



                        cmd.CommandText = "SELECT SUM(valor) AS total FROM Lucros;";
                        da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                        da.Fill(dt);
                        return dt;



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                }

            }
        public static DataTable RetornaSomaPagaOutrasDespesas()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {



                    cmd.CommandText = "SELECT SUM(valor) AS total FROM Despesas;";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }

        }





        //Planos
        public static DataTable ObterPlanos()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Planos";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddPlanos(string descricao, int valor)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Planos(descricao, valor) values (@descricao, @valor)";

                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@valor", valor);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void DeletePlanos(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Planos Where id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static void UpdatePlanos(int id, string descricao, int valor)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != 0)
                    {
                        cmd.CommandText = "UPDATE Planos SET descricao = @descricao, valor=@valor WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@descricao", descricao);
                        cmd.Parameters.AddWithValue("@valor", valor);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable PopularComboBoxPlanos()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT descricao, valor FROM Planos";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable ObterTurmasComAlunos()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT\r\ntbt.id as \"ID Turma\",\r\ntbt.descricao as \"Descrição\",\r\ntbp.Nome as \"Professor\",\r\ntbh.horario as \"horario\",\r\ntbt.MaximoAlunos as \"Max. alunos\",\r\ntbt.status as \"Status\"\r\n FROM\r\n Turmas as tbt\r\ninner join\r\nHorarios as tbh on tbh.id = tbt.idHorario,\r\nProfessores as tbp on tbp.id = tbt.idProfessor";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void InserirAlunoEmTurma(int idcliente, int idTurma)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (idcliente != 0)
                    {
                        cmd.CommandText = "UPDATE Clientes SET idTurma = @idTurma WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@idTurma", idTurma);
                        cmd.Parameters.AddWithValue("@Id", idcliente);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static void UpdateQuantidadeAlunos(int idTurma, int QuantidadeAlunos)
        {

            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (idTurma != 0)
                    {
                        cmd.CommandText = "UPDATE Turmas SET QuantidadeAlunos=@QuantidadeAlunos WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@Id", idTurma);
                        cmd.Parameters.AddWithValue("@QuantidadeAlunos", QuantidadeAlunos);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void UpdateAcrescimo(int idcliente, int acrescimo)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (idcliente != 0)
                    {
                        cmd.CommandText = "UPDATE Clientes SET acrescimo = @acrescimo WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@acrescimo", acrescimo);
                        cmd.Parameters.AddWithValue("@Id", idcliente);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static void InserirAlunoEmTurma2(int idcliente, int idTurma2)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (idcliente != 0)
                    {
                        cmd.CommandText = "UPDATE Clientes SET idTurma2 = @idTurma2 WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@idTurma2", idTurma2);
                        cmd.Parameters.AddWithValue("@Id", idcliente);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        //EQUIAMENTOS E ESTOQUE

        public static DataTable ObterEstoque()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Equipamento";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddEstoque(string descricao, int CustoMensalManutenção)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Equipamento(Descricao, CustoMensalManutenção) values (@descricao, @CustoMensalManutenção)";

                    cmd.Parameters.AddWithValue("@Descricao", descricao);
                    cmd.Parameters.AddWithValue("@CustoMensalManutenção", CustoMensalManutenção);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void AddEstoqueComImagem(string descricao, int CustoMensalManutencao, byte[] imagem)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Equipamento(Descricao, CustoMensalManutencao, imagem) values (@descricao, @CustoMensalManutencao, @imagem)";

                    cmd.Parameters.AddWithValue("@Descricao", descricao);
                    cmd.Parameters.AddWithValue("@CustoMensalManutencao", CustoMensalManutencao);
                    cmd.Parameters.AddWithValue("@imagem", imagem);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static void DeleteEstoque(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Equipamento Where id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static void UpdateEstoque(int id, string descricao, int CustoMensalManutenção, byte[] imagem)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != 0)
                    {
                        cmd.CommandText = "UPDATE Equipamento SET Descricao = @Descricao, CustoMensalManutencao=@CustoMensalManutencao, imagem=@imagem WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@Descricao", descricao);
                        cmd.Parameters.AddWithValue("@CustoMensalManutencao", CustoMensalManutenção);
                        cmd.Parameters.AddWithValue("@imagem", imagem);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataTable SelectImagemEquipamentoForID(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT imagem FROM Equipamento WHERE id = '" + id + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        public static DataTable SelectTudoEstoqueForID(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Equipamento WHERE id = '" + id + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }



        //SALARIO USER

        public static void UpdateSalarioUser(int id, int salario)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != 0)
                    {
                        cmd.CommandText = "UPDATE Usuarios SET salario=@salario WHERE id=@Id";
                        cmd.Parameters.AddWithValue("@salario", salario);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable ObterNomeEsalrioUsuarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT id, Nome, Salario FROM Usuarios";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //despesas
        public static DataTable ObterDespesas()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Despesas";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddDespesas(string descricao, int valor)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Despesas(descricao, valor) values (@descricao, @valor)";

                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@valor", valor);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void DeleteDespesas(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Despesas Where id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable SelectTudoDespesasFordes(string desc)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Despesas WHERE descricao = '" + desc + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        public static DataTable ObterLucros()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Lucros";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddLucros(string descricao, int valor)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Lucros(descricao, valor) values (@descricao, @valor)";

                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@valor", valor);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void DeleteLucros(int id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Lucros Where id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static DataTable SelectTudoLucrossFordes(string desc)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Lucros WHERE descricao = '" + desc + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
    }
}
