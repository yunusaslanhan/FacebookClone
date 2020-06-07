using FacebookApp.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Business.Services.Interfaces
{
	public interface IRequestFriendServices
	{
		void AddRequestFriends(RequestFriendDto requestFriendDto);
		void DeleteRequestFriends(RequestFriendDto requestFriendDto);
		bool isRequestFriendsByMe(int loginId, int userId);
		bool isRequestFriendsByOne(int loginId, int userId);
		int CountRequestFriends(int id);
		List<UserDto> RequestFriends(int id);

	}
}
