FROM node:latest

RUN mkdir -p /app/src
WORKDIR /app

RUN apt-get update && apt-get install --yes bash build-essential python

ADD . /app
RUN npm ci
RUN npm install -g nodemon

EXPOSE 3002
CMD ["node", "/app/src/bin/www"]
