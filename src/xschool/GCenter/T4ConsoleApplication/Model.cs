﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
<<<<<<< Updated upstream
//	   生成时间 2019-07-11 16:59:59 by yongyi
=======
<<<<<<< Updated upstream
//	   生成时间 2019-07-16 09:42:06 by yongyi
=======
//	   生成时间 2019-07-15 21:49:32 by yongyi
>>>>>>> Stashed changes
>>>>>>> Stashed changes
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
namespace XSchool.GCenter.Model
{	

	public class KpiManageAuditDetail
    {
		
		/// <summary>
		/// 
		/// </summary>		
		public int Id { get; set; }
		
		/// <summary>
		/// 考核管理记录Id
		/// </summary>		
<<<<<<< Updated upstream
		public int KpiManageRecordId { get; set; }
		
		/// <summary>
		/// 考核对象类型，1-部门负责人，2-人员
		/// </summary>		
		public int ObjectType { get; set; }
=======
<<<<<<< Updated upstream
		public int KpiTemplateRecordId { get; set; }
=======
		public int KpiManageRecordId { get; set; }
>>>>>>> Stashed changes
>>>>>>> Stashed changes
		
		/// <summary>
		/// 当前步骤
		/// </summary>		
		public int Steps { get; set; }
		
		/// <summary>
		/// 评价
		/// </summary>		
		public string Evaluation { get; set; }
		
		/// <summary>
		/// 公司Id
		/// </summary>		
		public int CompanyId { get; set; }
		
		/// <summary>
		/// 公司名称
		/// </summary>		
		public string CompanyName { get; set; }
		
		/// <summary>
		/// 部门Id
		/// </summary>		
		public int DptId { get; set; }
		
		/// <summary>
		/// 部门名称
		/// </summary>		
		public string DptName { get; set; }
		
		/// <summary>
		/// 人员Id
		/// </summary>		
		public int EmployeeId { get; set; }
		
		/// <summary>
		/// 人员名称
		/// </summary>		
		public string UserName { get; set; }
		
		/// <summary>
		/// 添加时间
		/// </summary>		
		public DateTime? AddDate { get; set; }
		 
    }
}

