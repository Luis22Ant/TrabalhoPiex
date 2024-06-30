namespace ApiProjetoIntegrador.Infra.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public DateTime DataDoacao { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }  
        public Guid DoadorId { get; set; }  

        public Doador Doador { get; set; }  

        public void DiminuirItem(int quantidade)
        {
            Quantidade -= quantidade;
        }
    }
}

