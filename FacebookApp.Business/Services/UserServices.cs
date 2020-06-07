using FacebookApp.Business.Context;
using FacebookApp.Business.Services.Interfaces;
using FacebookApp.Common.Dtos;
using FacebookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace FacebookApp.Business.Services
{
	public class UserServices:IUserServices
	{
		private FacebookContext _dbContext;

		public UserServices(IHttpContextAccessor httpAccessor)
		{
			_dbContext = (FacebookContext)httpAccessor.HttpContext.RequestServices.GetService(typeof(FacebookContext));

		}

		public void AddUsers(UserDto userDto)
		{

			_dbContext.Users.Add(new User
			{

				Password = userDto.Password,
				Name = userDto.Name,
				LastName = userDto.LastName,
				Email = userDto.Email,
				CreateDate = DateTime.Now,
				Photo = "images\\profilImage.png"

		});

			_dbContext.SaveChanges();

		}



		public void Delete(UserDto user)
		{
			throw new NotImplementedException();
		}

		public User GetUser(string email)
		{
			var model = _dbContext.Users.Where(x => x.Email == email).FirstOrDefault();
			return model;
			
		}

		public UserDto GetByUserEmail(string email)
		{
			var user = GetUser(email);
			return new UserDto
			{
				UserId = user.UserId,
				Name = user.Name,
				LastName = user.LastName,
				Email = user.Email,
				Password = user.Password,
				CreateDate = user.CreateDate,
				Photo = user.Photo,
			
			};


		}

		public List<UserDto> GetUsers()
		{

			var model = _dbContext.Users.Select(m => new UserDto
			{

				UserId = m.UserId,
				Name = m.Name,
				LastName = m.LastName,
				CreateDate = m.CreateDate,
				Email = m.Email,
				Password = m.Password,
				Photo = m.Photo


			}).ToList();

			return model;

		}

		public bool LoginControl(string email, string password)
		{

			var indexUserNamePassword = _dbContext.Users.Any(x => x.Email == email && x.Password == password);


			if (indexUserNamePassword)
			{
				return true;
			}

			else
			{
				return false;
			}

		}

		public UserDto GetUserById(int id)
		{
			var model = _dbContext.Users.Where(x => x.UserId == id).Select(u => new UserDto
			{
				UserId = u.UserId,
				Name = u.Name,
				LastName = u.LastName,
				CreateDate = u.CreateDate,
				Email = u.Email,
				Password = u.Password,
				Photo = u.Photo,

			}).FirstOrDefault();


			return model;
		}

		public List<UserDto> GetUsersByName(string name)
		{

			var model = _dbContext.Users.Where(x => x.Name.Contains(name)).Select(m => new UserDto
			{
				UserId=m.UserId,
				Name=m.Name,
				LastName=m.LastName,
				CreateDate=m.CreateDate,
				Email=m.Email,
				Password=m.Password,
				Photo=m.Photo
				
			}).ToList();

			return model;

		}


		public void UpdateUserPhoto(int id,string fileName) {

			User model = _dbContext.Users.First(x => x.UserId == id);

			model.Photo = fileName;
			
			_dbContext.SaveChanges();
				
			
		}


		public List<UserDto> GetMyFriendsById(int id)
		{

			List<UserDto> friendlist = new List<UserDto>();

			List<int> friend1 = new List<int>();
			List<int> friend2 = new List<int>();

			friend1 = _dbContext.Friends.Where(x => x.FromUserFriendId == id).Select(x => x.ToUserFriendId).ToList();
			friend2 = _dbContext.Friends.Where(x => x.ToUserFriendId == id).Select(x => x.FromUserFriendId).ToList();

			foreach (var item in friend2)
			{
				if (!friend1.Contains(item)) friend1.Add(item);

			}

			foreach (var item in friend1)
			{
				friendlist.Add(GetUserById(item));

			}

			return friendlist;
		}



		public List<UserDto> GetMyRequestFriendsById(int id)
		{

			List<UserDto> friendlist = new List<UserDto>();

			List<int> friend1 = new List<int>();
			List<int> friend2 = new List<int>();

			
			friend2 = _dbContext.RequestFriends.Where(x => x.ToUserId == id).Select(x => x.FromUserId).ToList();

			

			foreach (var item in friend2)
			{
				friendlist.Add(GetUserById(item));

			}

			return friendlist;
		}

	}
}
