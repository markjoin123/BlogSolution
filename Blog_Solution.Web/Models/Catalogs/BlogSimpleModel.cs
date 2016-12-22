using Abp.Application.Services.Dto;
using System;

namespace Blog_Solution.Web.Models.Catalogs
{
    public class BlogSimpleModel:EntityDto
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public string CategoryName { get; set; }
        public bool Audit { get; set; }

        public int BrowsingTimes { get; set; }

        public int ReviewsTimes { get; set; }
        
        public int Start { get; set; }

        public DateTime CreationTime { get; set; }

    }
}