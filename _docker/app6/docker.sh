docker run -d \
  --name mysql_container \
  -e MYSQL_ROOT_PASSWORD=rootpassword \
  -e MYSQL_DATABASE=mydb \
  -e MYSQL_USER=myuser \
  -e MYSQL_PASSWORD=mypassword \
  -p 3306:3306 \
  -v mysql_data:/var/lib/mysql \
  mysql:latest

mkdir -p /c/Users/Administrateur/Desktop/_dev/.NET/_docker/app6
echo "<h1>Welcome to My NGINX & MySQL setup!</h1>" > /c/Users/Administrateur/Desktop/_dev/.NET/_docker/app6/index.html


docker run -d \
  --name nginx_container \
  -p 8080:80 \
  -v /c/Users/YourUserName/app6:/usr/share/nginx/html:ro \
  nginx:latest
