namespace LojaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categorias", "DapartamentoId", c => c.Int(nullable: false));
            AddColumn("dbo.Categorias", "Departamento_Id", c => c.Int());
            CreateIndex("dbo.Categorias", "Departamento_Id");
            AddForeignKey("dbo.Categorias", "Departamento_Id", "dbo.Departamentos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categorias", "Departamento_Id", "dbo.Departamentos");
            DropIndex("dbo.Categorias", new[] { "Departamento_Id" });
            DropColumn("dbo.Categorias", "Departamento_Id");
            DropColumn("dbo.Categorias", "DapartamentoId");
        }
    }
}
