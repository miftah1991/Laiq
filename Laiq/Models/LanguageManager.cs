using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Globalization;
namespace Laiq.Models
{
    public class LanguageManager
    {
         public static List<Languages> AvailableLanguages = new List<Languages> {
            new Languages {
                LanguageFullName = "English", LanguageCultureName = "en",LanguageDirection ="ltr" ,LangPrefix="" ,Align="left"
            },
             new Languages {  
                LanguageFullName = "Persian", LanguageCultureName = "fa"  ,LanguageDirection="rtl",LangPrefix ="Dr",Align="right"
            },
            new Languages {  
                LanguageFullName = "Pashto", LanguageCultureName = "Ps"  ,LanguageDirection="rtl",LangPrefix="Ps",Align="right"
            }
          
        };

        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(a => a.LanguageCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }
        public string GetLangDirection(string lang)
        {
            var LangDirection = (from lm in AvailableLanguages
                                 where lm.LanguageCultureName == lang
                                 select new { lm.LanguageDirection }).Single();
            return LangDirection.LanguageDirection;
        }
        public string GetLangAlign(string lang)
        {
            var LangAlign = (from lm in AvailableLanguages
                                 where lm.LanguageCultureName == lang
                                 select new { lm.Align }).Single();
            return LangAlign.Align;
        }
        public string GetLangPrefix(string lang)
        {
            var LangPr = (from lm in AvailableLanguages
                                 where lm.LanguageCultureName == lang
                                 select new { lm.LangPrefix }).Single();
            return LangPr.LangPrefix;
        }

        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[0].LanguageCultureName;
        }

        public void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang)) lang = GetDefaultLanguage();
                var cultureInfo = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpCookie langCookie = new HttpCookie("culture", lang);
                HttpCookie langdirCookie = new HttpCookie("dir", GetLangDirection(lang));
                HttpCookie langalignCookie = new HttpCookie("align", GetLangAlign(lang));
                HttpCookie langsuffCookie = new HttpCookie("suffix", GetLangPrefix(lang));
                langCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(langCookie);
                HttpContext.Current.Response.Cookies.Add(langdirCookie);
                HttpContext.Current.Response.Cookies.Add(langsuffCookie);
                HttpContext.Current.Response.Cookies.Add(langalignCookie);
            }
            catch (Exception) { }
        }
    }

    public class Languages
    {
        public string LanguageFullName
        {
            get;
            set;
        }
        public string LanguageCultureName
        {
            get;
            set;
        }
        public string LanguageDirection { get; set; }
        public string Align { get; set; }
        public string LangPrefix { get; set; }
    }
    }
