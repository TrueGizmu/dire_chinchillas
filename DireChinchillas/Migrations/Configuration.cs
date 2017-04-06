namespace DireChinchillas.Migrations
{
    using DireChinchillas.DbAccess;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DireChinchillas.DbAccess.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.ColorMutations.AddOrUpdate(
              new Models.ColourMutation
              {
                  ColourId = 0,
                  Name = "Brown Velvet",
                  BeigeGene = Enums.BeigeGenes.HeteroBeige,
                  TovGene = Enums.TovGenes.VelvetTOV
              },
              new Models.ColourMutation
              {
                  ColourId = 1,
                  Name = "Pink White TOV",
                  BeigeGene = Enums.BeigeGenes.HeteroBeige,
                  WhiteGene = Enums.WhiteGenes.White,
                  TovGene = Enums.TovGenes.VelvetTOV
              },
              new Models.ColourMutation
              {
                  ColourId = 2,
                  Name = "Standard"
              }
            );
        }
    }
}
