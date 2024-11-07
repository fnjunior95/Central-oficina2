
FROM mysql:latest

# Adicionar um script de inicialização (opcional)
COPY ./init.sql /docker-entrypoint-initdb.d/

# Definir variáveis de ambiente
ENV MYSQL_ROOT_PASSWORD=root
ENV MYSQL_DATABASE=mydatabase
ENV MYSQL_USER=user
ENV MYSQL_PASSWORD=password

