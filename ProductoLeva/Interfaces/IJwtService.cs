namespace ProductoLeva.Interfaz
{
    public interface IJwtService
    {
        string GenerateToken(string username, string Role);
    }
}
