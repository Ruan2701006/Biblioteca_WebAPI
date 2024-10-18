namespace Biblioteca_WebApi_ruan.Model
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateOnly DataReserva { get; set; }
        public int FkMembros { get; set; }
        public int FkLivros { get; set; }
        
    }
}
