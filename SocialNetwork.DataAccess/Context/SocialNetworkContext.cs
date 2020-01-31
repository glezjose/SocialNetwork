using Microsoft.EntityFrameworkCore;
using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DataAccess.Context
{
    public class SocialNetworkContext: DbContext
    {
        public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BOT-JGONZALEZA;Database=SocialNetworkDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendRelationship>().Property(f => f.IsAccepted).HasDefaultValue(false);
            
            modelBuilder.Entity<Post>().Property(p => p.Date).HasDefaultValueSql("GETDATE()");
            
            modelBuilder.Entity<Chat>().Property(c => c.Date).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<FriendRelationship>().HasOne(f => f.User).WithMany(u => u.FriendsWith).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FriendRelationship>().HasOne(f => f.FriendUser).WithMany(u => u.FriendsOf).HasForeignKey(f => f.FriendUserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>().HasOne(p => p.User).WithMany(u => u.Posts).HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Chat>().HasOne(c => c.SenderUser).WithMany(u => u.SentMessages).HasForeignKey(c => c.SenderUserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chat>().HasOne(c => c.TargetUser).WithMany(u => u.RecievedMessages).HasForeignKey(c => c.TargetUserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>().HasOne(m => m.Chat).WithOne(c => c.Message).HasForeignKey<Chat>(c => c.MessageId);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<FriendRelationship> Friends { get; set; }
    }
}
