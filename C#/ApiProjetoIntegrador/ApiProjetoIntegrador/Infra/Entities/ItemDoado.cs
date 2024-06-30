namespace ApiProjetoIntegrador.Infra.Entities
{
    public class ItemDoado
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid DonatarioId { get; set; }

        public Donatario? Donatario { get; set; }
        public DateTime DataDoacao { get; set; }
        public int Quantidade { get; set; }


    }
}
