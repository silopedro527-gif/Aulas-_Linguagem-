using GestaoFila_HGU.Enum;
using GestaoFila_HGU.Models;
using System;

namespace GestaoFila_HGU
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE GESTÃO DE FILAS - HOSPITAL GERAL DO UÍGE ===");

            GestorFila gestor = new GestorFila();

          
            var sala1 = new SalaAtendimento("Sala de Triagem",
                new ProfissionalSaude("Dr. António", "Clínica Geral"),
                new ProfissionalSaude("Enf. Maria", "Triagem"));

            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("\nMENU PRINCIPAL:");
                Console.WriteLine("1 - Registar Utente na Recepção");
                Console.WriteLine("2 - Ver Fila de Espera");
                Console.WriteLine("3 - Chamar Próximo Utente");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Nome do Utente: ");
                        string nome = Console.ReadLine();

                        Console.Write("Idade: ");
                        int idade = int.Parse(Console.ReadLine());

                        Console.WriteLine("Prioridade: 1 - Urgência Clínica | 2 - Idoso/Gestante | 3 - Normal");
                        Console.Write("Escolha a prioridade: ");
                        int prioridadeNum = int.Parse(Console.ReadLine());

                        PrioridadeUtente prioridade = (PrioridadeUtente)prioridadeNum;

                        gestor.RegistarUtente(nome, idade, prioridade);
                        break;

                    case "2":
                        gestor.MostrarFila();
                        break;

                    case "3":
                        var utenteChamado = gestor.ChamarProximo();
                        if (utenteChamado != null)
                        {
                            Console.WriteLine($"\n>>> CHAMANDO SENHA {utenteChamado.NumeroSenha} <<<");
                            Console.WriteLine($"Utente: {utenteChamado.Nome}");
                            Console.WriteLine($"Dirija-se para: {sala1.NomeSala}");
                            Console.WriteLine($"Médico Responsável: {sala1.Medico.Nome}");
                            Console.WriteLine($"Enfermeiro Responsável: {sala1.Enfermeiro.Nome}");
                        }
                        break;

                    case "0":
                        sair = true;
                        Console.WriteLine("A encerrar o sistema...");
                        break;

                    default:
                        Console.WriteLine("[ERRO] Opção inválida!");
                        break;
                }
            }
        }
    }
}