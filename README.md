<h1 align="center">
   🌱 Gerenciamento de Pomar
</h1>

<h4 align="center">
   🚧 Em construção 🚧
</h4>

Tabela de conteúdos
=================
<!--ts-->
   * [Objetivo](#-objetivo)
   * [Definição](#-definicao)
   * [Como executar o projeto](#-como-executar-o-projeto)
     * [Pré-requisitos](#pré-requisitos)
     * [Rodando o Backend (servidor)](#user-content--rodando-o-backend-servidor)
   * [Tecnologias](#-tecnologias)
     * [Server](#user-content-server--nodejs----typescript)   
   * [Como contribuir no projeto](#-como-contribuir-no-projeto)
   * [Autor](#-autor)
<!--te-->


## 💻 Objetivo

🌱 Desenvolver uma aplicação para gerenciar o pomar de um produtor de frutas.

---

## ⚙️ Definição

O pomar precisa catalogar suas plantas, organizando-as em grupos e espécies e manter um histórico da colheita. Sendo assim a aplicação tem os seguintes requisitos:

- Gerenciar as árvores, espécies de árvores e grupos de árvores.
- Gerenciar a colheita que pode ser realizada por árvore ou grupo de árvores.
- Relatório ou telas de visualização das colheitas incluindo filtros de árvore, grupo de árvore, espécie e período.
---
## ✍️ Funcionalidades

- [x] API:
  - [x] Usuários (sem autenticação);
  - [x] Crud de Espécies;
  - [x] Crud de Grupo de Árvores;
  - [x] Crud de Árvores;
  - [x] Crud de Colheitas;
  - [x] Autenticação com JWT para todas as rotas exceto de Usuário;
- [ ] Web:
  - [ ] Tela de login com possibilidade de login e cadastro para acesso;
  - [ ] Telas de cadastro e listagem de todas rotas da API;
  - [ ] Tela de relatório e filtros;
- [ ] Mobile:
  - [ ] Tela de login e cadastro
  - [ ] Telas de cadastro e listagem de todas a rotas da API;
  - [ ] Tela de relatórios e filtros;

---

## 🚀 Como executar o projeto

Por hora este projeto possui somente o Backend:
1. Backend (pasta Pomar)

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [.NET Core 3.1](https://dotnet.microsoft.com/download).
Além disto é bom ter um editor para trabalhar com o código como [VSCode](https://code.visualstudio.com/)

#### 🎲 Rodando o Backend (servidor)

```bash
# Clone este repositório
$ git clone https://github.com/andrebsoares/Pomar.git && cd Pomar

# Vá para a pasta ...Pomar\Pomar\Pomar - Inicializa o banco
$ dotnet ef database update

# Execute a aplicação
$ dotnet run

# O servidor inciará na porta:5001 - acesse https://localhost:5001

```
---

## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

#### **Server**  ([.NET Core 3.1](https://dotnet.microsoft.com/download))

-   **[Migrations]**
-   **[CORS]**
-   **[LocalDB]**
-   **[JWT]**
---