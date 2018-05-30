namespace LojaOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterprodutodescricao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtos", "Descricao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtos", "Descricao");
        }
    }
}
