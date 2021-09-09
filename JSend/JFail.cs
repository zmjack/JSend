namespace Ajax
{
    /// <summary>
    /// There was a problem with the data submitted, or some pre-condition of the API call wasn't satisfied.
    /// </summary>
    public class JFail : JSend<object>
    {
        public override string status => "fail";
    }

    /// <summary>
    /// There was a problem with the data submitted, or some pre-condition of the API call wasn't satisfied.
    /// </summary>
    public class JFail<TData> : JSend<TData>
    {
        public override string status => "fail";
    }
}
