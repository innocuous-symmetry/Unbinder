# get .net 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

COPY . ./src
WORKDIR /src

RUN dotnet build -o /app
RUN dotnet publish -o /publish

ENV AWS_S3_URL=$AWS_S3_URL
ENV AWS_ACCESS_KEY=$AWS_ACCESS_KEY
ENV AWS_SECRET_KEY=$AWS_SECRET_KEY
ENV AWS_BUCKET_NAME=$AWS_BUCKET_NAME

WORKDIR /publish

EXPOSE 80
ENTRYPOINT ["./Unbinder"]