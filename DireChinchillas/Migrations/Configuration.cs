namespace DireChinchillas.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DireChinchillas.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DireChinchillas.Models.ApplicationDbContext";
        }

        protected override void Seed(DireChinchillas.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.ColorMutations.AddOrUpdate(
              new Models.ColourMutation
              {
                  Name = "Brown Velvet",
                  BeigeGene = Enums.BeigeGenes.HeteroBeige,
                  TovGene = Enums.TovGenes.VelvetTOV
              },
              new Models.ColourMutation
              {
                  Name = "Pink White TOV",
                  BeigeGene = Enums.BeigeGenes.HeteroBeige,
                  WhiteGene = Enums.WhiteGenes.White,
                  TovGene = Enums.TovGenes.VelvetTOV
              },
              new Models.ColourMutation
              {
                  Name = "Standard"
              }
            );
        }
    }
}
