namespace LojaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categorias", "DepartamentoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categorias", "DepartamentoId");
            AddForeignKey("dbo.Categorias", "DepartamentoId", "dbo.Departamentos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categorias", "DepartamentoId", "dbo.Departamentos");
            DropIndex("dbo.Categorias", new[] { "DepartamentoId" });
            DropColumn("dbo.Categorias", "DepartamentoId");
        }
    }
}
