﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using XSchool.Core;

namespace XSchool.GCenter.Model
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class PowerRole : IModel<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>		
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>		
        public string Remarks { get; set; }

        /// <summary>
        /// 状态
        /// </summary>		
        public NomalStatus Status { get; set; }

        /// <summary>
        /// 排序，数字越小越靠前
        /// </summary>		
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 模块中的元素
        /// </summary>
        [NotMapped]
        public List<PowerElement> Elements { get; set; } = new List<PowerElement>();
    }
}
