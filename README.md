# invest-service

### Visão geral

invest-service é uma API desenvolvida em ASP.NET Core Web.API 5.0 que recupera
informações de investimentos de clientes.

 - Estruturado em camadas.
 - Aplica conceitos de DDD (Domain Driven Design) para modelar entidades.
 - Utiliza Redis para armazenar as informações de investimentos por cliente e dia de consulta.
 - Utiliza Polly para resiliência.

### Organização

A estrutura do projeto é dividida nas seguintes camadas:

 - Application: camada responsável pelos casos de uso.
 - Domain: camada responsável pelo domínio da aplicação. Neste projeto
 em particular, não é necessário a manipulação de registros em base de dados, apenas
 a busca de informações em serviços externos. Uma alternativa para a abordagem implementada seria utilizar
 o padrão CQRS. Contudo, devido à algumas regras relacionadas aos cálculos de investimentos, optou-se pela modelagem da entidade Investimento.
 - Infra: contêm toda a infraestrutura necessária para auxiliar os casos de uso. Busca de informações externas, cache e injeção de dependência.
 - Services: camada onde reside o serviço que expõe as funcionalidades do projeto.

### Padrões e boas práticas

O projeto foi desenvolvido sempre levando em consideração os princípios: SOLID, KISS, DRY etc.  
As regras para cálculos de IR sobre os investimentos foram isoladas em políticas.  
Os testes unitários cobrem as camadas de Aplicação e Domínio.  

### Execução

Para executar o projeto, é necessário o docker-compose instalado na máquina.  
Neste [repositório](https://www.google.com), é possível baixar os arquivos do docker-compose para executar o projeto.  
Baixe os projetos invest-stack e invest-service no mesmo diretório. Entre no projeto invest-stack, na pasta docker-compose e execute o comando:

```sh
docker-compose up
```

O projeto será executado na porta 5000. Para realizar uma requisição, é necessário informar
o código do cliente.

    localhost:5000/api/investment?customerId=1