namespace LojaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categorias", "Departamento_Id", "dbo.Departamentos");
            DropForeignKey("dbo.Produtos", "CategoriaId", "dbo.Categorias");
            //DropIndex("dbo.Categorias", new[] { "Departamento_Id" });
            DropIndex("dbo.Produtos", new[] { "CategoriaId" });
            DropColumn("dbo.Categorias", "DapartamentoId");
            //DropColumn("dbo.Categorias", "Departamento_Id");
            DropColumn("dbo.Produtos", "CategoriaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtos", "CategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.Categorias", "Departamento_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Categorias", "DapartamentoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtos", "CategoriaId");
            //CreateIndex("dbo.Categorias", "Departamento_Id");
            AddForeignKey("dbo.Produtos", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Categorias", "Departamento_Id", "dbo.Departamentos", "Id", cascadeDelete: true);
        }
    }
}
