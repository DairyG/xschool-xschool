﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using XSchool.Businesses;
using XSchool.Core;
using XSchool.WorkFlow.Model;
using XSchool.WorkFlow.Repositories;
using static XSchool.WorkFlow.Model.Enums;

namespace XSchool.WorkFlow.Businesses
{
    /// <summary>
    /// 流程组别
    /// </summary>
    public class SubjectTypeBusiness : Business<SubjectType>
    {
        private readonly SubjectTypeRepository _repository;
        private readonly SubjectRepository _repositorySubject;
        public SubjectTypeBusiness(IServiceProvider provider, SubjectTypeRepository repository, SubjectRepository repositorySubject) : base(provider, repository)
        {
            this._repository = repository;
            this._repositorySubject = repositorySubject;

        }
        /// <summary>
        /// /验证流程组别名称重复
        /// </summary>
        /// <param name="SubjectTypeName"></param>
        /// <returns></returns>
        public SubjectType IsExist(string SubjectTypeName)
        {
            var model = _repository.GetSingle(p => p.SubjectTypeName == SubjectTypeName);
            return model;
        }
        /// <summary>
        /// /添加组别
        /// </summary>
        /// <param name="SubjectTypeName"></param>
        /// <returns></returns>
        public Result AddOrEdit(SubjectType model)
        {
            string msg = string.Empty;
            if (IsExist(model.SubjectTypeName) != null)
            {
                return new Result() { Message = "流程名称重复!", Succeed = false };
            }

            if (model.Id > 0)
            {
                msg = _repository.Update(s=>s.Id==model.Id,s=>new SubjectType { SubjectTypeName=model.SubjectTypeName })? "" : "编辑失败！";
            }
            else
            {
                msg = _repository.Add(model) > 0 ? "" : "添加失败";
            }
            return new Result() { Message = msg, Succeed = string.IsNullOrEmpty(msg) ? true : false };
        }
        /// <summary>
        /// /获取启用的所有流程组别
        /// </summary>
        /// <returns></returns>
        public IList<SubjectType> GetSubjectTypeList()
        {
            var subjectTypeList = _repository.Query(s => s.Status == EDStatus.Enable);
            return subjectTypeList;
        }
           
        /// <summary>
        /// 删除流程组别
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Result DeleteSubjectType(int Id)
        {
            string msg = string.Empty;
            bool status = false;
            var obj = _repository.GetSingle(s => s.IsDelete);
                if(obj.Id==Id) return new Result() { Message = "【其他】选项不能删除！", Succeed = status };

            var list = _repositorySubject.Query(s => s.SubjectTypeId == Id);
            if (list != null && list.Count > 0)
            {
                status = _repositorySubject.Update(s => s.SubjectTypeId == Id, s => new Subject { SubjectTypeId = obj.Id });
           
                status = _repository.DeleteExt(s=>s.Id==Id);
            }
            if (!status) msg = "删除失败。。。";
            return new Result() { Message = msg, Succeed = status };
        }


        /// <summary>
        /// 删除流程组别
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Result DeleteSubjectType1(int Id)
        {
            string msg = string.Empty;
            bool status = false;

            status = _repository.Delete(s => s.Id == Id) > 0 ? true : false;
            return new Result() { Message = msg, Succeed = status };
        }

    }
}
