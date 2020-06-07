using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacebookApp.Domain.Entities
{
	[Table("Friends")]
	public class Friend
	{

		[Key, Column(Order = 0)]
		[ForeignKey("ToUserFriend")]
		public int ToUserFriendId { get; set; }
		public User ToUserFriend { get; set; }


		[Key, Column(Order = 1)]
		[ForeignKey("FromUserFriend")]
		public int	FromUserFriendId { get; set; }
		public User FromUserFriend { get; set; }
		
	}
}
