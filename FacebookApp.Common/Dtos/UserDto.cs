using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Common.Dtos
{
	public class UserDto
	{
		public int UserId { get; set; }

		public string Name { get; set; }

		public string LastName { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public DateTime CreateDate { get; set; }

		public string Photo { get; set; }



		public override string ToString()
		{
			return this.Name;
		}

	}
}
