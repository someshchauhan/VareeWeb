using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace VareeWeb.Models
{
    public class BeddingService
    {
        public static List<BeddingCategory> GetBeddingCategories()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/BeddingData.xml");
            XDocument xmlDoc = XDocument.Load(filePath);

            var categories = xmlDoc.Descendants("Category")
                .Select(cat => new BeddingCategory
                {
                    Name = cat.Attribute("name")?.Value,
                    Types = cat.Elements("Type").Select(t => t.Value).ToList()
                }).ToList();

            return categories;
        }

        public static List<KitchenCat> GetKitchenCategories()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Kitchen.xml");
            XDocument xmlDoc = XDocument.Load(filePath);

            var categories = xmlDoc.Descendants("Category")
                .Select(cat => new KitchenCat
                {
                    Name = cat.Attribute("name")?.Value,
                    Types = cat.Elements("Type").Select(t => t.Value).ToList()
                }).ToList();

            return categories;
        }

        public static List<furnishingCat> GetFurnishCategories()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/furnishing.xml");
            XDocument xmlDoc = XDocument.Load(filePath);

            var categories = xmlDoc.Descendants("Category")
                .Select(cat => new furnishingCat
                {
                    Name = cat.Attribute("name")?.Value,
                    Types = cat.Elements("Type").Select(t => t.Value).ToList()
                }).ToList();

            return categories;
        }

        public static List<diningCat> GetDiningCategories()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/dining.xml");
            XDocument xmlDoc = XDocument.Load(filePath);

            var categories = xmlDoc.Descendants("Category")
                .Select(cat => new diningCat
                {
                    Name = cat.Attribute("name")?.Value,
                    Types = cat.Elements("Type").Select(t => t.Value).ToList()
                }).ToList();

            return categories;
        }

        public static List<decorCat> GetDecorCategories()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/decor.xml");
            XDocument xmlDoc = XDocument.Load(filePath);

            var categories = xmlDoc.Descendants("Category")
                .Select(cat => new decorCat
                {
                    Name = cat.Attribute("name")?.Value,
                    Types = cat.Elements("Type").Select(t => t.Value).ToList()
                }).ToList();

            return categories;
        }

        public static List<kidsCat> GetKidCategories()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/kids.xml");
            XDocument xmlDoc = XDocument.Load(filePath);

            var categories = xmlDoc.Descendants("Category")
                .Select(cat => new kidsCat
                {
                    Name = cat.Attribute("name")?.Value,
                    Types = cat.Elements("Type").Select(t => t.Value).ToList()
                }).ToList();

            return categories;
        }

        public static List<organiseCat> GetOrganiserCategories()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/organisers.xml");
            XDocument xmlDoc = XDocument.Load(filePath);

            var categories = xmlDoc.Descendants("Category")
                .Select(cat => new organiseCat
                {
                    Name = cat.Attribute("name")?.Value,
                    Types = cat.Elements("Type").Select(t => t.Value).ToList()
                }).ToList();

            return categories;
        }

        public static List<bathCat> GetBathCategories()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/bath.xml");
            XDocument xmlDoc = XDocument.Load(filePath);

            var categories = xmlDoc.Descendants("Category")
                .Select(cat => new bathCat
                {
                    Name = cat.Attribute("name")?.Value,
                    Types = cat.Elements("Type").Select(t => t.Value).ToList()
                }).ToList();

            return categories;
        }

        public static List<gardenCat> GetGardenCategories()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/garden.xml");
            XDocument xmlDoc = XDocument.Load(filePath);

            var categories = xmlDoc.Descendants("Category")
                .Select(cat => new gardenCat
                {
                    Name = cat.Attribute("name")?.Value,
                    Types = cat.Elements("Type").Select(t => t.Value).ToList()
                }).ToList();

            return categories;
        }

        public static List<giftCat> GetGiftCategories()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/gift.xml");
            XDocument xmlDoc = XDocument.Load(filePath);

            var categories = xmlDoc.Descendants("Category")
                .Select(cat => new giftCat
                {
                    Name = cat.Attribute("name")?.Value,
                    Types = cat.Elements("Type").Select(t => t.Value).ToList()
                }).ToList();

            return categories;
        }

        public static List<footCat> GetFooterCategories()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/footer.xml");
            XDocument xmlDoc = XDocument.Load(filePath);

            var categories = xmlDoc.Descendants("Category")
                .Select(cat => new footCat
                {
                    Name = cat.Attribute("name")?.Value,
                    Types = cat.Elements("Type").Select(t => t.Value).ToList()
                }).ToList();

            return categories;
        }
    }
}