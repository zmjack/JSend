
namespace Ajax
{
#pragma warning disable IDE1006

    public partial class JSend
    {
        public static class Fail
        {
            public static Fail<object> Create() => new Fail<object>();
            public static Fail<TData> Create<TData>(TData data) => new Fail<TData>(data);
        }

        /// <summary>
        /// There was a problem with the data submitted, or some pre-condition of the API call wasn't satisfied.
        /// </summary>
        public class Fail<TData> : IJSend<TData>
        {
            public Fail() { }
            public Fail(TData data)
            {
                this.data = data;
            }

            public string status => JSendConst.FAIL_STATUS;
            string IJSend<TData>.code { get; set; }
            string IJSend<TData>.message { get; set; }

            /// <summary>
            /// Required Key:
            ///     Provides the wrapper for the details of why the request failed.
            ///     If the reasons for failure correspond to POST values,
            ///     the response object's keys SHOULD correspond to those POST values.
            /// </summary>
            public TData data { get; set; }

            public override string ToString()
            {
                return $"{{ {nameof(status)}: {status}, {nameof(data)}: {data} }}";
            }

            public static implicit operator JSend<TData>(Fail<TData> @this) => JSend<TData>.Parse(@this);
            public static implicit operator JSend(Fail<TData> @this) => Parse(@this);
        }

    }
#pragma warning restore
}
