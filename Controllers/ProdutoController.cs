using Microsoft.AspNetCore.Mvc;
using API.Models;
namespace API;

[ApiController]
[Route("api/produto")]
public class ProdutoController : ControllerBase
{
    private static List<Produto> produtos = new List<Produto>();
    //GET: api/produto/listar
    [HttpGet]
    [Route("listar")]

    public IActionResult Listar() =>
        produtos.Count == 0 ? NotFound() : Ok(produtos);

    //GET: api/produto/buscar/{bolacha}
    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        foreach (Produto produtoCadastrado in produtos)
        {
            if (produtoCadastrado.Nome == nome)
            {
                return Ok(produtoCadastrado);
            }
        }
        return NotFound();
    }

    //POST: api/produto/cadastrar
    [HttpPost]
    [Route("cadastrar")]

    public IActionResult Cadastrar([FromBody] Produto produto)
    {
        produtos.Add(produto);
        return Created("", produto);
    }

}
