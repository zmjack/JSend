namespace Ajax
{
    public class DeserializedJSend : JSend
    {
        public new string Status
        {
            get => base.Status;
            set => base.Status = value;
        }

        public object Data
        {
            get => (this as IJSend).Data;
            set => (this as IJSend).Data = value;
        }

        public string Code
        {
            get => (this as IJSend).Code;
            set => (this as IJSend).Code = value;
        }

        public string Message
        {
            get => (this as IJSend).Message;
            set => (this as IJSend).Message = value;
        }
    }
}
