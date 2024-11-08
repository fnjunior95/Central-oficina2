namespace SSE.Oficina.Domain.Entities
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public static Aluno CreateInstance()
        {
            return new Aluno();
        }
    }
}