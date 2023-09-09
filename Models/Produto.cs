namespace API.Models;
public class Produto
{
    //Um construtor que toda vez que um produto é criado um datetime
    public Produto() => CriadoEm = DateTime.Now;

    public int ProdutoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public string? Funcionario { get; set; }
    public DateTime CriadoEm { get; set; }
}
