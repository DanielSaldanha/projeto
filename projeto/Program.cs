using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace praticando
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //VARIAVEIS
            string nome;
            string area;
            string cargo;
            int cargaHoraria;
            int salarioPorHora;
            string instruçao = "";
            bool controller = true;
            string instruction = "";

            //INSTRUÇAO
            Console.WriteLine("escolhe uma instruçao: cadastrar, deletar, mudar");
            Console.Write("escreva: ");
            instruction = Console.ReadLine();
            Console.Clear();

            while (controller == true)
            {
                switch (instruction)
                {
                    
                    case "cadastrar":
                        
                        Console.WriteLine("insira os dados");
                        Console.Write("nome do funcionario: ");
                        nome = Console.ReadLine();

                        Console.Write("area de atuaçao: ");
                        area = Console.ReadLine();

                        Console.Write("cargo na empresa: ");
                        cargo = Console.ReadLine();

                        Console.Write("carga horaria diaria: ");
                        cargaHoraria = int.Parse(Console.ReadLine());

                        Console.Write("ganhos por hora: ");
                        salarioPorHora = int.Parse(Console.ReadLine());

                        nome = marcaçao(nome);
                        area = marcaçao(area);
                        cargo = marcaçao(cargo);

                        instruçao = $"insert into cadastro (nome, area, cargo ,cargaHoraria ,salarioPorHora ) values" +
                        $"({nome},{area},{cargo},{cargaHoraria},{salarioPorHora})";
                        controller = false;
                        break;

                    
                    case "deletar":

                        Console.WriteLine("<deletar um registro>");
                        Console.Write("insira o id do registro: ");
                        int id = int.Parse(Console.ReadLine());
                        instruçao = $"delete from cadastro where id = {id}";
                        controller = false;
                        break;

                   
                    case "mudar":

                        Console.Clear();

                        Console.WriteLine("escolher id do cadastrado");
                        Console.Write("digite aqui: ");
                        id = int.Parse(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("alterar registros");
                        Console.WriteLine("area ou cargo");
                        Console.Write("escolha um: ");
                        string alterado = Console.ReadLine();
                        Console.Clear();

                        Console.WriteLine("nova informaçao");
                        Console.Write("digite aqui: ");
                        string novaInformaçao = Console.ReadLine();
                       

                        instruçao = $"Update cadastro set {alterado} = '{novaInformaçao}' where id = {id}";
                        controller = false;
                        break;
                }
            }

            Console.Clear();
            //CONEXAO
            try
            {
                var strConexao = "server=localhost;uid=root;database=teste";
                var connection = new MySqlConnection(strConexao);
                connection.Open();
                Console.WriteLine("conexao efetuada");

                var comando = new MySqlCommand(instruçao, connection);
                var reader = comando.ExecuteReader();               
            }
            catch (Exception ex)
            {
                Console.WriteLine("ocorreu um erro: " + ex.Message);
            }

            Console.ReadLine();
        }
        static string marcaçao(string var)
        {
            string marcador = "'";
            string aux = marcador;
            aux += var;
            var = aux;
            var += marcador;
            aux = marcador;
            return var;
        }
    }
}
