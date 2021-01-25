docker cp DbScript.txt mysql:/DbScript.txt
docker exec -it  mysql mysql -uroot -proot -e "create database if not exists dbddd; use dbddd; source DbScript.txt;"