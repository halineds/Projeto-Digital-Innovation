using System;

namespace DIO.Produtos
{
    class Program
    {
        static ProdutoRepositorio repositorio = new ProdutoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarProdutos();
						break;
					case "2":
						InserirProduto();
						break;
					case "3":
						AtualizarProduto();
						break;
					case "4":
						ExcluirProduto();
						break;
					case "5":
						VisualizarProduto();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirProduto()
		{
			Console.Write("Digite o id da produto: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceProduto);
		}

        private static void VisualizarProduto()
		{
			Console.Write("Digite o id da produto: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			var Produto = repositorio.RetornaPorId(indiceProduto);

			Console.WriteLine(Produto);
		}

        private static void AtualizarProduto()
		{
			Console.Write("Digite o id da produto: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da produto: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da produto: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da produto: ");
			string entradaDescricao = Console.ReadLine();

			Produto atualizaProduto = new Produto(id: indiceProduto,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceProduto, atualizaProduto);
		}
        private static void ListarProdutos()
		{
			Console.WriteLine("Listar produtos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma produto cadastrada.");
				return;
			}

			foreach (var Produto in lista)
			{
                var excluido = Produto.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Produto.retornaId(), Produto.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirProduto()
		{
			Console.WriteLine("Inserir nova produto");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da produto: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da produto: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da produto: ");
			string entradaDescricao = Console.ReadLine();

			Produto novaProduto = new Produto(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaProduto);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO produtos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar produtos");
			Console.WriteLine("2- Inserir nova produto");
			Console.WriteLine("3- Atualizar produto");
			Console.WriteLine("4- Excluir produto");
			Console.WriteLine("5- Visualizar produto");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
