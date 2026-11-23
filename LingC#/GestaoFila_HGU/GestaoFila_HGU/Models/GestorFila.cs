using GestaoFila_HGU.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFila_HGU.Models
{
   public  class GestorFila
    {


        private List<Utente> _filaEspera;
        private int _proximaSenha;

        public GestorFila()
        {
            _filaEspera = new List<Utente>();
            _proximaSenha = 1;
        }

     
        public Utente RegistarUtente(string nome, int idade, PrioridadeUtente prioridade)
        {
            var novoUtente = new Utente(_proximaSenha, nome, idade, prioridade, _proximaSenha);
            _filaEspera.Add(novoUtente);
            _proximaSenha++;

            Console.WriteLine($"\n[SUCESSO] {nome} registado. Senha atribuída: {novoUtente.NumeroSenha}");
            return novoUtente;
        }

        public Utente ChamarProximo()
        {
            if (_filaEspera.Count == 0)
            {
                Console.WriteLine("\n[AVISO] A fila está vazia.");
                return null;
            }

            var proximoUtente = _filaEspera
                .OrderBy(u => u.Prioridade)
                .ThenBy(u => u.DataChegada)
                .First();

            _filaEspera.Remove(proximoUtente);
            return proximoUtente;
        }

        public void MostrarFila()
        {
            Console.WriteLine("\n--- FILA DE ESPERA ATUAL ---");
            if (_filaEspera.Count == 0) Console.WriteLine("(Vazia)");

            var filaOrdenada = _filaEspera.OrderBy(u => u.Prioridade).ThenBy(u => u.DataChegada);

            foreach (var u in filaOrdenada)
            {
                Console.WriteLine($"Senha: {u.NumeroSenha} | Nome: {u.Nome} | Idade: {u.Idade} | Prioridade: {u.Prioridade}");
            }
            Console.WriteLine("----------------------------");
        }


    }
}
