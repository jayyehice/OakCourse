using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GeneralDAO : PostContext
    {
        public List<PostDTO> GetBreakingPost()
        {
            List<PostDTO> dtolist = new List<PostDTO>();
            var list = (from p in db.Posts.Where(x => x.Slider == false && x.isDeleted == false)
                        join c in db.Categories on p.CategoryID equals c.ID
                        select new
                        {
                            postID = p.ID,
                            title = p.Title,
                            categoryName = c.CategoryName,
                            seolink = p.SeoLink,
                            viewcount = p.ViewCount,
                            Adddate = p.AddDate
                        }
                        ).OrderByDescending(x => x.Adddate).Take(5).ToList();

            foreach (var item in list)
            {
                PostDTO dto = new PostDTO();
                dto.ID = item.postID;
                dto.Title = item.title;
                dto.CategoryName = item.categoryName;
                dto.ViewCount = item.viewcount;
                dto.SeoLink = item.seolink;
                PostImage image = db.PostImages.First(x => x.isDeleted == false && x.PostID == item.postID);
                dto.ImagePath = image.ImagePath;
                dto.CommentCount = db.Comments.Where(x => x.isDeleted == false && x.PostID == item.postID && x.isApproved == true).Count();
                dto.AddDate = item.Adddate;
                dtolist.Add(dto);
            }

            return dtolist;
        }

        public List<PostDTO> GetMostViewedPost()
        {
            List<PostDTO> dtolist = new List<PostDTO>();
            var list = (from p in db.Posts.Where(x => x.isDeleted == false)
                        join c in db.Categories on p.CategoryID equals c.ID
                        select new
                        {
                            postID = p.ID,
                            title = p.Title,
                            categoryName = c.CategoryName,
                            seolink = p.SeoLink,
                            viewcount = p.ViewCount,
                            Adddate = p.AddDate
                        }
                        ).OrderByDescending(x => x.viewcount).Take(5).ToList();

            foreach (var item in list)
            {
                PostDTO dto = new PostDTO();
                dto.ID = item.postID;
                dto.Title = item.title;
                dto.CategoryName = item.categoryName;
                dto.ViewCount = item.viewcount;
                dto.SeoLink = item.seolink;
                PostImage image = db.PostImages.First(x => x.isDeleted == false && x.PostID == item.postID);
                dto.ImagePath = image.ImagePath;
                dto.CommentCount = db.Comments.Where(x => x.isDeleted == false && x.PostID == item.postID && x.isApproved == true).Count();
                dto.AddDate = item.Adddate;
                dtolist.Add(dto);
            }

            return dtolist;
        }

        public List<PostDTO> GetPopularPost()
        {
            List<PostDTO> dtolist = new List<PostDTO>();
            var list = (from p in db.Posts.Where(x => x.isDeleted == false && x.Area2 == true)
                        join c in db.Categories on p.CategoryID equals c.ID
                        select new
                        {
                            postID = p.ID,
                            title = p.Title,
                            categoryName = c.CategoryName,
                            seolink = p.SeoLink,
                            viewcount = p.ViewCount,
                            Adddate = p.AddDate
                        }
                        ).OrderByDescending(x => x.Adddate).Take(5).ToList();

            foreach (var item in list)
            {
                PostDTO dto = new PostDTO();
                dto.ID = item.postID;
                dto.Title = item.title;
                dto.CategoryName = item.categoryName;
                dto.ViewCount = item.viewcount;
                dto.SeoLink = item.seolink;
                PostImage image = db.PostImages.First(x => x.isDeleted == false && x.PostID == item.postID);
                dto.ImagePath = image.ImagePath;
                dto.CommentCount = db.Comments.Where(x => x.isDeleted == false && x.PostID == item.postID && x.isApproved == true).Count();
                dto.AddDate = item.Adddate;
                dtolist.Add(dto);
            }

            return dtolist;
        }

        public List<PostDTO> GetSliderPosts()
        {
            List<PostDTO> dtolist = new List<PostDTO>();
            var list = (from p in db.Posts.Where(x => x.Slider == true && x.isDeleted == false)
                        join c in db.Categories on p.CategoryID equals c.ID
                        select new
                        {
                            postID = p.ID,
                            title = p.Title,
                            categoryName = c.CategoryName,
                            seolink = p.SeoLink,
                            viewcount = p.ViewCount,
                            Adddate = p.AddDate
                        }
                        ).OrderByDescending(x => x.Adddate).Take(8).ToList();

            foreach(var item in list)
            {
                PostDTO dto = new PostDTO();
                dto.ID = item.postID;
                dto.Title = item.title;
                dto.CategoryName = item.categoryName;
                dto.ViewCount = item.viewcount;
                dto.SeoLink = item.seolink;
                PostImage image = db.PostImages.First(x => x.isDeleted == false && x.PostID == item.postID);
                dto.ImagePath = image.ImagePath;
                dto.CommentCount = db.Comments.Where(x => x.isDeleted == false && x.PostID == item.postID && x.isApproved == true).Count();
                dto.AddDate = item.Adddate;
                dtolist.Add(dto);
            }

            return dtolist;
        }

        public List<VideoDTO> GetVideos()
        {
            List<VideoDTO> dtolist = new List<VideoDTO>();
            List<Video> list = db.Videos.Where(x => x.isDeleted ==false).OrderByDescending(x => x.AddDate).Take(3).ToList();

            foreach(var item in list)
            {
                VideoDTO dto = new VideoDTO();
                dto.ID = item.ID;
                dto.Title = item.Title;
                dto.VideoPath = item.VideoPath;
                dto.OrinialVideoPath = item.OriginalVideoPath;
                dto.AddDate = item.AddDate;

                dtolist.Add(dto);
            }

            return dtolist;
        }
    }
}
