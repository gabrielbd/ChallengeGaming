# ChallangeGaming

ChallangeGaming é uma API desenvolvida para a criação de vários servidores de jogos. Todos esses jogos resultam em ganho ou perda de pontos, e um jogador pode participar de diversos jogos, cada um com seu ranking dos top 100 jogadores.

# Intalação
Para instalar e começar a usar, siga os passos abaixo:

1- Clone o repositório.
2- Crie um banco de dados MongoDB e outro SQL Server.
3- Altere as credenciais de conexão nos arquivos .json das camadas Services.API e Infra com os dados dos bancos de dados criados.
4- Defina o projeto Infra como o projeto de inicialização, abra o terminal com execução para essa camada e execute o comando update-database. Esse comando será responsável por implantar todas as tabelas e colunas necessárias no banco de dados SQL Server.
5- Retorne a definição de inicialização para a API.
6- Compile a solução e, em seguida, execute.
7- A página de inicialização está configurada para o Swagger, mas você também pode utilizar nossos serviços por outras ferramentas.

# Serviços disponiveis
Atualmente, em nosso projeto, temos 4 serviços disponíveis para uso:

- /api/Player - POST - Serviço para criar um PLAYER
- /api/Plays(POST)(idGame/idPlayer) - Serviço responsavel para realizar suas jogadas.
- /api/Plays(GET)(idGame) - Serviço retorna o TOP 100 players em relação a pontuação do game selecionado.

#  Atualmente nossa empresa tem 4 games disponíveis, segue abaixo eles.
  *    PREDIFY - MMORPG    id = 4
  *    PREDIFY - MOBA          id = 5
  *    PREDIFY - FPS             id = 6
  *    PREDIFY - NFT             id = 7
