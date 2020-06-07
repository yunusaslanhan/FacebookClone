using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Common.Dtos
{
	public class MessageDto
	{
		public int MessageId { get; set; }
		public int FromId { get; set; }
		public int ToId { get; set; }
		public string MessageText { get; set; }
	}
}
