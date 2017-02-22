using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Common
{

    public class ResultStatus
    {
        #region private variable
        private int _status = -1;
        private string _messageText = string.Empty;
        #endregion

        #region Constructor
        public ResultStatus() { }
        #endregion

        #region public method and properties
        public bool IsSuccess
        {
            get { return _status == 0; }
        }

        public int Status
        {
            get { return _status; }
        }

        public string MessageText
        {
            get { return _messageText; }
            set { _messageText = value; }
        }

        public void SetSuccessStatus()
        {
            _status = 0;
        }

        public void SetSuccessStatus(string message)
        {
            _status = 0;
            _messageText = message;
        }

        public void SetErrorStatus()
        {
            _status = -1;
        }

        public void SetErrorStatus(string message)
        {
            _status = -1;
            _messageText = message;
        }

        #endregion
    }
}
