﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BForms.Utilities;
using Newtonsoft.Json;

namespace BForms.Models
{
    /// <summary>
    /// Extends JsonResult with ResponseStatus and compression
    /// </summary>
    public class BsJsonResult : ActionResult
    {
        public string Json { get; set; }

        public BsJsonResult(object obj = null, BsResponseStatus statusInfo = BsResponseStatus.Success, string errorMessage = null, string json = null, int? jsonMaxLength = null)
        {
            if (json == null)
            {
                object result = new
                    {
                        Data = obj,
                        Status = statusInfo,
                        Message = errorMessage,
                        Release = BForms.Utilities.BsConfigurationManager.GetRelease()
                    };

                Json = JsonConvert.SerializeObject(result);
            }
            else
            {
                Json = json;
            }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.AddHeader("Content-Type", "application/json; charset=utf-8");
            context.HttpContext.Response.Charset = "UTF-8";

            context.AddSupportForCompression();

            context.HttpContext.Response.Write(Json);
        }
    }
}
