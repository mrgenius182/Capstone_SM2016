﻿using System;
using MongoDB.Bson;
using System.Collections.Generic;
using iVolunteer.Common;
using iVolunteer.Models.MongoDB.EmbeddedClass.ItemClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.ListClass;
using MongoDB.Bson.Serialization.Attributes;

namespace iVolunteer.Models.MongoDB.EmbeddedClass.InformationClass
{
    /// <summary>
    /// This class store project's infomation
    /// </summary>
    [BsonIgnoreExtraElements]
    public class ProjectInformation
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string ProjectDescription { get; set; }
        public string Location { get; set; }
        public int MemberCount { get; set; }
        public int FollowerCount { get; set; }
        public bool IsRecruit { get; set; }
        public bool IsActivate { get; set; }
        public TagsList TagList { get; set; }


        public ProjectInformation()
        {
            this.ProjectID = "";
            this.ProjectName = "";
            this.DateCreate = new DateTime();
            this.DateStart = new DateTime();
            this.DateEnd = new DateTime();
            this.ProjectDescription = "";
            this.Location = "";
            this.MemberCount = 0;
            this.FollowerCount = 0;
            this.IsRecruit = Status.IS_RECRUITING;
            this.IsActivate = Status.IS_ACTIVATE;
            this.TagList = new TagsList();
        }
    }
}