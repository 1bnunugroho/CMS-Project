using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Srikandi.Models
{

    public class PostModel
    {
        public PostModel()
        {
            ListWidgets = new List<PostWidgetModel>();
        }
        public long ID { get; set; }
        [Required(ErrorMessage = "Category required")]
        public long CategoryID { get; set; }
        public long? CategoryPostID { get; set; }
        public string CategoryName { get; set; }
        [Required]
        public long ParentID { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; }
        [Required(ErrorMessage = "Title required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Slug required")]
        public string Slug { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Content required")]
        public string Body { get; set; }
        public string ImageURL { get; set; }
        public string ThumbURL { get; set; }
        public string BannerImageURL { get; set; }
        public string BannerImageURLMobile { get; set; }
        public string VideoURL { get; set; }
        public string FileURL { get; set; }
        public string Type { get; set; }
        public String Source { get; set; }
        public bool IsFeatured { get; set; }

        public bool PublishedStatus
        {
            get
            {
                if (!this.PublishDate.HasValue)
                    return false;
                else if (!this.ExpiredDate.HasValue)
                    return true;
                else
                {
                    if (this.PublishDate <= DateTime.Now && this.ExpiredDate >= DateTime.Now)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public Nullable<System.DateTime> PublishDate
        {
            get
            {
                if (!string.IsNullOrEmpty(this.PublishDay) && !string.IsNullOrEmpty(this.PublishHour) && !string.IsNullOrEmpty(this.PublishMinute))
                {
                    DateTime date;
                    if (DateTime.TryParseExact(this.PublishDay, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out date))
                    {
                        double hour = 0;
                        if (double.TryParse(this.PublishHour, out hour))
                        {
                            date = date.AddHours(hour);
                            double minute = 0;
                            if (double.TryParse(this.PublishMinute, out minute))
                            {
                                date = date.AddMinutes(minute);
                                return date;
                            }
                        }
                        return date;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
        public Nullable<System.DateTime> ExpiredDate
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ExpiredDay) && !string.IsNullOrEmpty(this.ExpiredHour) && !string.IsNullOrEmpty(this.ExpiredMinute))
                {
                    DateTime date;
                    if (DateTime.TryParseExact(this.ExpiredDay, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out date))
                    {
                        double hour = 0;
                        if (double.TryParse(this.ExpiredHour, out hour))
                        {
                            date = date.AddHours(hour);
                            double minute = 0;
                            if (double.TryParse(this.ExpiredMinute, out minute))
                            {
                                date = date.AddMinutes(minute);
                                return date;
                            }
                        }
                        return date;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }

        public string PublishDay { get; set; }

        public string PublishHour { get; set; }

        public string PublishMinute { get; set; }

        public string ExpiredDay { get; set; }

        public string ExpiredHour { get; set; }

        public string ExpiredMinute { get; set; }

        public Guid? MultilingualGroupID { get; set; }

        public int Sort { get; set; }
        public string Tag { get; set; }
        public string WidgetTitle { get; set; }
        public List<PostWidgetModel> ListWidgets { get; set; }
    }

    public class PostModelPreview
    {
        public long ID { get; set; }
        public long CategoryID { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string ImageURL { get; set; }
        public string ThumbURL { get; set; }
        public string VideoURL { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public Nullable<System.DateTime> ExpiredDate { get; set; }
        public Guid? MultilingualGroupID { get; set; }



    }

    public class CategoryModel
    {
        public long ID { get; set; }
        public long ApplicationID { get; set; }
        public long LanguageID { get; set; }
        public long ParentID { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public int Sort { get; set; }
        public Guid? MultilingualGroupID { get; set; }
    }

    public class PostWidgetModel
    {
        public long ID { get; set; }

        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int Sort { get; set; }

    }


}