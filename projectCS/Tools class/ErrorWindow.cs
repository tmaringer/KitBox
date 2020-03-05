using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectCS.Tools_class
{
    public class ErrorWindow
    {
        private string _errorMessage;
        private string _errorTitle;

        public ErrorWindow() : this(ErrorMessages.defaultTitleMsg)
        {
        }
        
        public ErrorWindow(string errorMsg) : this(ErrorMessages.defaultErrorMsg, ErrorMessages.defaultTitleMsg)
        {
            this._errorMessage = errorMsg;
            this._errorTitle = ErrorMessages.defaultTitleMsg;
        }
        
        public ErrorWindow(string errorMsg, string errorTitle)
        {
            this._errorMessage = errorMsg;
            this._errorTitle = errorTitle;
        }

        public void displayWindow()
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(_errorMessage, _errorTitle, buttons);
        }

    }
}
