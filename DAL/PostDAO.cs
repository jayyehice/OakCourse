﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PostDAO : PostContext
    {
        public int AddImage(PostImage item)
        {
            try
            {
                db.PostImages.Add(item);
                db.SaveChanges();
                return item.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddPost(Post post)
        {
            try 
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return post.ID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int AddTag(PostTag item)
        {
            try
            {
                db.PostTags.Add(item);
                db.SaveChanges();
                return item.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PostImageDTO> DeletePost(int ID)
        {
            try
            {
                Post post = db.Posts.First(x => x.ID == ID);
                post.isDeleted = true;
                post.DeletedDate = DateTime.Now;
                post.LastUpdateDate = DateTime.Now;
                post.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();

                List<PostImage> imagelist = db.PostImages.Where(x => x.PostID == ID).ToList();
                List<PostImageDTO> dtolist = new List<PostImageDTO>();

                foreach (var item in imagelist)
                {
                    PostImageDTO dto = new PostImageDTO();
                    dto.ImagePath = item.ImagePath;
                    item.isDeleted = true;
                    item.DeletedDate = DateTime.Now;
                    item.LastUpdateDate = DateTime.Now;
                    item.LastUpdateUserID = UserStatic.UserID;
                    dtolist.Add(dto);
                }
                db.SaveChanges();

                return dtolist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeletePostImage(int ID)
        {
            try
            {
                PostImage img = db.PostImages.First(x => x.ID == ID);
                string imagepath = img.ImagePath;
                img.isDeleted = true;
                img.DeletedDate = DateTime.Now;
                img.LastUpdateDate = DateTime.Now;
                img.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
                return imagepath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTags(int PostID)
        {
            List<PostTag> list = db.PostTags.Where(x => x.isDeleted == false && x.PostID == PostID).ToList(); 
            foreach(var item in list)
            {
                item.isDeleted = true;
                item.DeletedDate = DateTime.Now;
                item.LastUpdateDate = DateTime.Now;
                item.LastUpdateUserID = UserStatic.UserID;
            }

            db.SaveChanges();
        }

        public List<PostDTO> GetHotNews()
        {
            var postlist = (from p in db.Posts.Where(x => x.isDeleted == false && x.Area1 == true)
                            join c in db.Categories on p.CategoryID equals c.ID
                            select new
                            {
                                ID = p.ID,
                                Title = p.Title,
                                categoryname = c.CategoryName,
                                AddDate = p.AddDate,
                                Seolink = p.SeoLink
                            }).OrderByDescending(x => x.AddDate).Take(8).ToList();

            List<PostDTO> dtolist = new List<PostDTO>();

            foreach (var item in postlist)
            {
                PostDTO dto = new PostDTO();
                dto.ID = item.ID;
                dto.Title = item.Title;
                dto.CategoryName = item.categoryname;
                dto.AddDate = item.AddDate;
                dto.SeoLink = item.Seolink;

                dtolist.Add(dto);
            }

            return dtolist;
        }

        public List<PostImageDTO> GetPostImagesWithPostID(int PostID)
        {
            List<PostImage> list = db.PostImages.Where(x => x.isDeleted == false && x.PostID == PostID).ToList();
            List<PostImageDTO> dtolist = new List<PostImageDTO>();

            foreach (var item in list)
            {
                PostImageDTO dto = new PostImageDTO();
                dto.ID = item.ID;
                dto.ImagePath = item.ImagePath;
                dtolist.Add(dto);
            }

            return dtolist;
        }

        public List<PostDTO> GetPosts()
        {
            var postlist = (from p in db.Posts.Where(x => x.isDeleted == false)
                            join c in db.Categories on p.CategoryID equals c.ID
                            select new
                            {
                                ID = p.ID,
                                Title = p.Title,
                                categoryname = c.CategoryName,
                                AddDate = p.AddDate
                            }).OrderByDescending(x => x.AddDate).ToList();

            List<PostDTO> dtolist = new List<PostDTO>();

            foreach (var item in postlist)
            {
                PostDTO dto = new PostDTO();
                dto.ID = item.ID;
                dto.Title = item.Title;
                dto.CategoryName = item.categoryname;
                dto.AddDate = item.AddDate;

                dtolist.Add(dto);
            }

            return dtolist;
        }

        public List<PostTag> GetPostTagsWithPostID(int ID)
        {
            return db.PostTags.Where(x =>  x.isDeleted == false && x.ID == ID).ToList();
        }

        public PostDTO GetPostWithID(int ID)
        {
            Post post = db.Posts.First(x => x.ID == ID);
            PostDTO dto = new PostDTO();
            dto.ID = post.ID;
            dto.Title = post.Title;
            dto.ShortContent = post.ShortContent;
            dto.PostContent = post.PostContent;
            dto.Language = post.LanguageName;
            dto.Notification = post.Notification;
            dto.SeoLink = post.SeoLink;
            dto.Slider = post.Slider;
            dto.Area1 = post.Area1;
            dto.Area2 = post.Area2;
            dto.Area3 = post.Area3;
            dto.CategoryID = post.CategoryID;

            return dto;
        }

        public void UpdatePost(PostDTO model)
        {
            Post post = db.Posts.First(x => x.ID == model.ID);
            post.Title = model.Title;
            post.Area1 = model.Area1;
            post.Area2 = model.Area2;
            post.Area3 = model.Area3;
            post.CategoryID = model.CategoryID;
            post.LanguageName = model.Language;
            post.LastUpdateDate = DateTime.Now;
            post.LastUpdateUserID = UserStatic.UserID;
            post.Notification = model.Notification;
            post.PostContent = model.PostContent;
            post.SeoLink = model.SeoLink;
            post.ShortContent = model.ShortContent;
            post.Slider = model.Slider;
            
            db.SaveChanges();
            
        }
    }
}
