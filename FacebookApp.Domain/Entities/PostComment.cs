using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacebookApp.Domain.Entities
{
	[Table("PostComments")]
	public class PostComment
	{
		[Key]
		public int PostCommentId { get; set; }
		
		[Required]
		public int PostId { get; set; }
		public Post postId { get; set; }

		[Required]
		public int UserId { get; set; }
		public User userId { get; set; }

		[Required]
		public string CommentText { get; set; }

		[Required]
		public DateTime CreateDate { get; set; }

	}
}
