# Dockerfile

# Usar a imagem base do Java
FROM openjdk:11-jdk-slim

# Definir o diretório de trabalho
WORKDIR /app

# Copiar o JAR da aplicação para o container
COPY target/myapp.jar myapp.jar

# Executar a aplicação
ENTRYPOINT ["java", "-jar", "myapp.jar"]

# Usar a imagem oficial do MySQL
FROM mysql:latest

# Adicionar um script de inicialização (opcional)
COPY ./init.sql /docker-entrypoint-initdb.d/

# Definir variáveis de ambiente
ENV MYSQL_ROOT_PASSWORD=root
ENV MYSQL_DATABASE=mydatabase
ENV MYSQL_USER=user
ENV MYSQL_PASSWORD=password

FROM mysql:latest

RUN apt-get update && apt-get install -y git

RUN git clone https://github.com/Eduardogdfrt/Oficina2.git /tmp/Oficina2

COPY /tmp/Oficina2/db/backup_ellp.sql /docker-entrypoint-initdb.d/backup_ellp.sql

CMD ["mysqld"]