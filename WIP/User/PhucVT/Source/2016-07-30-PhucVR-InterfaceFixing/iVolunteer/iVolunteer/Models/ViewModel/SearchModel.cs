﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iVolunteer.Models.MongoDB.EmbeddedClass.ListClass;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace iVolunteer.Models.ViewModel
{
    public class SearchModel
    {
        [MaxLength(100, ErrorMessage ="Độ dài không quá 100 ký tự")]
        public string Name { get; set; }
        [MaxLength(100, ErrorMessage = "Độ dài không quá 100 ký tự")]
        public string Location { get; set; }
        [BsonDateTimeOptions(DateOnly = true, Kind = DateTimeKind.Local)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }
        [BsonDateTimeOptions(DateOnly = true, Kind = DateTimeKind.Local)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }
        public string[] TagsList { get; set; }
        public bool Progress { get; set; }

        public SearchModel()
        {
            this.Name = "";
            this.Location = "";
            this.DateStart = new DateTime();
            this.DateEnd = new DateTime();
            this.Progress = true;
        }
    }
}