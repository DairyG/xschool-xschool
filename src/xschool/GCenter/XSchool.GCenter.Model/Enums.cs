﻿using System.ComponentModel;

namespace XSchool.GCenter.Model
{
    /// <summary>
    /// 常用状态，[有效，无效]
    /// </summary>
    public enum NomalStatus
    {
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        Invalid = 0,

        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        Valid = 1,
    }

    /// <summary>
    /// 禁启状态，[禁用，启用]
    /// </summary>
    public enum EDStatus
    {
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disable = 1,

        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enable = 2,
    }

    /// <summary>
    /// 基础信息类型
    /// </summary>
    public enum BasicInfoType
    {
        /// <summary>
        /// 到岗时间
        /// </summary>
        [Description("到岗时间")]
        WorkerInField = 1,

        /// <summary>
        /// 面试方式
        /// </summary>
        [Description("面试方式")]
        InterviewMethod = 2,

        /// <summary>
        /// 学历
        /// </summary>
        [Description("学历")]
        Education = 3,

        /// <summary>
        /// 教育性质
        /// </summary>
        [Description("教育性质")]
        Properties = 4,

        /// <summary>
        /// 社会关系
        /// </summary>
        [Description("社会关系")]
        SocialRelations = 5,

        /// <summary>
        /// 招聘来源
        /// </summary>
        [Description("招聘来源")]
        RecruitmentSource = 6,

        /// <summary>
        /// 合同性质
        /// </summary>
        [Description("合同性质")]
        ContractNature = 7,

        /// <summary>
        /// 工资类别
        /// </summary>
        [Description("工资类别")]
        WagesType = 8,

        /// <summary>
        /// 保险类别
        /// </summary>
        [Description("保险类别")]
        InsuranceType = 9,
    }

    /// <summary>
    /// 性别
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Man = 1,

        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        Woman = 2,
    }

    /// <summary>
    /// 是否为系统数据
    /// </summary>
    public enum IsSystem
    {
        /// <summary>
        /// 是
        /// </summary>
        [Description("是")]
        Yes = 1,

        /// <summary>
        /// 否
        /// </summary>
        [Description("否")]
        No = 0,
    }

    /// <summary>
    /// 加or减
    /// </summary>
    public enum AddSubtraction
    {
        /// <summary>
        /// 增加
        /// </summary>
        [Description("增加")]
        Add = 1,

        /// <summary>
        /// 扣除
        /// </summary>
        [Description("扣除")]
        Subtraction = 2,
    }

    /// <summary>
    /// 预算管理
    /// </summary>
    public enum BudgetType
    {
        /// <summary>
        /// 建设成本
        /// </summary>
        [Description("建设成本")]
        Construction = 1,
        /// <summary>
        /// 费用预算
        /// </summary>
        [Description("费用预算")]
        CostBudget = 2,
        /// <summary>
        /// 固定资产
        /// </summary>
        [Description("固定资产")]
        FixedAssets = 3,
    }

    /// <summary>
    /// 简历状态
    /// </summary>
    public enum ResumeStatus
    {
        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        Effective = 1,
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        Invalid = 2,
    }
    /// <summary>
    /// 面试状态
    /// </summary>
    public enum InterviewStatus
    {
        /// <summary>
        /// 未面试
        /// </summary>
        [Description("未面试")]
        NoInterview = 1,
        /// <summary>
        /// 面试中
        /// </summary>
        [Description("面试中")]
        InterviewIng = 2,
        /// <summary>
        /// 已通过
        /// </summary>
        [Description("已通过")]
        IsPass = 3,
        /// <summary>
        /// 未通过
        /// </summary>
        [Description("未通过")]
        NoPass = 4,
    }
}
