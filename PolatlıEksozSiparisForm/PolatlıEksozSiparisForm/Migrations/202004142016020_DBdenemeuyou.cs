namespace PolatlıEksozSiparisForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBdenemeuyou : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Uruns", "KategoriLookUpID", "dbo.GenericLookUps");
            AddColumn("dbo.Uruns", "GenericLookUp_ID", c => c.Long());
            AddColumn("dbo.Uruns", "GenericLookUp_ID1", c => c.Long());
            CreateIndex("dbo.Uruns", "UrunTipiLookUpID");
            CreateIndex("dbo.Uruns", "GenericLookUp_ID");
            CreateIndex("dbo.Uruns", "GenericLookUp_ID1");
            AddForeignKey("dbo.Uruns", "UrunTipiLookUpID", "dbo.GenericLookUps", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Uruns", "GenericLookUp_ID1", "dbo.GenericLookUps", "ID");
            AddForeignKey("dbo.Uruns", "GenericLookUp_ID", "dbo.GenericLookUps", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uruns", "GenericLookUp_ID", "dbo.GenericLookUps");
            DropForeignKey("dbo.Uruns", "GenericLookUp_ID1", "dbo.GenericLookUps");
            DropForeignKey("dbo.Uruns", "UrunTipiLookUpID", "dbo.GenericLookUps");
            DropIndex("dbo.Uruns", new[] { "GenericLookUp_ID1" });
            DropIndex("dbo.Uruns", new[] { "GenericLookUp_ID" });
            DropIndex("dbo.Uruns", new[] { "UrunTipiLookUpID" });
            DropColumn("dbo.Uruns", "GenericLookUp_ID1");
            DropColumn("dbo.Uruns", "GenericLookUp_ID");
            AddForeignKey("dbo.Uruns", "KategoriLookUpID", "dbo.GenericLookUps", "ID", cascadeDelete: true);
        }
    }
}
