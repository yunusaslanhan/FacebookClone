using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FacebookApp.Business.Services.Interfaces;
using FacebookApp.Common.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FacebookApp.Web.Controllers
{
    public class ProfileController : Controller
    {

		
		private IUserServices _userServices;
		private IPostServices _postServices;
		private IFriendServices _friendServices;
		private IRequestFriendServices _requestFriendServices;
		private readonly IHostingEnvironment he;
		private static UserDto model;
		private static int _commentPostId;
	
		public ProfileController(IUserServices userServices,IPostServices postServices, IFriendServices friendServices,IRequestFriendServices requestFriendServices, IHostingEnvironment e)
		{
			_userServices = userServices;
			_postServices = postServices;
			_friendServices = friendServices;
			_requestFriendServices = requestFriendServices;
			he = e;
		}


		public IActionResult Index(int Id)
        {
			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));

			usermodel = _userServices.GetUserById(usermodel.UserId);

			model = _userServices.GetUserById(Id);
			
			var model2 = _postServices.GetPostsById(model.UserId);

			var MysharedPostList = _postServices.GetSharedPost(usermodel.UserId);

			model2.AddRange(MysharedPostList);

			var userListModel = _userServices.GetMyFriendsById(usermodel.UserId);

			

			foreach (var item in model2)
			{
				item.isLike = _postServices.IsLikeControl(usermodel.UserId, item.PostId);
				item.isShared = _postServices.IsSharedControl(usermodel.UserId, item.PostId);
			}


			ViewBag.userListModels = userListModel;

			UserPostDto userPostDto = new UserPostDto();


			userPostDto.userDto = model;

			userPostDto.postList = model2;

			userPostDto.loginUser = usermodel;

			userPostDto.userList = userListModel;

			ViewBag.IsFriend = _friendServices.isFriends(usermodel.UserId, model.UserId);



			ViewBag.isRequestFriendsByMe = _requestFriendServices.isRequestFriendsByMe(usermodel.UserId, model.UserId);
			ViewBag.isRequestFriendsByOne = _requestFriendServices.isRequestFriendsByOne(usermodel.UserId, model.UserId);

			
			ViewBag.photo = usermodel.Photo;
			ViewBag.name = usermodel.Name;
			ViewBag.id = usermodel.UserId;


			ViewBag.PostCount = _postServices.CountPost(Id);
			ViewBag.FriendCount = _friendServices.CountFriends(Id);


			return View(userPostDto);
        }

		[HttpPost]
		public IActionResult NewPostForAjax(PostDto postDto ,IFormFile pic)
		{
			int userId = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User")).UserId;
			if (pic != null)
			{

				var fileName = Path.Combine(he.WebRootPath, "images", "PostImages", Path.GetFileName(pic.FileName));
				pic.CopyTo(new FileStream(fileName, FileMode.Create));
				postDto.PostImage = pic.FileName;

			}

			if (postDto.PostImage != null || postDto.PostText != null)
			{
				_postServices.AddPosts(postDto);

			}


			return RedirectPermanent("/Profile/Index?Id="+ userId);
		}


		[HttpPost]
		public IActionResult PostAddFriendForAjax(RequestFriendDto requestFriendDto)
		{
			int userId = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User")).UserId;
			
			var requestfriend = new RequestFriendDto
			{
				FromUserId = userId,
				ToUserId = requestFriendDto.ToUserId

			};

			
			_requestFriendServices.AddRequestFriends(requestfriend);

			return Json("/Profile?Id=" + requestFriendDto.ToUserId);
		}
		[HttpPost]
		public IActionResult PostDeleteFriendForAjax(FriendDto friendDto)
		{
			int userId = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User")).UserId;

			var friend = new FriendDto
			{
				FromUserFriendId=userId,
				ToUserFriendId=friendDto.ToUserFriendId

			};

		
			_friendServices.DeleteFriends(friend);
		

			return Json("/Profile?Id=" + friendDto.ToUserFriendId);
		}

		[HttpPost]
		public IActionResult PostConfirmationFriendForAjax(FriendDto friendDto)
		{
			int userId = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User")).UserId;

			var friend = new FriendDto
			{
				FromUserFriendId = userId,
				ToUserFriendId = friendDto.ToUserFriendId

			};

			var requestFriend = new RequestFriendDto
			{
				FromUserId = userId,
				ToUserId = friend.ToUserFriendId


			};

			
			_friendServices.AddFriends(friend);
			_requestFriendServices.DeleteRequestFriends(requestFriend);


			return Json("/Profile?Id=" + friendDto.ToUserFriendId);
		}

		[HttpPost]
		public IActionResult PostRejectionFriendForAjax(RequestFriendDto requestFriendDto)
		{
			int userId = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User")).UserId;
			
			var requestfriend = new RequestFriendDto
			{
				FromUserId = userId,
				ToUserId = requestFriendDto.ToUserId

			};


			_requestFriendServices.DeleteRequestFriends(requestfriend);

			return Json("/Profile?Id=" + requestFriendDto.ToUserId);
		}


		[HttpPost]
		public IActionResult PostDeleteConfirmationForAjax(RequestFriendDto requestFriendDto)
		{
			int userId = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User")).UserId;

			var requestfriend = new RequestFriendDto
			{
				FromUserId = userId,
				ToUserId = requestFriendDto.ToUserId

			};


			_requestFriendServices.DeleteRequestFriends(requestfriend);

			return Json("/Profile?Id=" + requestFriendDto.ToUserId);
		}

		
		public ActionResult ShowFields(IFormFile pic)
		{
			int userId = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User")).UserId;

			if (pic!=null)
			{

				var fileName = Path.Combine(he.WebRootPath, Path.GetFileName(pic.FileName));
				pic.CopyTo(new FileStream(fileName, FileMode.Create));
				

			}
			_userServices.UpdateUserPhoto(userId, pic.FileName);


			return RedirectPermanent("/Profile?Id="+userId);
		}


		[HttpPost]
		public IActionResult SetLike(int postId)
		{
			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));

			var request = _postServices.IsLikeControl(usermodel.UserId, postId);

			if (request)
			{
				_postServices.DeleteLikes(usermodel.UserId, postId);

			}
			else
			{
				_postServices.AddLikes(usermodel.UserId, postId);
			}
			return RedirectPermanent("/Profile?Id=" + model.UserId);

		}



		public IActionResult PostSharedForAjax(int PostId)
		{

			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));

			//var model = _postServices.GetPost(PostId);

			//   shareUserId = model.UserId;



			//model.UserId = usermodel.UserId;

			//_postServices.AddPosts(model);




			//int sharePostId=_postServices.GetLastPostId();



			_postServices.AddShared(usermodel.UserId, PostId);

			return Json("/Profile?Id=" + model.UserId);
		}


		public IActionResult GetComment(int PostId)
		{
			_commentPostId = PostId;
			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));
			CommentDto commentDto = new CommentDto();

			commentDto.commentList = _postServices.getComments(PostId);
			//userPostDto.messageDto = new MessageDto();



			return PartialView("CommentPartial", commentDto);
		}

		[HttpPost]
		public IActionResult AddCommentForAjax(int postId, string commentText)
		{

			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));

			CommentDto commentDto = new CommentDto();

			_postServices.AddComments(new CommentDto
			{
				UserId = usermodel.UserId,
				PostId = postId,
				CommentText = commentText

			});


			commentDto.commentList = _postServices.getComments(postId);

			return PartialView("CommentPartial", commentDto);
		}
	}
}