using BlogSide.BussinessLayer.Abstract;
using BlogSide.DataAccessLayer.EntityFramework;
using BlogSide.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogSide
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            using (DataContext db = new DataContext())
            {

                

                //var varmı = db.article.Count();
                //varmı == 0
                if (db.Database.CreateIfNotExists())
                {
                    Repository<Article> repoArticle = new Repository<Article>();
                    Article itemArticle = new Article();
                    itemArticle.ArticleDate = "13 Kasım 2018";
                    itemArticle.Author = "İlker Aksu";
                    itemArticle.CategoryName = "Seyahat";
                    itemArticle.Content = "Print this page to PDF for the complete set of  your vectors. Or to use on the desktop, intall font in your FontAwesome.otf, set it as the font in your your application, and copy and paste the icons (not the unicode)";
                    itemArticle.ImageUrl = "Content/img/blog/9.jpg";
                    itemArticle.IsActive = true;
                    itemArticle.Title = "Bu Benim Öyküm";
                    itemArticle.ReadingCount = 1453;
                    itemArticle.Tags = "Seyahat, Eğlence, Yazılım";
                    itemArticle.ArticleUrl = "bursa'nin-cennet-sakli-yeri-yesil-havuzlar";
                    repoArticle.Insert(itemArticle);

                    itemArticle.ArticleDate = "16 Eylül 2018";
                    itemArticle.Author = "Burak Aksu";
                    itemArticle.CategoryName = "Eğlence";
                    itemArticle.Content = "The complete set of  your vectors. Or to use on the desktop, intall font in your FontAwesome.otf, set it as the font in your your application, and copy and paste the icons (not the unicode)";
                    itemArticle.ImageUrl = "Content/img/blog/5.jpg";
                    itemArticle.IsActive = true;
                    itemArticle.Title = "Yaşar Ustanın Dizeleri";
                    itemArticle.ReadingCount = 563;
                    itemArticle.Tags = "Seyahat, Eğlence, Yazılım, Ekonomi";
                    itemArticle.ArticleUrl = "bursa'nin-cennet-sakli-yeri-oylat-kaplicalari";
                    repoArticle.Insert(itemArticle);

                    Repository<Author> repoAuthor = new Repository<Author>();
                    Author itemAuthor = new Author();
                    itemAuthor.AuthorAbout = "Bursa İnegöl Doğumlu. 22 Yaşında";
                    itemAuthor.Email = "ilkeraksu.16@gmail.com";
                    itemAuthor.FacebookAdress = "facebook.com/ilker";
                    itemAuthor.Image = "Content/img/blog/8.jpg";
                    itemAuthor.InstagramAdress = "instagram.com/mr_ilker1";
                    itemAuthor.NameSurname = "İlker Aksu";
                    itemAuthor.Password = "asdasddda";
                    itemAuthor.Role = "Admin";
                    itemAuthor.TwitterAdress = "twitter.com/ilker";
                    repoAuthor.Insert(itemAuthor);
                }

            }
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
