
namespace Ajax
{
#pragma warning disable IDE1006

    public partial class JSend
    {
        public static class Success
        {
            public static Success<object> Create() => new Success<object>();
            public static Success<TData> Create<TData>(TData data) => new Success<TData>(data);
        }

        /// <summary>
        /// All went well, and (usually) some data was returned.
        /// </summary>
        public class Success<TData> : IJSend<TData>
        {
            public Success() { }
            public Success(TData data)
            {
                this.data = data;
            }

            public string status => JSendConst.SUCCESS_STATUS;
            string IJSend<TData>.code { get; set; }
            string IJSend<TData>.message { get; set; }

            /// <summary>
            /// Required Key:
            ///     Acts as the wrapper for any data returned by the API call.
            ///     If the call returns no data, data should be set to null.
            /// </summary>
            public TData data { get; set; }

            public static implicit operator JSend<TData>(Success<TData> @this) => JSend<TData>.Parse(@this);
            public static implicit operator JSend(Success<TData> @this) => Parse(@this);
        }

    }
#pragma warning restore
}
