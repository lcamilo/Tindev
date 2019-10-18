namespace Tindev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Desenvolvedores",
                c => new
                    {
                        DesenvolvedorId = c.Guid(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                        UserName = c.String(maxLength: 100, unicode: false),
                        Bio = c.String(unicode: false),
                        Avatar = c.String(maxLength: 100, unicode: false),
                        Empresa = c.String(maxLength: 100, unicode: false),
                        Blog = c.String(maxLength: 100, unicode: false),
                        Localizacao = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.DesenvolvedorId);
            
            CreateTable(
                "dbo.Dislikes",
                c => new
                    {
                        DislikeId = c.Guid(nullable: false),
                        DesenvolvedorId = c.Guid(nullable: false),
                        AlvoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.DislikeId)
                .ForeignKey("dbo.Desenvolvedores", t => t.AlvoId)
                .ForeignKey("dbo.Desenvolvedores", t => t.DesenvolvedorId)
                .Index(t => t.DesenvolvedorId)
                .Index(t => t.AlvoId);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikeId = c.Guid(nullable: false),
                        DesenvolvedorId = c.Guid(nullable: false),
                        AlvoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LikeId)
                .ForeignKey("dbo.Desenvolvedores", t => t.AlvoId)
                .ForeignKey("dbo.Desenvolvedores", t => t.DesenvolvedorId)
                .Index(t => t.DesenvolvedorId)
                .Index(t => t.AlvoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "DesenvolvedorId", "dbo.Desenvolvedores");
            DropForeignKey("dbo.Likes", "AlvoId", "dbo.Desenvolvedores");
            DropForeignKey("dbo.Dislikes", "DesenvolvedorId", "dbo.Desenvolvedores");
            DropForeignKey("dbo.Dislikes", "AlvoId", "dbo.Desenvolvedores");
            DropIndex("dbo.Likes", new[] { "AlvoId" });
            DropIndex("dbo.Likes", new[] { "DesenvolvedorId" });
            DropIndex("dbo.Dislikes", new[] { "AlvoId" });
            DropIndex("dbo.Dislikes", new[] { "DesenvolvedorId" });
            DropTable("dbo.Likes");
            DropTable("dbo.Dislikes");
            DropTable("dbo.Desenvolvedores");
        }
    }
}
