using FacebookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp.Business.Context
{
	public class FacebookContext:DbContext
	{

		public FacebookContext(DbContextOptions<FacebookContext> options=null):base (options)
		{
				


		}


		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Post> Posts { get; set; }
		public virtual DbSet<Message> Messages { get; set; }
		public virtual DbSet<Friend> Friends { get; set; }
		public virtual DbSet<PostLike> PostLikes { get; set; }
		public virtual DbSet<PostComment> PostComment { get; set; }
		public virtual DbSet<PostShare> PostShare { get; set; }
		public virtual DbSet<RequestFriend> RequestFriends { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Friend>().HasKey(f => new { f.FromUserFriendId, f.ToUserFriendId });
			modelBuilder.Entity<RequestFriend>().HasKey(f => new { f.FromUserId, f.ToUserId });
			modelBuilder.Entity<PostLike>().HasKey(f => new { f.PostId, f.UserId });
			modelBuilder.Entity<PostShare>().HasKey(f => new { f.UserId, f.PostId });
			modelBuilder.Entity<PostComment>().HasKey(f => new { f.UserId, f.PostId });


			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

		}

	}
}
