namespace FileReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        ClienteNome = c.String(),
                        DataNascimento = c.String(),
                        Sexo = c.String(),
                        Email = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Produto = c.String(),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        ProdutoNome = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        ClienteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoID)
                .ForeignKey("dbo.Produto", t => t.ClienteID)
                .Index(t => t.ClienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "ClienteID", "dbo.Produto");
            DropIndex("dbo.Produto", new[] { "ClienteID" });
            DropTable("dbo.Produto");
            DropTable("dbo.Cliente");
        }
    }
}
