
namespace Ajax
{
#pragma warning disable IDE1006

    // Refer: http://labs.omniti.com/labs/jsend
    public partial class JSend : IJSend<object>
    {
        public string status { get; set; }
        public object data { get; set; }

        public string code { get; set; }
        public string message { get; set; }

        public override string ToString()
        {
            return $"{{ {nameof(status)}: {status}, {nameof(data)}: {data}, {nameof(code)}: {code}, {nameof(message)}: {message} }}";
        }

        public static JSend Parse<TData>(IJSend<TData> jSend)
        {
            return new JSend
            {
                code = jSend.code,
                data = jSend.data,
                message = jSend.message,
                status = jSend.status,
            };
        }
    }

    public class JSend<TData> : IJSend<TData>
    {
        public string status { get; set; }
        public TData data { get; set; }

        public string code { get; set; }
        public string message { get; set; }

        public override string ToString()
        {
            return $"{{ {nameof(status)}: {status}, {nameof(data)}: {data}, {nameof(code)}: {code}, {nameof(message)}: {message} }}";
        }

        public static JSend<TData> Parse(IJSend<TData> jSend)
        {
            return new JSend<TData>
            {
                code = jSend.code,
                data = jSend.data,
                message = jSend.message,
                status = jSend.status,
            };
        }
    }
#pragma warning restore
}