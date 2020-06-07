using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Common.Dtos
{
	public class CommentDto
	{
		public int PostCommentId { get; set; }
		public int PostId { get; set; }
		public int UserId { get; set; }
		public string CommentText { get; set; }

		public UserDto CommentUserDto { get; set; }

		public List<CommentDto> commentList { get; set; }
	}
}
