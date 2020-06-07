using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacebookApp.Domain.Entities
{
	[Table("PostLikes")]
	public class PostLike
	{
		
		[Key]
		public int PostLikeId { get; set; }


		[Required]
		public int PostId { get; set; }
		public Post postId { get; set; }

		[Required]
		public int UserId { get; set; }
		public User userId { get; set; }
		

	}
}
