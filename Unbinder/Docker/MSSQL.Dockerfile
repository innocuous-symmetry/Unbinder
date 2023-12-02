# build from sql server image
FROM mcr.microsoft.com/mssql/server:2022-latest

# set environment variables
ENV ACCEPT_EULA=Y
ENV MSSQL_PID Express
ENV SA_PASSWORD=$DB_PASSWORD

# run the command to start sql server
CMD /opt/mssql/bin/sqlservr
