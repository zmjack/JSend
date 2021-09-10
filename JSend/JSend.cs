using System;
using System.Collections.Generic;

namespace Ajax
{
    //// Refer: http://labs.omniti.com/labs/jsend
    public class JSend
    {
        internal JSendModel _model;
        public JSend() => _model = new();
        internal JSend(JSendModel model) => _model = model;

        public string status
        {
            get => _model.Status;
            set => _model.Status = value;
        }

        public object data
        {
            get => _model.Data;
            set => _model.Data = value;
        }

        public object exData
        {
            get => _model.Data;
            set => _model.Data = value;
        }

        public string message
        {
            get => _model.Message;
            set => _model.Message = value;
        }

        public string code
        {
            get => _model.Code;
            set => _model.Code = value;
        }

        public const string Status_Success = "success";
        public const string Status_Fail = "fail";
        public const string Status_Error = "error";

        public static JSend Success() => new() { status = Status_Success };
        public static JSend<TData> Success<TData>(TData data) => new() { status = Status_Success, data = data };
        public static JSend Fail() => new() { status = Status_Fail };
        public static JSend Fail(object exData) => new() { status = Status_Fail, exData = exData };
        public static JSend Error(string message) => new() { status = Status_Error, message = message };
        public static JSend Error(string message, string code) => new() { status = Status_Error, message = message, code = code };
        public static JSend Error(string message, string code, object exData) => new() { status = Status_Error, message = message, code = code, exData = exData };

        public bool IsSuccess() => status == "success";
        public bool IsFail() => status == "fail";
        public bool IsError() => status == "error";
    }

    public class JSend<TData>
    {
        internal JSendModel _model;
        public JSend() => _model = new();
        internal JSend(JSendModel model) => _model = model;

        public string status
        {
            get => _model.Status;
            set => _model.Status = value;
        }

        public TData data
        {
            get => (TData)_model.Data;
            set => _model.Data = value;
        }

        public object exData
        {
            get
            {
                if (status == JSend.Status_Fail || status == JSend.Status_Error)
                    return _model.Data as IDictionary<string, string>;
                else return default;
            }
            set => _model.Data = value;
        }

        public string message
        {
            get => _model.Message;
            set => _model.Message = value;
        }

        public string code
        {
            get => _model.Code;
            set => _model.Code = value;
        }

        public static implicit operator JSend<TData>(JSend @this) => new(@this._model);
        public static implicit operator JSend(JSend<TData> @this) => new(@this._model);
    }

}
