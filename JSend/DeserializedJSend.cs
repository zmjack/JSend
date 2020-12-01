namespace Ajax
{
    public class DeserializedJSend : JSend
    {
        public new string status
        {
            get => base.status;
            set => base.status = value;
        }

        public new object data
        {
            get => (this as IJSend).data;
            set => (this as IJSend).data = value;
        }

        public string code
        {
            get => (this as IJSend).code;
            set => (this as IJSend).code = value;
        }

        public string message
        {
            get => (this as IJSend).message;
            set => (this as IJSend).message = value;
        }
    }
}
