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

        public List<SUBMITTION> GetAllPostByUser(int userid)
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
                return 1;
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
    }
}
