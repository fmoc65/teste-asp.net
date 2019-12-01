namespace TesteAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.AgendaDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TesteAPI.Models.AgendaDBContext";
        }

        protected override void Seed(TesteAPI.Models.AgendaDBContext context)
        {
            context.Agendas.AddOrUpdate(a => a.Id, new Models.Agenda
            {
                Nome = "Antonio José Matoso",
                Data = DateTime.Parse("01/02/2019"),
                Tipo = "Novo",
                Observacao = "Indicação Maria"
            });
        }
    }
}
