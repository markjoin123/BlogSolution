using Blog_Solution.Web.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog_Solution.Web.Models.Catalogs
{
    public class BlogListModel
    {
        public BlogListModel()
        {
            AvailableCategories = new List<SelectListItem>();
            SearchCategories = new List<int>();
        }

        [UIHint("MultiSelect")]
        [ResourceDisplayName("Blogs.Categories")]
        public IList<int> SearchCategories { get; set; }
        public IList<SelectListItem> AvailableCategories { get; set; }

        [ResourceDisplayName("Common.Keywords")]
        [AllowHtml]
        public string Keywords { get; set; }


        [ResourceDisplayName("Blogs.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [ResourceDisplayName("Blogs.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }
    }
}