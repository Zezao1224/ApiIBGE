# API IBGE
### Objetivo
Esta api tem o objetivo de facilitar a utilização de dados IBGE, componentizando um banco de dados em SQLite e possibilitando a atualização e inclusão de mais dados por meio dos EndPoints disponíveis. Assim, facilitando a implementação de suas funcionalidades em diversas aplicações.

### Endpoints

Alguns exemplos de EndPoints:

* '**GET /v1/ibge/{ id }**': Retorna os dados ibge com base no id.
* '**POST /v1/ibge**': Persiste um novo dado do ibge no banco.
* '**PUT /v1/ibge**': Altera um dado do ibge existente.
* '**DELETE /v1/ibge**': Deleta um dado do ibge existente.

Os demais EndPoints estão disponíveis na documentação oficial no título "Links" deste Readme.

### Autenticação

A autenticação é feita por meio do cabeçalho Authorization, com o valor "Bearer {seu_token}".
O token expirará após 2hs de sua criação e só será gerado pelo EndPoint de login disponível no título "Links" deste Readme.


### Links
* Documentação: https://ibgeapi.azurewebsites.net/swagger/index.html

* Link oficial da api: https://ibgeapi.azurewebsites.net

### Ajuda
 Caso precise de ajuda, pode entrar em contato com algum dos autores que iremos te auxiliar.

### Autores
<h3> Bruno Luiz</h3>

*  👨🏻‍💻 https://github.com/Zezao1224
*  🔗 https://www.linkedin.com/in/brunoluizdesouza/
*  📧 brunoluiz1809@gmail.com

<h3> Lucas Lira </h3>

*  👨🏻‍💻 https://github.com/LLucasLira
*  🔗 https://www.linkedin.com/in/lucas-lira-084b2a17a/
*  📧 lucas_afl1505@hotmail.com

<h3> Vitor Renno </h3>

*  👨🏻‍💻 https://github.com/vitorrenno
*  🔗 https://www.linkedin.com/in/vitorrenno/
*  📧 vitorrenno@outlook.com
