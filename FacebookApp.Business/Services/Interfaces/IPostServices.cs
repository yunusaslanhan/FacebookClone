using FacebookApp.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Business.Services.Interfaces
{
	public interface IPostServices
	{
		void AddPosts(PostDto postDto);
		List<PostDto> GetPostsById(int id);
		List<PostDto> GetFriendPostsById(int id);
		int CountPost(int id);
		void AddLikes(int userId,int postId);
		void DeleteLikes(int userId, int postId);
		bool IsLikeControl(int userId,int postId);
		void AddShared(int userId, int postId);
		bool IsSharedControl(int userId, int postId);
		PostDto GetPost(int id);
		int GetLastPostId();
		List<CommentDto> getComments(int postId);
		void AddComments(CommentDto commentDto);
		List<PostDto> GetSharedPost(int userId);



	}
}
