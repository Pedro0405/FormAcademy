using csharp_Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademyForm
{
    public class globais
    {
        public static Boolean logado = false;
        public static int id;
        public static string nome;
        public static string email;
        public static int acesso;  //acessos 0 = desenvolvedor, 1=supervisor, 2=funcionario, 3=cliente
        public static string cpf;
        public static string telefone;
        public static string usuario;
        public static string password;



        public static int diahoje =  DateTime.Now.Day;


        public static int QuantidadeCliente = DalHelper.ObterClientes().Rows.Count;
    }
}
