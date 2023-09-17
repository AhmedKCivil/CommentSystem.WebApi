using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentSystem.Data.CommentSystemDB
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class CommentSystemDB : DbContext
	{
		public CommentSystemDB()
			: base("name=CommentSystemDB")
		{
		}

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Comment> Comments { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
