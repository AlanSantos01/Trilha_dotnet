namespace OrdemDeServico.Application.InputModels;
public class NewClienteInputModel
{
    public required string NomeUsuario { get; set; }
    public required string Senha { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get; set; }
    public required NewEnderecoInputModel Endereco { get; set; }
}
