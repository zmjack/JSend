﻿namespace Ajax
{
    /// <summary>
    /// There was a problem with the data submitted, or some pre-condition of the API call wasn't satisfied.
    /// </summary>
    public class JFail : IJSend
    {
        public string Status => JSend.FAIL_STATUS;
        string IJSend.Code { get; set; }
        string IJSend.Message { get; set; }
        object IJSend.Data { get; set; }

        /// <summary>
        /// Required Key:
        ///     Provides the wrapper for the details of why the request failed.
        ///     If the reasons for failure correspond to POST values,
        ///     the response object's keys SHOULD correspond to those POST values.
        /// </summary>
        public object Data
        {
            get => (this as IJSend).Data;
            set => (this as IJSend).Data = value;
        }
    }

    /// <summary>
    /// There was a problem with the data submitted, or some pre-condition of the API call wasn't satisfied.
    /// </summary>
    public class JFail<TData> : JFail
    {
        /// <summary>
        /// Required Key:
        ///     Provides the wrapper for the details of why the request failed.
        ///     If the reasons for failure correspond to POST values,
        ///     the response object's keys SHOULD correspond to those POST values.
        /// </summary>
        public new TData Data
        {
            get => base.Data is null ? default : (TData)base.Data;
            set => base.Data = value;
        }
    }
}
