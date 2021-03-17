using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DataAccess
{
    public class LoginDataAccess
    {
        ManageSubmits db = null;
        public LoginDataAccess() 
        {
            db = new ManageSubmits();
        }

        public int LoginHome(string username, string password)
        {

            var data = db.USERS.SingleOrDefault(x => x.Username == username);

            if (data == null)
            {
                return 0;  // Tài khoản không tồn tại
            }
            else if (data.Password == password)
            {
                if (data.Role_ID == 1 || data.Role_ID == 4)
                {
                    return 1; // Đăng nhập thành công
                }
                return -3; // account not permission
            }
            else if (data.Password != password)
            {
                return -1; // sai password
            }
            else
            {
                return -2; // dang nhap khong thanh cong
            }
        }
        public USER GetUserInfoLogging(string username)
        {
            var info = db.USERS.Where(x => x.Username == username).FirstOrDefault();
            return info;
        }


        //// Login Cordinator side////
        public int LoginAdmin(string username, string password)
        {

            var data = db.USERS.SingleOrDefault(x => x.Username == username);

            if (data == null)
            {
                return 0;  // Tài khoản không tồn tại
            }
            else if (data.Password == password)
            {
                if (data.Role_ID == 2)
                {
                    return 1; // Đăng nhập thành công
                }
                return -3; // account not permission
            }
            else if (data.Password != password)
            {
                return -1; // sai password
            }
            else
            {
                return -2; // dang nhap khong thanh cong
            }
        }

        ///// Login Manager side///////
        public int LoginManager(string username, string password)
        {

            var data = db.USERS.SingleOrDefault(x => x.Username == username);

            if (data == null)
            {
                return 0;  // Tài khoản không tồn tại
            }
            else if (data.Password == password)
            {
                if (data.Role_ID == 3)
                {
                    return 1; // Đăng nhập thành công
                }
                return -3; // account not permission
            }
            else if (data.Password != password)
            {
                return -1; // sai password
            }
            else
            {
                return -2; // dang nhap khong thanh cong
            }
        }
    }
}
