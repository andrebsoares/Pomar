# Projeto Pomar
O projeto foi desenvolvida em .Net Core e React
Banco de dados utilizado foi o LocalDb com Migrations.

Se não quiser executar os comandos de projeto em projeto criei alguns bats

Configurar:
-> Executar o configura.bat e esperar o processo ser concluído

Executar:
-> Executar o startserver.bat para subir a API
-> Executar startweb.bat para subir o Web


Obs: Se optar subir no Vs Studio deve ser utilizado o VS 2019 ou o VS Code

VS Studio (API de Pomar):
-> Abrir o Projeto Pomar 
-> No Package Manager Console executar: Update-Database para executar o Migrations
Não deve aparecer nenhum erro
-> Rodar o projeto
Ou
VS Studio Code(API de Pomar):
-> Abrir o Projeto Pomar 
-> Se atentar no terminal para que esteja posicionado na Pasta Pomar dentro da Pomar(Pomar/Pomar)
-> Executar o comando: dotnet ef database update
-> Executar dotnet run para executar o projeto

Obs: Os comandos para rodar pelo CLI e VS 2019 não são iguais.

VS Code (PomarWeb):
-> Abrir o Projeto PomarWeb
-> Executar yarn Install para instalar as dependencias
-> Executar yarn start para executar o projeto