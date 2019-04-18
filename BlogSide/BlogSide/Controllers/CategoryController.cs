using BlogSide.BussinessLayer;
using BlogSide.DataEntities;
using BlogSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSide.Controllers
{
    public class CategoryController : Controller
    {
        ArticleManager repoArticle = new ArticleManager();
        // GET: Category
        public ActionResult Index(string CategoryName)
        {
            if(CategoryName == null)
            {
                return RedirectToAction("", "");
            }

            List<ArticleByCategory> _articleByCategories;
            _articleByCategories = (from article in repoArticle.List()
                                    where CategoryName == Utils.UrlDuzenleme.UrlCevir(article.CategoryName).ToLower()
                                    select new ArticleByCategory
                                    {
                                        ArticleCategory = article.CategoryName,
                                        ArticleDate = article.ArticleDate,
                                        ArticleReading = article.ReadingCount,
                                        ArticleUrl = article.ArticleUrl,
                                        AuthorName = article.Author,
                                        Title = article.Title,
                                        ImageUrl = article.ImageUrl,
                                        Content = article.Content
                                    }
                                   ).ToList();

            ViewBag.Title = "BlogSite | " + _articleByCategories.FirstOrDefault().ArticleCategory;
            return View(_articleByCategories);
        }
    }
}