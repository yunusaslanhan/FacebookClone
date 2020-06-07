using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacebookApp.Domain.Entities
{
	[Table("Messages")]
	public class Message
	{
		[Key]
		public int MessageId { get; set; }

		[ForeignKey("FromUser")]
		public int FromId { get; set; }
		public User FromUser { get; set; }

		[ForeignKey("ToUser")]
		public int ToId { get; set; }
		public User ToUser { get; set; }

		[Required]
		public string MessageText { get; set; }


	}

}
