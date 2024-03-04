## Anotações do curso

### 8. NUGET

 - O NuGet é um sistema de gerenciamento de pacotes para o desenvolvimento de software na plataforma Microsoft. Ele permite que os desenvolvedores compartilhem, distribuam e instalem bibliotecas de código, ferramentas e outros recursos de software em seus projetos .NET.

  - <https://www.nuget.org/>

~~~
  dotnet add package Microsoft.AspNetCore.Mvc --version 2.2.0
  dotnet add package Microsoft.EntityFrameworkCore --Version 6.0.0
  dotnet add package Microsoft.EntityFrameworkCore.Design --Version 6.0
~~~

 Os pacotes NuGet são unidades de distribuição de software que podem conter bibliotecas compiladas, arquivos de recursos, metadados e scripts de instalação. 

## Seção 3: O conceito de uma aplicação WEB

#### Web Server:

 - Um servidor web é um software que processa solicitações HTTP (Hypertext Transfer Protocol) de clientes (geralmente navegadores) e envia as respostas. Ele gerencia recursos como arquivos HTML, imagens, scripts e outros conteúdos web.
 - Exemplos de servidores web incluem o Internet Information Services (IIS) da Microsoft, Apache, Nginx, entre outros.

#### Hosting:

 - O hosting refere-se ao ambiente onde a aplicação web é implantada e executada. Em um contexto .NET, a aplicação pode ser hospedada em diferentes ambientes, como servidores locais, servidores dedicados, máquinas virtuais ou serviços em nuvem (por exemplo, Azure, AWS, etc.).
 - O hosting também pode ser gerenciado por servidores web, como o IIS, ou por servidores de aplicação.

#### API (Interface de Programação de Aplicações):

 - Uma API é um conjunto de regras e definições que permite que diferentes softwares se comuniquem entre si. No contexto web, uma API geralmente se refere a uma API da web, que expõe funcionalidades específicas de uma aplicação para serem consumidas por outras aplicações.

 - Em aplicações .NET, as APIs são frequentemente construídas usando o ASP.NET Web API ou o ASP.NET Core MVC, permitindo a criação de serviços web RESTful.

Esses conceitos são fundamentais para entender como as aplicações web .NET funcionam, desde a comunicação via HTTP até a hospedagem em servidores web.

## Seção 4: Primeira API

#### 13. Instalando Postman

 - <https://www.postman.com/downloads/>

 #### 14. Hello World Web

Realizar testes enquanto coda a aplicação
~~~
dotnet watch run
~~~

#### Endpoint

 - Em desenvolvimento de software, um "endpoint" geralmente se refere a um ponto de extremidade em uma API (Interface de Programação de Aplicações). Em C# usando .NET, você pode criar endpoints usando o framework ASP.NET Core, que é uma estrutura moderna para construir aplicativos web e APIs.

 ### 27. Status code

Os códigos de status de resposta HTTP indicam se uma solicitação HTTP específica foi concluída com êxito. As respostas são agrupadas em cinco classes:

 * Respostas Informativas (100 – 199)
 * Respostas bem-sucedidas (200 – 299)
 * Mensagens de redirecionamento (300 – 399)
 * Respostas de erro do cliente (400 – 499)
 * Respostas de erro do servidor (500 – 599)
 
<https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status>


### 31. Environments
Ambientes (Environments) em .NET, especialmente no contexto do ASP.NET Core, são utilizados para definir diferentes configurações e comportamentos com base no ambiente em que a aplicação está sendo executada. O ambiente pode ser, por exemplo, "Development", "Staging" ou "Production". Cada ambiente pode ter diferentes configurações de banco de dados, serviços, níveis de log, etc.

Aqui estão algumas informações sobre como configurar e usar ambientes no contexto do ASP.NET Core:

 * 1. Definindo o Ambiente:
    * O ambiente é frequentemente definido através da variável de ambiente **ASPNETCORE_ENVIRONMENT**. Você pode definir essa variável no sistema operacional ou utilizar configurações específicas do seu ambiente de hospedagem.
 * 2. Configuração do Ambiente no Startup.cs:
    * No arquivo **Startup.cs**, você pode configurar serviços e middleware com base no ambiente da seguinte forma:

~~~
public void ConfigureServices(IServiceCollection services)
{
    if (env.IsDevelopment())
    {
        // Configurações específicas para o ambiente de desenvolvimento
    }
    else if (env.IsStaging())
    {
        // Configurações específicas para o ambiente de staging
    }
    else if (env.IsProduction())
    {
        // Configurações específicas para o ambiente de produção
    }
}
~~~

 * 3. Configuração no appsettings.json:
    * Você pode ter arquivos de configuração específicos para cada ambiente. Por exemplo, appsettings.**Development.json**, **appsettings.Staging.json** e **appsettings.Production.json**. As configurações específicas do ambiente substituirão as configurações no arquivo principal **appsettings.json**.

 * 4. Configuração de Logging:
    * Você pode configurar o sistema de log com base no ambiente. Por exemplo:
~~~
if (env.IsDevelopment())
{
    // Configuração de log específica para o ambiente de desenvolvimento
}
~~~

 * 5. Utilizando Environments em Aplicações Console:
    * Em aplicações console .NET, você pode obter o ambiente da seguinte forma:
~~~
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
~~~

Ou, se estiver usando **WebHost.CreateDefaultBuilder:**

~~~
var builder = new HostBuilder()
    .UseEnvironment("Development") // substitua "Development" pelo ambiente desejado
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });
~~~

 - Lembrando que o uso e configuração específicos podem variar dependendo da versão do ASP.NET Core que você está utilizando e da estrutura geral da sua aplicação. Certifique-se de verificar a documentação oficial e as melhores práticas para a versão específica que você está utilizando.

 ### 33. Instalando WSL

  * <https://learn.microsoft.com/en-us/windows/wsl/install>

 Abrir o Powershell como adm 

 ~~~
 wsl --install
 ~~~

  ### 34. Instalando docker

  https://www.docker.com/

### 35. Instalando SQL Server via container

No Powershell execute o comando:

~~~
docker pull mcr.microsoft.com/mssql/server:2022-latest
~~~

Para executar a imagem de contêiner do Linux com o Docker, você pode usar o comando a seguir em um shell de bash ou no prompt de comando com privilégios elevados do PowerShell

~~~
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=@Sql2019" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest
~~~

### 36. Instalando Azure Data Studio

 * O Azure Data Studio é uma ferramenta para desenvolvedores leve e de gerenciamento de dados de plataforma cruzada, com conectividade com bancos de dados locais e na nuvem populares. O Azure Data Studio oferece suporte ao Windows, ao macOS e ao Linux, com capacidade imediata de conexão ao SQL do Azure e ao SQL Server. Navegue pela biblioteca de extensões para obter mais opções de suporte a bancos de dados, incluindo MySQL, PostgreSQL e Cosmos DB.

 - <https://learn.microsoft.com/pt-br/azure-data-studio/download-azure-data-studio?tabs=win-install%2Cwin-user-install%2Credhat-install%2Cwindows-uninstall%2Credhat-uninstall>

 ## Seção 09: Entity Framework Core

 ### 37. Instalando pacotes 
~~~
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Designer
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
~~~
