﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using XSchool.Core;
using XSchool.GCenter.Businesses;
using XSchool.GCenter.Model;

namespace XSchool.GCenter.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ScheduleController : ApiBaseController
    {
        private readonly ScheduleBusiness _scheduleBusiness;
        private readonly ScheduleCompleteBusiness _scheduleCompleteBusiness;
        public ScheduleController(ScheduleBusiness scheduleBusiness, ScheduleCompleteBusiness scheduleCompleteBusiness)
        {
            _scheduleBusiness = scheduleBusiness;
            _scheduleCompleteBusiness = scheduleCompleteBusiness;
        }
        public class ScheduleModel
        {
            public Schedule Sche { get; set; }
            /// <summary>
            /// 考核计划
            /// </summary>
            public string Plan { get; set; }
            /// <summary>
            /// 提醒时间名称
            /// </summary>
            public string RemindTimeName { get; set; }
            /// <summary>
            /// 提醒方式名称
            /// </summary>
            public string RemindWayName { get; set; }
            /// <summary>
            /// 紧急程度名称
            /// </summary>
            public string EmergencyName { get; set; }
            /// <summary>
            /// 完成情况
            /// </summary>
            public string Completion { get; set; }
        }
        public class ScheduleKPI
        {
            public int Id { get; set; }
            /// <summary>
            /// 标题
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// 开始时间
            /// </summary>
            public DateTime BeginTime { get; set; }
            /// <summary>
            /// 结束时间
            /// </summary>
            public DateTime EndTime { get; set; }
            /// <summary>
            /// 考核管理记录Id
            /// </summary>
            public int KpiManageRecordId { get; set; }
            /// <summary>
            /// 考核管理记录名称
            /// </summary>
            public string KpiManageRecordName { get; set; }
            /// <summary>
            /// 完成时间
            /// </summary>
            public DateTime FinishTime { get; set; }
            /// <summary>
            /// 完成情况
            /// </summary>
            public string Completion { get; set; }
        }
        /// <summary>
        /// [添加] 日程
        /// </summary>
        /// <param name="model">传入的参数</param>
        /// <returns></returns>
        [HttpPost]
        public Result Add([FromForm]Schedule model)
        {
            return _scheduleBusiness.Add(model);
        }
        /// <summary>
        /// 获取全部日程
        /// </summary>
        /// <returns></returns>
        [HttpGet("{eid}")]
        public IList<Schedule> Get(int eid)
        {
            return _scheduleBusiness.Get(eid);
        }
        /// <summary>
        /// 根据KPI获取日程
        /// </summary>
        /// <param name="eid">员工ID</param>
        /// <param name="planId">方案Id</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        [HttpPost]
        public IList<ScheduleKPI> GetByKpi([FromForm]int eid, [FromForm]KpiPlan planId,[FromForm]DateTime startDate,[FromForm]DateTime endDate)
        {
            //先根据条件获取所有日程
            IList<Schedule> list = _scheduleBusiness.GetByKpi(eid, planId, startDate, endDate);
            //封装新集合
            IList<ScheduleKPI> newList = new List<ScheduleKPI>();
            foreach (Schedule item in list)
            {
                ScheduleKPI sm = new ScheduleKPI();
                sm.Id = item.Id;
                sm.Title = item.Title;
                sm.BeginTime = item.BeginTime;
                sm.EndTime = item.EndTime;
                sm.KpiManageRecordId = item.KpiManageRecordId;
                sm.KpiManageRecordName = item.KpiManageRecordName;
                //完成了的集合
                IList<ScheduleComplete> cmp = _scheduleCompleteBusiness.Get(item.Id);
                //执行人集合
                string exestring = item.Executors.Substring(1);
                exestring = exestring.Substring(0, exestring.Length - 1);
                string[] exes = exestring.Split(",");
                //如果完成数等于执行人数
                if (cmp.Count >= exes.Length)
                {
                    sm.Completion = "已完成";
                }
                else
                {
                    sm.Completion = "未完成";
                }
                newList.Add(sm);
            }
            return newList;
        }
        /// <summary>
        /// 根据ID修改Pid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public int UpdatePid(int id)
        {
            return _scheduleBusiness.UpdatePid(id);
        }
        /// <summary>
        /// 根据ID获取任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ScheduleModel GetSingle(int id)
        {
            ScheduleModel newmodel = new ScheduleModel();
            Schedule model = _scheduleBusiness.GetSingle(id);
            newmodel.Sche = model;
            newmodel.Plan = GetDescription(model.KpiPlan);
            newmodel.RemindTimeName = GetDescription(model.RemindTime);
            newmodel.RemindWayName = GetDescription(model.RemindWay);
            newmodel.EmergencyName = GetDescription(model.Emergency);
            DoRepeat(model);
            return newmodel;
        }
        #region 处理重复
        private void DoRepeat(Schedule model)
        {
            _scheduleBusiness.DoRepeat(model);
        }
        #endregion
        /// <summary>
        /// 根据日期查询日程（写总结处使用）
        /// </summary>
        /// <param name="eid">人员ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        [HttpPost]
        public Schedule GetByDate([FromForm] int eid, [FromForm]string date)
        {
            return _scheduleBusiness.GetByDate(eid, date);
        }
        /// <summary>
        /// 根据条件查询日程
        /// </summary>
        /// <param name="eid">人员ID</param>
        /// <param name="catalog">要查询的目录（All,Executors,EmployeeId,Scribbles）</param>
        /// <returns></returns>
        [HttpPost]
        public IList<ScheduleModel> Get([FromForm]int eid, [FromForm]string catalog)
        {
            catalog = string.IsNullOrWhiteSpace(catalog) ? "All" : catalog;
            string empty = catalog;
            if (catalog == "Finish")
            {
                catalog = "All";
            }
            //先根据条件获取所有日程
            IList<Schedule> list = _scheduleBusiness.Get(eid, catalog);
            //封装新集合
            IList<ScheduleModel> newList = new List<ScheduleModel>();
            //已完成的集合
            IList<ScheduleModel> finishList = new List<ScheduleModel>();
            //未完成的集合
            IList<ScheduleModel> ingList = new List<ScheduleModel>();
            foreach (Schedule item in list)
            {
                ScheduleModel sm = new ScheduleModel();
                sm.Sche = item;
                sm.Plan = GetDescription(item.KpiPlan);
                sm.RemindTimeName = GetDescription(item.RemindTime);
                sm.RemindWayName = GetDescription(item.RemindWay);
                sm.EmergencyName = GetDescription(item.Emergency);
                //完成了的集合
                IList<ScheduleComplete> cmp = _scheduleCompleteBusiness.Get(item.Id);
                //执行人集合
                string exestring = item.Executors.Substring(1);
                exestring = exestring.Substring(0, exestring.Length - 1);
                string[] exes = exestring.Split(",");
                //如果完成数等于执行人数
                if (cmp.Count >= exes.Length)
                {
                    sm.Completion = exes.Length + "/" + exes.Length + "完成";
                    finishList.Add(sm);
                }
                else
                {
                    bool me = true;
                    //判断是否该我完成(如果需要我完成，默认为未完成)
                    foreach (string e in exes)
                    {
                        if (e == eid.ToString())
                        {
                            me = false;
                        }
                    }
                    //判断我是否完成（该我去完成）
                    if (!me)
                    {
                        foreach (ScheduleComplete sc in cmp)
                        {
                            if (sc.EmployeeId.Equals(eid))
                            {
                                me = true;
                            }
                        }
                    }
                    //如果我完成了，统计总共完成数
                    if (me)
                    {
                        sm.Completion = cmp.Count + "/" + exes.Length + "完成";
                    }
                    //如果我未完成，显示
                    else
                    {
                        sm.Completion = "我未完成";
                    }
                    ingList.Add(sm);
                }
                newList.Add(sm);
            }
            if (empty == "Finish")
            {
                return finishList;
            }
            else if (empty == "Doing")
            {
                return ingList;
            }
            return newList;
        }
        /// <summary>
        /// 删除日程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Result Delete(int id)
        {
            return _scheduleBusiness.Delete(id);
        }
        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <param name="en">枚举</param>
        /// <returns>返回枚举的描述</returns>
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();   //获取类型
            MemberInfo[] memberInfos = type.GetMember(en.ToString());   //获取成员
            if (memberInfos != null && memberInfos.Length > 0)
            {
                DescriptionAttribute[] attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];   //获取描述特性

                if (attrs != null && attrs.Length > 0)
                {
                    return attrs[0].Description;    //返回当前描述
                }
            }
            return en.ToString();
        }
    }
}