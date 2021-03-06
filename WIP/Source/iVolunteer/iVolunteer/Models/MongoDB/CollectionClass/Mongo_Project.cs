﻿using MongoDB.Bson;
using iVolunteer.Models.MongoDB.EmbeddedClass.InformationClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.LinkClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.ItemClass;
using iVolunteer.Models.MongoDB.EmbeddedClass.ListClass;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace iVolunteer.Models.MongoDB.CollectionClass
{
    /// <summary>
    /// This class define structure of "Project" collection in MongoDB
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Mongo_Project
    {
        public ObjectId _id { get; set; }
        public ProjectInformation ProjectInformation { get; set; }
        [BsonIgnoreIfDefault]
        public RequestList RequestList { get; set; }
        public List<Sponsor> GuestSponsor { get; set; }
        [BsonIgnoreIfDefault]
        public Agenda Agenda { get; set; }

        public Mongo_Project()
        {
            this._id = new ObjectId();
            this.ProjectInformation = new ProjectInformation();
            this.RequestList = new RequestList();
            this.GuestSponsor = new List<Sponsor>();
            this.Agenda = new Agenda();
        }

        public Mongo_Project(ProjectInformation projectInfo)
        {
            this._id = ObjectId.GenerateNewId();
            this.ProjectInformation = projectInfo;
            this.ProjectInformation.ProjectID = this._id.ToString();
            this.RequestList = new RequestList();
            this.GuestSponsor = new List<Sponsor>();
            this.Agenda = new Agenda();
        }
    }
}