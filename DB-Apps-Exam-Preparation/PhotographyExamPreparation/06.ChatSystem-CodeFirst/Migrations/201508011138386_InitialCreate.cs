namespace _06.ChatSystem_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChannelMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        ChannelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ChannelId);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        FullName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserChannels",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Channel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Channel_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Channels", t => t.Channel_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Channel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMessages", "UserId", "dbo.Users");
            DropForeignKey("dbo.ChannelMessages", "UserId", "dbo.Users");
            DropForeignKey("dbo.ChannelMessages", "ChannelId", "dbo.Channels");
            DropForeignKey("dbo.UserChannels", "Channel_Id", "dbo.Channels");
            DropForeignKey("dbo.UserChannels", "User_Id", "dbo.Users");
            DropIndex("dbo.UserChannels", new[] { "Channel_Id" });
            DropIndex("dbo.UserChannels", new[] { "User_Id" });
            DropIndex("dbo.UserMessages", new[] { "UserId" });
            DropIndex("dbo.ChannelMessages", new[] { "ChannelId" });
            DropIndex("dbo.ChannelMessages", new[] { "UserId" });
            DropTable("dbo.UserChannels");
            DropTable("dbo.UserMessages");
            DropTable("dbo.Users");
            DropTable("dbo.Channels");
            DropTable("dbo.ChannelMessages");
        }
    }
}
