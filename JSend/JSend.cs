using System;
using System.Collections.Generic;

namespace Ajax
{
    // Refer: http://labs.omniti.com/labs/jsend
    // Diff : Add ExData for type checking
    public class JSend
    {
        internal JSendModel _model;
        public JSend() => _model = new();
        internal JSend(JSendModel model) => _model = model;

        public const string Status_Success = "success";
        public const string Status_Fail = "fail";
        public const string Status_Error = "error";

        public bool IsSuccess() => status == Status_Success;
        public bool IsFail() => status == Status_Fail;
        public bool IsError() => status == Status_Error;

        public string status
        {
            get => _model.Status;
            set => _model.Status = value;
        }

        public object data
        {
            get
            {
                if (status == Status_Success) return _model.Data;
                else return default;
            }
            set => _model.Data = value;
        }

        public object exData
        {
            get
            {
                if (status == Status_Fail || status == Status_Error)
                    return _model.ExData;
                else return default;
            }
            set => _model.ExData = value;
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

        public static JSend Success() => new() { status = Status_Success };
        public static JSend<TData> Success<TData>(TData data) => new() { status = Status_Success, data = data };
        public static JSend Fail() => new() { status = Status_Fail };
        public static JSend Fail(object exData) => new() { status = Status_Fail, exData = exData };
        public static JSend Error(string message) => new() { status = Status_Error, message = message };
        public static JSend Error(string message, string code) => new() { status = Status_Error, message = message, code = code };
        public static JSend Error(string message, string code, object exData) => new() { status = Status_Error, message = message, code = code, exData = exData };
    }

    public class JSend<TData>
    {
        internal JSendModel _model;
        public JSend() => _model = new();
        internal JSend(JSendModel model) => _model = model;

        public bool IsSuccess() => status == JSend.Status_Success;
        public bool IsFail() => status == JSend.Status_Fail;
        public bool IsError() => status == JSend.Status_Error;

        public string status
        {
            get => _model.Status;
            set => _model.Status = value;
        }

        public TData data
        {
            get
            {
                if (status == JSend.Status_Success)
                    return (TData)_model.Data;
                else return default;
            }
            set => _model.Data = value;
        }

        public object exData
        {
            get
            {
                if (status == JSend.Status_Fail || status == JSend.Status_Error)
                    return _model.ExData;
                else return default;
            }
            set => _model.ExData = value;
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
