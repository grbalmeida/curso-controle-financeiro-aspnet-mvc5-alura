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