﻿using MongoDB.Bson;
using iVolunteer.Models.MongoDB.EmbeddedClass.InformationClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.LinkClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.ItemClass;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace iVolunteer.Models.MongoDB.CollectionClass
{
    /// <summary>
    /// This class define structure of "Post" collection in MongoDB
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Mongo_Post
    {
        public ObjectId _id { get; set; }
        public PostInformation PostInfomation { get; set; }
        [BsonIgnoreIfDefault]
        public List<SDLink> LikerList { get; set; }
        [BsonIgnoreIfDefault]
        public List<Comment> CommentList { get; set; }

        public Mongo_Post()
        {
            this._id = new ObjectId();
            this.PostInfomation = new PostInformation();
            this.LikerList = new List<SDLink>();
            this.CommentList = new List<Comment>();
        }
        public Mongo_Post(PostInformation postInfor)
        {
            this._id = ObjectId.GenerateNewId();
            this.PostInfomation = postInfor;
            this.PostInfomation.PostID = this._id.ToString();
            this.LikerList = new List<SDLink>();
            this.CommentList = new List<Comment>();

        }
    }
}