<div align="center">
	<h1 align="center">
        <img height="71" width="476" alt=".NET Core" src="http://telessaude.saude.ba.gov.br/wp-content/uploads/2023/01/marca-site.png"/>
	</h1>
</div>

## Sistema de Avaliação da Telessaúde Bahia
Este projeto visa desenvolver uma Aplicação Web dedicada à avaliação do Telessaúde, proporcionando um mecanismo aprimorado para aprimorar o sistema existente. O propósito fundamental é fornecer uma plataforma intuitiva e eficiente, permitindo que os usuários realizem avaliações de forma fácil e precisa.

## Requisitos
Certifique-se de ter as seguintes ferramentas e componentes instalados em seu sistema:

- .NET Core (versão 7.0 ou superior, compatível com o projeto) (https://dotnet.microsoft.com/pt-br/download)
- Oracle Database (https://hub.docker.com/r/truevoly/oracle-12c/tags)
- EntityFramework (https://learn.microsoft.com/pt-br/ef/)

## Configuração do Banco de Dados
- Instale e configure o Oracle Database (local) em seu sistema, se ainda não estiver instalado (recomenda-se instalar via Docker).
- Crie um novo banco de dados vazio com o nome "Telessaude" para o projeto.
- Execute o script SQL fornecido na raiz do projeto (scripts.sql) no banco de dados "Telessaude" para criar as tabelas necessárias e realizar outras configurações específicas do banco de dados.

Obs: Certifique-se de atualizar as informações de conexão do banco de dados no arquivo de configuração do projeto, conforme necessário.

## Executando o Projeto
Siga as etapas abaixo para configurar e executar o projeto:

- Abra o projeto no Visual Studio ou na sua IDE de preferência.
- Certifique-se de que as dependências do projeto estejam instaladas corretamente. Caso contrário, use o NuGet Package Manager para restaurar as dependências necessárias.
- Verifique se as configurações do banco de dados estão corretas no arquivo de configuração do projeto.
- Compile o projeto para garantir que não haja erros de compilação.
- Execute o projeto pressionando F5 ou usando a opção "Executar" na sua IDE.
- O projeto será executado em um servidor local e poderá ser acessado por meio do navegador no endereço https://localhost:44360.
