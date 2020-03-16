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
        readonly ILogger _logge;
        readonly IDbConnection _db;
        public LeaveRepository(IDbConnection db, ILogger logger)
        {
            _logge = logger;
            _db = db;
        }

        public bool Save(LeavePO leavePO)
        {
            using (_db)
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var tran = _db.BeginTransaction();
                try
                {
                    var sql = @"INSERT INTO public.leaves(
	id, applicantid, applicantname, applicanttype, approverid, approvername, leavetype, status, starttime, endtime, duration)
	VALUES (@id, @applicantid, @applicantname, @applicanttype, @approverid, @approvername, @leavetype, @status, @starttime, @endtime, @duration);";
                    _db.Execute(sql, leavePO, tran);

                    sql = @"INSERT INTO public.history_approval_infos(
	approvalinfoid, leaveid, applicantid, approverid, approverlevel, approvername, msg, ""time"")
    VALUES(@approvalinfoid, @leaveid, @applicantid, @approverid, @approverlevel, @approvername, @msg, @time); ";
                    _db.Execute(sql, leavePO.HistoryApprovalInfoPOList, tran);
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
        }

        public bool SaveEvent(LeaveEventPO leaveEventPO)
        {
            using (_db)
            {
                try
                {
                    var sql = @"INSERT INTO public.events(
	leaveeventtype, ""timestamp"", source, data)
    VALUES(@leaveeventtype, @timestamp, @source, @data); ";
                    _db.Execute(sql, leaveEventPO);
                    return true;
                }
                catch (Exception exc)
                {
                    _logge.LogCritical(exc, exc.Message);
                    return false;
                }
            }
        }


        public LeavePO FindById(string id)
        {
            using (_db)
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
        }


        public List<LeavePO> QueryByApplicantId(string applicantId)
        {
            using (_db)
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
        }

        public List<LeavePO> QueryByApproverId(string approverId)
        {
            using (_db)
            {
                try
                {
                    var sql = @"SELECT id, applicantid, applicantname, applicanttype, approverid, approvername, leavetype, status, starttime, endtime, duration
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
}
