using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DataAccess
{
    public class StatisticDataAccess
    {
        ManageSubmits db = null;
        public StatisticDataAccess()
        {
            db = new ManageSubmits(); 
        }

        public List<SUBMITTION> GetSubmissionPublic(int? DepID, string role)
        {
            var list = new List<SUBMITTION>();
            var model = db.SUBMITTIONS.Join(db.USERS, x => x.Created_By, y => y.User_ID, (x, y) => x).ToList();
            if (role == "Admin")
            {                
                 list = model.Where(x => x.USER.Dep_ID == DepID && x.IsPublic == 1).ToList();
            }
            else
            {
                 list = model.Where(x => x.IsPublic == 1).ToList();
            }
            
            return list;
        }

        public List<SUBMITTION> GetSubmissionNotPublic(int? DepID, string role)
        {
            var model = db.SUBMITTIONS.Join(db.USERS, x => x.Created_By, y => y.User_ID, (x, y) => x).ToList();
            var list = new List<SUBMITTION>();
            if (role == "Admin")
            {
                list = model.Where(x => x.USER.Dep_ID == DepID && x.IsPublic == 0).ToList();
            }
            else
            {
                list = model.Where(x => x.IsPublic == 0).ToList();
            }          
            return list;
        }

        public List<StatisticNumberOfSubmissionModel> GetSubmissionsInDepartment(int? DepID,string role, out int total)
        {
            var data = db.SUBMITTIONS.Join(db.USERS, x => x.Created_By, y => y.User_ID, (x, y) => x).ToList();
            var userinDep = new List<USER>();
            if (role == "Admin")
            {
                total = data.Where(x => x.USER.Dep_ID == DepID).Count();
                userinDep = db.USERS.Where(x => x.Dep_ID == DepID && x.Role_ID == 1).ToList(); //lay danh sách học sinh trong khoa của admin đang đăng nhập
            }
            else
            {
                total = data.Count();
                userinDep = db.USERS.Where(x => x.Role_ID == 1).ToList();
            }
            
            var model = new List<StatisticNumberOfSubmissionModel>();
            foreach (var item in userinDep)
            {
                model.Add(new StatisticNumberOfSubmissionModel
                {
                    name = item.Username,
                    value = db.SUBMITTIONS.Where(x => x.Created_By == item.User_ID).Count()
                });
            }
            return model;
        }
    }
}
