# Sistema de Hospedagem - Trilha .NET - Explorando a Linguagem C#

## Descrição
Este projeto foi desenvolvido como parte do desafio da Trilha .NET da DIO, utilizando a linguagem C#. O sistema simula o gerenciamento de reservas em um hotel, permitindo o cadastro de suítes, a realização de reservas, o cálculo do valor das diárias e a visualização de reservas feitas.

## Funcionalidades e Regras de Negócio
O sistema oferece as seguintes funcionalidades e regras de negócio:
1. **Cadastrar Suítes**: O usuário pode cadastrar novas suítes informando o tipo, a capacidade e o valor da diária.
2. **Fazer Reserva**: O usuário pode fazer uma reserva para uma suíte, informando a quantidade de hóspedes e a duração da estadia. Caso a quantidade de hóspedes seja maior que a capacidade da suíte, o sistema lança uma exceção.
3. **Calcular Valor da Diária**: O sistema calcula o valor da diária com base no número de dias da reserva e no valor da diária da suíte. Se a reserva for maior ou igual a 10 dias, um desconto de 10% é aplicado.
4. **Listar Reservas**: O usuário pode visualizar as reservas feitas, com informações sobre a suíte, hóspedes, dias de estadia e o valor total da diária.

**Regras de Negócio Adicionais**: <br>
*Capacidade da Suíte*: Não é possível realizar uma reserva em uma suíte com capacidade menor do que o número de hóspedes. <br>
*Método ObterQuantidadeHospedes*: Retorna a quantidade total de hóspedes na reserva. <br>
*Método CalcularValorDiaria*: Calcula o valor total da diária, aplicando o desconto de 10% para reservas de 10 dias ou mais. <br>

## Estrutura de Classes <br>
**Pessoa**: Representa um hóspede, com atributos como nome e outros dados. <br>
**Suíte**: Representa as suítes do hotel, com informações como tipo, capacidade e valor da diária. <br>
**Reserva**: Gerencia a relação entre hóspedes e suítes, calcula a quantidade de hóspedes e o valor da diária, aplicando o desconto conforme o período de reserva. <br>

## Diagrama de Classe
![Diagrama de classe do sistema de reservas](diagrama_classe_hotel.png)

### Passos para Executar
1. Clone este repositório:
    ```bash
    git clone https://github.com/seu-usuario/nome-do-repositorio.git
    ```

2. Abra o projeto em sua IDE favorita.

3. Compile e execute o programa.

4. O menu de opções será exibido no console, permitindo que você:
   - Cadastre suítes.
   - Realize reservas.
   - Calcule o valor das diárias.
   - Liste as reservas feitas.
