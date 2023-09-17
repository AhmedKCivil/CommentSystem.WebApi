namespace CommentSystem.Data.CommentSystemDB
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table("Comment")]
	public partial class Comment
	{
		public Guid ID { get; set; }
		public Guid UserID { get; set; }
		public string UserName { get; set; }
		public DateTime DateTime { get; set; }
		public string UserComment { get; set; }
		[Required]
		public Boolean Edited { get; set; }
		public Guid? CommentID { get; set; }

	}
}