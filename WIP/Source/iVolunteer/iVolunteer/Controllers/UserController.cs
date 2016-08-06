﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using System.Web.Mvc;
using iVolunteer.Models.SQL;
using iVolunteer.Models.ViewModel;
using iVolunteer.Models.MongoDB.CollectionClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.InformationClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.ItemClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.LinkClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.ListClass;
using iVolunteer.DAL.SQL;
using iVolunteer.DAL.MongoDB;
using iVolunteer.Common;
using Newtonsoft.Json;
using System.IO;

namespace iVolunteer.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// ユーザーホームページを表示
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UserHome(string userID)
        {
            SDLink result = null;
            try
            {
                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                result = userDAO.Get_SDLink(userID);
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }

            if (result == null)
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }
            return View("UserHome", result);
        }
        /// <summary>
        /// アバターカバー写真セクションを表示
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [ChildActionOnly]
        [OutputCache(Duration = 1)]
        public ActionResult AvatarCover(string userID)
        {
            SDLink result = null;
            try
            {
                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                result = userDAO.Get_SDLink(userID);
                if (Session["UserID"] != null && userID == Session["UserID"].ToString()) ViewBag.CanChange = "true";
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }

            if (result == null)
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }
            return PartialView("_AvatarCover", result);
        }
        /// <summary>
        /// アバター変更画面を表示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeAvatar()
        {
            ViewBag.Action = "UploadAvatar";
            ViewBag.Controller = "User";
            return PartialView("_ImageUpload");
        }
        /// <summary>
        /// アバター写真を更新
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadAvatar()
        {
            HttpPostedFileBase file = Request.Files["Image"];
            if (file != null)
            {
                string userID = Session["UserID"].ToString();
                // write your code to save image
                string uploadPath = Server.MapPath("/Images/User/Avatar/" + userID + ".jpg");
                file.SaveAs(uploadPath);
                return RedirectToAction("UserHome", "User", new { userID = userID });

            }
            else return PartialView("_ImageUpload");
        }
        /// <summary>
        /// カバー変更画面を表示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeCover()
        {
            ViewBag.Action = "UploadCover";
            ViewBag.Controller = "User";
            return PartialView("_ImageUpload");
        }
        /// <summary>
        /// カバー写真を更新
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadCover()
        {
            HttpPostedFileBase file = Request.Files["Image"];
            if (file != null)
            {
                string userID = Session["UserID"].ToString();
                // write your code to save image
                string uploadPath = Server.MapPath("/Images/User/Cover/" + userID + ".jpg");
                file.SaveAs(uploadPath);
                return RedirectToAction("UserHome", "User", new { userID = userID });

            }
            else return PartialView("_ImageUpload");
        }
        /// <summary>
        /// プロファイル情報を表示
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult PersonalInformation(string userID)
        {
            // check if parameter valid
            if (String.IsNullOrEmpty(userID))
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }

            if (Session["UserID"] != null && Session["UserID"].ToString() == userID)
                ViewBag.IsMyHome = true;
            else ViewBag.IsMyHome = false;

            try
            {
                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                var result = userDAO.Get_PersonalInformation(userID);
                return PartialView("_PersonalInformation", result);
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }
        }
        /// <summary>
        /// 参加したグループリストを表示
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult JoinedGroups(string userID)
        {
            // check if parameter valid
            if (String.IsNullOrEmpty(userID))
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }

            if (Session["UserID"] != null && Session["UserID"].ToString() == userID)
                ViewBag.IsMyHome = true;
            else ViewBag.IsMyHome = false;

            try
            {
                // get joined group list
                SQL_AcGr_Relation_DAO relationDAO = new SQL_AcGr_Relation_DAO();
                var listID = relationDAO.Get_Joined_Groups(userID);
                // get joined group Info
                Mongo_Group_DAO groupDAO = new Mongo_Group_DAO();
                var result = groupDAO.Get_GroupsInformation(listID);

                return PartialView("_JoinedGroups", result);
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }
        }
        /// <summary>
        /// 友達リスト
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult Friends(string userID)
        {
            // check if parameter valid
            if (String.IsNullOrEmpty(userID))
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }

            try
            {
                if (Session["UserID"] != null && Session["UserID"].ToString() == userID)
                    ViewBag.IsMyHome = true;
                else ViewBag.IsMyHome = false;

                ViewBag.UserID = userID;

                return PartialView("_Friends");
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }
        }
        /// <summary>
        /// 友達リストを表示
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult FriendList(string userID)
        {
            // check if parameter valid
            if (String.IsNullOrEmpty(userID))
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }

            if (Session["UserID"] != null && Session["UserID"].ToString() == userID)
                ViewBag.IsMyHome = true;
            else ViewBag.IsMyHome = false;

            try
            {
                // get friend
                SQL_AcAc_Relation_DAO relationDAO = new SQL_AcAc_Relation_DAO();
                var listID = relationDAO.Get_Friends(userID);
                // get friend
                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                var result = userDAO.Get_AccountsInformation(listID);

                return PartialView("_FriendList", result);
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }
        }
        /// <summary>
        /// 現在参加しているプロジェクトリストを表示
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult CurrentProjects(string userID)
        {
            // check if parameter valid
            if (String.IsNullOrEmpty(userID))
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }

            if (Session["UserID"] != null && Session["UserID"].ToString() == userID)
                ViewBag.IsMyHome = true;
            else ViewBag.IsMyHome = false;

            try
            {
                // get joined group list
                SQL_AcPr_Relation_DAO relationDAO = new SQL_AcPr_Relation_DAO();
                var listID = relationDAO.Get_Current_Projects(userID);
                // get joined group Info
                Mongo_Project_DAO projectDAO = new Mongo_Project_DAO();
                var result = projectDAO.Get_ProjectsInformation(listID);

                return PartialView("_CurrentProjects", result);
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }
        }
        /// <summary>
        /// 管理したプロジェクトリストを表示
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult OrganizedProjects(string userID)
        {
            // check if parameter valid
            if (String.IsNullOrEmpty(userID))
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }

            try
            {
                // get joined group list
                SQL_AcPr_Relation_DAO relationDAO = new SQL_AcPr_Relation_DAO();
                var listID = relationDAO.Get_Organized_Projects(userID);
                // get joined group Info
                Mongo_Project_DAO projectDAO = new Mongo_Project_DAO();
                var result = projectDAO.Get_ProjectsInformation(listID);

                return PartialView("_OrganizedProjects", result);
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }
        }
        /// <summary>
        /// 寄付したプロジェクトリストを取得
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult SponsoredProjects(string userID)
        {
            // check if parameter valid
            if (String.IsNullOrEmpty(userID))
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }

            try
            {
                // get joined group list
                SQL_AcPr_Relation_DAO relationDAO = new SQL_AcPr_Relation_DAO();
                var listID = relationDAO.Get_Sponsored_Projects(userID);
                // get joined group Info
                Mongo_Project_DAO projectDAO = new Mongo_Project_DAO();
                var result = projectDAO.Get_ProjectsInformation(listID);

                return PartialView("_SponsoredProjects", result);
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }
        }
        /// <summary>
        /// 参加したプロジェクトのリストを表示
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult ParticipatedProjects(string userID)
        {
            // check if parameter valid
            if (String.IsNullOrEmpty(userID))
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }

            try
            {
                // get joined group list
                SQL_AcPr_Relation_DAO relationDAO = new SQL_AcPr_Relation_DAO();
                var listID = relationDAO.Get_Participated_Projects(userID);
                // get joined group Info
                Mongo_Project_DAO projectDAO = new Mongo_Project_DAO();
                var result = projectDAO.Get_ProjectsInformation(listID);

                return PartialView("_ParticipatedProjects", result);
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }
        }
        /// <summary>
        /// 過去の活動画面を表示
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult ActivityHistory(string userID)
        {
            // check if parameter valid
            if (String.IsNullOrEmpty(userID))
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }

            try
            {
                ViewBag.UserID = userID;
                return PartialView("_ActivityHistory");
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult SearchUser(string name)
        {
            ViewBag.Name = name;
            return View("SearchUser");
        }
        /// <summary>
        /// 次の検索結果画面を表示
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult NextResultPage(string name, int page)
        {
            try
            {
                if (page <= 0) page = 1;
                if (String.IsNullOrEmpty(name.Trim()))
                {
                    ViewBag.Message = "Rất tiếc, chúng tôi không hiểu tìm kiếm này. Vui lòng thử truy vấn theo cách khác.";
                    return PartialView("ErrorMessage");
                }

                Mongo_User_DAO userDAO = new Mongo_User_DAO();

                List<AccountInformation> result = new List<AccountInformation>();
                if (Session["Role"] != null && Session["Role"].ToString() == "Admin")
                    result = userDAO.User_Search(name, 10 * (page - 1), 10);
                else result = userDAO.Active_User_Search(name, 10 * (page - 1), 10);

                ViewBag.Name = name;

                if (result.Count == 0)
                {
                    if (page == 1)
                        ViewBag.Message = "Không tìm thấy kết quả";
                    else
                        ViewBag.Message = "Không còn kết quả nào nữa!";
                    return PartialView("ErrorMessage");
                }

                ViewBag.NextPage = page + 1;
                return PartialView("_UserResult", result);
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return View("ErrorMessage");
            }
        }
        /// <summary>
        /// 友達リストを取得
        /// </summary>
        /// <returns></returns>
        public ActionResult displayFriendDemo()
        {
            try
            {
                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                List<SDLink> friendList = userDAO.Get_FriendList(Session["UserID"].ToString());

                return View("_ChatRoom", friendList);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 最近のメッセージを取得
        /// </summary>
        /// <param name="friendID"></param>
        /// <returns></returns>
        public JsonResult GetRecentMessages(string friendID)
        {
            if (Session["UserID"] == null) { return null; }
            string userID = Session["UserID"].ToString();
            //get SDLink user and friend
            Mongo_User_DAO userDAO = new Mongo_User_DAO();
            SDLink userSDLink = userDAO.Get_SDLink(userID);
            SDLink friendSDLink = userDAO.Get_SDLink(friendID);

            try
            {
                SQL_Message_DAO messageDAO = new SQL_Message_DAO();
                //Get messageID of the two persons
                string messageID = messageDAO.Get_MessageID(userID, friendID);
                Mongo_Message_DAO mgMessageDAO = new Mongo_Message_DAO();

                //check if the two have talk before
                // if NO then create new messageID
                if (messageID == null)
                {
                    // Add messageID to mongo
                    Mongo_Message message = new Mongo_Message();
                    message.Senders.Add(userSDLink);
                    message.Senders.Add(friendSDLink);

                    mgMessageDAO.Add_Message(message);

                    //Add messageID to SQL
                    SQL_Message sqlmessage1 = new SQL_Message();
                    sqlmessage1.MessageID = message._id.ToString();
                    sqlmessage1.UserID = userID;
                    SQL_Message sqlmessage2 = new SQL_Message();
                    sqlmessage2.MessageID = message._id.ToString();
                    sqlmessage2.UserID = friendID;

                    messageDAO.Add_Message(sqlmessage1);
                    messageDAO.Add_Message(sqlmessage2);

                    var result1 = new { messages = "", MessageID = message._id.ToString() };
                    return Json(result1);
                }
                List<MessageItem> messages = mgMessageDAO.Get_Recent_Messages(messageID);
                //Format time before Display 
                List<string> times = new List<string>();
                foreach (var item in messages)
                {
                    times.Add(Format_Time(item.DateSend));
                }
                var result = new { Messages = messages, MessageID = messageID, DisplayTimes = times };
                return Json(result);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// メッセージを作成
        /// </summary>
        /// <param name="messageID"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public JsonResult CreateMessage(string messageID, string content)
        {
            string userID = Session["UserID"].ToString();
            try
            {
                Mongo_Message_DAO mgMessageDAO = new Mongo_Message_DAO();
                DateTime time = mgMessageDAO.Add_Message_Item(messageID, userID, content);

                //FormatTime before showing;
                var displayTime = Format_Time(time);

                return Json(time.ToShortTimeString());
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 時間を形式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string Format_Time(DateTime time)
        {
            DateTime lcTime = time.ToLocalTime();
            DateTime now = DateTime.Now;
            string displayTime = "";
            if (now.Year == lcTime.Year)
            {
                if (now.Month == lcTime.Month)
                {
                    if ((now.Day - lcTime.Day) == 1)
                    {
                        displayTime = "Yesterday " + lcTime.ToShortTimeString();
                    }
                    else if (now.Day == lcTime.Day)
                    {
                        displayTime = lcTime.ToShortTimeString();
                    }
                    else displayTime = lcTime.Day + "/" + lcTime.Month + " " + lcTime.ToShortTimeString();
                }
                else displayTime = lcTime.Day + "/" + lcTime.Month + " " + lcTime.ToShortTimeString();
            }
            else displayTime = lcTime.ToLongDateString() + " " + lcTime.ToShortTimeString();

            return displayTime;
        }
        /// <summary>
        /// Search User in ChatBox
        /// 友達リストを取得
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string SearchUserForChat(string name)
        {
            try
            {
                if (String.IsNullOrEmpty(name))
                {
                    ViewBag.Message = Error.INVALID_INFORMATION;
                    return null;
                }

                Mongo_User_DAO userDAO = new Mongo_User_DAO();

                List<AccountInformation> result = new List<AccountInformation>();
                if (Session["Role"] != null && Session["Role"].ToString() == "Admin")
                    result = userDAO.User_Search(name, 0, 10);
                else result = userDAO.Active_User_Search(name, 0, 10);

                return JsonConvert.SerializeObject(result);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Load all Friend request notificaton
        /// 友達申請の通知を取得
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadFriendRequestNotif()
        {
            if (Session["UserID"] == null) return null;

            try
            {
                string userID = Session["UserID"].ToString();
                SQL_AcAc_Relation_DAO relation = new SQL_AcAc_Relation_DAO();
                var listID = relation.Get_Requests(userID);

                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                var listRequest = userDAO.Get_AccountsInformation(listID);

                return Json(listRequest);
            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// Load all Friend request accepted Notification
        /// 友達承認通知を取得
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadFriendRequestAccepted()
        {
            try
            {
                if (Session["UserID"] == null) return null;

                string userID = Session["UserID"].ToString();
                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                var notifList = userDAO.Get_FriendAcceptedNotification(userID, 0, 5);
                if (notifList == null) return Json(false);
                return Json(notifList);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Load all Unseen Notification
        /// 見ていない通知リストを取得
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadNotification()
        {
            try
            {
                if (Session["UserID"] == null) return null;

                string userID = Session["UserID"].ToString();
                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                var notifList = userDAO.Get_UnSeen_Notifications(userID, 0, 5);
                if (notifList == null) return Json(false);
                return Json(notifList);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Count unseen notification
        /// 見ていない通知を数える
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public JsonResult GetNotificationsCount(string userID)
        {
            Mongo_User_DAO userDAO = new Mongo_User_DAO();
            return Json(userDAO.Count_Notifications(userID));
        }
        /// <summary>
        /// Announce that user has seen this notification
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="notifyID"></param>
        /// <returns></returns>
        public JsonResult SeenJoinRequestAccepted(string userID, string notifyID)
        {
            try
            {
                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                userDAO.Set_Notification_IsSeen(userID, notifyID);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
        /// <summary>
        /// Annouce that user has seen this friend request accepted notification
        /// 通知の状態をIsSeenに設定
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="notifyID"></param>
        /// <returns></returns>
        public JsonResult SeenFriendRequestAccepted(string userID, string notifyID)
        {
            try
            {
                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                userDAO.Set_Notification_IsSeen(userID, notifyID);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
        /// <summary>
        /// プロファイル情報更新画面を表示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdatePersonalInformation()
        {
            // check if parameter valid
            if (Session["UserID"] == null)
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }

            try
            {
                string userID = Session["UserID"].ToString();

                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                var result = userDAO.Get_PersonalInformation(userID);
                return PartialView("_UpdatePersonalInformation", result);
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }
        }
        /// <summary>
        /// プロファイル情報を更新
        /// </summary>
        /// <param name="newInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdatePersonalInformation(PersonalInformation newInfo)
        {
            /// check if parameter valid
            if (Session["UserID"] == null)
            {
                ViewBag.Message = Error.ACCESS_DENIED;
                return PartialView("ErrorMessage");
            }

            if(!ModelState.IsValid) return PartialView("_UpdatePersonalInformation", newInfo);

            try
            {
                string userID = Session["UserID"].ToString();
                if (userID != newInfo.UserID)
                {
                    ViewBag.Message = Error.ACCESS_DENIED;
                    return PartialView("ErrorMessage");
                }

                Mongo_User_DAO userDAO = new Mongo_User_DAO();
                var result = userDAO.Update_PersonalInformation(userID, newInfo);
                return PersonalInformation(userID);
            }
            catch
            {
                ViewBag.Message = Error.UNEXPECT_ERROR;
                return PartialView("ErrorMessage");
            }
        }
    }
}