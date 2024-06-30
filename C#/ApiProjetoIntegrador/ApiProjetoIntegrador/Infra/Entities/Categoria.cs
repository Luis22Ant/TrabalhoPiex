namespace ApiProjetoIntegrador.Infra.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
