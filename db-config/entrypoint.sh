#!/bin/bash
# Iniciar SQL Server en segundo plano
/opt/mssql/bin/sqlservr &

# Esperar a que SQL Server esté disponible
sleep 30s

# Variables de entorno
SA_PASSWORD="${SA_PASSWORD:-TuPassword123!}"  # Asume una contraseña predeterminada si no se especifica

# Ejecutar los scripts DDL y DML
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -i /usr/src/app/persona_ddl_ms.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -i /usr/src/app/persona_dml_ms.sql

# Esperar a que finalice el proceso SQL Server
wait
