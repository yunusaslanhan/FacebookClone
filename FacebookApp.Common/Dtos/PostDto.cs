using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Common.Dtos
{
	public class PostDto
	{
		public int PostId { get; set; }

		public int UserId { get; set; }

		public string Name { get; set; }

		public string LastName { get; set; }

		public string Photo { get; set; }

		public string PostText { get; set; }

		public string PostImage { get; set; }

		public int LikeCount { get; set; }

		public int CommentCount { get; set; }

		public int ShareCount { get; set; }

		public DateTime CreateDate { get; set; }

		public bool isLike { get; set; }

		public bool isShared { get; set; }



		public override string ToString()
		{
			return this.PostText;
		}

	}
}
