namespace HomeWork2019._12._14.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ImagePath = c.String(),
                        LikeCount = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPostLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Post_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPostLikes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserPostLikes", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropIndex("dbo.UserPostLikes", new[] { "User_Id" });
            DropIndex("dbo.UserPostLikes", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropTable("dbo.UserPostLikes");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
        }
    }
}
