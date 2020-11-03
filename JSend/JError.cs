
namespace Ajax
{
    /// <summary>
    /// There was a problem with the data submitted, or some pre-condition of the API call wasn't satisfied.
    /// </summary>
    public class JError : IJSend
    {
        public string Status => JSend.ERROR_STATUS;
        object IJSend.Data { get; set; }

        /// <summary>
        /// Optional Key:
        ///     A generic container for any other information about the error,
        ///         i.e.the conditions that caused the error, stack traces, etc.
        /// </summary>
        public object Data
        {
            get => (this as IJSend).Data;
            set => (this as IJSend).Data = value;
        }

        /// <summary>
        /// Optional Key:
        ///     A numeric code corresponding to the error, if applicable.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Required Key:
        ///     A meaningful, end-user-readable (or at the least log-worthy) message, explaining what went wrong.
        /// </summary>
        public string Message { get; set; }
    }

    public class JError<TData> : JError
    {
        /// <summary>
        /// Optional Key:
        ///     A generic container for any other information about the error,
        ///         i.e.the conditions that caused the error, stack traces, etc.
        /// </summary>
        public new TData Data
        {
            get => base.Data is null ? default : (TData)base.Data;
            set => base.Data = value;
        }
    }
}
