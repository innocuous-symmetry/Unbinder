# get .net 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

ENV AWS_S3_URL=$AWS_S3_URL
ENV AWS_ACCESS_KEY=$AWS_ACCESS_KEY
ENV AWS_SECRET_KEY=$AWS_SECRET_KEY
ENV AWS_BUCKET_NAME=$AWS_BUCKET_NAME

COPY . .
RUN dotnet restore
RUN dotnet publish -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["./Unbinder"]