# Dockerfile

# Usar a imagem base do Java
FROM openjdk:11-jdk-slim

# Definir o diretório de trabalho
WORKDIR /app

# Copiar o JAR da aplicação para o container
COPY target/myapp.jar myapp.jar

# Executar a aplicação
ENTRYPOINT ["java", "-jar", "myapp.jar"]
