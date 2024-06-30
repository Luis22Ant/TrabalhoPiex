namespace ApiProjetoIntegrador.Infra.Entities
{
    public class Donatario 
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public ICollection<ItemDoado> Items { get; set; } = new List<ItemDoado>();
    }
}
