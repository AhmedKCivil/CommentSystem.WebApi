namespace CommentSystem.Data.CommentSystemDB
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table("User")]
	public partial class User
	{
		public Guid ID { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }

	}
}