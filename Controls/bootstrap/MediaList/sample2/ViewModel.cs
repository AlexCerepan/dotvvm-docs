﻿using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.MediaList.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<MediaItem> Medias { get; set; } = new List<MediaItem>()
        {
            new MediaItem() { ImageUrl = "/Content/Images/img12.jpg", AltText = "google alt", NavigateUrl = "https://www.google.cz/",
                Header = "Google", Description = "This is description for Google", Width = "100", Height = "200" },
            new MediaItem() { ImageUrl = "/Content/Images/img12.jpg", AltText = "w3schools alt", NavigateUrl = "http://www.w3schools.com/",
                Header = "W3Schools", Description = "This is description for W3Schools", Width = "300", Height = "200" },
            new MediaItem() { ImageUrl = "/Content/Images/img12.jpg", AltText = "bootstrap alt", NavigateUrl = "http://getbootstrap.com/",
                Header = "Bootstrap", Description = "This is description for Bootstrap", Width = "200", Height = "100" },
            new MediaItem() { ImageUrl = "/Content/Images/img12.jpg", AltText = "dotvvm alt", NavigateUrl = "https://www.dotvvm.com/",
                Header = "DotVVM", Description = "This is description for DotVVM", Width = "50", Height = "50" }
        };
    }

    public class MediaItem
    {
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public string NavigateUrl { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }
}