using Xunit;
using Moq;
using Commerce.Application.Services;
using Commerce.Domain;
using Commerce.Application.DTOs;
using System.Threading.Tasks;
using AutoMapper;
using Commerce.Application;

namespace Commerce.Test;

public class ProdutoServiceTest
{
    private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly ProdutoService _produtoService;

    public ProdutoServiceTest()
    {
        _produtoRepositoryMock = new Mock<IProdutoRepository>();
        _mapperMock = new Mock<IMapper>();
        _produtoService = new ProdutoService(_produtoRepositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task CriaProdutoAsync_DeveRetornarProduto_QuandoProdutoDTOValido()
    {
        // Arrange
        var produtoDTO = new ProdutoDTO { Nome = "Produto Teste", Valor = 10, Estoque = 5 };
        var produto = new Produto("Produto Teste", 10, 5, true, 1);

        _mapperMock.Setup(m => m.Map<Produto>(produtoDTO)).Returns(produto);
        _produtoRepositoryMock.Setup(r => r.CriaProdutoAsync(produto)).ReturnsAsync(produto);

        // Act
        var result = await _produtoService.CriaProdutoAsync(produtoDTO);

        // Assert
        Assert.Equal(produto, result);
    }

    [Fact]
    public async Task CriaProdutoAsync_DeveRetornarExcecao_QuandoProdutoDTOInvalido()
    {
        // Arrange
        var produto = new Produto ("Produto Teste", -10, 5, true, 1);
        var produtoDTO = new ProdutoDTO { Nome = produto.Nome, Valor = produto.Valor, Estoque = produto.Estoque };

        _mapperMock.Setup(m => m.Map<Produto>(produtoDTO)).Returns(produto);
        _produtoRepositoryMock.Setup(r => r.CriaProdutoAsync(produto)).ReturnsAsync(produto);

        // Act
        var result = async () => await _produtoService.CriaProdutoAsync(produtoDTO);

        // Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(result);
        Assert.Equal("O valor do produto não pode ser negativo!", ex.Message);
    }

    [Fact]
    public async Task AtualizaProdutoAsync_DeveRetornarProdutoAtualizado_QuandoProdutoDTOValido()
    {
        var dataAgora = DateTime.UtcNow;
        // Arrange
        var produtoDTO = new ProdutoDTO { Nome = "Produto Atualizado", Valor = 20, Estoque = 10, DataAtualizacaoUtc = dataAgora, DataCadastroUtc = dataAgora, CategoriaId = 1, Status = true };
        var produto = new Produto ("Produto Original", 10, 5, true, 1);

        _produtoRepositoryMock.Setup(r => r.AtualizaProdutoAsync(It.IsAny<Produto>())).ReturnsAsync((Produto p) => p);

        // Act
        var result = await _produtoService.AtualizaProdutoAsync(produtoDTO);

        // Assert
        Assert.Equal(produtoDTO.Nome, result.Nome);
        Assert.Equal(produtoDTO.Valor, result.Valor);
        Assert.Equal(produtoDTO.Estoque, result.Estoque);
        Assert.Equal(produtoDTO.Status, result.Status);
        Assert.Equal(produtoDTO.CategoriaId, result.CategoriaId);
    }

    [Fact]
    public async Task AtualizaProdutoAsync_DeveRetornarExcecao_QuandoProdutoDTONulo()
    {
        var dataAgora = DateTime.UtcNow;
        // Arrange
        var produto = new Produto ("Produto Original", 10, 5, true, 1);
        var produtoDTO = new ProdutoDTO { Nome = produto.Nome, Valor = -produto.Valor, Estoque = produto.Estoque, DataAtualizacaoUtc = dataAgora, DataCadastroUtc = dataAgora, CategoriaId = 1, Status = true };

        // Act
        var result = async () => await _produtoService.AtualizaProdutoAsync(produtoDTO);

        // Assert
        var ex = await Assert.ThrowsAsync<ArgumentException>(result);
        Assert.Equal("O valor do produto não pode ser negativo!", ex.Message);
    }


}