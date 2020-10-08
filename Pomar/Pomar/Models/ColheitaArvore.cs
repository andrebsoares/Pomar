namespace Pomar.Models
{
    public class ColheitaArvore
    {
        public ColheitaArvore(int colheitaId, int arvoreId)
        {
            ColheitaId = colheitaId;            
            ArvoreId = arvoreId;
        }
        
        public int Codigo { get; private set; }
        public int ColheitaId { get; private set; }
        public virtual Colheita Colheita { get; private set; }
        public int ArvoreId { get; private set; }
        public virtual Arvore Arvore { get; private set; }
    }
}
