# Cadastro de clientes com C# e TDD

## Proposta da atividade

Desenvolva um aplicativo de console em C# com .NET 10 para cadastrar e listar clientes. Construa as regras usando TDD e xUnit: escreva um teste, veja esse teste falhar, implemente o comportamento e refatore com os testes passando.

Público: iniciantes em testes de unidade. Tempo sugerido: 2 horas de prática, ajustável ao ritmo da turma.

Nesta atividade, estilo legado significa usar namespaces com chaves, classes convencionais e uma classe Program com método Main. Não significa utilizar uma versão antiga do .NET. Não use top-level statements nem records.

## O que entregar

- Uma solução com um console-app, uma biblioteca de classes e um projeto de testes xUnit.
- As classes Cliente e CadastroCliente desenvolvidas em pequenos ciclos de TDD.
- Cadastro e listagem no console, com mensagens para entradas inválidas.
- Um breve registro de pelo menos três ciclos: teste escrito, motivo da falha e alteração que fez passar. Pode ser um arquivo de texto ou capturas da execução.

## Regras do cadastro

| Dado ou operação | Regra |
| --- | --- |
| Nome | Obrigatório; entre 3 e 100 caracteres depois de remover espaços nas extremidades. |
| E-mail | Obrigatório; remover espaços nas extremidades; deve conter exatamente um @ e texto antes e depois dele, sem espaços. É uma validação didática simplificada. |
| Idade | Deve estar entre 18 e 120 anos, inclusive. |
| Cadastro | Um cliente válido deve ficar disponível na lista em memória. |
| Duplicidade | Não cadastrar novamente o mesmo e-mail, ignorando maiúsculas e minúsculas. |
| Listagem | Um cadastro novo começa vazio; clientes diferentes devem permanecer na lista. |

Use ArgumentException para dados inválidos e InvalidOperationException para e-mail duplicado. Os dados existem somente enquanto o aplicativo está aberto. Não utilize banco de dados, API, injeção de dependência ou mocks nesta atividade.

## Passo 1 Preparar o ambiente

Instale o SDK do .NET 10 e use o VS Code ou a IDE de sua preferência. No terminal, confira:

```bash
dotnet --version
```

O SDK selecionado deve ser da família 10.x. Execute os comandos seguintes na pasta em que deseja criar a atividade.

## Passo 2 Criar a solução e os projetos

```bash
mkdir CadastroClientesTdd
cd CadastroClientesTdd

dotnet new sln -n CadastroClientesTdd --format sln
dotnet new console -n CadastroClientes.Console -f net10.0 --use-program-main
dotnet new classlib -n CadastroClientes.Dominio -f net10.0
dotnet new xunit -n CadastroClientes.Tests -f net10.0

dotnet sln CadastroClientesTdd.sln add CadastroClientes.Console/CadastroClientes.Console.csproj
dotnet sln CadastroClientesTdd.sln add CadastroClientes.Dominio/CadastroClientes.Dominio.csproj
dotnet sln CadastroClientesTdd.sln add CadastroClientes.Tests/CadastroClientes.Tests.csproj

dotnet add CadastroClientes.Console/CadastroClientes.Console.csproj reference CadastroClientes.Dominio/CadastroClientes.Dominio.csproj
dotnet add CadastroClientes.Tests/CadastroClientes.Tests.csproj reference CadastroClientes.Dominio/CadastroClientes.Dominio.csproj

dotnet test CadastroClientesTdd.sln
```

O comando do console gera Program com Main. O parâmetro --format sln escolhe explicitamente o formato tradicional da solução; no .NET 10, o padrão é .slnx. O template xunit utilizado aqui é o template convencional fornecido pelo SDK; não instale o template xunit3 para este roteiro.

O projeto Console cuida da interação com o usuário. Dominio contém o cliente e as regras do cadastro. Tests verifica essas regras e referencia apenas Dominio.

Remova Class1.cs da biblioteca e UnitTest1.cs do projeto de testes usando a IDE. O teste gerado pelo template só verifica a configuração inicial; ele não conta como teste da atividade.

## Passo 3 Entender como trabalhar com TDD

Para cada comportamento, siga esta ordem:

1. Vermelho: escreva um teste e execute-o. Confirme que falha pelo comportamento ainda não implementado.
2. Verde: escreva apenas o código necessário para fazê-lo passar.
3. Refatorar: melhore nomes, organização e duplicação sem mudar o comportamento. Execute os testes novamente.

Ao escrever um teste que usa uma classe inexistente, haverá erro de compilação. Crie somente a estrutura mínima para compilar; depois execute o teste e observe a falha de comportamento. Não confunda erro de compilação com uma validação do comportamento da regra.

Durante toda a atividade, execute na raiz da solução:

```bash
dotnet test CadastroClientesTdd.sln
```

## Passo 4 Primeiro ciclo de TDD completo

Comportamento: um cliente criado com dados válidos deve guardar nome, e-mail e idade.

### Escrever o teste primeiro

Crie ClienteTests.cs no projeto CadastroClientes.Tests:

```csharp
using CadastroClientes.Dominio;
using Xunit;

namespace CadastroClientes.Tests
{
    public class ClienteTests
    {
        [Fact]
        public void CriarCliente_ComDadosValidos_DeveGuardarOsDados()
        {
            // Arrange e Act: preparar os dados e criar o cliente.
            Cliente cliente = new Cliente("Ana Silva", "ana@email.com", 25);

            // Assert: verificar o comportamento esperado.
            Assert.Equal("Ana Silva", cliente.Nome);
            Assert.Equal("ana@email.com", cliente.Email);
            Assert.Equal(25, cliente.Idade);
        }
    }
}
```

Execute os testes. A compilação falha porque Cliente ainda não existe.

### Criar apenas a estrutura mínima

Crie Cliente.cs no projeto CadastroClientes.Dominio:

```csharp
using System;

namespace CadastroClientes.Dominio
{
    public class Cliente
    {
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public int Idade { get; private set; }

        public Cliente(string nome, string email, int idade)
        {
            throw new NotImplementedException();
        }
    }
}
```

Execute novamente. Agora o projeto compila, mas o teste falha com NotImplementedException. Esse é o vermelho de comportamento esperado nesta etapa.

### Fazer o teste passar

Substitua o conteúdo do construtor por:

```csharp
Nome = nome;
Email = email;
Idade = idade;
```

Execute os testes e confirme que passaram. Não implemente todas as validações agora: elas serão introduzidas pelos próximos testes.

### Refatorar

Revise os nomes e a legibilidade. Se nada precisar mudar, não force uma refatoração. Atribuir as propriedades já é suficiente para este comportamento.

## Passo 5 Nome obrigatório

Adicione using System; no arquivo de testes. Dentro de ClienteTests, escreva:

```csharp
[Theory]
[InlineData(null)]
[InlineData("")]
[InlineData("   ")]
public void CriarCliente_ComNomeAusente_DeveRejeitar(string? nome)
{
    Assert.Throws<ArgumentException>(() =>
        new Cliente(nome!, "ana@email.com", 25));
}
```

O operador ! apenas suprime o aviso de nulidade para enviar intencionalmente um dado inválido ao código testado; ele não transforma null em uma string válida.

Execute e veja as falhas. Implemente a verificação com string.IsNullOrWhiteSpace antes das atribuições. Lance ArgumentException para nome ausente. Execute toda a suíte e confirme que o teste de dados válidos continua passando.

## Passo 6 Tamanho e normalização do nome

Introduza cada comportamento separadamente, sempre executando o teste antes de implementá-lo.

```csharp
[Theory]
[InlineData("A")]
[InlineData("Al")]
public void CriarCliente_ComNomeCurto_DeveRejeitar(string nome)
{
    Assert.Throws<ArgumentException>(() =>
        new Cliente(nome, "ana@email.com", 25));
}

[Fact]
public void CriarCliente_ComNomeAcimaDoLimite_DeveRejeitar()
{
    string nome = new string('A', 101);
    Assert.Throws<ArgumentException>(() =>
        new Cliente(nome, "ana@email.com", 25));
}

[Fact]
public void CriarCliente_ComEspacosNasExtremidades_DeveNormalizarNome()
{
    Cliente cliente = new Cliente("  Ana Silva  ", "ana@email.com", 25);
    Assert.Equal("Ana Silva", cliente.Nome);
}
```

Orientação: valide primeiro a ausência do nome, remova espaços com Trim e só então verifique o tamanho. Armazene o nome normalizado. Crie também testes que aceitem exatamente 3 e exatamente 100 caracteres e que rejeitem "  Al  ". As fronteiras são parte da regra.

## Passo 7 E-mail obrigatório e formato simplificado

Antes de implementar a validação, adicione:

```csharp
[Theory]
[InlineData(null)]
[InlineData("")]
[InlineData("   ")]
[InlineData("ana.email.com")]
[InlineData("@email.com")]
[InlineData("ana@")]
[InlineData("ana@@email.com")]
[InlineData("ana silva@email.com")]
public void CriarCliente_ComEmailInvalido_DeveRejeitar(string? email)
{
    Assert.Throws<ArgumentException>(() =>
        new Cliente("Ana Silva", email!, 25));
}
```

Comece com os casos de ausência. Depois introduza os casos de formato, um comportamento por vez. Implemente somente após observar cada falha.

Orientação: verifique a ausência antes de usar Trim. Localize o @ e confirme que ele não é o primeiro nem o último caractere e que não existe um segundo @. Rejeite caracteres de espaço em branco no e-mail normalizado; char.IsWhiteSpace também reconhece tabulações e quebras de linha. Não é necessário usar uma expressão regular.

Depois crie um teste para provar que "  ana@email.com  " é armazenado como "ana@email.com". Adicione casos com tabulação e quebra de linha internas para confirmar a regra de espaços. Esta regra não representa uma validação completa de endereços de e-mail para produção.

## Passo 8 Idade e limites

```csharp
[Theory]
[InlineData(-1)]
[InlineData(0)]
[InlineData(17)]
[InlineData(121)]
public void CriarCliente_ComIdadeInvalida_DeveRejeitar(int idade)
{
    Assert.Throws<ArgumentException>(() =>
        new Cliente("Ana Silva", "ana@email.com", idade));
}

[Theory]
[InlineData(18)]
[InlineData(25)]
[InlineData(120)]
public void CriarCliente_ComIdadeValida_DeveAceitar(int idade)
{
    Cliente cliente = new Cliente("Ana Silva", "ana@email.com", idade);
    Assert.Equal(idade, cliente.Idade);
}
```

O teste de rejeição deve falhar antes da implementação. Os testes de aceitação podem passar com o código existente: eles registram limites que precisam continuar aceitos. Implemente a condição para rejeitar idade abaixo de 18 ou acima de 120. Execute todos os testes.

## Passo 9 Começar o cadastro em memória

Crie CadastroClienteTests.cs com os usings System, CadastroClientes.Dominio e Xunit e o namespace CadastroClientes.Tests. Adicione uma classe pública CadastroClienteTests.

O primeiro comportamento é começar com uma lista vazia:

```csharp
[Fact]
public void Listar_SemClientes_DeveRetornarListaVazia()
{
    CadastroCliente cadastro = new CadastroCliente();
    Assert.Empty(cadastro.Listar());
}
```

Escreva o teste antes de criar CadastroCliente. Crie CadastroCliente.cs na biblioteca com a estrutura abaixo para compilar:

```csharp
using System;
using System.Collections.Generic;

namespace CadastroClientes.Dominio
{
    public class CadastroCliente
    {
        public IReadOnlyList<Cliente> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
```

Observe a falha e retorne uma lista vazia para chegar ao verde.

Em seguida, escreva este novo teste na classe CadastroClienteTests:

```csharp
[Fact]
public void Cadastrar_ComDadosValidos_DeveArmazenarCliente()
{
    CadastroCliente cadastro = new CadastroCliente();

    cadastro.Cadastrar("Ana Silva", "ana@email.com", 25);

    Cliente cliente = Assert.Single(cadastro.Listar());
    Assert.Equal("Ana Silva", cliente.Nome);
    Assert.Equal("ana@email.com", cliente.Email);
    Assert.Equal(25, cliente.Idade);
}
```

Crie o método public void Cadastrar(string nome, string email, int idade) inicialmente lançando NotImplementedException. Execute para observar a falha de comportamento.

Para chegar ao verde, mantenha uma List<Cliente> como campo de instância, crie o Cliente e adicione à coleção. Atualize Listar para consultar essa mesma coleção. Retorne uma visão somente de leitura com AsReadOnly, evitando expor a lista mutável diretamente. Não use uma coleção static: cada cadastro precisa ter seu próprio estado.

Adicione um teste que cadastre Ana e Bruno com e-mails diferentes e confirme os dois dados com Assert.Collection. Implemente ajustes somente se esse teste revelar um comportamento ausente.

## Passo 10 Impedir e-mail duplicado

Escreva antes de implementar:

```csharp
[Theory]
[InlineData("ana@email.com")]
[InlineData("ANA@EMAIL.COM")]
[InlineData("  ana@email.com  ")]
public void Cadastrar_ComEmailDuplicado_DeveRejeitar(string email)
{
    CadastroCliente cadastro = new CadastroCliente();
    cadastro.Cadastrar("Ana Silva", "ana@email.com", 25);

    Assert.Throws<InvalidOperationException>(() =>
        cadastro.Cadastrar("Outra Pessoa", email, 30));

    Assert.Single(cadastro.Listar());
}
```

Orientação: crie e valide o Cliente antes de alterar a lista; assim você pode comparar seu e-mail já normalizado. Compare com os e-mails existentes usando StringComparison.OrdinalIgnoreCase. Lance InvalidOperationException ao encontrar duplicidade e só adicione quando todas as verificações passarem. Use um foreach; LINQ é opcional.

Adicione um teste que confirme que um cadastro com idade 17 lança ArgumentException e mantém a lista vazia. Isso verifica que o serviço respeita as regras de Cliente e não armazena dados inválidos.

## Passo 11 Refatorar com os testes verdes

Execute toda a suíte antes e depois de cada alteração. Revise:

- As validações ficam em Cliente e não são repetidas no console.
- CadastroCliente cuida da coleção e da duplicidade.
- Cada teste cria seu próprio CadastroCliente, sem depender da ordem dos testes.
- Cada cenário inválido utiliza dados válidos nos outros campos, isolando a regra avaliada.
- Os nomes dos testes descrevem ação, condição e resultado.

Não acrescente uma nova regra durante a refatoração. Se surgir um comportamento novo, inicie outro ciclo com um teste.

## Passo 12 Conectar o domínio ao console

Com os testes verdes, substitua Program.cs pelo código abaixo. Este passo integra a entrada e saída do console às regras já testadas. Os testes desta atividade verificam o domínio; a interação do menu será validada manualmente.

```csharp
using System;
using CadastroClientes.Dominio;

namespace CadastroClientes.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CadastroCliente cadastro = new CadastroCliente();
            bool executando = true;

            while (executando)
            {
                Console.WriteLine("\n1 - Cadastrar cliente");
                Console.WriteLine("2 - Listar clientes");
                Console.WriteLine("0 - Sair");
                string opcao = Console.ReadLine() ?? string.Empty;

                switch (opcao)
                {
                    case "1":
                        CadastrarCliente(cadastro);
                        break;
                    case "2":
                        ListarClientes(cadastro);
                        break;
                    case "0":
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        private static void CadastrarCliente(CadastroCliente cadastro)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? string.Empty;
            Console.Write("E-mail: ");
            string email = Console.ReadLine() ?? string.Empty;
            Console.Write("Idade: ");
            string entradaIdade = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(entradaIdade, out int idade))
            {
                Console.WriteLine("Informe um número inteiro para a idade.");
                return;
            }

            try
            {
                cadastro.Cadastrar(nome, email, idade);
                Console.WriteLine("Cliente cadastrado com sucesso!");
            }
            catch (ArgumentException erro)
            {
                Console.WriteLine(erro.Message);
            }
            catch (InvalidOperationException erro)
            {
                Console.WriteLine(erro.Message);
            }
        }

        private static void ListarClientes(CadastroCliente cadastro)
        {
            if (cadastro.Listar().Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            foreach (Cliente cliente in cadastro.Listar())
            {
                Console.WriteLine(
                    $"{cliente.Nome} | {cliente.Email} | {cliente.Idade} anos");
            }
        }
    }
}
```

O namespace ConsoleApp evita usar o nome Console como namespace da classe e mantém System.Console acessível. Execute na raiz:

```bash
dotnet run --project CadastroClientes.Console/CadastroClientes.Console.csproj
```

## Passo 13 Validar a entrega

Execute a suíte e confirme que todos os testes passaram. No console, verifique:

| Ação | Resultado esperado |
| --- | --- |
| Listar antes de cadastrar | Exibir que não há clientes. |
| Cadastrar Ana Silva, ana@email.com, 25 | Confirmar cadastro e mostrar os dados na listagem. |
| Cadastrar outro cliente com ANA@EMAIL.COM | Informar duplicidade e manter apenas um cliente. |
| Informar nome vazio, e-mail inválido ou idade 17 | Informar o erro sem adicionar o cliente. |
| Informar texto no campo idade | Informar que é necessário um número inteiro. |
| Cadastrar cliente com outro e-mail | Manter os dois clientes na listagem. |
| Escolher 0 e abrir novamente o aplicativo | Encerrar; ao reabrir, começar sem clientes. |

## Critérios de conclusão

- A solução compila usando net10.0 e o console utiliza Program.Main.
- Os testes cobrem dados válidos, dados ausentes, limites, normalização, cadastro, listagem e duplicidade.
- As classes foram construídas com testes introduzidos antes das respectivas implementações.
- As falhas observadas foram relacionadas ao comportamento esperado, sem tratar erros de configuração como validação de regras.
- Nenhum dado inválido ou e-mail duplicado fica armazenado.
- O console utiliza as classes testadas e apresenta mensagens compreensíveis.

Perguntas para discussão: qual teste levou você a escrever uma validação? O que aconteceu quando a implementação mudou? Ter todos os testes verdes significa que todos os comportamentos possíveis foram testados?

## Desafio opcional

Acrescente uma profissão obrigatória, com até 60 caracteres, ou uma busca de cliente por e-mail. Antes de alterar o domínio, escreva o teste do comportamento escolhido, observe a falha e repita o ciclo. Atualize o console somente depois dos testes verdes.

## Referências técnicas

- Microsoft Learn — templates do SDK e opção use-program-main: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates
- Microsoft Learn — formato de solução no .NET 10: https://learn.microsoft.com/en-us/dotnet/core/compatibility/sdk/10.0/dotnet-new-sln-slnx-default
- Microsoft Learn — testes C# com dotnet test e xUnit: https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-csharp-with-xunit

Nota de preparação: os comandos e exemplos foram revisados com apoio da documentação. O ambiente de elaboração não possui o SDK do .NET instalado; a solução não foi compilada nem executada aqui.
