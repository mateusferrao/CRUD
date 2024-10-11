using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Database
    {
        public List<Cliente> listaClientes { get; set; }
        public List<Cliente> listaClientesDeletados { get; set; }

        public int GeraId()
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
        public int buscarIdade()
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

        void AdicionaUsuario(int id, string nome, int idade)
        {
            Cliente usuarioNovo = new Cliente(id, nome, idade);
            listaClientes.Add(usuarioNovo);
            Cliente novoUsuario = listaClientes.Find(x => x.Id == id);
            Console.WriteLine($"ID: {novoUsuario.Id}; Nome: {novoUsuario.Nome}; Idade: {novoUsuario.Idade}");
            Console.WriteLine("Usuário cadastrado com sucesso!\n");
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

        public void ListarUsuariosAtivos()
        {
            ListarUsuarios(listaClientes);
        }

        public void ListarUsuariosDeletados()
        {
            ListarUsuarios(listaClientesDeletados);
        }

        public void CadastrarUsuario()
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

        public void BuscarUsuario()
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
                        ListaUsuarioEncontrado(idEncontrado);
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

        public void DeletarUsuario()
        {
            ListarUsuariosAtivos();
            Console.WriteLine("Digite o ID do usuário a ser deletado: ");
            string a = Console.ReadLine();
            int.TryParse(a, out int id);

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

        public Database()
        {
            this.listaClientes = new List<Cliente>();
            this.listaClientesDeletados = new List<Cliente>();
        }
    }

   
}
