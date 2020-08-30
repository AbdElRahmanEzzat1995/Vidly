namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set MembershipTypes.Name = 'Pay as You Go ' where DurationInMonths = 0  update MembershipTypes set MembershipTypes.Name = 'Monthly ' where DurationInMonths = 1  update MembershipTypes set MembershipTypes.Name = 'Quarterly' where DurationInMonths = 3  update MembershipTypes set MembershipTypes.Name = 'Annualy ' where DurationInMonths = 12");
        }
        
        public override void Down()
        {
        }
    }
}
