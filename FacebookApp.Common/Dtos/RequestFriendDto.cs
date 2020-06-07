using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Common.Dtos
{
	public class RequestFriendDto
	{
		public int ToUserId { get; set; }

		public int FromUserId { get; set; }
	}
}
