using System;

namespace frontend
{
    public class ClientInfo
    {
    public int id { get; set; }
    public string? nombres { get; set; }
    public string? apellidos { get; set; }
    public string? correoElectronico { get; set; }
    public string? tipoCliente { get; set; }
    public DateTime fechaCreacion { get; set; }
}
}