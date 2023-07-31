FROM node:18.17.0 AS build
WORKDIR /app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build --prod --configuration=production

FROM nginx:1.19.5-alpine
COPY --from=build /app/dist/tariff-comparison-web /usr/share/nginx/html
CMD sed -i -e 's,REPLACE_API_URL,'"$API_URL"',' /usr/share/nginx/html/main*.js && nginx -g 'daemon off;'
