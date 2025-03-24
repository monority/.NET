docker run -it ubuntu
docker run -it debian

mkdir app

echo "Hello world" > app/config.txt

apt update
apt install nano

nano config.txt

cat config.txt