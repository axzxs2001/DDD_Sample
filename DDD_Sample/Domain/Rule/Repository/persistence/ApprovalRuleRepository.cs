using Dapper;
using Domain.Rule.Entity;
using Domain.Rule.Repository.facade;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Rule.Repository.persistence
{
    public class ApprovalRuleRepository : IApprovalRuleRepository
    {
        readonly ILogger<ApprovalRuleRepository> _logge;
        readonly IDbConnection _db;
        public ApprovalRuleRepository(IDbConnection db, ILogger<ApprovalRuleRepository> logger)
        {
            _logge = logger;
            _db = db;
        }
        /// <summary>
        /// 查询规则最大级别
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public int GetLeaderMaxLevel(ApprovalRule rule)
        {
            try
            {
                var sql = @"SELECT maxleaderlevel from approval_rules where persontype=@persontype and leavetype=@leavetype and duration=@duration order by duration limit 1";
                return _db.ExecuteScalar<int>(sql, rule);
            }
            catch (Exception exc)
            {
                _logge.LogCritical(exc, exc.Message);
                return 0;
            }      
        }
    }
}
