[Coldmart] - Plataforma de cursos online
1. Apresentação
Bem-vindo ao repositório do projeto [Coldmart]. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo `Pipeline CI/CD, Docker e Kubernetes`. O objetivo principal é evoluir o projeto da entrega do módulo anterior, transformando a solução de microserviços com um pipeline de CI/CD completos e fazendo deploy com kubernetes.

Autor(es)

✅ Cristian Kruger Silva - @mr.krug3r
✅ Gilberto Moshim Yabiku Junior - @junmoriyama3d
✅ Tiago Henrique de Castilhos - @zsfnightmare
✅ Victor Higaki - @victorhigaki

2. Proposta do Projeto

O projeto consiste em:

APIs RESTful: Exposição dos casos de uso do sistema de gestão de cursos

Autenticação e Autorização: Implementação de controle de acesso, diferenciando administradores e alunos.

Acesso a Dados: Implementação de acesso ao banco de dados através de ORM.

3. Tecnologias Utilizadas

Linguagem de Programação: C#

Frameworks:

ASP.NET Core Web API

Entity Framework Core

Banco de Dados: SQL Server

Autenticação e Autorização:

ASP.NET Core Identity

JWT (JSON Web Token) para autenticação na API

Documentação da API: Swagger

Containerização e virtualização: Docker

4. Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

src/

Coldmart.{ Nome do contexto }.Business/ - Definição e implementação da orquestração dos casos de uso.

Coldmart.{ Nome do contexto }.Data/ - Definição da camada de acesso a dados (configuração do EF).

Coldmart.{ Nome do contexto }.Domain/ - Definição das entidades, enums e constantes do módulo.

Coldmart.{ Nome do contexto }.API/ - API RESTful do contexto.

Coldmart.{ Nome do contexto }.{ Nome da camada }.Tests/ - Projeto de testes do respectivo projeto.

README.md - Arquivo de Documentação do Projeto

FEEDBACK.md - Arquivo para Consolidação dos Feedbacks

Dockerfile - Instruções para o build das imagens da respectiva API

docker-compose.yml - Arquivo de instrução para o ambiente virtualizado com as devidas dependências.

.gitignore - Arquivo de para ignorar arquivos e pastas do Git

5. Funcionalidades Implementadas

Casos de uso especificados no documento do projeto, que pode ser acessado [aqui](./docs/Projeto-Quarto-Modulo-Mba-DevXpert.pdf).

Autenticação e Autorização: Diferenciação entre alunos e administradores.

API RESTful: Exposição de use cases via API.
Documentação da API: Documentação automática dos endpoints da API utilizando Swagger.

6. Como Executar o Projeto

Pré-requisitos

.NET SDK 9.0 ou superior

Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)

Git

Docker

Passos para Execução

Clone o Repositório:

git clone https://github.com/seu-usuario/nome-do-repositorio.git
cd nome-do-repositorio

Uma vez na pasta raíz do projeto, rode o comando: `docker compose up`

Os serviços e as dependências serão buildados (ou baixados dos respectivos registries).

6.1 Credenciais dos usuários padrões (criados via seed)

## Admin
### Email
admin@coldmart.com
### Senha
Admin@123

## Aluno
### Email
aluno@coldmart.com
### Senha
Aluno@123

6.2 Remoção do suporte ao SQLite

A partir do EF Core (9 e superiores), alguns comportamentos mudaram com relação à aplicar a migration em um banco de dados, uma delas é [esse novo comportamento](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-9.0/breaking-changes#exception-is-thrown-when-applying-migrations-if-there-are-pending-model-changes).

É possível ignorar esse erro configurando o EF da seguinte maneira:
```dotnet
options.ConfigureWarnings(w =>
    w.Ignore(RelationalEventId.PendingModelChangesWarning));
```
Ao configurar o model builder dessa forma, percebemos o seguinte erro:
```
Unhandled exception. Microsoft.Data.SqlClient.SqlException (0x80131904): Column 'Id' in table 'Curso' is of a type that is invalid for use as a key column in an index.
```
Isso indica que ao menos a versão do sql server utilizada no projeto não suporta o data type `text` como Id. Embora seja possível trocar o Id para usar um identificar diferente, como um inteiro com auto increment por exemplo, o suporte ao SQLite não deveria ser um fator de decisão para tal mudança. Considerando isso e também o fato de que o Docker já é um requisito do projeto, não se faz necessário usar o SQLite a fim de facilitar o desenvolvimento, uma vez que se pode simplesmente instanciar um container do SQL Server dentro do mesmo compose.
Outro ponto é que tipos legado como TEXT não são mais utilizados no SQL server e devem ser alterados para usar o respectivo tipo. Armazenar identificadores únicos, datas e outros como TEXT implica em degradação de performance do próprio mecanismo ao realizar filtros ou criar índices para esses campos.

7. Instruções de Configuração
JWT para API: As chaves de configuração do JWT estão no appsettings.json.
Migrações do Banco de Dados: As migrações são gerenciadas pelo Entity Framework Core. Não é necessário aplicar devido a configuração do Seed de dados.

8. Documentação da API
A documentação de cada API está disponível através do Swagger. Após executar o docker compose, abra um navegador e então acesse em:

http://localhost:{ Porta do serviço, especificado no docker-compose.yml }/swagger

9. Considerações do grupo

- O projeto Coldmart.BFF não foi coberto por testes unitários por falta de tempo para implementação

10. Avaliação

Este projeto é parte de um curso acadêmico e não aceita contribuições externas.

Para feedbacks ou dúvidas utilize o recurso de Issues

O arquivo FEEDBACK.md é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.