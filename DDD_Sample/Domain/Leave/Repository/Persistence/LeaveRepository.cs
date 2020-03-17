using Domain.Leave.Repository.Facade;
using Domain.Leave.Repository.PO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Domain.Leave.Repository.Persistence
{
    public class LeaveRepository : ILeaveRepository
    {
        readonly ILogger<LeaveRepository> _logge;
        readonly IDbConnection _db;
        public LeaveRepository(IDbConnection db, ILogger<LeaveRepository> logger)
        {
            _logge = logger;
            _db = db;
        }

        public bool Save(LeavePO leavePO)
        {
         
            try
            {
                var sql = @"INSERT INTO public.leaves(
	id, applicantid, applicantname, applicanttype, approverid, approvername, leavetype, status, starttime, endtime, duration,maxleaderlevel)
	VALUES (@id, @applicantid, @applicantname, @applicanttype, @approverid, @approvername, @leavetype, @status, @starttime, @endtime, @duration,@maxleaderlevel);";
                _db.Execute(sql, leavePO);
                return true;
            }
            catch (Exception exc)
            {         
                _logge.LogCritical(exc, exc.Message);
                return false;
            }

        }
        public bool Submit(LeavePO leavePO)
        {
            if (_db.State == ConnectionState.Closed)
            {
                _db.Open();
            }
            var tran = _db.BeginTransaction();
            try
            {
                //枚举有坑
                var i = (int)leavePO.Status;
                var sql = @"update public.leaves set
	 applicantid=@applicantid, applicantname=@applicantname, applicanttype=@applicanttype, approverid=@approverid, approvername=@approvername, leavetype=@leavetype, status=@Status, starttime=@starttime, endtime=@endtime, duration=@duration,maxleaderlevel=@maxleaderlevel where id=@id;";
                _db.Execute(sql, leavePO, tran);

                sql = @"INSERT INTO public.approval_infos(
	approvalinfoid, leaveid, applicantid, approverid,approvaltype, approverlevel, approvername, msg, ""time"")
    VALUES(@approvalinfoid, @leaveid, @applicantid,@approverid,@approvaltype,  @approverlevel, @approvername, @msg, @time); ";
                _db.Execute(sql, leavePO.CurrentApprovalInfo, tran);
                tran.Commit();
                return true;
            }
            catch (Exception exc)
            {
                tran.Rollback();
                _logge.LogCritical(exc, exc.Message);
                return false;
            }

        }

        public bool SaveEvent(LeaveEventPO leaveEventPO)
        {
            try
            {
                var sql = @"INSERT INTO public.events(
	leaveeventtype, ""timestamp"", source, data)
    VALUES(@leaveeventtype, @timestamp, @source, @data::json); ";
                _db.Execute(sql, leaveEventPO);
                return true;
            }
            catch (Exception exc)
            {
                _logge.LogCritical(exc, exc.Message);
                return false;
            }
        }


        public LeavePO FindById(string id)
        {
            try
            {
                var sql = @"SELECT id, applicantid, applicantname, applicanttype, approverid, approvername, leavetype, status, starttime, endtime, duration
	FROM public.leaves where id=@id";
                return _db.Query<LeavePO>(sql, id).SingleOrDefault();

            }
            catch (Exception exc)
            {
                _logge.LogCritical(exc, exc.Message);
                return null;
            }
        }


        public List<LeavePO> QueryByApplicantId(string applicantId)
        {
            try
            {
                var sql = @"SELECT id, applicantid, applicantname, applicanttype, approverid, approvername, leavetype, status, starttime, endtime, duration
	FROM public.leaves where applicantid=@applicantid";
                return _db.Query<LeavePO>(sql, new { applicantId }).ToList();
            }
            catch (Exception exc)
            {
                _logge.LogCritical(exc, exc.Message);
                return null;
            }
        }

        public List<LeavePO> QueryByApproverId(string approverId)
        {
            try
            {
                var sql = @"SELECT id, applicantid, applicantname, applicanttype, approverid, approvername, leavetype, status, starttime, endtime, duration,maxleaderlevel
	FROM public.leaves where approverid=@approverid";
                return _db.Query<LeavePO>(sql, new { approverId }).ToList();
            }
            catch (Exception exc)
            {
                _logge.LogCritical(exc, exc.Message);
                return null;
            }
        }
    }
}
