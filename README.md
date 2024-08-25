# OrcamentoAuto

OrcamentoAuto é uma API desenvolvida em C# .NET 8 com MongoDB para gerenciar as operações de uma oficina. O sistema está em desenvolvimento e oferece funcionalidades para cadastro de clientes, produtos, fornecedores, orçamentos e cotações.

## Funcionalidades

- **Cadastro de Clientes:** Permite adicionar, editar e visualizar informações dos clientes.
- **Cadastro de Produtos:** Gerenciamento do inventário de produtos.
- **Cadastro de Fornecedores:** Registro e gerenciamento dos fornecedores.
- **Orçamentos:** Criação e gestão de orçamentos para os clientes.
- **Cotações:** Geração de cotações com fornecedores.

## Tecnologias Utilizadas

- **C# .NET 8:** Framework para o desenvolvimento da API.
- **MongoDB:** Banco de dados NoSQL utilizado para armazenar os dados do sistema.
- **Swagger:** Para documentação e teste das rotas da API.

## Estrutura do Projeto

O projeto está organizado nas seguintes camadas:

- **api:** Contém os controladores que lidam com as requisições HTTP.
- **core:** Implementa as entidades e interfaces que representam o domínio do sistema.
- **exception:** Gerencia exceções personalizadas do projeto.
- **communication:** Lida com a comunicação entre as diferentes partes do sistema, como DTOs (Data Transfer Objects).
- **application:** Contém a lógica de aplicação, incluindo serviços e manipulação dos dados.

## Configuração do `appsettings.json`

A configuração atual do `appsettings.json` inclui:

```json
{
  "ConnectionURI: "mongodb://localhost:27017/OrcamentoAutoDB",
  "DatabaseName": "OrcamentoAuto",
  "CollectionsNames": {
    "Cliente": "Cliente",
    "Orcamento": "Orcamento",
    "Veiculo": "Veiculo",
    "Fornecedor": "Fornecedor",
    "Cotacao": "Cotacao",
    "Produto":  "Produto"
  }
}
```

## Como Executar

### Pré-requisitos

- .NET 8 SDK
- MongoDB

### Passos

1. Clone este repositório:
   ```bash
   git clone https://github.com/usuario/orcamentoauto.git
   ```
2. Navegue até a pasta do projeto:
   ```bash
   cd orcamentoauto
   ```
3. Restaure as dependências do projeto:
   ```bash
   dotnet restore
   ```
4. Configure as variáveis de ambiente no arquivo `appsettings.json` conforme mostrado acima.
5. Execute o projeto:
   ```bash
   dotnet run
   ```

## Documentação da API

A documentação da API pode ser acessada através do Swagger em `http://localhost:5289/swagger` após iniciar o projeto.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para enviar pull requests ou abrir issues para melhorias ou correções.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
