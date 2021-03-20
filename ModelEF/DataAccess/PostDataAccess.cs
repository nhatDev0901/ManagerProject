using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DataAccess
{
    public class PostDataAccess
    {
        ManageSubmits db = null;
        public PostDataAccess()
        {
            db = new ManageSubmits();
        }

        public List<SUBMITTION> GetAllPostByUser(int? userid)
        {
            var list = db.SUBMITTIONS.Where(x => x.Created_By == userid).ToList();
            return list;
        }

        public string CreateIDAuto(string ma)
        {
            int i = 1;
            bool flag = false;
            string idSubmit = "";
            do
            {
                idSubmit = ma + i;
                if (CheckIDBook(idSubmit))
                {
                    flag = true;
                }
                i++;
            } while (flag == false);
            return idSubmit;

        }

        public bool CheckIDBook(string id)
        {
            var ma = db.SUBMITTIONS.SingleOrDefault(x => x.Sub_Code == id);
            if (ma != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int AddSubmits(SUBMITTION input)
        {
            try
            {
                db.SUBMITTIONS.Add(input);
                db.SaveChanges();
                
                var id = db.SUBMITTIONS.Where(x => x.Sub_Code == input.Sub_Code).FirstOrDefault();
                return id.Sub_ID;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public USER GetUserInfoByID(int id)
        {
            var res = db.USERS.Where(x => x.User_ID == id).FirstOrDefault();
            if (res == null)
            {
                res = new USER();
            }
            return res;
        }

        public int InsertFile(FILE input)
        {
            try
            {
                db.FILES.Add(input);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
                throw;
            }
        }

        public SUBMITTION GetSubmittionByID(int id)
        {
            var data = db.SUBMITTIONS.Where(x => x.Sub_ID == id).FirstOrDefault();
            return data;
        }

        public int EditSubmission(SUBMITTION entity)
        {
            try
            {
                var submission = db.SUBMITTIONS.Find(entity.Sub_ID);
                submission.Sub_Title = entity.Sub_Title;
                submission.Sub_Description = entity.Sub_Description;
                submission.Updated_By = entity.Updated_By;
                submission.Updated_Date = entity.Updated_Date;
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public int EditPublicStatus(SUBMITTION entity)
        {
            try
            {
                var data = db.SUBMITTIONS.Find(entity.Sub_ID);
                data.IsPublic = entity.IsPublic;

                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return -1;
                throw;
            }
        }

        public int DeleteSubmission(int id)
        {
            try
            {
                var data = db.SUBMITTIONS.Find(id);
                var removeFile = db.FILES.RemoveRange(db.FILES.Where(x => x.Sub_ID == id));
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<FILE> GetFilesBySubCode(string code)
        {
            try
            {
                var data = db.FILES.Where(x => x.Sub_Code == code).ToList();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<FILE> GetFilesBySubID(int id)
        {
            try
            {
                var data = db.FILES.Where(x => x.Sub_ID == id).ToList();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int EditFileByID(FILE entity, List<int> listid)
        {
            try
            {
                foreach (var item in listid)
                {
                    var data = db.FILES.Find();
                    data.File_Path = entity.File_Path;
                    data.File_Name = entity.File_Name;
                    data.Sub_ID = entity.Sub_ID;
                    db.SaveChanges();
                }              
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int DeleteFile(int id)
        {
            try
            {
                var data = db.FILES.Find(id);
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<SUBMITTION> GetListSubmisstionForAdmin(int? DepID)
        {
            try
            {
                var model = db.SUBMITTIONS.Join(db.USERS, x => x.Created_By, y => y.User_ID, (x, y) => x).ToList();
                var list = model.Where(x => x.USER.Dep_ID == DepID).ToList();
                return list;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<DEPARTMENT> GetListDepartment()
        {
            var list = db.DEPARTMENTS.ToList();
            return list;
        }

        public List<SUBMITTION> GetSubmissionsForManager()
        {
            var model = db.SUBMITTIONS.Join(db.USERS, x => x.Created_By, y => y.User_ID, (x, y) => x).ToList();
            var list = model.Where(x => x.IsPublic == 1).ToList();
            return list;
        }

        public DEPARTMENT GetDepartmentByUserID(int userID)
        {
            var dataUser = db.USERS.Where(x => x.User_ID == userID).FirstOrDefault();
            var departmentData = db.DEPARTMENTS.Where(y => y.Dep_ID == dataUser.Dep_ID).FirstOrDefault();
            return departmentData;
        }

        public int SetDeadLine(DEADLINE input)
        {
            try
            {
                db.DEADLINEs.Add(input);
                db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
