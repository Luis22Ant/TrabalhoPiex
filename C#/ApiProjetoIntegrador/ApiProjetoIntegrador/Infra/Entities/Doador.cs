namespace ApiProjetoIntegrador.Infra.Entities
{
    public class Doador 
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
