# SeventhServers

Run Database

docker run --name seventhdb -e POSTGRES_PASSWORD=seventh -e POSTGRES_USER=seventh -e POSTGRES_DB=Seventh -p 5432:5432 -d postgres


Run RabbitMQ

docker run -d --hostname my-rabbitmq-server --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management