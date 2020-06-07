using FacebookApp.Business.Context;
using FacebookApp.Business.Services.Interfaces;
using FacebookApp.Common.Dtos;
using FacebookApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp.Business.Services
{
	public class PostServices : IPostServices
	{

		private FacebookContext _dbContext;

		public PostServices(IHttpContextAccessor httpAccessor)
		{
			_dbContext = (FacebookContext)httpAccessor.HttpContext.RequestServices.GetService(typeof(FacebookContext));

		}

		public void AddPosts(PostDto postDto)
		{

			_dbContext.Posts.Add(new Post
			{
				UserId = postDto.UserId,
				PostText = postDto.PostText,
				LikeCount = postDto.LikeCount,
				CommentCount = postDto.CommentCount,
				ShareCount = postDto.ShareCount,
				PostImage = postDto.PostImage,
				CreateDate = DateTime.Now,
				

			});

			_dbContext.SaveChanges();



		}

		public int CountPost(int id)
		{
			return _dbContext.Posts.Count(t => t.UserId == id);
		}

		public List<PostDto> GetFriendPostsById(int id)
		{
			List<PostDto> list = new List<PostDto>();

			List<int> listFriend1 = new List<int>();
			List<int> listFriend2 = new List<int>();
		
			listFriend1 = _dbContext.Friends.Where(x => x.FromUserFriendId == id).Select(x => x.ToUserFriendId).ToList();
			listFriend2 = _dbContext.Friends.Where(x => x.ToUserFriendId == id).Select(x => x.FromUserFriendId).ToList();

			foreach (var item in listFriend2)
			{
				if (!listFriend1.Contains(item)) listFriend1.Add(item); 
				
			}
			
			foreach (var item in listFriend1)
			{
				list.AddRange(GetPostsById(item));

			}

			return list;



		}

		public List<PostDto> GetPostsById(int id)
		{

			var model = _dbContext.Posts.OrderByDescending(m => m.PostId).Where(x => x.UserId == id).Select(m => new PostDto
			{

				PostId = m.PostId,
				UserId = id,
				PostText = m.PostText,
				CommentCount = m.CommentCount,
				LikeCount = m.LikeCount,
				ShareCount = m.ShareCount,
				Name = _dbContext.Users.Where(a => a.UserId == id).Select(a => a.Name).SingleOrDefault(),
				LastName = _dbContext.Users.Where(a => a.UserId == id).Select(a => a.LastName).SingleOrDefault(),
				Photo = _dbContext.Users.Where(a => a.UserId == id).Select(a => a.Photo).SingleOrDefault(),
				CreateDate = m.CreateDate,
				PostImage = m.PostImage,
				isLike = _dbContext.PostLikes.Any(f=>(f.UserId == id) && (f.PostId == m.PostId)),
				isShared=_dbContext.PostShare.Any(f => (f.UserId == id) && (f.PostId == m.PostId))

			}).ToList();

			return model;




		}

		public void AddLikes(int userId,int postId)
		{
		     var post =_dbContext.PostLikes.ToList();
			if (post.Count()==0)
			{
				_dbContext.PostLikes.Add(new PostLike
				{
					PostLikeId = 1,
					UserId = userId,
					PostId = postId

				});
			}
			else
			{
				_dbContext.PostLikes.Add(new PostLike
				{
					PostLikeId = post.Last().PostLikeId +1,
					UserId = userId,
					PostId = postId

				});
			}	
			

			_dbContext.SaveChanges();

		}


		public void AddShared(int userId, int postId)
		{
			var post = _dbContext.PostShare.ToList();
			if (post.Count() == 0)
			{
				_dbContext.PostShare.Add(new PostShare
				{
					PostShareId = 1,
					UserId = userId,
					PostId = postId

				});
			}
			else
			{
				_dbContext.PostShare.Add(new PostShare
				{
					PostShareId = post.Last().PostShareId + 1,
					UserId = userId,
					PostId = postId

				});
			}


			_dbContext.SaveChanges();

		}

		public void DeleteLikes(int userId, int postId)
		{

			_dbContext.PostLikes.Remove(new PostLike
			{
				UserId = userId,
				PostId = postId

			});

			_dbContext.SaveChanges();

		}

		public bool IsLikeControl(int userId, int postId)
		{
			return _dbContext.PostLikes.Any(f => (f.UserId == userId) && (f.PostId == postId));
		}

		public bool IsSharedControl(int userId, int postId)
		{
			return _dbContext.PostShare.Any(f => (f.UserId == userId) && (f.PostId == postId));
		}


		public PostDto GetPost(int id)
		{

			var model = _dbContext.Posts.Where(p => p.PostId == id).Select(m => new PostDto
			{
				PostId = m.PostId,
				UserId = m.UserId,
				PostText = m.PostText,
				CommentCount = m.CommentCount,
				LikeCount = m.LikeCount,
				ShareCount = m.ShareCount,
				Name = _dbContext.Users.Where(a => a.UserId == id).Select(a => a.Name).SingleOrDefault(),
				LastName = _dbContext.Users.Where(a => a.UserId == id).Select(a => a.LastName).SingleOrDefault(),
				Photo = _dbContext.Users.Where(a => a.UserId == id).Select(a => a.Photo).SingleOrDefault(),
				CreateDate = m.CreateDate,
				PostImage = m.PostImage,
				isLike = _dbContext.PostLikes.Any(f => (f.UserId == id) && (f.PostId == m.PostId)),
				isShared = _dbContext.PostShare.Any(f => (f.UserId == id) && (f.PostId == m.PostId))


			}).Single();

			return model;
		}

		public int GetLastPostId()
		{

			int id=_dbContext.Posts.Max(p=>p.PostId);
			
			return id;
		}


		public List<CommentDto> getComments(int postId)
		{

			var q1 = from c in _dbContext.PostComment
					 join u in _dbContext.Users on c.UserId equals u.UserId
					 select new CommentDto
					 {
						 CommentText = c.CommentText,
						 PostId = c.PostId,
						 UserId = c.UserId,
						 PostCommentId = c.PostCommentId,
						 CommentUserDto = new UserDto
						 {

							 Name = u.Name,
							 LastName = u.LastName,
							 Photo = u.Photo

						 }
					 };

			return q1.Where(p => p.PostId == postId).ToList();
		}


		public void AddComments(CommentDto commentDto)
		{

			var post = _dbContext.PostComment.ToList();
			if (post.Count() == 0)
			{
				_dbContext.PostComment.Add(new PostComment
				{
					PostCommentId = 1,
					CommentText = commentDto.CommentText,
					PostId = commentDto.PostId,
					UserId = commentDto.UserId
					


				});
			}
			else
			{
				_dbContext.PostComment.Add(new PostComment
				{
					PostCommentId = post.Last().PostCommentId + 1,
					CommentText = commentDto.CommentText,
					PostId = commentDto.PostId,
					UserId = commentDto.UserId
					

				});
			}
			
			_dbContext.SaveChanges();

		}


		public List<PostDto> GetSharedPost(int userId)
		{

			var q1 = (from ps in _dbContext.PostShare
					  join p in _dbContext.Posts on ps.PostId equals p.PostId
					  join u in _dbContext.Users on p.UserId equals u.UserId
					  where ps.UserId == userId
					  select new PostDto
					  {
						  PostId = p.PostId,
						  CreateDate = p.CreateDate,
						  PostText = p.PostText,
						  PostImage = p.PostImage,
						  UserId = u.UserId,
						  Name = u.Name,
						  LastName = u.LastName,
						  Photo = u.Photo,
						  

					  }).ToList();

			return q1;
		}




	}
}
