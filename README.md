# Commerce

Este projeto é uma aplicação de comércio eletrônico simples, que permite gerenciar produtos em um banco de dados.

## Estrutura do Projeto

O projeto é dividido em várias partes, cada camada com um propósito específico:

- Commerce.Application: Esta é a camada de aplicação que contém a lógica de negócios e os serviços de aplicação.
- Commerce.API: Esta é a camada de apresentação responsável por expor os endpoints que os clientes usarão para interagir com a aplicação.
- Commerce.Test: Esta é a camada de testes que contém testes unitários para a lógica de negócios.
- Commerce.Domain: Esta é a camada que contém as entidades do domínio, que são as representações dos objetos de negócios.
- Commerce.Infrastructure: Esta é a camada responsável pela persistência dos dados, contendo o contexto do banco de dados e os repositórios.

## Arquitetura e Padrões

- **Clean Architecture**: A arquitetura limpa enfatiza a separação de preocupações, permitindo um teste mais fácil e a evolução do sistema. Ela promove a segregação de operações de leitura e escrita, melhorando desempenho e escalabilidade, enquanto o padrão Repository fornece uma camada de abstração flexível para acesso a dados, aprimorando a manutenibilidade e testabilidade.
- **Padrão Repository**: Este padrão separa a lógica de acesso a dados da lógica de negócios em uma aplicação, fornecendo uma interface consistente para operações de dados. Isso permite uma manutenção e testabilidade mais fácil do código, promovendo a reutilização de código ao encapsular detalhes de acesso a dados dentro de repositórios.
- **DB-First**: Para este projeto, foi utilizado o método DB-First, onde a tabela foi mapeada no método `OnModelCreating` na classe `CommerceDbContext`. Também no projeto encontra-se o script para criação da tabela.
  
## Funcionalidades

- Gerenciamento de produtos: A aplicação permite adicionar, atualizar e remover produtos.

## Como usar

Para usar a aplicação, você precisa ter um ambiente .NET 8 configurado. Depois de clonar o repositório, você pode iniciar a aplicação executando o projeto Commerce.API. A aplicação irá inicializar um banco de dados com alguns produtos de exemplo se o banco de dados estiver vazio.

## Mapeamento de Objetos

O projeto usa o AutoMapper para mapear entre os objetos de domínio e os objetos de transferência de dados (DTOs).

## Testes

O projeto inclui testes unitários para a lógica de negócios. Os testes estão localizados no projeto Commerce.Test.

## Contribuindo

Contribuições são bem-vindas. Por favor, abra uma issue ou faça um pull request se você quiser contribuir com o projeto.
