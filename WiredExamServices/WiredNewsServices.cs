using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WiredExamDomain;
using WiredExamDomain.Models;

namespace WiredExamServices
{
    public class WiredNewsServices
    {

        private BaseClassContext db = new BaseClassContext();

        public Boolean saveNews()
        {
            try
            {
                var url = "https://newsapi.org/v2/everything?sources=wired&apiKey=cf71b031de64437ea4d39d47e998f74b";
                var json = new WebClient().DownloadString(url);
                List<articles> listArticles = new List<articles>();
                dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                var listArticle = x.articles;
                //Tüm Haber Listesi (JSON)
                foreach (var article in listArticle)
                {
                    listArticles.Add(new articles()
                    {
                        sources = new source()
                        {
                            id = (string)article.source.id,
                            name = (string)article.source.name
                        },
                        title = (string)article.title,
                        author = (string)article.author,
                        description = (string)article.description,
                        url = (string)article.url,
                        urlToImage = (string)article.urlToImage,
                        publishedAt = (string)article.publishedAt
                    });
                }

                //Son 5 parçayı getir
                List<articles> lastFiveArticles = new List<articles>();
                if (listArticles.Count > 0)
                {
                    if (listArticles.Count > 5)
                    {
                        var sa = listArticles.Count;
                        for (int i = 0; i < 5; i++)
                        {
                            lastFiveArticles.Add(listArticles[i]);
                        }
                    }
                }

                List<articles> listNoExist = new List<articles>();

                foreach (var item in lastFiveArticles)
                {
                    var itemExist = db.articles.Where(j => j.title == item.title).FirstOrDefault();
                    if (itemExist == null)
                    {
                        listNoExist.Add(item);
                    }
                }

                if (listNoExist.Count > 0)
                {
                    foreach (var items in listNoExist)
                    {
                        db.articles.Add(items);
                    }
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<articles> getNews()
        {
            var articles = db.articles.OrderByDescending(p => p.publishedAt).Take(5).ToList<articles>();
            return articles;
        }

    }
}
