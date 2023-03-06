#Programa de Processamento de Folha de Pagamento
Este programa é uma aplicação console escrita em C# que lê arquivos CSV contendo informações de pagamento de funcionários, processa essas informações e envia os dados processados para uma API RESTful.

O programa é executado em três etapas principais:

* O usuário informa o caminho da pasta contendo os arquivos CSV a serem processados.

* Os arquivos CSV são lidos e as informações de pagamento são processadas.

* Os dados processados são enviados para uma API RESTful através de uma requisição HTTP POST.

Ao final do processamento, o programa exibe uma mensagem informando que o processamento foi finalizado e que os arquivos processados podem ser baixados em https://localhost:7248/Home/Payroll.

## Requisitos
+ .NET 6.0 ou superior
+ Conexão com a internet

### Clone este repositório em sua máquina.

### Abra um terminal ou prompt de comando na pasta raiz do projeto.

### Execute o comando dotnet run para iniciar o programa.

### Quando solicitado, informe o caminho da pasta contendo os arquivos CSV a serem processados.

### Aguarde o processamento dos arquivos.

## Ao final do processamento, os arquivos processados podem ser baixados em https://localhost:7248/Home/Payroll.