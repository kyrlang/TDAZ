namespace LojaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabelainicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DapartamentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamentos", t => t.DapartamentoId, cascadeDelete: true)
                .Index(t => t.DapartamentoId);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Preco = c.Double(nullable: false),
                        Imagem = c.Binary(),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Categorias", "DepartamentoId", "dbo.Departamentos");
            DropIndex("dbo.Produtos", new[] { "CategoriaId" });
            DropIndex("dbo.Categorias", new[] { "DepartamentoId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Categorias");
        }
    }
}
