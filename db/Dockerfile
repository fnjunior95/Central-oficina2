FROM mysql:latest


RUN apt-get update && apt-get install -y git

RUN git clone https://github.com/Eduardogdfrt/Oficina2.git /tmp/Oficina2


COPY /tmp/Oficina2/db/backup_ellp.sql /docker-entrypoint-initdb.d/backup_ellp.sql


CMD ["SqlServer"]
