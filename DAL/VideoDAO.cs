﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DAL
{
    public class VideoDAO : PostContext
    {
        public int AddVideo(Video video)
        {
            try
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return video.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteVideo(int ID)
        {
            try
            {
                Video video = db.Videos.First(x => x.ID == ID);
                video.isDeleted = true;
                video.DeletedDate = DateTime.Now;
                video.LastUpdateDate = DateTime.Now;
                video.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VideoDTO> GetVideos()
        {
            List<Video> list = db.Videos.Where( x => x.isDeleted == false).OrderByDescending(x => x.AddDate).ToList();
            List<VideoDTO> dtolist = new List<VideoDTO>();

            foreach (Video video in list)
            {
                VideoDTO dto = new VideoDTO();
                dto.ID = video.ID;
                dto.Title = video.Title;
                dto.OrinialVideoPath = video.OriginalVideoPath;
                dto.VideoPath = video.VideoPath;
                dto.AddDate = video.AddDate;

                dtolist.Add(dto);
            }

            return dtolist;
        }

        public VideoDTO GetVideoWithID(int ID)
        {
            Video video = db.Videos.First(x => x.ID == ID);
            VideoDTO dto = new VideoDTO();
            dto.ID = video.ID;
            dto.OrinialVideoPath = video.OriginalVideoPath;
            dto.Title = video.Title;

            return dto;
        }

        public void UpdateVideo(VideoDTO model)
        {
            try
            {
                Video video = db.Videos.First( x => x.ID == model.ID);

                video.VideoPath = model.VideoPath;
                video.Title = model.Title;
                video.OriginalVideoPath = model.OrinialVideoPath;
                video.LastUpdateDate = DateTime.Now;
                video.LastUpdateUserID = UserStatic.UserID;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
