FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /src
COPY StackUnderflowRDC.Web/StackUnderflowRDC.Web.csproj StackUnderflowRDC.Web/
COPY StackUnderflowRDC.Business/StackUnderflowRDC.Business.csproj StackUnderflowRDC.Business/
COPY StackUnderflowRDC.Data/StackUnderflowRDC.Data.csproj StackUnderflowRDC.Data/
COPY StackUnderflowRDC.Entities/StackUnderflowRDC.Entities.csproj StackUnderflowRDC.Entities/
RUN dotnet restore StackUnderflowRDC.Web/StackUnderflowRDC.Web.csproj
COPY . .
WORKDIR /src/StackUnderflowRDC.Web
RUN dotnet build StackUnderflowRDC.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish StackUnderflowRDC.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet StackUnderflowRDC.Web.dll
