namespace DireChinchillas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chinchillas",
                c => new
                    {
                        ChinchillaId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Birthday = c.DateTime(nullable: false),
                        ColourId = c.Int(nullable: false),
                        MotherId = c.Int(),
                        FatherId = c.Int(),
                    })
                .PrimaryKey(t => t.ChinchillaId)
                .ForeignKey("dbo.ColourMutations", t => t.ColourId, cascadeDelete: true)
                .ForeignKey("dbo.Chinchillas", t => t.FatherId)
                .ForeignKey("dbo.Chinchillas", t => t.MotherId)
                .Index(t => t.ColourId)
                .Index(t => t.MotherId)
                .Index(t => t.FatherId);
            
            CreateTable(
                "dbo.ColourMutations",
                c => new
                    {
                        ColourId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        BeigeGene = c.Int(nullable: false),
                        WhiteGene = c.Int(nullable: false),
                        TovGene = c.Int(nullable: false),
                        EbonyGene = c.Int(nullable: false),
                        RecessiveGene = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ColourId);
            
            CreateTable(
                "dbo.Weights",
                c => new
                    {
                        ChinchillaId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChinchillaId, t.Date })
                .ForeignKey("dbo.Chinchillas", t => t.ChinchillaId, cascadeDelete: true)
                .Index(t => t.ChinchillaId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 4000),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 4000),
                        RoleId = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 4000),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
                        PhoneNumber = c.String(maxLength: 4000),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 4000),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 4000),
                        ProviderKey = c.String(nullable: false, maxLength: 4000),
                        UserId = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ChinchillaChildren",
                c => new
                    {
                        ParentId = c.Int(nullable: false),
                        ChildId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ParentId, t.ChildId })
                .ForeignKey("dbo.Chinchillas", t => t.ParentId)
                .ForeignKey("dbo.Chinchillas", t => t.ChildId)
                .Index(t => t.ParentId)
                .Index(t => t.ChildId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Weights", "ChinchillaId", "dbo.Chinchillas");
            DropForeignKey("dbo.Chinchillas", "MotherId", "dbo.Chinchillas");
            DropForeignKey("dbo.Chinchillas", "FatherId", "dbo.Chinchillas");
            DropForeignKey("dbo.Chinchillas", "ColourId", "dbo.ColourMutations");
            DropForeignKey("dbo.ChinchillaChildren", "ChildId", "dbo.Chinchillas");
            DropForeignKey("dbo.ChinchillaChildren", "ParentId", "dbo.Chinchillas");
            DropIndex("dbo.ChinchillaChildren", new[] { "ChildId" });
            DropIndex("dbo.ChinchillaChildren", new[] { "ParentId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Weights", new[] { "ChinchillaId" });
            DropIndex("dbo.Chinchillas", new[] { "FatherId" });
            DropIndex("dbo.Chinchillas", new[] { "MotherId" });
            DropIndex("dbo.Chinchillas", new[] { "ColourId" });
            DropTable("dbo.ChinchillaChildren");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Weights");
            DropTable("dbo.ColourMutations");
            DropTable("dbo.Chinchillas");
        }
    }
}
