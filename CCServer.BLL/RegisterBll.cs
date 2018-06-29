using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT.Manage.Core;

namespace CCServer.BLL
{
    public class RegisterBll : BaseBll
    {
        public static bool CheckAccount(string FAccount)
        {
            //用户名是否已存在
            bool ExistAccount = ModelOpretion.ScalarDataExist(@" Select * From e_MobileUser
                            where FAccount=@FAccount  ", new { FAccount = FAccount.Trim() });
            return ExistAccount;
        }

        public static bool CheckNickName(string FNickName)
        {
            //判断昵称是否已存在
            bool ExistNickName = ModelOpretion.ScalarDataExist(@" Select * From e_MobileUser
                            where FNickName=@FNickName  ", new { FNickName = FNickName.Trim() });
            return ExistNickName;
        }

        public static bool CheckMobile(string FMobile)
        {
            //判断手机号是否已存在
            bool ExistMobile = ModelOpretion.ScalarDataExist(@" Select * From e_MobileUser
                            where FMobile=@FMobile  ", new { FMobile = FMobile.Trim() });
            return ExistMobile;
        }
    }
}
