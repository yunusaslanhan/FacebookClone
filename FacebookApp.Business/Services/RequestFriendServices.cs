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
	public class RequestFriendServices:IRequestFriendServices
	{
		private FacebookContext _dbContext;

		public RequestFriendServices(IHttpContextAccessor httpAccessor)
		{
			_dbContext = (FacebookContext)httpAccessor.HttpContext.RequestServices.GetService(typeof(FacebookContext));


		}

		public void AddRequestFriends(RequestFriendDto requestFriendDto)
		{
			_dbContext.RequestFriends.Add(new RequestFriend
			{
				FromUserId=requestFriendDto.FromUserId,
				ToUserId=requestFriendDto.ToUserId
		
			});

			_dbContext.SaveChanges();
		}

		public int CountRequestFriends(int id)
		{
			return _dbContext.RequestFriends.Count(f => f.ToUserId == id);
		}

		public void DeleteRequestFriends(RequestFriendDto requestFriendDto)
		{
			if (_dbContext.RequestFriends.Any(x => x.FromUserId == requestFriendDto.FromUserId && x.ToUserId == requestFriendDto.ToUserId))
			{
				_dbContext.RequestFriends.Remove(new RequestFriend
				{
					FromUserId = requestFriendDto.FromUserId,
					ToUserId = requestFriendDto.ToUserId

				});
			}
			else
			{
				_dbContext.RequestFriends.Remove(new RequestFriend
				{
					FromUserId = requestFriendDto.ToUserId,
					ToUserId = requestFriendDto.FromUserId

				});
			}
			_dbContext.SaveChanges();
		}

		public bool isRequestFriendsByMe(int loginId, int userId)
		{
			return _dbContext.RequestFriends.Any(f => ((f.FromUserId == loginId) && (f.ToUserId == userId)));
		}

		public bool isRequestFriendsByOne(int loginId, int userId)
		{
			return _dbContext.RequestFriends.Any(f => ((f.ToUserId == loginId) && (f.FromUserId == userId)));
		}


		public List<UserDto> RequestFriends(int id)
		{
			List<UserDto> dto = _dbContext.RequestFriends
				.Where(f => f.ToUserId == id)
				.Include(u => u.FromRequestUser)
				.Select(f => f.ToRequestUser)
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
	}
}
