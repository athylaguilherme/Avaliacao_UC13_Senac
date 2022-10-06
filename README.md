# Avaliacao_UC13_Senac


##  Inconsistências da Model

Metodo Verificar Aprovação da model está errado, pois ele da falso em pessoa com media 5, devido que no metodo Verifica Aprovação está > 5, o correto seria >= 5.

A Models precisa também ter construtor para obrigar, o usuario passar os dados. E Validações para evitar que Usuário passe nome com cheio de caracter especiais, e número negativos na Média.

## Inconsistências na Controller

O Metodo Details da controller, quando id é nulo, está retornando um NotFound(), o certo era pra retornar um BadRequest(), Ele está retornando o NotFound(), pois na controller se ele for null retorna um NotFound(), devia retornar um BadRequest().
