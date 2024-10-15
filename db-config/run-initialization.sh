#!/bin/bash
# run-initialization.sh
# Esperar a que el servicio de SQL Server esté completamente iniciado
sleep 30s
# Variables de entorno
SA_PASSWORD="${SA_PASSWORD:-TuPassword123!}"  # Asume una contraseña predeterminada si no se especifica

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -i persona_ddl_ms.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -i persona_dml_ms.sql
