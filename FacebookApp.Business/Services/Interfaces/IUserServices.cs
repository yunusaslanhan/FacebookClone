using FacebookApp.Common.Dtos;
using FacebookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Business.Services.Interfaces
{
	public interface IUserServices
	{
		void AddUsers(UserDto userDto);
		List<UserDto> GetUsers();
		User GetUser(string email);
		UserDto GetUserById(int id);
		void Delete(UserDto user);
		bool LoginControl(string email, string password);
		UserDto GetByUserEmail(string email);
		List<UserDto> GetUsersByName(string name);// search yeri
		void UpdateUserPhoto(int id, string fileName);
		List<UserDto> GetMyFriendsById(int id);
		List<UserDto> GetMyRequestFriendsById(int id);

	}
}
