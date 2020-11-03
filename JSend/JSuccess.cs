namespace Ajax
{
    public class JSuccess : IJSend
    {
        public string Status => JSend.SUCCESS_STATUS;
        string IJSend.Code { get; set; }
        string IJSend.Message { get; set; }
        object IJSend.Data { get; set; }

        /// <summary>
        /// Required Key:
        ///     Acts as the wrapper for any data returned by the API call.
        ///     If the call returns no data, data should be set to null.
        /// </summary>
        public object Data
        {
            get => (this as IJSend).Data;
            set => (this as IJSend).Data = value;
        }
    }

    /// <summary>
    /// All went well, and (usually) some data was returned.
    /// </summary>
    public class JSuccess<TData> : JSuccess
    {
        /// <summary>
        /// Required Key:
        ///     Acts as the wrapper for any data returned by the API call.
        ///     If the call returns no data, data should be set to null.
        /// </summary>
        public new TData Data
        {
            get => base.Data is null ? default : (TData)base.Data;
            set => base.Data = value;
        }
    }
}
