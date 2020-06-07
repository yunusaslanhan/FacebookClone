using FacebookApp.Business.Context;
using FacebookApp.Business.Services.Interfaces;
using FacebookApp.Common.Dtos;
using FacebookApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp.Business.Services
{
	public class FriendServices:IFriendServices
	{
		private FacebookContext _dbContext;

		public FriendServices(IHttpContextAccessor httpAccessor)
		{
			_dbContext = (FacebookContext)httpAccessor.HttpContext.RequestServices.GetService(typeof(FacebookContext));

			
		}

		public void AddFriends(FriendDto friendDto)
		{

			_dbContext.Friends.Add(new Friend
			{
				FromUserFriendId = friendDto.FromUserFriendId,
				ToUserFriendId = friendDto.ToUserFriendId
			});

			_dbContext.SaveChanges();




		}

		public int CountFriends(int id)
		{
			return _dbContext.Friends.Count(f => f.FromUserFriendId == id || f.ToUserFriendId==id);
		}

		public void DeleteFriends(FriendDto friendDto)
		{
			if (_dbContext.Friends.Any(x=>x.ToUserFriendId==friendDto.ToUserFriendId && x.FromUserFriendId==friendDto.FromUserFriendId))
			{
				_dbContext.Friends.Remove(new Friend
				{
					FromUserFriendId = friendDto.FromUserFriendId,
					ToUserFriendId = friendDto.ToUserFriendId
				});
			}
			else {
			_dbContext.Friends.Remove(new Friend
			{
				FromUserFriendId = friendDto.ToUserFriendId,
				ToUserFriendId = friendDto.FromUserFriendId
			});

			}


			_dbContext.SaveChanges();



		}

		public List<UserDto> Friends(int id)
		{
			List<UserDto> dto = _dbContext.Friends
				.Where(f => f.FromUserFriendId == id)
				.Include(u => u.FromUserFriend)
				.Select(f => f.ToUserFriend)
				.Select(user => new UserDto
				{
					UserId = user.UserId,
					Name = user.Name,
					LastName = user.LastName,
					Email = user.Email,
					Password = user.Password,
					CreateDate = user.CreateDate,
					Photo = user.Photo

				}).ToList();
			return dto;
		}

		public bool isFriends(int loginId, int userId)
		{
			return _dbContext.Friends.Any(f => ((f.FromUserFriendId == loginId) && (f.ToUserFriendId == userId)) || ((f.ToUserFriendId == loginId) && (f.FromUserFriendId == userId)));
		}
	}
}
