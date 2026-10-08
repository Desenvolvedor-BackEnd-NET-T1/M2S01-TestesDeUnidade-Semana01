# Calculadora Console

Aplicação simples de console em C# para realizar operações matemáticas básicas: soma, subtração, multiplicação e divisão.

A lógica das operações fica encapsulada na classe `Calculadora`, permitindo que ela seja testada diretamente sem depender da interação com o console.

## Visão geral

- `CalculadoraConsole/Program.cs`: interface de console com menu e leitura de entrada do usuário
- `CalculadoraConsole/Calculadora.cs`: implementação das operações matemáticas
- `README.md`: documentação do projeto

## Requisitos

- .NET SDK instalado
- Terminal ou prompt de comando

## Como executar

Na raiz do projeto, rode:

```bash
dotnet run --project CalculadoraConsole
```

## Como depurar os testes no VS Code

Instale a extensão **C# Dev Kit** recomendada para este workspace e compile a solução. Depois, abra o **Test Explorer** (ícone de béquer), atualize a lista de testes e selecione **Debug Test** no teste desejado. Também é possível usar a opção **Debug Test** exibida acima do método de teste no editor.

Testes marcados com `Skip` não são executados nem podem ser depurados; use um teste habilitado.

## Como usar

Ao iniciar a aplicação, o programa exibe um menu com as operações disponíveis:

```text
Escolha a operação:
1 - Soma
2 - Subtração
3 - Multiplicação
4 - Divisão
Opção: 
```

Em seguida, ele solicita:

1. o primeiro valor
2. o segundo valor

Depois disso, o resultado da operação é exibido na tela.

### Exemplo de execução

```text
Escolha a operação:
1 - Soma
2 - Subtração
3 - Multiplicação
4 - Divisão
Opção: 1
Informe o primeiro valor: 10
Informe o segundo valor: 5
Resultado: 15
```

### Operações suportadas

- `SOMA`
- `SUBTRACAO`
- `MULTIPLICACAO`
- `DIVISAO`

A aplicação aceita também a entrada numérica via opções do menu (`1`, `2`, `3`, `4`) e também nomes das operações em texto, sem diferenciar maiúsculas e minúsculas.

## Entrada por pipe (opcional)

Também é possível enviar a entrada diretamente pela linha de comando:

```bash
printf '1\n10\n5\n' | dotnet run --project CalculadoraConsole
```

Resultado esperado:

```text
Escolha a operação:
1 - Soma
2 - Subtração
3 - Multiplicação
4 - Divisão
Opção: Informe o primeiro valor: Informe o segundo valor: Resultado: 15
```
