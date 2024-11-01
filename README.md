# Upload para o Google Drive usando Google Drive API e C#
![Badge License](https://img.shields.io/badge/license-MIT-green)
![Badge Release](https://img.shields.io/badge/release-May-blue)

Este projeto tem como finalidade, ensinar como enviar arquivos locais para dentro de uma pasta no Google Drive, usando a Google Drive API, dentro do <a href="https://console.cloud.google.com/">Google Cloud Console</a>

# 🔴 Execute todos os passos abaixo para o funcionamento correto do código.

# ⚙️ Configurações iniciais
Para podermos iniciar o projeto, precisamos primeiramente criar e configurar um projeto no <a href="https://console.cloud.google.com/">Google Cloud Console</a>, pois sem ele não teremos acesso à API. Para isso seguiremos os seguintes passos:
* Criar um projeto
* Na aba <b>Ativar APIs e serviços</b>, ative a Google Drive API
* Na mesma tela, clique em <b>Criar credenciais</b>, selecionando Dados do usuário, preenchendo todos os campos obrigatórios, não colocando escopos e em ID do Cliente OAuth, selecione "App para Computador"
* Na aba <b>OAuth consent screen</b>, publique o projeto.
* Baixe as credenciais, pois elas serão necessárias para o funcionamento do projeto.
* Coloque as credenciais dentro do caminho <b>"UploadFileToGoogleDrive-WindowsForms\SendFileToDriveWinForm\bin\Debug"</b>

Na parte do código, antes de tudo, precisamos baixar o pacote <b>Google.Apis.Drive.v3</b> através do NuGet, para conseguirmos executar o código.

# 🔨 Mudanças necessárias
Há algumas partes do código em que alterações serão necessárias, para que o projeto funcione de acordo com as suas necessidades:
* Na linha 32, selecione o diretório inicial para seleção de arquivos
* Na linha 86, insira o nome do arquivo de crendenciais armazenado dentro da pasta Debug (com .json no final)
* Na linha 92, insira o nome que você deseja que o arquivo seja exibido no Google Drive

# ✔️ Tecnologias utilizadas
* C#
* Visual Studio
* Google Drive API
