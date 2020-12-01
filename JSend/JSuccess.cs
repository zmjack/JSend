namespace Ajax
{
    public class JSuccess : JSend
    {
        public override string status => "success";
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
        public new TData data
        {
            get => base.data is null ? default : (TData)base.data;
            set => base.data = value;
        }
    }

}
