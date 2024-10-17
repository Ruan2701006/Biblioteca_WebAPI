namespace Biblioteca_WebApi_ruan.Model
{
    public class ReservaDto
    {
        public DateOnly DataReserva { get; set; }
        public string FkMembros { get; set; }
        public string FkLivros { get; set; }
    }
}
