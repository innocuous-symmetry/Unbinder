# build from sql server image
FROM mcr.microsoft.com/mssql/server:2022-latest

# set environment variables
ENV ACCEPT_EULA=Y
ENV MSSQL_PID Express
ENV SA_PASSWORD=$DB_PASSWORD

# WORKDIR /db
# COPY ../DB/SQL/create_database.sql .

# run the sql script
# CMD /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P fhhwergaiuh12480y53 -d master -i create_database.sql

# run the command to start sql server
CMD /opt/mssql/bin/sqlservr
