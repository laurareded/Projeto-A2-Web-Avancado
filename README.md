# 📚 DracarysApi


## 🧾 Descrição

> "Esta API simula o gerenciamento de elementos do universo de Game of Thrones. Permite cadastrar Casas, Personagens e Dragões, vinculando-os de acordo com suas respectivas relações dentro do contexto fictício da série."

---

## 👥 Integrantes da Dupla

- Laura Reded de Melo - [laurareded](https://github.com/laurareded)
- Maiara Regina Wojciekovski - [MayRww](https://github.com/MayRww)

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C# (.NET 8)
- **Framework:** ASP.NET Core
- **ORM:** Entity Framework Core
- **Banco de Dados:** MySQL
- **Front-end:** JavaScript
- **Versionamento:** Git + GitHub

---

## 🚀 Como Executar o Projeto

### Pré-requisitos

- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download)
- MySQL instalado
- Git instalado

### Passos

```bash
# 1. Clone o repositório
git clone https://github.com/laurareded/Projeto-A2-Web-Avancado.git

# 2. Acesse a pasta do projeto
cd Projeto-A2-Web-Avancado/DracarysApi

# 3. Restaure os pacotes
dotnet restore

# 4. Aplique as migrações para criar o banco de dados
dotnet ef database update

# 5. Execute a aplicação 
dotnet run

# 6. Caso queira abrir o swagger, digite no navegador:
http://localhost:5161/swagger


## 🌐 Como Executar o Front-End

Para rodar o front-end, siga os seguintes passos:

1- Acesse a pasta "front" e abra o arquivo "index.html"
2- Clique com o botão direito em index.html e selecione "Open with live server"
⚠️ Importante: Certifique-se de que a extensão Live Server está instalada e ativada no VS Code.
O projeto também precisa estar rodando (com dotnet run)






