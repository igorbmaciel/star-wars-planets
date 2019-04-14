namespace star_wars_planets.Datas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Planet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150, unicode: false),
                        Weather = c.String(nullable: false, maxLength: 100, unicode: false),
                        Ground = c.String(nullable: false, maxLength: 100, unicode: false),
                        MovieQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Planet");
        }
    }
}
