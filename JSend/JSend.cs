﻿
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

        public virtual string Status { get; protected set; }
        public virtual object Data { get; set; }
        string IJSend.Code { get; set; }
        string IJSend.Message { get; set; }
    }

}
