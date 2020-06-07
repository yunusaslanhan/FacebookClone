using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacebookApp.Domain.Entities
{
	[Table("RequestFriends")]
	public class RequestFriend
	{
		[Key, Column(Order = 0)]
		[ForeignKey("ToRequestUser")]
		public int ToUserId { get; set; }
		public User ToRequestUser { get; set; }
		

		[Key, Column(Order = 1)]
		[ForeignKey("FromRequestUser")]
		public int FromUserId { get; set; }
		public User FromRequestUser { get; set; }
	}
}
