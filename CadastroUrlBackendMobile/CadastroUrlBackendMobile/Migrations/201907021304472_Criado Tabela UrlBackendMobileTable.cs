namespace CadastroUrlBackendMobile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriadoTabelaUrlBackendMobileTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UrlBackendMobile",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CNPJ = c.String(),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UrlBackendMobile");
        }
    }
}
