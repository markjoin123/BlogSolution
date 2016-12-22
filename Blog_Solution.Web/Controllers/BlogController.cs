using Blog_Solution.Catalog;
using Blog_Solution.Domain.Catalogs;
using Blog_Solution.Web.Framework.Kendoui;
using Blog_Solution.Web.Framework.Mvc;
using Blog_Solution.Web.Helper;
using Blog_Solution.Web.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Blog_Solution.Web.Controllers
{
    public class BlogController : Blog_SolutionControllerBase
    {
        #region Fields && Ctor


        private readonly ICategoryService _categoryService;
        private readonly IBlogService _blogService;
        private readonly IBlogReviewService _reviewService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryService"></param>
        /// <param name="blogService"></param>
        /// <param name="reviewService"></param>
        public BlogController(ICategoryService categoryService, IBlogService blogService, IBlogReviewService reviewService)
        {
            this._categoryService = categoryService;
            this._blogService = blogService;
            this._reviewService = reviewService;
        }

        #endregion

        #region Utilities


        [NonAction]
        protected virtual void PrepareBlogListModel(BlogListModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            
            var allCategories = SelectListHelper.GetCategoryList(_categoryService, true);
            foreach (var c in allCategories)
            {
                c.Selected = model.SearchCategories.Contains(int.Parse(c.Value));
                model.AvailableCategories.Add(c);
            }
        }

        [NonAction]
        protected BlogSimpleModel PrepareBlogListModel(Blog b)
        {
            var model = new BlogSimpleModel
            {
                Id = b.Id,
                Audit = b.Audit,
                Author = b.Author,
                BrowsingTimes = b.BrowsingTimes,
                CategoryName = _categoryService.GetCagegoryById(b.CategoryId).Name,
                ReviewsTimes = b.CategoryId,
                Start = b.Start,
                Title = b.BolgTitle,
                CreationTime  =b.CreationTime,
            };
            return model;
        }
        #endregion

        #region Method

        public ActionResult List()
        {
            var model = new BlogListModel();
            PrepareBlogListModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult List(DataSourceRequest command, BlogListModel model)
        {
            model.SearchCategories = model.SearchCategories.Count == 0 ?
                                    model.SearchCategories :
                                    model.SearchCategories.Where(x => x != 0).ToList();

            var blogs = _blogService.GetAllBlogs(keywords: model.Keywords,
                                    categoryIds: model.SearchCategories,
                                    CreatedFrom: model.StartDate,
                                    CreatedTo: model.StartDate,
                                    showHidden: true,
                                    pageIndex: command.Page - 1,
                                    pageSize: command.PageSize);

            var data = new DataSourceResult
            {
                Data = blogs.Items.Select(x => PrepareBlogListModel(x)),
                Total = blogs.TotalCount
            };
            return AbpJson(data);
        }
        
              [HttpPost]
        public ActionResult AuditTrue(string selectedIds)
        {
            var blogs = new List<Blog>();
            if (selectedIds != null)
            {
                var ids = selectedIds
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();
                blogs.AddRange(_blogService.GetBlogs(ids));
            }

            blogs.ForEach(b =>
            {
                b.Audit = true;
                _blogService.UpdateBlog(b);
            });

            return new NullJsonResult();
        }
        #endregion
    }
}