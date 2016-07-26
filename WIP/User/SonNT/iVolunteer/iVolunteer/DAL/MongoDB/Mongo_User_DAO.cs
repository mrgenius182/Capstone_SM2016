﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.IO;
using MongoDB.Driver.Builders;
using iVolunteer.Models.MongoDB.CollectionClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.InformationClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.ListClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.ItemClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.LinkClass;
using iVolunteer.Common;

namespace iVolunteer.DAL.MongoDB
{
    public class Mongo_User_DAO : Mongo_DAO
    {
        IMongoCollection<Mongo_User> collection = db.GetCollection<Mongo_User>("User");
        /// <summary>
        /// add new user to mongoDB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Add_User(Mongo_User user)
        {
            try
            {
                collection.InsertOne(user);
                return true;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// get personal infofmation of an user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public PersonalInformation Get_PersonalInformation(string userID)
        {
            try
            {
                var result = collection.AsQueryable().FirstOrDefault(u => u.PersonalInformation.UserID == userID);
                return result.PersonalInformation;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// get account infofmation of an user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public AccountInformation Get_AccountInformation(string userID)
        {
            try
            {
                var result = collection.AsQueryable().FirstOrDefault(u => u.AccountInformation.UserID == userID);
                return result.AccountInformation;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// get SDlink of a user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public SDLink Get_SDLink(string userID)
        {
            try
            {
                var result = collection.AsQueryable().FirstOrDefault(u => u.AccountInformation.UserID == userID);
                return new SDLink(result.AccountInformation);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// get list accoutn information from list ID
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public List<AccountInformation> Get_AccountsInformation(List<string> listID)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.In(gr => gr.AccountInformation.UserID, listID);
                var result = collection.Find(filter).ToList().Select(gr => gr.AccountInformation).ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// inscrease groupCount by 1
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Join_Group(string userID)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(u => u.AccountInformation.UserID, userID);
                var update = Builders<Mongo_User>.Update.Inc(u => u.AccountInformation.GroupCount, 1);
                var result = collection.UpdateOne(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// decrease groupCount by 1
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Out_Group(string userID)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(u => u.AccountInformation.UserID, userID);
                var update = Builders<Mongo_User>.Update.Inc(u => u.AccountInformation.GroupCount, -1);
                var result = collection.UpdateOne(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// inscrease ProjectCOunt by 1
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Join_Project(string userID)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(u => u.AccountInformation.UserID, userID);
                var update = Builders<Mongo_User>.Update.Inc(u => u.AccountInformation.ProjectCount, 1);
                var result = collection.UpdateOne(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// decrease ProjectCOunt by 1
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Out_Project(string userID)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(u => u.AccountInformation.UserID, userID);
                var update = Builders<Mongo_User>.Update.Inc(u => u.AccountInformation.ProjectCount, -1);
                var result = collection.UpdateOne(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// inscrease FriendCount by 1
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Add_Friend(string userID)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(u => u.AccountInformation.UserID, userID);
                var update = Builders<Mongo_User>.Update.Inc(u => u.AccountInformation.FriendCount, 1);
                var result = collection.UpdateOne(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// decrease FriendCount by 1
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Delete_Friend(string userID, string friendID)
        {
            try
            {
<<<<<<< HEAD
                var filter = Builders<Mongo_User>.Filter.Eq(u => u.AccountInformation.UserID, userID);
                var update = Builders<Mongo_User>.Update.Inc(u => u.AccountInformation.FriendCount, -1);
                var result = collection.UpdateOne(filter, update);
=======
                var user_filter = Builders<Mongo_User>.Filter.Eq(acc => acc.AccountInformation.UserID, userID);
                var friend_filter = Builders<SDLink>.Filter.Eq(s => s.ID, friendID);
                var update = Builders<Mongo_User>.Update.PullFilter(u => u.FriendList, friend_filter)
                                                        .Inc(u => u.AccountInformation.FriendCount, -1); ;
                var result = collection.UpdateOne(user_filter, update);
>>>>>>> origin/master
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// confirmed account
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Confirmed(string userID)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(u => u.AccountInformation.UserID, userID)
                           & Builders<Mongo_User>.Filter.Eq(u => u.AccountInformation.IsActivate, Status.IS_ACTIVATE)
                           & Builders<Mongo_User>.Filter.Eq(u => u.AccountInformation.IsConfirmed, Status.IS_NOT_CONFIRMED);
                var update = Builders<Mongo_User>.Update.Set(u => u.AccountInformation.IsConfirmed, Status.IS_CONFIRMED);
                var result = collection.UpdateOne(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// udpate user personal information, only phone and address
        /// </summary>
        /// <param name="userID"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public bool Update_PersonalInformation(string userID, string newPhone, string newAddress)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(u => u.PersonalInformation.UserID, userID)
                           & Builders<Mongo_User>.Filter.Eq(u => u.AccountInformation.IsActivate, Status.IS_ACTIVATE);
                var update = Builders<Mongo_User>.Update.Set(u => u.PersonalInformation.Phone, newPhone)
                                                        .Set(u => u.PersonalInformation.Address, newAddress)
                                                        .Set(u => u.AccountInformation.Address, newAddress);
                var result = collection.UpdateOne(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// search active user, for user usage
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<AccountInformation> Active_User_Search(string name, int skip, int number)
        {
            try
            {
                var result = collection.AsQueryable().Where(ac => ac.AccountInformation.DisplayName.ToLower().Contains(name.ToLower())
                                                               && ac.AccountInformation.IsActivate == Status.IS_ACTIVATE)
                                                     .Skip(skip).Take(number)
                                                     .Select(ac => ac.AccountInformation).ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// search all user, for admin usage
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<AccountInformation> User_Search(string name, int skip, int number)
        {
            try
            {
                var result = collection.AsQueryable().Where(ac => ac.AccountInformation.DisplayName.ToLower().Contains(name.ToLower()))
                                                     .Skip(skip).Take(number)
                                                     .Select(ac => ac.AccountInformation).ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Get users who is deactivated
        /// </summary>
        /// <returns></returns>
        public List<SDLink> Get_Banned_Users()
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(gr => gr.AccountInformation.IsActivate, Status.IS_BANNED);
                var result = collection.Find(filter).ToList();
                List<SDLink> BannedUsers = new List<SDLink>();
                foreach (var item in result)
                {
                    BannedUsers.Add(Get_SDLink(item.AccountInformation.UserID));
                }
                return BannedUsers;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// set activation statuc for an account in mongDB
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="status"></param>
        /// <returns>true if success</returns>
        public bool Set_Activation_Status(string userID, bool status)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(acc => acc.AccountInformation.UserID, userID);
                var update = Builders<Mongo_User>.Update.Set(acc => acc.AccountInformation.IsActivate, status);
                var result = collection.UpdateOne(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Get friend list ***NEED FOR CHAT FUNCTION
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<SDLink> Get_FriendList(string userID)
        {
            try
            {
                var result = collection.AsQueryable().FirstOrDefault(u => u.AccountInformation.UserID == userID);
                return result.FriendList;
            }
            catch
            {
                throw;
            }
        }
        public bool Add_Friend_To_List(string userID, SDLink user)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(acc => acc.AccountInformation.UserID, userID);
                var update = Builders<Mongo_User>.Update.AddToSet(u => u.FriendList, user)
                                                        .Inc(u => u.AccountInformation.FriendCount, 1);
                var result = collection.UpdateOne(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
<<<<<<< HEAD
        /// increase each user groupcount by 1
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public bool Batch_Join_Group(IEnumerable<string> listID)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.In(u => u.AccountInformation.UserID, listID);
                var update = Builders<Mongo_User>.Update.Inc(u => u.AccountInformation.GroupCount, 1);
                var result = collection.UpdateMany(filter, update);
=======
        /// add new notification to user
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="notify"></param>
        /// <returns></returns>
        public bool Add_Notification(string userID, Notification notify)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(acc => acc.AccountInformation.UserID, userID);
                var update = Builders<Mongo_User>.Update.AddToSet(u => u.NotificationList, notify);
                var result = collection.UpdateOne(filter, update);
>>>>>>> origin/master
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }
<<<<<<< HEAD
=======
        /// <summary>
        /// set a notification is seen
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="notifyID"></param>
        /// <returns></returns>
        public bool Set_Notification_IsSeen(string userID, string notifyID)
        {
            try
            {
                var user_filter = Builders<Mongo_User>.Filter.Where(u => u.AccountInformation.UserID == userID && u.NotificationList.Any(no => no.NotifyID == notifyID));
                var update = Builders<Mongo_User>.Update.Set(u => u.NotificationList.ElementAt(-1).IsSeen, Status.IS_SEEN);
                var result = collection.UpdateOne(user_filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// get a number of user's notification
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="skip"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<Notification> Get_Notifications(string userID, int skip, int number)
        {
            try
            {
                var result = collection.AsQueryable().FirstOrDefault(u => u.AccountInformation.UserID == userID);
                return result.NotificationList.Skip(skip).Take(number).ToList();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Notificaiton
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="friendID"></param>
        /// <returns></returns>
        public bool Delete_Notification(string userID, string notifyID)
        {
            try
            {
                var user_filter = Builders<Mongo_User>.Filter.Eq(acc => acc.AccountInformation.UserID, userID);
                var notify_filter = Builders<Notification>.Filter.Eq(nt => nt.NotifyID, notifyID);
                var update = Builders<Mongo_User>.Update.PullFilter(u => u.NotificationList, notify_filter);
                var result = collection.UpdateOne(user_filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }

>>>>>>> origin/master

        /// <summary>
        /// decrease each user groupCount by 1
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Batch_Out_Group(IEnumerable<string> listID)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.In(u => u.AccountInformation.UserID, listID);
                var update = Builders<Mongo_User>.Update.Inc(u => u.AccountInformation.GroupCount, -1);
                var result = collection.UpdateMany(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// inscrease each user ProjectCOunt by 1
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Batch_Join_Project(IEnumerable<string> listID)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.In(u => u.AccountInformation.UserID, listID);
                var update = Builders<Mongo_User>.Update.Inc(u => u.AccountInformation.ProjectCount, 1);
                var result = collection.UpdateMany(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// decrease each user ProjectCOunt by 1
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Batch_Out_Project(IEnumerable<string> listID)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.In(u => u.AccountInformation.UserID, listID);
                var update = Builders<Mongo_User>.Update.Inc(u => u.AccountInformation.ProjectCount, -1);
                var result = collection.UpdateMany(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }

        public bool Update_ProjectCount(string userID, int newCount)
        {
            try
            {
                var filter = Builders<Mongo_User>.Filter.Eq(u => u.AccountInformation.UserID, userID);
                var update = Builders<Mongo_User>.Update.Inc(u => u.AccountInformation.ProjectCount, newCount);
                var result = collection.UpdateOne(filter, update);
                return result.IsAcknowledged;
            }
            catch
            {
                throw;
            }
        }
    }
}