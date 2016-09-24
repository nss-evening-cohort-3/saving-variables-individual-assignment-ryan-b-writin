namespace SavingVariables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Variables",
                c => new
                    {
                        VariableID = c.Int(nullable: false, identity: true),
                        VariableName = c.String(nullable: false, maxLength: 1),
                        VariableValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VariableID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Variables");
        }
    }
}
