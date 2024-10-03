// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;

List<Cliente> listaClientes = new List<Cliente>();
List<Cliente> listaClientesDeletados = new List<Cliente>();

//List<int> lista = new List<int>();
//var database = new Database();
//database.Create();

string opcao;

do
{
    Menu();
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            CadastrarUsuario();
            break;
        case "2":
            ListarUsuarios();
            break;
        case "3":
            ListarUsuariosDeletados();
            break;
        case "4":
            BuscarUsuario();
            break;
        case "5":
            DeletarUsuario();
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

int buscarIdade()
{
    int idade;
    while (true)
    {
        Console.WriteLine("Idade: ");
        string a = Console.ReadLine();

        if (int.TryParse(a, out idade) && idade > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Digite uma idade válida!");
        }
    }

    return idade;
}

int GeraId()
{
        return listaClientes.Count + 1;
}

void AdicionaUsuario(int id, string nome, int idade)
{
    Cliente usuarioNovo = new Cliente(id, nome, idade);
    listaClientes.Add(usuarioNovo);
    Cliente novoUsuario = listaClientes.Find(x => x.Id == id);
    Console.WriteLine($"ID: {novoUsuario.Id}; Nome: {novoUsuario.Nome}; Idade: {novoUsuario.Idade}");
    Console.WriteLine("Usuário cadastrado com sucesso!\n");
}

void CadastrarUsuario()
{
    Console.WriteLine("Nome: ");
    string nome = Console.ReadLine();

    int idade = buscarIdade();

    int id = GeraId();

    AdicionaUsuario(id, nome, idade);
}

void ListarUsuarios()
{
    if (listaClientes.Count != 0)
    {
        for (int i = 0; i < listaClientes.Count; i++)
        {
            Console.WriteLine($"ID: {listaClientes[i].Id}; Nome: {listaClientes[i].Nome}; Idade: {listaClientes[i].Idade}\n");
        }
    }
    else
    {
        Console.WriteLine("Ainda não existem usuários cadastrados!\n");
    }
}

void ListarUsuariosDeletados()
{
    if (listaClientesDeletados.Count != 0)
    {
        for (int i = 0; i < listaClientesDeletados.Count; i++)
        {
            Console.WriteLine($"ID: {listaClientesDeletados[i].Id}; Nome: {listaClientesDeletados[i].Nome}; Idade: {listaClientesDeletados[i].Idade}\n");
        }
    }
    else
    {
        Console.WriteLine("Ainda não existem usuários deletados!\n");
    }
}

void BuscarUsuario()
{
    Console.WriteLine("Por qual parâmetro deseja localizar?\n1-ID\n2-Nome\n3-Idade");
    string a = Console.ReadLine();
    int.TryParse(a, out int parametro);

    switch (parametro)
    {
        case 1:
            int id;
            string b;
            while (true)
            {
                Console.WriteLine("Digite ID: ");
                b = Console.ReadLine();
                if (int.TryParse(b, out id) && id >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ID inválida!");
                }
            }

            if (listaClientes.Exists(x => x.Id == id))
            {
                int.TryParse(b, out id);
                Cliente idEncontrado = listaClientes.Find(x => x.Id == id);
                Console.WriteLine($"ID: {idEncontrado.Id}; Nome: {idEncontrado.Nome}; Idade: {idEncontrado.Idade}\n");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado!");
            }
            break;
        case 2:
            Console.WriteLine("Digite Nome: ");
            string nome = Console.ReadLine();

            if (listaClientes.Exists(x => x.Nome.Contains(nome)))
            {
                Cliente nomeEncontrado = listaClientes.Find(x => x.Nome.Contains(nome));
                Console.WriteLine($"ID: {nomeEncontrado.Id}; Nome: {nomeEncontrado.Nome}; Idade: {nomeEncontrado.Idade}\n");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado!");
            }
            break;
        case 3:
            int idade;
            string c;
            while (true)
            {
                Console.WriteLine("Digite Idade: ");
                c = Console.ReadLine();
                if (int.TryParse(c, out idade) && idade >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Idade inválida!");
                }
            }
            if (listaClientes.Exists(x => x.Idade == idade))
            {
                int.TryParse(c, out idade);
                Cliente idadeEncontrada = listaClientes.Find(x => x.Id == idade);
                Console.WriteLine($"ID: {idadeEncontrada.Id}; Nome: {idadeEncontrada.Nome}; Idade: {idadeEncontrada.Idade}\n");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado!");
            }
            break;
        default:
            Console.WriteLine("Opção inválida!\n");
            break;
    }
}

void DeletarUsuario()
{
    ListarUsuarios();
    Console.WriteLine("Digite o ID do usuário a ser deletado: ");
    string a = Console.ReadLine();
    int.TryParse(a,out int id);

    if (listaClientes.Exists(x => x.Id == id))
    {
        Cliente usuarioDeletado = listaClientes.Find(x => x.Id == id);
        listaClientesDeletados.Add(usuarioDeletado);
        listaClientes.Remove(listaClientes.Find(x => x.Id == id));
        Console.WriteLine($"ID: {usuarioDeletado.Id}; Nome: {usuarioDeletado.Nome}; Idade: {usuarioDeletado.Idade}");
        Console.WriteLine("Usuário deletado com sucesso!\n");
    }
    else
    {
        Console.WriteLine("Usuário não encontrado!\n/");
    }
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

//pq eu tenho que declarar a lista antes da classe?
//explicar namespace