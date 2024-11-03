# Usar a imagem do Node.js como base
FROM node:14 AS build

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia o package.json e o package-lock.json
COPY package*.json ./

# Instala as dependências da aplicação
RUN npm install

# Copia o restante do código da aplicação
COPY . .

# Compila a aplicação para produção
RUN npm run build

# Usar uma imagem de produção para servir os arquivos estáticos
FROM nginx:alpine

# Copia os arquivos da build do React para o diretório padrão do Nginx
COPY --from=build /app/build /usr/share/nginx/html

# Expondo a porta em que o Nginx irá rodar
EXPOSE 80

# Comando para iniciar o Nginx
CMD ["nginx", "-g", "daemon off;"]
