namespace Gighub.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                        FollowerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FolloweeId, t.FollowerId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FolloweeId)
                .Index(t => t.FollowerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropTable("dbo.Followings");
        }
    }
}
