namespace OficinaELLP.Domain.Entities
{
    public class Workshop
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public static Aluno CreateInstance()
        {
            return new Aluno();
        }
    }
}