// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;


Database database = new Database();

string opcao;

do
{
    Menu();
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            database.CadastrarUsuario(); 
            break;
        case "2":
            database.ListarUsuariosAtivos();
            break;
        case "3":
            database.ListarUsuariosDeletados();
            break;
        case "4":
            database.BuscarUsuario();
            break;
        case "5":
            database.DeletarUsuario();
            break;
        case "6":
            Console.WriteLine("Programa finalizado!");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
} while (opcao != "6");

void Menu()
{
    Console.WriteLine("1-Cadastrar Usuário\n2-Listar Usuários Ativos\n3-Listar Usuários Deletados\n4-Buscar Usuário\n5-Deletar Usuário\n6-Sair\n");
}

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public Cliente(int id, string nome, int idade)
    {
        this.Id = id;
        this.Nome = nome;
        this.Idade = idade;
    }
}

//explicar namespace