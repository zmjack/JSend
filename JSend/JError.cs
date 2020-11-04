using System.Text.Json.Serialization;

namespace Ajax
{
    /// <summary>
    /// There was a problem with the data submitted, or some pre-condition of the API call wasn't satisfied.
    /// </summary>
    public class JError : JSend
    {
        public override string Status => ERROR_STATUS;

        /// <summary>
        /// Optional Key:
        ///     A numeric code corresponding to the error, if applicable.
        /// </summary>
        public string Code
        {
            get => (this as IJSend).Code;
            set => (this as IJSend).Code = value;
        }

        /// <summary>
        /// Required Key:
        ///     A meaningful, end-user-readable (or at the least log-worthy) message, explaining what went wrong.
        /// </summary>
        public string Message
        {
            get => (this as IJSend).Message;
            set => (this as IJSend).Message = value;
        }
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
