namespace PolatlıEksozSiparisForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UrunFotoes", "DosyaAdi", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UrunFotoes", "DosyaAdi", c => c.Long(nullable: false));
        }
    }
}
