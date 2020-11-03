
using System.ComponentModel;

namespace Ajax
{
    public interface IJSend
    {
        string Status { get; }
        object Data { get; set; }

        string Code { get; set; }
        string Message { get; set; }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class XIJSend
    {
        public static bool IsSuccess(this IJSend @this) => @this.Status == JSend.SUCCESS_STATUS;
        public static bool IsFail(this IJSend @this) => @this.Status == JSend.FAIL_STATUS;
        public static bool IsError(this IJSend @this) => @this.Status == JSend.ERROR_STATUS;
    }
}
