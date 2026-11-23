using GestaoFila_HGU.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoFila_HGU.Models
{
    public  class Utente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public PrioridadeUtente Prioridade { get; set; }
        public int NumeroSenha { get; set; }
        public DateTime DataChegada { get; set; }

        public Utente(int id, string nome, int idade, PrioridadeUtente prioridade, int senha)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Prioridade = prioridade;
            NumeroSenha = senha;
            DataChegada = DateTime.Now;
        }


    }
}
