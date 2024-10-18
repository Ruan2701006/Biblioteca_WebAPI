namespace Biblioteca_WebApi_ruan.Model
{
    public class ReservaDto
    {
        public DateOnly DataReserva { get; set; }
        public int FkMembros { get; set; }
        public int FkLivros { get; set; }
    }
}
