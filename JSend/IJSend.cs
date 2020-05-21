
namespace Ajax
{
#pragma warning disable IDE1006    
    public interface IJSend<TData>
    {
        string status { get; }
        TData data { get; set; }

        string code { get; set; }
        string message { get; set; }
    }

    public static class IJSendExtension
    {
        public static bool IsSuccess<TData>(this IJSend<TData> @this) => @this.status == JSendConst.SUCCESS_STATUS;
        public static bool IsFail<TData>(this IJSend<TData> @this) => @this.status == JSendConst.FAIL_STATUS;
        public static bool IsError<TData>(this IJSend<TData> @this) => @this.status == JSendConst.ERROR_STATUS;
    }
#pragma warning restore
}
