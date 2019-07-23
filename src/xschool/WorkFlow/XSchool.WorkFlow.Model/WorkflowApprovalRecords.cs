﻿using System;
using System.Collections.Generic;
using System.Text;
using XSchool.Core;

namespace XSchool.WorkFlow.Model
{
    /// <summary>
    /// 工作流审核记录表
    /// </summary>
    public class WorkflowApprovalRecords : IModel<int>
    {

        /// <summary>
        /// 
        /// </summary>		
        public int Id { get; set; }

        /// <summary>
        /// 工作流业务主键Id
        /// </summary>		
        public int WorkflowBusinessId { get; set; }

        /// <summary>
        /// 流程节点Id
        /// </summary>		
        public int WorkflowApprovalStepId { get; set; }

        /// <summary>
        ///  -1 拒绝，1等待审批，2同意，3未接收审批
        /// </summary>		
        public int Status { get; set; }

        /// <summary>
        /// 审核人Id
        /// </summary>		
        public int AuditidUserId { get; set; }

        /// <summary>
        /// 审核人姓名
        /// </summary>		
        public int AuditidUserName { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>		
        public DateTime? AuditidTime { get; set; }

        /// <summary>
        /// 审批意见或操作说明
        /// </summary>		
        public string Memo { get; set; }

        /// <summary>
        /// 最大编号为最新记录，其他为旧的记录
        /// </summary>		
        public int OldCode { get; set; }

        /// <summary>
        /// 1 审核内容，2操作记录
        /// </summary>		
        public int DataType { get; set; }

    }
}
