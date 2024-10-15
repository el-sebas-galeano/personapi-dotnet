
# Usa la imagen oficial de SQL Server 2019
FROM mcr.microsoft.com/mssql/server:2019-latest

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /usr/src/app

# Cambiar a usuario root para instalar las herramientas
USER root

# Instalar las herramientas de SQL Server (mssql-tools) y otras dependencias necesarias
RUN apt-get update && apt-get install -y curl gnupg2 apt-transport-https && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && ACCEPT_EULA=Y apt-get install -y msodbcsql17 mssql-tools unixodbc-dev && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# Copiar los archivos necesarios
COPY entrypoint.sh /usr/src/app/entrypoint.sh
COPY persona_ddl_ms.sql /usr/src/app/persona_ddl_ms.sql
COPY persona_dml_ms.sql /usr/src/app/persona_dml_ms.sql

# Otorgar permisos de ejecución a los scripts
RUN chmod +x /usr/src/app/entrypoint.sh

# Exponer el puerto predeterminado de SQL Server
EXPOSE 1433

# Configura el script de entrada para que se ejecute cuando el contenedor se inicie
ENTRYPOINT ["/bin/bash", "/usr/src/app/entrypoint.sh"]
