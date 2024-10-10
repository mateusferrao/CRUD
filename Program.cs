// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;

List<Cliente> listaClientes = new List<Cliente>();
List<Cliente> listaClientesDeletados = new List<Cliente>();

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
            ListarUsuariosAtivos();
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
    if (listaClientes.Count == 0)
    {
        return 0;
    }
    else
    {
        int id = listaClientes.Max(x => x.Id);
        return id;
    }
        
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
    string nome;
    do
    {
        Console.WriteLine("Nome: ");
        nome = Console.ReadLine();
        if (nome == "") Console.WriteLine("Digite um nome válido");
    } while (nome == "");
    

    int idade = buscarIdade();

    int id = GeraId();

    AdicionaUsuario(id, nome, idade);
}

void ListarUsuarios(List<Cliente> lista)
{
    if (lista.Count != 0)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine($"ID: {lista[i].Id}; Nome: {lista[i].Nome}; Idade: {lista[i].Idade}\n");
        }
    }
    else
    {
        Console.WriteLine("Ainda não existem usuários!\n");
    }
}

void ListarUsuariosAtivos()
{
    ListarUsuarios(listaClientes);
}

void ListarUsuariosDeletados()
{
    ListarUsuarios(listaClientesDeletados);
}

void BuscarUsuario()
{
    void ListaUsuarioEncontrado(Cliente usuario)
    {
        Console.WriteLine($"ID: {usuario.Id}; Nome: {usuario.Nome}; Idade: {usuario.Idade}\n");
    }
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
                ListaUsuarioEncontrado(idEncontrado);            }
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
                ListaUsuarioEncontrado(nomeEncontrado);
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
                ListaUsuarioEncontrado(idadeEncontrada);
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
    ListarUsuariosAtivos();
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
//explicar namespace