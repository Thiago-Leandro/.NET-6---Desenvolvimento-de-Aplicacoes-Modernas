## Anotações do curso

### 8. NUGET

 - O NuGet é um sistema de gerenciamento de pacotes para o desenvolvimento de software na plataforma Microsoft. Ele permite que os desenvolvedores compartilhem, distribuam e instalem bibliotecas de código, ferramentas e outros recursos de software em seus projetos .NET.

  - <https://www.nuget.org/>

 Os pacotes NuGet são unidades de distribuição de software que podem conter bibliotecas compiladas, arquivos de recursos, metadados e scripts de instalação. 

### Seção 3: O conceito de uma aplicação WEB

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

### Seção 4: Primeira API

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