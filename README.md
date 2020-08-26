### Instalação do Entity Framework

```
Install-Package EntityFramework -version 6.1.1
```

### String de Conexão para o SQL Server

```xml
<connectionStrings>
    <add
		name="FinancasContext"
		providerName="System.Data.SqlClient"
		connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|financas.mdf;Initial Catalog=aspnet-movimentacao;Integrated Security=True"
    />
</connectionStrings>
```

### Comando para habilitar migrations

```
Enable-Migrations
```

### Comando para adicionar migrations iniciais

```
Add-Migration TabelasIniciais
```

### Comando para atualizar o banco de dados

```
Update-Database -Verbose
```

### Comando para instalação do container de injeção de dependência Ninject

```
Install-Package Ninject.MVC3 -version 3.2.1
```

### Comando para instalação do pacote para autenticação e autorização e Simple Membership

```
Install-Package Microsoft.AspNet.WebPages.WebData -version 3.1.1
Update-Package Microsoft.AspNet.WebPages.Data
```

### Configuração do pacote Simple Membership no Web.config

```xml
<membership defaultProvider="financasProvider">
	<providers>
		<add name="financasProvider" type="WebMatrix.WebData.SimpleMembershipProvider,WebMatrix.WebData" />
	</providers>
</membership>
```

### Configuração da url de login no Web.config

```xml
<add key="loginUrl" value="~/Login" />
```

### Inicialização do Simple Membership no Global.asax.cs

```csharp
WebSecurity.InitializeDatabaseConnection("FinancasContext", "Usuarios", "Id", "Nome", true);
```

Devemos chamar o método InitializeDatabaseConnection passando o nome da connection string,
o nome da tabela de usuários, a chave primária, a coluna nome
e uma flag para indicar se o Simple Membership deve criar as tabelas automaticamente.