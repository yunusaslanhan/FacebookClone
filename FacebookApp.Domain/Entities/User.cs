using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacebookApp.Domain.Entities
{

	[Table("Users")]
	public class User
	{
		[Key]
		public int UserId { get; set; }
	
		[Required]
		[StringLength(50)]
		public string Password { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		public string Email { get; set; }

		[Required]
		[StringLength(50)]
		public string LastName { get; set; }


		[StringLength(50)]
		public DateTime CreateDate { get; set; }


		[StringLength(100)]
		public string Photo { get; set; }


		public virtual ICollection<Post> Posts { get; set; }

		[InverseProperty("FromUser")]
		public virtual ICollection<Message> FromMessage { get; set; }

		[InverseProperty("ToUser")]
		public virtual ICollection<Message> ToMessage { get; set; }

		[InverseProperty("ToUserFriend")]
		public virtual ICollection<Friend> ToUserFriend { get; set; }

		[InverseProperty("FromUserFriend")]
		public virtual ICollection<Friend> FromUserFriend { get; set; }

		[InverseProperty("ToRequestUser")]
		public virtual ICollection<RequestFriend> ToRequestUser { get; set; }

		[InverseProperty("FromRequestUser")]
		public virtual ICollection<RequestFriend> FromRequestUser { get; set; }
		

		public virtual ICollection<PostLike> PostLikes { get; set; }
		public virtual ICollection<PostComment> PostComments { get; set; }
		public virtual ICollection<PostShare> PostShares { get; set; }


	}
}
