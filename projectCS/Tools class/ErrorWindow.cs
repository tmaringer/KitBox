using System.Windows.Forms;

namespace projectCS.Tools_class
{
    public class ErrorWindow
    {
        private string _errorMessage;
        private string _errorTitle;

        public ErrorWindow() : this(ErrorMessages.defaultErrorTitle)
        {
        }

        public ErrorWindow(string errorMsg) : this(ErrorMessages.defaultErrorMsg, ErrorMessages.defaultErrorTitle)
        {
            this._errorMessage = errorMsg;
            this._errorTitle = ErrorMessages.defaultErrorTitle;
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
