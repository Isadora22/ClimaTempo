namespace ClimaTempo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        UF = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrevisaoClima",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CidadeId = c.Int(nullable: false),
                        DataPrevisao = c.DateTime(nullable: false),
                        Clima = c.String(nullable: false, maxLength: 15),
                        TemperaturaMinima = c.Decimal(precision: 18, scale: 2),
                        TemperaturaMaxima = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidade", t => t.CidadeId)
                .Index(t => t.CidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrevisaoClima", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estado");
            DropIndex("dbo.PrevisaoClima", new[] { "CidadeId" });
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropTable("dbo.PrevisaoClima");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
        }
    }
}
