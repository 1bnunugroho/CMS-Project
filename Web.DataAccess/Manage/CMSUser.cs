using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Common;

namespace Web.DataAccess
{
    public partial class CMSUser : BaseAction<CMSUser>, IDisposable
    {
        private static WebEntity _db = new WebEntity();

        public ResultStatus Insert(CMSUser ObjToSave, string By)
        {
            ResultStatus rs = new ResultStatus();
            rs.MessageText = string.Format(insertFailed, typeof(CMSUser).Name);

            CMSUser userCheckUsernameAvailability = GetByUsername(this.Username);
            if (userCheckUsernameAvailability != null)
            {
                rs.MessageText = "Username already exist";
                return rs;
            }

            try
            {
                ObjToSave.CreatedBy = By;
                ObjToSave.CreatedDate = DateTime.Now;
                ObjToSave.IsDeleted = false;
                _db.CMSUsers.Add(ObjToSave);
                _db.SaveChanges();

                rs.SetSuccessStatus(string.Format(insertSuccess, typeof(CMSUser).Name));
            }
            catch (Exception ex)
            {
                rs.MessageText = string.Format(insertFailedWithException, typeof(CMSUser).Name, ex);
            }
            return rs;
        }

        public ResultStatus Update(CMSUser ObjToUpdate, string By)
        {
            ResultStatus rs = new ResultStatus();
            rs.MessageText = string.Format(updateFailed, typeof(CMSUser).Name);

            try
            {
                ObjToUpdate.UpdateBy = By;
                ObjToUpdate.UpdateDate = DateTime.Now;
                _db.Entry(ObjToUpdate).State = EntityState.Modified;
                _db.SaveChanges();

                rs.SetSuccessStatus(string.Format(updateSuccess, typeof(CMSUser).Name));
            }
            catch (Exception ex)
            {
                rs.MessageText = string.Format(updateFailedWithException, typeof(CMSUser).Name, ex);
            }
            return rs;
        }
        public ResultStatus Delete(CMSUser ObjToUpdate, string By)
        {
            ResultStatus rs = new ResultStatus();
            rs.MessageText = string.Format(deleteFailed, typeof(CMSUser).Name);

            try
            {
                ObjToUpdate.IsDeleted = true;
                _db.Entry(ObjToUpdate).State = EntityState.Modified;
                _db.SaveChanges();

                rs.SetSuccessStatus(string.Format(deleteSuccess, typeof(CMSUser).Name));
            }
            catch (Exception ex)
            {
                rs.MessageText = string.Format(deleteFailedWithException, typeof(CMSUser).Name, ex);
            }

            return rs;
        }


        public static IQueryable<CMSUser> GetAll()
        {
            return _db.CMSUsers.Where(x => x.ID > 0 && !x.IsDeleted)
                .OrderByDescending(x => x.ID);
        }

        public static CMSUser GetByUsername(string username)
        {
            return GetAll().Where(x => x.Username == username).FirstOrDefault();
        }


        public static CMSUser GetByUsernameAndPassword(string Username, string Password)
        {
            IQueryable<CMSUser> res = GetAll().Where(x => x.Username.ToLower() == Username.ToLower() && x.Password == Password);
            return res.FirstOrDefault();
        }

        public static CMSUser GetByID(long ID)
        {
            IQueryable<CMSUser> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
