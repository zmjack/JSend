﻿
namespace Ajax
{
#pragma warning disable IDE1006

    public partial class JSend
    {
        public static class Error
        {
            public static Error<object> Create() => new Error<object>();
            public static Error<TData> Create<TData>(string message, string code, TData data) => new Error<TData>(message, code, data);

            public static Error<object> Create(string message) => new Error<object>(message);
            public static Error<object> Create(string message, string code) => new Error<object>(message, code);

            public static Error<TData> Create<TData>(string message) => new Error<TData>(message);
            public static Error<TData> Create<TData>(string message, string code) => new Error<TData>(message, code);
        }

        /// <summary>
        /// There was a problem with the data submitted, or some pre-condition of the API call wasn't satisfied.
        /// </summary>
        public class Error<TData> : IJSend<TData>
        {
            public Error() { }
            public Error(string message)
            {
                this.message = message;
            }
            public Error(string message, string code)
            {
                this.message = message;
                this.code = code;
            }
            public Error(string message, string code, TData data)
            {
                this.message = message;
                this.code = code;
                this.data = data;
            }

            public string status => JSendConst.ERROR_STATUS;

            /// <summary>
            /// Required Key:
            ///     A meaningful, end-user-readable (or at the least log-worthy) message, explaining what went wrong.
            /// </summary>
            public string message { get; set; }

            /// <summary>
            /// Optional Key:
            ///     A numeric code corresponding to the error, if applicable.
            /// </summary>
            public string code { get; set; }

            /// <summary>
            /// Optional Key:
            ///     A generic container for any other information about the error,
            ///         i.e.the conditions that caused the error, stack traces, etc.
            /// </summary>
            public TData data { get; set; }

            public override string ToString()
            {
                var _status = status.Replace("\"", "\\\"");
                var _data = data.ToString().Replace("\"", "\\\"");
                var _code = code.Replace("\"", "\\\"");
                var _message = message.ToString().Replace("\"", "\\\"");
                return $@"{{ ""{nameof(status)}"": ""{_status}"", ""{nameof(data)}"": ""{_data}"", ""{nameof(code)}"": ""{_code}"", ""{nameof(message)}"": ""{_message}"" }}";
            }

            public static implicit operator JSend<TData>(Error<TData> @this) => JSend<TData>.Parse(@this);
            public static implicit operator JSend(Error<TData> @this) => JSend.Parse(@this);
        }

    }
#pragma warning restore
}
