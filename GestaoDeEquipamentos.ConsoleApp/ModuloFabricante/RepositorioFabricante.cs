using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class RepositorioFabricante
    {
        public Fabricante[] fabricantes = new Fabricante[100];
        public int contadorFabricante = 0;
        public void CadastrarFabricante(Fabricante novoFabricante)
        {
            novoFabricante.Id = GeradorIds.GerarIdFabricante();

            fabricantes[contadorFabricante++] = novoFabricante;
        }

        public bool EditarFabricante(int idFabricante, Fabricante novoFabricante)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                if (fabricantes[i] == null)
                    continue;

                else if (fabricantes[i].Id == idFabricante)
                {
                    fabricantes[i].Nome = novoFabricante.Nome;
                    fabricantes[i].Email = novoFabricante.Email;
                    fabricantes[i].Telefone = novoFabricante.Telefone;

                    return true;
                }
            }

            return false;
        }

        public Fabricante[] SelecionarFabricante()
        {
            return fabricantes;
        }

        public bool ExcluirFabricante(int idFabricante)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                if (fabricantes[i] == null) continue;

                else if (fabricantes[i].Id == idFabricante)
                {
                    fabricantes[i] = null;

                    return true;
                }
            }

            return false;
        }
    }
}
