using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TesteAPI.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        [Display(Name ="Nome Cliente")]
        public string Nome { get; set; }
        [Display(Name ="Data Agendamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Data { get; set; }

        public string Tipo { get; set; }
        [Display(Name ="Observação")]
        public string Observacao { get; set; }
    }

    public enum Tipo
    {
        Novo,
        Retorno
    }

    public class AgendaDBContext : DbContext
    {
        public DbSet<Agenda> Agendas { get; set; }
    }
}