FROM ubuntu:latest

WORKDIR /app
COPY app2-files/ .

RUN apt-get update && apt-get install -y iputils-ping
CMD ["tail", "-f", "/dev/null"]