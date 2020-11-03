
namespace Ajax
{
    // Refer: http://labs.omniti.com/labs/jsend
    public class JSend : IJSend
    {
        public const string SUCCESS_STATUS = "success";
        public const string FAIL_STATUS = "fail";
        public const string ERROR_STATUS = "error";

        public static JSuccess Success() => new JSuccess();
        public static JFail Fail() => new JFail();
        public static JError Error(string message) => new JError { Message = message };
        public static JError Error(string message, string code) => new JError { Code = code, Message = message };

        public static JSuccess<TData> Success<TData>(TData data) => new JSuccess<TData> { Data = data };
        public static JFail<TData> Fail<TData>(TData data) => new JFail<TData> { Data = data };
        public static JError<TData> Error<TData>(string message, string code, TData data) => new JError<TData> { Data = data, Code = code, Message = message };

        public string Status { get; set; }
        public object Data { get; set; }

        public string Code { get; set; }
        public string Message { get; set; }

        public static implicit operator JSend(JSuccess jsend)
        {
            return new JSend
            {
                Status = jsend.Status,
                Data = jsend.Data,
                Code = null,
                Message = null,
            };
        }

        public static implicit operator JSend(JFail jsend)
        {
            return new JSend
            {
                Status = jsend.Status,
                Data = jsend.Data,
                Code = null,
                Message = null,
            };
        }

        public static implicit operator JSend(JError jsend)
        {
            return new JSend
            {
                Status = jsend.Status,
                Data = jsend.Data,
                Code = jsend.Code,
                Message = jsend.Message,
            };
        }
    }

    public class JSend<TData> : JSend
    {
        public new TData Data { get; set; }

        public static implicit operator JSend<TData>(JSuccess<TData> jsend)
        {
            return new JSend<TData>
            {
                Status = jsend.Status,
                Data = jsend.Data,
                Code = null,
                Message = null,
            };
        }

        public static implicit operator JSend<TData>(JFail<TData> jsend)
        {
            return new JSend<TData>
            {
                Status = jsend.Status,
                Data = jsend.Data,
                Code = null,
                Message = null,
            };
        }

        public static implicit operator JSend<TData>(JError<TData> jsend)
        {
            return new JSend<TData>
            {
                Status = jsend.Status,
                Data = jsend.Data,
                Code = jsend.Code,
                Message = jsend.Message,
            };
        }
    }
}
