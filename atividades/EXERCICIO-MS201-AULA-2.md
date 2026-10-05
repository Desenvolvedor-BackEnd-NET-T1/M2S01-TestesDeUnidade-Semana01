# Exercício Guiado M2S01 — TDD

## Objetivo

Praticar o desenvolvimento orientado por testes (TDD) implementando uma nova operação na classe `Calculadora`. Durante toda a atividade, siga o ciclo:

1. **Red:** escreva um teste que descreva um comportamento e confirme que ele falha.
2. **Green:** escreva apenas o código necessário para fazer o teste passar.
3. **Refactor:** melhore a implementação ou os testes sem alterar o comportamento; execute os testes novamente.

Não implemente a operação antes de escrever seu primeiro teste.

## Funcionalidade: cálculo de porcentagem

Adicione à calculadora uma operação que calcule quanto representa uma porcentagem de um valor. A regra é:

> valor da porcentagem = valor base × percentual ÷ 100

Por exemplo, 10% de 200 é 20.

A funcionalidade deve:

- disponibilizar o método público `Calculadora.Porcentagem(decimal valor, decimal percentual)`;
- permitir que a operação também seja chamada por `Calculadora.Calcular("PORCENTAGEM", valor, percentual)`;
- aceitar valores decimais e percentuais maiores que 100 ou negativos, aplicando a mesma fórmula;
- manter o comportamento existente das outras operações.

## Atividade 1 — Red: escreva o primeiro teste

No projeto `CalculadoraConsole.Tests`, escreva um teste para a chamada abaixo, esperando o resultado `20m`:

```csharp
Calculadora.Calcular("PORCENTAGEM", 200m, 10m)
```

Execute o teste:

```bash
dotnet test CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

O projeto deve compilar, mas o teste deve falhar porque a operação ainda não é reconhecida. Se o teste não compilar, revise a chamada e os tipos utilizados.

## Atividade 2 — Green: faça o teste passar

Implemente somente o necessário para suportar a nova operação:

- crie o método público `Porcentagem`;
- faça `Calcular` encaminhar a operação `"PORCENTAGEM"` para esse método.

Execute os testes novamente e confirme que o novo teste e os testes anteriores passam.

## Atividade 3 — Red, Green e Refactor: amplie os cenários

Adicione testes para o método `Porcentagem` cobrindo estes casos:

| Valor base | Percentual | Resultado esperado |
|---:|---:|---:|
| `200m` | `10m` | `20m` |
| `99.90m` | `15m` | `14.985m` |
| `80m` | `125m` | `100m` |
| `-50m` | `10m` | `-5m` |
| `0m` | `25m` | `0m` |

Escreva um caso por vez. Para cada novo caso:

1. execute o teste e observe o resultado;
2. ajuste a implementação somente se necessário;
3. execute a suíte completa;
4. refatore, se houver uma melhoria clara, e confirme que os testes continuam passando.

Você pode usar `[Theory]` e `[InlineData]` para fornecer os valores e resultados esperados ao mesmo teste.

## Critérios de conclusão

- O primeiro teste foi escrito antes da implementação e falhou pelo comportamento esperado.
- A operação está disponível pelo método `Porcentagem` e pelo método `Calcular`.
- Todos os cenários da tabela estão cobertos por testes.
- Os testes existentes continuam passando.
- Após cada alteração, `dotnet test CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj` termina sem falhas.