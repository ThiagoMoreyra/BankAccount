# BankAccount - Gerenciado de Contas-Correntes.

<!--ts-->
   * [Sobre](#Sobre)
   * [Status do Projeto](#Status)
   * [Instalação](#instalacao)
   * [Como usar](#como-usar)
      * [Tecnologias](#Tecnologias)
      * [Scripts](#Scripts)      
   * [Conta Remunerada](#Conta)
   * [Teste de segurança](#segurança)
<!--te-->


<h4>* Sobre: </h4>

<p> - Implementar um sistema de controle de conta corrente bancária, processando solicitações de depósito, resgates e pagamentos. Um ponto extra seria rentabilizar o dinheiro parado em conta de um dia para o outro como uma conta corrente remunerada.</p>

<h4>* Status do projeto: </h4>

<p> - Finalizando a parte de front do projeto.</p>

<h4>* Instalação: </h4>

<p> - Instalar a IDE Visual Studio 2019 <br> Segue o Link: https://visualstudio.microsoft.com/pt-br/vs/community/</p>

<h4>* Como usar: </h4>

<p> - Abra o prompt de comando e vá até a pasta do projeto e digite os seguintes comandos:</p>

<b> 1 - dotnet restore </b><br>
<b> 2 - Vá até a pasta <i>src/BankAccount.Api<i> e digite dotnet run </b><br>
<b> 3 - Vá até o seu navegador e digite: https://localhost:5001/swagger/index.html</b> 

<h4>* Tecnologias: </h4>
<p>
  1 - .NET Core 3.1 <br>
   2 - MySql <br>
   3 - Entity FrameWork <br>
   4 - Swagger <br>
   5 - AspNetCoreRateLimit <br>
   6 - XUnit
</p>
   
<h4>* Scripts</h4>

<p> - Na pasta: <i>BankAccount.App\src\BankAccount.Data\Scripts</i> está o script de criação de tabelas</p>

<h4>* Conta Remunerada: </h4>

<p> - Assim que a conta é criada há um método chamado <i>GetAccountYield</i> que calcula a sua remuneração de acordo com a data de criação</p>

<h4>* Teste de Segurança </h4>

<p>
   - Para o teste de segurança eu utilizei a package <i>AspNetCoreRateLimit</i> <br>
Ela é utilizada para controlar a taxa de solicitações que os clientes podem fazer para uma API Web ou aplicativo MVC com base no endereço IP ou ID do cliente.<br>
Instalação: dotnet add package AspNetCoreRateLimit. <br>
Referência: https://www.infoworld.com/article/3442946/how-to-implement-rate-limiting-in-aspnet-core.html<br>
Para realizar o teste será necessário teclar Ctrl + F5 várias vezes chamado uma rota.
</p>
