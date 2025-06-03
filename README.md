# SIRECE - Sistema Integrado de Resiliência Energética e Comunicação de Emergência

## 📌 Sobre o Projeto

O **SIRECE** é um sistema desenvolvido em **C# (Console App)** com foco em **resposta a falhas energéticas** causadas por eventos climáticos extremos.  
Ele simula um ambiente operacional onde falhas podem ser registradas manualmente ou por sensores, e alertas são gerados automaticamente com base nessas falhas.

---

## ⚙️ Funcionalidades Principais

- 🔐 **Login de usuário com autenticação**
- ⚡ **Registro de falhas de energia**
- 🚨 **Geração automática de alertas com base na falha**
- 🧾 **Visualização de logs e relatórios estatísticos**
- 🤖 **Simulação de sensores (vento, temperatura, inundação, etc.)**
- 📝 **Exportação de relatórios para arquivos .txt na pasta Downloads**

---

## 🧠 Regras de Negócio

- Toda falha registrada gera automaticamente um alerta.
- O alerta herda a gravidade e local da falha e é enviado para um órgão apropriado, conforme a origem (ex: vento → Defesa Civil).
- Apenas usuários autenticados podem acessar o sistema.
- O sistema trata entradas inválidas e exibe mensagens claras para o usuário.

---

## 💻 Tecnologias Utilizadas

- Linguagem: **C#**
- Plataforma: **.NET 6 - Console Application**
- IDE recomendada: **Visual Studio**
- Estrutura baseada em:
  - `Models/` → classes de dados
  - `Services/` → lógica de negócio
  - `Program.cs` → ponto de entrada e menu

---

## 📤 Exportação de Relatórios

O relatório pode ser exportado para um arquivo `.txt` automaticamente salvo em:

```
C:\Users\SeuUsuario\Downloads\Relatorio_SIRECE_YYYYMMDD_HHMM.txt
```

---

## 🚀 Execução

1. Abra o projeto no Visual Studio.
2. Execute a aplicação (`Ctrl + F5`).
3. Faça login com o usuário:
   ```
   Usuário: admin
   Senha: 1234
   ```
4. Navegue pelo menu e explore as funcionalidades.

---

## 🛠️ Desenvolvido por:

* Adriano Lopes - RM98574
* Henrique de Brito - RM98831
* Rodrigo Lima - RM98326 
