# Marketplace

# Sobre o projeto
<p>
O projeto marketplace se trata de uma implementação simplificada de um ecommerce, com gestão de usuários, anúncio de produtos para venda e também compra de produtos
</p>

# Sobre a arquitetura e padrões
<p>Nesse projeto foi utilizado conceitos de clean architecture e DDD visando a separação do dominío do negócio e da aplicação. E o padrão arquitetural fortemente usado foi o CQRS.</p>

# Tecnologias Utilizadas
<ul>
  <li>.NET 6</li>
  <li>Asp Net Core</li>
  <li>Postgres</li>
  <li>NetDevPack</li>
  <li>Mediatr</li>
  <li>AutoMapper</li>
  <li>EF Core</li>
</ul>

# Requisitos para rodar o projeto localmente
<ul>
  <li>Ter uma instância do postgres a disposição, seja por container ou instalada na máquina</li>
  <li>Ter a SDK do .NET 6 instalada</li>
</ul>

# Como rodar o projeto
<p>Acessar o appsettings.json e modificar a connection string para a sua.</p>
<p>No terminal, executar: cd MarketPlace.Api/</p>
<p>No terminal, executar: dotnet restore</p>
<p>No terminal, executar: cd ..</p>
<p>No terminal, executar: cd MarketPlace.Infra/</p>
<p>No terminal, executar: dotnet ef database update --startup-project ../MarketPlace.Api/</p>
<p>No terminal, executar: cd ..</p>
<p>No terminal, executar: cd MarketPlace.Api/</p>
<p>No terminal, executar: dotnet run</p>
