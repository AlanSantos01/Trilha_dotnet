﻿using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;
using OrdemDeServico.Domain.Exceptions;
using OrdemDeServico.Infra.Auth;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Application.Services;

public class ClienteService : IClienteService
{
    private readonly OrdemDeServicoContext _context;
    private readonly IAuthService _authService;
    private readonly IEnderecoService _enderecoService;
    public ClienteService(OrdemDeServicoContext context, IEnderecoService enderecoService, IAuthService authService)
    {
        _context = context;
        _authService = authService;
        _enderecoService = enderecoService;
    }
    public int Create(NewClienteInputModel cliente)
    {
        if (_context.Usuarios.Any(u => u.NomeUsuario == cliente.Usuario.NomeUsuario))
        {
            throw new UsuarioAlreadyExistsException();
        }

        var _hashedPassword = _authService.ComputeSha256Hash(cliente.Usuario.Senha);

        var _cliente = new Cliente
        {
            Usuario = new Usuario
            {
                NomeUsuario = cliente.Usuario.NomeUsuario,
                Senha = _hashedPassword,
                Role = cliente.Usuario.Role
            },
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            Endereco = new Endereco
            {
                Logradouro = cliente.Endereco.Logradouro,
                Bairro = cliente.Endereco.Bairro,
                Numero = cliente.Endereco.Numero,
                Complemento = cliente.Endereco.Complemento,
                Cidade = cliente.Endereco.Cidade,
                Estado = cliente.Endereco.Estado,
                Pais = cliente.Endereco.Pais,
                Cep = cliente.Endereco.Cep,
            },
            CreatedAt = DateTime.UtcNow,
        };
        _context.Clientes.Add(_cliente);
        _context.SaveChanges();

        return _cliente.ClienteId;
    }

    public ICollection<ClienteViewModel> GetAll()
    {
        var _clientes = _context.Clientes.Select(cliente => new ClienteViewModel
        {
            Usuario = new UsuarioViewModel
            {
                UsuarioId = cliente.UsuarioId,
                NomeUsuario = cliente.Usuario.NomeUsuario,
                Role = cliente.Usuario.Role
            },
            ClienteId = cliente.ClienteId,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            Endereco = new EnderecoViewModel
            {
                EnderecoId = cliente.Endereco.EnderecoId,
                Logradouro = cliente.Endereco.Logradouro,
                Bairro = cliente.Endereco.Bairro,
                Numero = cliente.Endereco.Numero,
                Complemento = cliente.Endereco.Complemento,
                Cidade = cliente.Endereco.Cidade,
                Estado = cliente.Endereco.Estado,
                Pais = cliente.Endereco.Pais,
                Cep = cliente.Endereco.Cep,
            }
        }).ToArray();

        return _clientes;
    }

    public ClienteViewModel? GetById(int id)
    {
        var _cliente = _context.Clientes.Find(id);

        if (_cliente is null)
        {
            return null;
        }

        var _endereco = _enderecoService.GetById(_cliente.EnderecoId);

        if (_endereco is null)
        {
            return null;
        }

        var _clienteViewModel = new ClienteViewModel
        {
            Usuario = new UsuarioViewModel
            {
                UsuarioId = _cliente.UsuarioId,
                NomeUsuario = _cliente.Usuario.NomeUsuario,
                Role = _cliente.Usuario.Role
            },
            ClienteId = _cliente.ClienteId,
            Nome = _cliente.Nome,
            Email = _cliente.Email,
            Telefone = _cliente.Telefone,
            Endereco = _endereco
        };

        return _clienteViewModel;
    }

    public void Update(int id, NewClienteInputModel cliente)
    {
        var _clienteDb = _context.Clientes.Find(id);

        if (_clienteDb is not null)
        {
            if (_context.Usuarios.Any(u => u.NomeUsuario == cliente.Usuario.NomeUsuario))
            {
                throw new UsuarioAlreadyExistsException();
            }

            var _usuario = _context.Usuarios.Find(_clienteDb.UsuarioId)!;

            var _hashedPassword = _authService.ComputeSha256Hash(cliente.Usuario.Senha);

            _usuario.NomeUsuario = cliente.Usuario.NomeUsuario;
            _usuario.Role = cliente.Usuario.Role;
            _usuario.Senha = _hashedPassword;
            _context.Update(_usuario);

            _clienteDb.Nome = cliente.Nome;
            _clienteDb.Email = cliente.Email;
            _clienteDb.Telefone = cliente.Telefone;
            _enderecoService.Update(_clienteDb.EnderecoId, cliente.Endereco);
            _clienteDb.UpdatedAt = DateTime.UtcNow;

            _context.Update(_clienteDb);
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var _clienteDb = _context.Clientes.Find(id);

        if (_clienteDb is not null)
        {
            _context.Clientes.Remove(_clienteDb);
            _context.SaveChanges();
        }
    }

    public List<ClienteViewModel> GetByTelefone(string telefone)
    {
        var clientes = _context.Clientes
            .Where(cliente => cliente.Telefone == telefone)
            .Select(cliente => new ClienteViewModel
            {
                Usuario = new UsuarioViewModel
                {
                    UsuarioId = cliente.UsuarioId,
                    NomeUsuario = cliente.Usuario.NomeUsuario,
                    Role = cliente.Usuario.Role
                },
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Endereco = new EnderecoViewModel
                {
                    EnderecoId = cliente.Endereco.EnderecoId,
                    Logradouro = cliente.Endereco.Logradouro,
                    Numero = cliente.Endereco.Numero,
                    Bairro = cliente.Endereco.Bairro,
                    Complemento = cliente.Endereco.Complemento,
                    Estado = cliente.Endereco.Estado,
                    Cidade = cliente.Endereco.Cidade,
                    Cep = cliente.Endereco.Cep,
                    Pais = cliente.Endereco.Pais
                }
            }).ToList();

        return clientes;
    }
}
