# Usar a imagem base do OpenJDK
FROM openjdk:11-jdk-slim

# Diretório de trabalho
WORKDIR /app

# Clonar o repositório do GitHub
RUN apt-get update && apt-get install -y git \
    && git clone https://github.com/Eduardogdfrt/Oficina2.git \
    && cd Oficina2/Back \
    && ./mvnw package -DskipTests

# Copiar o JAR gerado para o contêiner
COPY Oficina2/Back/target/*.jar app.jar

# Comando para executar a aplicação
ENTRYPOINT ["java", "-jar", "/app/app.jar"]
 