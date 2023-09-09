using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("api/produto")]
public class ProdutoController : ControllerBase
{
    private readonly AppDataContext _ctx;

    public ProdutoController(AppDataContext ctx) => _ctx = ctx;

    //GET: api/produto/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        List<Produto> produtos = _ctx.Produtos.ToList();
        return produtos.Count == 0 ? NotFound() : Ok(produtos);
    }

    //POST: api/produto/cadastrar
    [HttpPost]
    [Route("cadastrar")]

    public IActionResult Cadastrar([FromBody] Produto produto)
    {
        _ctx.Produtos.Add(produto);
        _ctx.SaveChanges();
        return Created("", produto);
    }

    //GET: api/produto/buscar/{bolacha}
    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        foreach (Produto produtoCadastrado in _ctx.Produtos.ToList())
        {
            if (produtoCadastrado.Nome == nome)
            {
                return Ok(produtoCadastrado);
            }
        }
        return NotFound();
    }

}
