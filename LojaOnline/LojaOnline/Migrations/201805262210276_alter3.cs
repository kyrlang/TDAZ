namespace LojaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categorias", "Departamento_Id", "dbo.Departamentos");
            DropIndex("dbo.Categorias", new[] { "Departamento_Id" });
            DropColumn("dbo.Categorias", "DapartamentoId");
            DropColumn("dbo.Categorias", "Departamento_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categorias", "Departamento_Id", c => c.Int());
            AddColumn("dbo.Categorias", "DapartamentoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categorias", "Departamento_Id");
            AddForeignKey("dbo.Categorias", "Departamento_Id", "dbo.Departamentos", "Id");
        }
    }
}
