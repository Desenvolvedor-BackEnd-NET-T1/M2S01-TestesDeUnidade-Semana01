# Registro de ciclos TDD

## Ciclo 1 - Cliente com dados válidos
- Teste escrito: `CriarCliente_ComDadosValidos_DeveGuardarOsDados`.
- Falha observada: a classe `Cliente` ainda não existia e o teste falhava por compilação/ausência de comportamento.
- Alteração que fez passar: foi criada a estrutura mínima da classe `Cliente` com propriedades e atribuição direta dos dados válidos no construtor.

## Ciclo 2 - Nome obrigatório e validações de limite
- Teste escrito: `CriarCliente_ComNomeAusente_DeveRejeitar` e `CriarCliente_ComNomeCurto_DeveRejeitar`.
- Falha observada: o construtor aceitava nomes vazios e com menos de 3 caracteres.
- Alteração que fez passar: foi adicionada validação com `string.IsNullOrWhiteSpace`, `Trim()` e limite de 3 a 100 caracteres.

## Ciclo 3 - E-mail e duplicidade
- Teste escrito: `CriarCliente_ComEmailInvalido_DeveRejeitar` e `Cadastrar_ComEmailDuplicado_DeveRejeitar`.
- Falha observada: o e-mail podia ser nulo, com formato inválido e sem prevenção de duplicidade.
- Alteração que fez passar: foi validado o formato simplificado do e-mail e implementada a checagem de duplicidade ignorando maiúsculas/minúsculas no cadastro.

## Ciclo 4 - Idade e integração do console
- Teste escrito: `CriarCliente_ComIdadeInvalida_DeveRejeitar`.
- Falha observada: a idade não era limitada ao intervalo esperado.
- Alteração que fez passar: foi aplicada a regra de aceitar apenas idades entre 18 e 120 anos e, em seguida, o menu do console foi conectado ao domínio testado.
