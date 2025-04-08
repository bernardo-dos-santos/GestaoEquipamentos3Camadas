using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante
    {
        public RepositorioFabricante repositorioFabricante;
        public RepositorioEquipamento repositorioEquipamento;
        public TelaFabricante(RepositorioEquipamento repositorioEquipamento)
        {
            this.repositorioEquipamento = repositorioEquipamento;
            repositorioFabricante = new RepositorioFabricante();
        }
        public char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine("Escolha a operação desejada:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1 - Cadastrar Fabricante");
            Console.WriteLine("2 - Editar Fabricante");
            Console.WriteLine("3 - Excluir Fabricante");
            Console.WriteLine("4 - Visualizar Fabricantes");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine()!);

            return operacaoEscolhida;
        }

        public void CadastrarFabricante()
        {
            ExibirCabecalho();

            Console.WriteLine("Cadastrando Fabricante...");
            Console.WriteLine("--------------------------------------------");

            Fabricante novoFabricante = ObterDadosFabricante();

            repositorioFabricante.CadastrarFabricante(novoFabricante);

            Console.WriteLine();
            Console.WriteLine("O fabricante Foi cadastrado com sucesso!");
        }

        public void EditarFabricante()
        {
            ExibirCabecalho();

            Console.WriteLine("Editando Fabricante...");
            Console.WriteLine("--------------------------------------------");

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do fabricante que deseja editar: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine());

            Fabricante novoFabricante = ObterDadosFabricante();

            bool conseguiuEditar = repositorioFabricante.EditarFabricante(idFabricante, novoFabricante);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição de um registro...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("O fabricante foi editado com sucesso!");
        }

        public void ExcluirFabricante()
        {
            ExibirCabecalho();

            Console.WriteLine("Excluindo Fabricante...");
            Console.WriteLine("--------------------------------------------");

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do fabricante que deseja excluir: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioFabricante.ExcluirFabricante(idFabricante);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusão de um registro...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("O fabricante foi excluído com sucesso!");
        }

        public void VisualizarFabricantes(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ExibirCabecalho();

                Console.WriteLine("Visualizando Fabricantes...");
                Console.WriteLine("--------------------------------------------");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -10} | {3, -15} | {4, -15}",
                "Id", "Nome", "Email", "Telefone", "Quant. Equipamentos"
            );

            Fabricante[] FabricanteCadastrados = repositorioFabricante.SelecionarFabricante();

            for (int i = 0; i < FabricanteCadastrados.Length; i++)
            {
                Fabricante f = FabricanteCadastrados[i];

                if (f == null)
                    continue;
                f.QuantosEquipamentos = repositorioEquipamento.RegistrarMesmoFabricante(f.Nome);
                Console.WriteLine(
                    "{0, -6} | {1, -20} | {2, -10} | {3, -15} | {4, -15}",
                    f.Id, f.Nome, f.Email, f.Telefone, f.QuantosEquipamentos
                );
            }

        }

        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Controle de Fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();
        }

        public Fabricante ObterDadosFabricante()
        {
            Console.Write("Digite o nome do fabricante: ");
            string nome = Console.ReadLine()!.Trim();

            Console.Write("Digite o email do fabricante: ");
            string email = Console.ReadLine()!.Trim();

            Console.Write("Digite o número do fabricante: ");
            string telefone = Console.ReadLine()!.Trim();

            Fabricante novoFabricante = new Fabricante(nome, email, telefone);

            return novoFabricante;
        }
    }
}
