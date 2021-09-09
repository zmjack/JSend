namespace Ajax
{
    public interface IJSend
    {
        string status { get; }
        object data { get; set; }
        string code { get; set; }
        string message { get; set; }
    }

}
