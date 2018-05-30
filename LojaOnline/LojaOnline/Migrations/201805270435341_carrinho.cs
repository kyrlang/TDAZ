namespace LojaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrinho : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrinhos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.ProdutoCarrinhoes",
                c => new
                    {
                        CarrinhoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CarrinhoId, t.ProdutoId })
                .ForeignKey("dbo.Carrinhos", t => t.CarrinhoId, cascadeDelete: true)
                .ForeignKey("dbo.Produtos", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.CarrinhoId)
                .Index(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoCarrinhoes", "ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.ProdutoCarrinhoes", "CarrinhoId", "dbo.Carrinhos");
            DropForeignKey("dbo.Carrinhos", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.ProdutoCarrinhoes", new[] { "ProdutoId" });
            DropIndex("dbo.ProdutoCarrinhoes", new[] { "CarrinhoId" });
            DropIndex("dbo.Carrinhos", new[] { "UsuarioId" });
            DropTable("dbo.ProdutoCarrinhoes");
            DropTable("dbo.Carrinhos");
        }
    }
}
