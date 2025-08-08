# TODO APP
 
TODO APP, é um projeto full-stack de organização de tarefas. 
<img width="886" height="575" alt="image" src="https://github.com/user-attachments/assets/ab0e5336-3b9e-4a03-8e44-db1315f6a1f9" />


## 🔥 Introdução

APP foi criação com .net versão 9 e Angular versão 14 e teste com Jasmine

### ⚙️ Pré-requisitos
* .Net Core versão 9.0 [.Net Core 6.0 Download](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0)
* Entity Framework Core versão 9.0 [Documentação](https://learn.microsoft.com/pt-br/ef/)
* Visual studio 2022, ou IDE que tenha suporte ao .Net 9.0 [Visual Studio 2022 Download](https://visualstudio.microsoft.com/pt-br/downloads/)
* Sql Server versão 2022 [Sql Server Download](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
* Sql Server Management Studio (SSMS) [SSMS Download](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
* Angular [Documentação](https://v14.angular.io/docs)
* Jasmine [Jasmine](https://jasmine.github.io/)


### 🔨 Guia de instalação

Para utilizar este projeto, necessário instalar o Entity Framework, e configurar o banco de dados no arquivo appsettings.Development.json, e instalar as migrations para conexão com o banco de dados

Etapas para instalar:

```bash
dotnet tool install --global dotnet-ef
```
Passo 2:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
Passo 3:
```bash
Install-Package Microsoft.EntityFrameworkCore.Design
```
Passo 4:
```bash
dotnet-ef migrations add (Nome da migration do projeto)
```

Passo 5:
```bash
dotnet-ef database update
```

# Executando a Aplicação 🌐

Para executar a aplicação App, digite o seguinte comando

```bash
ng serve --open
```

Para executar a aplicação back-end, digite o seguinte comando

```bash
dotnet run
```


# Endpoins 🚨
A API funciona, com os métodos HTTP GET, POST, PUT e DELETE.
No método de deletar, foi utilizado a prática de Soft Delete

Exemplo de dado deletado (IsDeleted = 1) no banco de dados

<img width="831" height="383" alt="image" src="https://github.com/user-attachments/assets/7cfc7cf1-d8d8-4317-bc6a-4b164d34acb2" />



# Testes 👁️‍🗨️

Para testes na aplicação Front-End, foi utilizado o framework Jasmine.

## 🛠️ Executando os testes (caso tenha testes)

Para executar o projeto, para testes. Digite o seguinte comando no terminal do Visual Studio Code, ou terminal CMD

```bash
ng test
```


