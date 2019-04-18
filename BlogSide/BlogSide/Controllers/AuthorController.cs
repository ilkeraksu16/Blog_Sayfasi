using BlogSide.BussinessLayer;
using BlogSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSide.Controllers
{
    public class AuthorController : Controller
    {
        ArticleManager repoArticle = new ArticleManager();
        AuthorManager repoAuthor = new AuthorManager();
        // GET: Author
        public ActionResult Index(string authorName)
        {
            if (authorName == null)
            {
                return RedirectToAction("", "");
            }

            
            List<ArticleByCategory> _articleByCategories;
            _articleByCategories = (from article in repoArticle.List()
                                    where authorName == Utils.UrlDuzenleme.UrlCevir(article.Author).ToLower()
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

            ViewBag.Title = "BlogSite | " + _articleByCategories.FirstOrDefault().AuthorName;

            return View(_articleByCategories);
        }

        public ActionResult AuthorArea(string authorName)
        {
            AuthorModel _authorModel = (from author in repoAuthor.List()
                                        where Utils.UrlDuzenleme.UrlCevir(author.NameSurname).ToLower() == authorName
                                        select new AuthorModel
                                        {
                                             AuthorName = author.NameSurname,
                                             AuthorAbout = author.AuthorAbout,
                                             Image = author.Image,
                                             Facebook = author.FacebookAdress,
                                             Twitter = author.TwitterAdress,
                                             Instagram = author.InstagramAdress

                                        }).FirstOrDefault();
            return View(_authorModel);
        }
    }
}