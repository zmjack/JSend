
using System.ComponentModel;

namespace Ajax
{
    public interface IJSend
    {
        string status { get; }
        object data { get; set; }
        string code { get; set; }
        string message { get; set; }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class XIJSend
    {
        public static bool IsSuccess(this IJSend @this) => @this.status == "success";
        public static bool IsFail(this IJSend @this) => @this.status == "fail";
        public static bool IsError(this IJSend @this) => @this.status == "error";
    }
}
