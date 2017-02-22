using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataAccess
{
    public abstract class BaseAction<T>
        where T : class, new()
    {
        public const string insertSuccess = "{0} has been save";
        public const string insertFailed = "{0} save failed";
        public const string insertFailedWithException = "{0} save failed : {1}";
        public const string updateSuccess = "update {0} data success";
        public const string updateFailed = "update {0} data failed";
        public const string updateFailedWithException = "update {0} data failed : {1}";
        public const string deleteSuccess = "{0} has been deleted";
        public const string deleteFailed = "delete {0} data failed";
        public const string deleteFailedWithException = "delete {0} data failed : {1}";

    }
}
