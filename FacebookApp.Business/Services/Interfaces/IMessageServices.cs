using FacebookApp.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Business.Services.Interfaces
{
	public interface IMessageServices
	{
		void AddMessages(MessageDto messageDto);
		List<MessageDto> getMessages(int fromId, int toId);
	}
}
