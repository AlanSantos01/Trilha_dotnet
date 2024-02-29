namespace ResTIConnect.Application.InputModels;

public class NewUsuarioInputModel
{
    public required string Nome { get; set; }
    public string? Apelido { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; }
    public required string Telefone { get; set; }
    public required NewEnderecoInputModel Endereco { get; set; }
    // public required ICollection<PerfilIntoUsuarioInputModel> Perfis { get; set; }
}
