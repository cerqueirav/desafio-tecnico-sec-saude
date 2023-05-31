<div align="center">
	<h1 align="center">
        <img height="120" width="120" alt=".NET Core" src="https://i.ibb.co/svgW8bp/net-removebg-preview.png"/>
    	  <img height="120" width="120" alt=".NET Core" src="https://www.daimto.com/wp-content/uploads/2017/10/NhibernateLogo400x400.png"/>
	</h1>
</div>

## Desafio Técnico - CRUD completo com WebForms + NHibernate 
Este projeto tem como objetivo realizar a criação de uma Aplicação Web com WebForms e integrá-la ao Banco de Dados utilizando o NHibernate como mecanismo de persistência de dados (ORM).

## Requisitos

- SDK .NET 7.0 or later
- NHibernate
- Docker

## Instalação da Aplicação Web (Aplicação WebForms)

```bash
# Clonar o repositório
git clone https://github.com/cerqueirav/desafio-tecnico-sec-saude/

# Navegue até a raiz do projeto
cd desafio-tecnico-sec-saude

# Instale as dependências (usando NuGet ou CMD)
- Newtonsoft Json 13.0.3 ou superior
- Microsoft Visual Studio Azure Containers Tools Targets 1.17.0 ou superior

# Execute a aplicação Web
dotnet run or run through visual studio
```

## Instalação da Aplicação WebAPI (NHibernate)

```bash
# Clonar o repositório
git clone https://github.com/cerqueirav/desafio-tecnico-sec-saude/

# Navegue até a raiz do projeto
cd desafio-tecnico-sec-saude

# Instale as dependências (usando NuGet ou CMD)
- Microsoft Visual Studio Azure Containers Tools Targets 1.17.0 ou superior
- NHibernate 5.4.2 ou superior
- Swashbuckle AspNetCore 6.4.0 ou superior

# Execute a aplicação WebAPI
dotnet run or run through visual studio

## Documentação

Enumeradores

Perfil de Acesso:
1 - Administrador
2 - Supervisor
3 - Operador

Tipo de Contato:
1 - Telefone Fixo
2 - Telefone Celular

```bash
POST https://localhost:44391/usuario/cadastrar
```

O corpo da requisição (body) deve ser um objeto JSON com os seguintes campos:

- Nome (obrigatório): O nome completo do Usuário
- Email (obrigatório): O email do Usuário
- Senha (obrigatório): A senha do Usuário
- CPF (obrigatório): O Cadastro de Pessoa Física (CPF) do Usuário
- DataNascimento (obrigatório): A data de nascimento do Usuário
- Telefones (obrigatório): A lista de contatos do usuário
- Perfil (obrigatório): O perfil de acesso do Usuário
- Endereço (obrigatório): O endereço completo do usuário, contendo os dados a seguir:
  - Logradouro, 
  - Complemento, 
  - Número, 
  - Cidade,
  - Estado, 
  - País
  - CEP 
 
Exemplo:

```json
{
    "Nome": "Fulano Beltrano",
    "Email": "fulano.beltrano@email.com",
    "Senha": "#1x1mp10$!",
    "CPF": "123.456.789-00",
    "DataNascimento": "10/01/1990",
    "Telefones":[ 
      {
         "TipoContato": 1,
         "Contato": "7132249874"
      },
      {
         "TipoContato": 2,
         "Contato": "71991079555"
      }
    ],
    "Perfil": "1",
    "Endereco": {
      "Logradouro" : "Rua da Alegria", 
      "Complemento": "Apartamento 905", 
      "Número": "88", 
      "Cidade": "Salvador",
      "Estado": "Bahia", 
      "País": "Brasil",
      "CEP": "40387987" 
    }
}
```

Definir mensagem de retorno
