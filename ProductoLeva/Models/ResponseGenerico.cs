namespace ProductoLeva.Models
{
    public class ResponseGenerico<T>
    {
        public int codigo { get; set; }
        public string message { get; set; }
        public T response { get; set; }
    }
}
