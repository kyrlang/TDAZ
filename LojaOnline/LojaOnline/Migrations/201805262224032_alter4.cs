namespace LojaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtos", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtos", "CategoriaId");
            AddForeignKey("dbo.Produtos", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "CategoriaId" });
            DropColumn("dbo.Produtos", "CategoriaId");
        }
    }
}
