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

        public List<SUBMITTION> GetAllPost()
        {
            var list = db.SUBMITTIONS.ToList();
            return list;
        }
    }
}
