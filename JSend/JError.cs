namespace Ajax
{
    /// <summary>
    /// There was a problem with the data submitted, or some pre-condition of the API call wasn't satisfied.
    /// </summary>
    public class JError : JSend<object>
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

    public class JError<TData> : JSend<TData>
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
}
