namespace Ajax
{
    /// <summary>
    /// All went well, and (usually) some data was returned.
    /// </summary>
    public class JSuccess : JSend<object>
    {
        public override string status => "success";
    }

    /// <summary>
    /// All went well, and (usually) some data was returned.
    /// </summary>
    public class JSuccess<TData> : JSend<TData>
    {
        public override string status => "success";
    }

}
