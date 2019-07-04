﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XSchool.Core;
using XSchool.WorkFlow.Businesses;
using XSchool.WorkFlow.Model;
using static XSchool.WorkFlow.Model.Enums;

namespace XSchool.WorkFlow.WebApi.Controllers
{
    public class SubjectTypeController : Controller
    {
        private readonly SubjectTypeBusiness subjectTypeBusiness;
        public SubjectTypeController(SubjectTypeBusiness _subjectTypeBusiness)
        {
            this.subjectTypeBusiness = _subjectTypeBusiness;
        }

        /// <summary>
        /// 添加或编辑流程组别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public Result AddOrEdit([FromForm]SubjectType model)
        {
            model.Status = EDStatus.Enable;
            return subjectTypeBusiness.AddOrEdit(model);
        }
    }
}