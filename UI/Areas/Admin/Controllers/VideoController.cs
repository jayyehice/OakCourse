﻿using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace UI.Areas.Admin.Controllers
{
    public class VideoController : BaseController
    {
        // GET: Admin/Video
        VideoBLL bll = new VideoBLL();

        public ActionResult VideoList()
        {
            List<VideoDTO> dtolist = new List<VideoDTO>();
            dtolist = bll.GetVideos();
            return View(dtolist);
        }

        public ActionResult AddVideo()
        {
            VideoDTO dto = new VideoDTO();
            return View(dto);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddVideo(VideoDTO model)
        {
            if (ModelState.IsValid)
            {
                string path = model.OrinialVideoPath.Substring(32);
                string mergelink = "https://www.youtube.com/embed/";
                mergelink += path;
                model.VideoPath = String.Format(@"<iframe width = ""300"" height = ""200"" src = ""{0}"" title = ""YouTube video player"" frameborder = ""0"" allowfullscreen></iframe>", mergelink);


                if (bll.AddVideo(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new VideoDTO();
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return View(model);
        }

        public ActionResult UpdateVideo(int ID)
        {
            VideoDTO dto = bll.GetVideoWithID(ID);
            return View(dto);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateVideo(VideoDTO model)
        {
            VideoDTO dto = bll.GetVideoWithID(model.ID);

            if (ModelState.IsValid)
            {
                string path = model.OrinialVideoPath.Substring(32);
                string mergelink = "https://www.youtube.com/embed/";
                mergelink += path;
                model.VideoPath = String.Format(@"< iframe width = ""300"" height = ""200"" src = ""{0}"" title = ""YouTube video player"" frameborder = ""0"" allowfullscreen ></ iframe >", mergelink);

                if (bll.UpdateVideo(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;

            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return View(model);
        }

        [HttpPost]
        public JsonResult DeleteVideo(int ID)
        {
            bll.DeleteVideo(ID);
            return Json("");
        }
    }
}