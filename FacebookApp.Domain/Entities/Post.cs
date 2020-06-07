using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacebookApp.Domain.Entities
{
	[Table("Posts")]
	public class Post
	{
		[Key]
		public int PostId { get; set; }

		[Required]
		public int UserId { get; set; }
		public User user { get; set; }

		
		public string PostText { get; set; }

		
		public string PostImage { get; set; }

		[Required]
		public int LikeCount { get; set; }

		[Required]
		public int CommentCount { get; set; }

		[Required]
		public int ShareCount { get; set; }

		[Required]
		public DateTime CreateDate { get; set; }

		public virtual ICollection<PostLike> PostLike { get; set; }
		public virtual ICollection<PostComment> PostComment { get; set; }
		public virtual ICollection<PostShare> PostShare { get; set; }

	}
}
