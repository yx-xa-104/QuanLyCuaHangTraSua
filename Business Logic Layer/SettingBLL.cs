using QuanLyCuaHangTraSua.DAO;

namespace QuanLyCuaHangTraSua.BLL
{
    public class SettingBLL
    {
        public bool UpdateDisplayName(string userName, string displayName, int type)
        {
            return AccountDAO.Instance.UpdateAccount(userName, displayName, type);
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (!AccountDAO.Instance.Login(userName, oldPassword))
                return false;
            return AccountDAO.Instance.ChangePassword(userName, newPassword);
        }
    }
}
