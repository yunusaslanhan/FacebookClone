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
	public class HomePageController : Controller
	{
		private IUserServices _userServices;
		private IPostServices _postServices;
		private IFriendServices _friendServices;
		private IRequestFriendServices _requestFriendServices;
		private readonly IHostingEnvironment he;
		private IMessageServices _messageServices;
		private static int _messageProfilUserId;
		private static int _commentPostId;
		

		private static int shareUserId=3;

		public HomePageController(IUserServices userServices, IPostServices postServices, IFriendServices friendServices, IRequestFriendServices requestFriendServices, IHostingEnvironment e, IMessageServices messageServices)
		{
			_userServices = userServices;
			_postServices = postServices;
			_friendServices = friendServices;
			_requestFriendServices = requestFriendServices;
			he = e;
			_messageServices = messageServices;
		}

		public IActionResult Index()
		{
			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));

			usermodel = _userServices.GetUserById(usermodel.UserId);

			var postListModel = _postServices.GetPostsById(usermodel.UserId);

			var friendListModel = _postServices.GetFriendPostsById(usermodel.UserId);
			foreach(var item in friendListModel)
			{
				item.isLike = _postServices.IsLikeControl(usermodel.UserId, item.PostId);
				item.isShared= _postServices.IsSharedControl(usermodel.UserId, item.PostId);
			}

			

			postListModel.AddRange(friendListModel);

			postListModel = postListModel.OrderByDescending(x => x.CreateDate).ToList();

			var requestFriendList = _userServices.GetMyRequestFriendsById(usermodel.UserId);

			var userListModel = _userServices.GetMyFriendsById(usermodel.UserId);

			ViewBag.userListModels = userListModel;

			UserPostDto userPostDto = new UserPostDto();

			userPostDto.userDto = usermodel;
			userPostDto.postList = postListModel;

			userPostDto.userList = requestFriendList;


			ViewBag.name = usermodel.Name;
			ViewBag.lastName = usermodel.LastName;
			ViewBag.photo = usermodel.Photo;
			ViewBag.id = usermodel.UserId;

			var modelShareUser = _userServices.GetUserById(shareUserId);

			ViewBag.ShareName = modelShareUser.Name;
			ViewBag.ShareLastName = modelShareUser.LastName;
			ViewBag.SharePhoto = modelShareUser.Photo;
			
			return View(userPostDto);
		}


		[HttpPost]
		public IActionResult Search(string name)
		{
			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));


			usermodel = _userServices.GetUserById(usermodel.UserId);
			var userList = _userServices.GetUsersByName(name);
			ViewBag.name = usermodel.Name;
			ViewBag.lastName = usermodel.LastName;
			ViewBag.photo = usermodel.Photo;
			ViewBag.id = usermodel.UserId;

			var userListModel = _userServices.GetMyFriendsById(usermodel.UserId);
			ViewBag.userListModels = userListModel;

			return View(userList);

		}

		[HttpPost]
		public IActionResult NewPostForAjax(PostDto postDto, IFormFile pic)
		{
			//var x = HttpContext.Request.Form.Files;
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


			return RedirectPermanent("/HomePage");

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


			return Json("/HomePage/");
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

			return Json("/HomePage/");
		}


		[HttpPost]
		public IActionResult SetLike(int postId)
		{
			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));

			var request = _postServices.IsLikeControl(usermodel.UserId,postId);

			if (request)
			{
				_postServices.DeleteLikes(usermodel.UserId, postId);
				
			}
			else
			{
				_postServices.AddLikes(usermodel.UserId, postId);
			}
			return RedirectPermanent("/HomePage");

		}

		public IActionResult GetMessage(int ToId)
		{
			_messageProfilUserId = ToId;
			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));
			UserPostDto userPostDto = new UserPostDto();

			userPostDto.messageList = _messageServices.getMessages(ToId, usermodel.UserId);
			userPostDto.messageDto = new MessageDto();
			userPostDto.loginUser = usermodel;
			
			userPostDto.userDto = _userServices.GetUserById(_messageProfilUserId);

			return PartialView("MessagePartial", userPostDto);
		}


		public IActionResult SendMessageForAjax(string MessageText)
		{
			
			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));
			UserPostDto userPostDto = new UserPostDto();

			_messageServices.AddMessages( new MessageDto {

				FromId=usermodel.UserId,
				ToId= _messageProfilUserId,
				MessageText=MessageText

			}
			);

			userPostDto.messageList = _messageServices.getMessages(_messageProfilUserId, usermodel.UserId);
			userPostDto.messageDto = new MessageDto();
			userPostDto.loginUser = usermodel;

			userPostDto.userDto = _userServices.GetUserById(_messageProfilUserId);

			return PartialView("MessagePartial", userPostDto);
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

			return Json("/HomePage/");
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
		public IActionResult AddCommentForAjax(int postId,string commentText)
		{

			UserDto usermodel = JsonConvert.DeserializeObject<UserDto>(HttpContext.Session.GetString("User"));

			CommentDto commentDto = new CommentDto();

			_postServices.AddComments(new CommentDto
			{
				UserId=usermodel.UserId,
				PostId=postId,
				CommentText=commentText

			});


			commentDto.commentList = _postServices.getComments(postId);
			
			return PartialView("CommentPartial", commentDto);
		}

	}
}