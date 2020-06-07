using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Common.Dtos
{
	public class UserPostDto
	{
		public UserDto userDto { get; set; }

		public UserDto loginUser { get; set; }

		public PostDto postDto { get; set; }

		public List<PostDto> postList { get; set; }

		public List<UserDto> userList { get; set; }

		public List<MessageDto> messageList { get; set; }

		public MessageDto messageDto { get; set; }


		public List<CommentDto> commentList { get; set; }

	}
}
