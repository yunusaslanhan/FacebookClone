using FacebookApp.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Business.Services.Interfaces
{
	public interface IFriendServices
	{
		void AddFriends(FriendDto friendDto);
		void DeleteFriends(FriendDto friendDto);
		bool isFriends(int loginId, int userId);
		int CountFriends(int id);
		List<UserDto> Friends(int id);

	}
}
