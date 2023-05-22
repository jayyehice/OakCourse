﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GeneralBLL
    {
        GeneralDAO dao = new GeneralDAO();
        public GeneralDTO GetAllPosts()
        {
            GeneralDTO dto = new GeneralDTO();
            dto.SliderPost = dao.GetSliderPosts();
            dto.BreakingPost = dao.GetBreakingPost();
            dto.PopularPost = dao.GetPopularPost();
            dto.MostViewedPost = dao.GetMostViewedPost();
            dto.Videos = dao.GetVideos();
            return dto;
        }
    }
}