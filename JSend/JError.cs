namespace Ajax
{
    /// <summary>
    /// There was a problem with the data submitted, or some pre-condition of the API call wasn't satisfied.
    /// </summary>
    public class JError : JSend
    {
        public override string status => "error";

        /// <summary>
        /// Optional Key:
        ///     A numeric code corresponding to the error, if applicable.
        /// </summary>
        public string code
        {
            get => (this as IJSend).code;
            set => (this as IJSend).code = value;
        }

        /// <summary>
        /// Required Key:
        ///     A meaningful, end-user-readable (or at the least log-worthy) message, explaining what went wrong.
        /// </summary>
        public string message
        {
            get => (this as IJSend).message;
            set => (this as IJSend).message = value;
        }
    }

    public class JError<TData> : JError
    {
        /// <summary>
        /// Optional Key:
        ///     A generic container for any other information about the error,
        ///         i.e.the conditions that caused the error, stack traces, etc.
        /// </summary>
        public new TData data
        {
            get => base.data is null ? default : (TData)base.data;
            set => base.data = value;
        }
    }
}
