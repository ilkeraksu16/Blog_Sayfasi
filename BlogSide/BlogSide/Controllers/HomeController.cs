using BlogSide.BussinessLayer;
using BlogSide.BussinessLayer.Abstract;
using BlogSide.DataEntities;
using BlogSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSide.Controllers
{
    public class HomeController : Controller
    {
        //Repository<Article> repoArticle = new Repository<Article>();
        ArticleManager repoArticle = new ArticleManager();
        //Repository<Author> repoAuthor = new Repository<Author>();
        AuthorManager repoAuthor = new AuthorManager();
        // GET: Home
        public ActionResult Index()
        {
           // BussinessLayer.Test test = new BussinessLayer.Test();
            var articleList = repoArticle.List();
            
            ViewBag.Keywords= "";//açıklama yaz. Google tarafından üst sıraya çıkmak için
            ViewBag.Description= "";
            ViewBag.Title = "Blog Site | Anasayfa";
            
            return View(articleList);
        }

        public ActionResult Authors()
        {
            var articleList = repoArticle.List();
            //makalesi olan yazarları listeleme
            var authorList = articleList.GroupBy(u => new { u.Author }).Select(grp => grp.FirstOrDefault()).ToList();
            ViewBag.AuthorList = authorList;
            return View();
        }

        public ActionResult Detail(string linkUrl)
        {
            if(linkUrl == null)
            {
                //Anasayfaya yönlendiriyoz
                return RedirectToAction("", "");
            }
            ViewBag.Title = "Makale | Detay Sayfası";
            // Join yaparak makalemizi yazar özellikleriyle birlikte getiriyoruz.
            ParticalViewModel articleModel = (from article in repoArticle.List()
                                              join author in repoAuthor.List() on article.Author equals author.NameSurname
                                              where article.ArticleUrl == linkUrl
                                              select new ParticalViewModel
                                              {
                                                  ArticleId = article.Id,
                                                  ArticleUrl = article.ArticleUrl,
                                                  ArticleCategory = article.CategoryName,
                                                  ArticleDate = article.ArticleDate,
                                                  ArticleReading = article.ReadingCount,
                                                  ArticleTags = article.Tags.Split(','),
                                                  Content = article.Content,
                                                  Title = article.Title,
                                                  AuthorName = author.NameSurname,
                                                  AuthorAbout = author.AuthorAbout,
                                                  AuthorImageUrl = author.Image,
                                                  AuthorFacebook = author.FacebookAdress,
                                                  AuthorInstagram = author.InstagramAdress,
                                                  AuthorTwitter = author.TwitterAdress
                                              }).FirstOrDefault();

            
            return View(articleModel);
        }

        public ActionResult TopArticle()
        {
            //en çok okunan 2 makaleyi alıyoruz.
            var articleList = repoArticle.List().OrderByDescending(m => m.ReadingCount).ToList().Take(2);

            return View(articleList);
        }

        public ActionResult InstagramArea()
        {
            return View();
        }


    }
}