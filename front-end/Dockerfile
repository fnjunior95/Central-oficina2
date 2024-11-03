# Usar uma imagem Node.js como base
FROM node:14

# Diretório de trabalho
WORKDIR /app

# Clonar o repositório do GitHub
RUN apt-get update && apt-get install -y git \
    && git clone https://github.com/Eduardogdfrt/Oficina2.git \
    && cd Oficina2/front-end \
    && npm install \
    && npm run build

# Expôr a porta que a aplicação irá usar
EXPOSE 3000

# Comando para iniciar a aplicação
CMD ["npx", "serve", "-s", "Oficina2/front-end/build"]
