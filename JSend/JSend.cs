using System.Text.Json.Serialization;

namespace Ajax
{
    // Refer: http://labs.omniti.com/labs/jsend
    [JsonConverter(typeof(JSendConverter))]
    public abstract class JSend : IJSend
    {
        public static JSuccess Success() => new JSuccess();
        public static JFail Fail() => new JFail();
        public static JError Error(string message) => new JError { message = message };
        public static JError Error(string message, string code) => new JError { code = code, message = message };

        public static JSuccess<TData> Success<TData>(TData data) => new JSuccess<TData> { data = data };
        public static JFail<TData> Fail<TData>(TData data) => new JFail<TData> { data = data };
        public static JError<TData> Error<TData>(string message, string code, TData data) => new JError<TData> { data = data, code = code, message = message };

        [JsonIgnore]
        public virtual string status { get; protected set; }

        [JsonIgnore]
        public virtual object data { get; set; }

        string IJSend.code { get; set; }
        string IJSend.message { get; set; }

        public bool IsSuccess() => status == "success";
        public bool IsFail() => status == "fail";
        public bool IsError() => status == "error";
    }

    [JsonConverter(typeof(JSendConverter))]
    public abstract class JSend<TData> : JSend
    {
        /// <summary>
        /// Required Key:
        ///     Provides the wrapper for the details of why the request failed.
        ///     If the reasons for failure correspond to POST values,
        ///     the response object's keys SHOULD correspond to those POST values.
        /// </summary>
        public new TData data
        {
            get => base.data is null ? default : (TData)base.data;
            set => base.data = value;
        }
    }

}
