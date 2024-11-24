@echo off
REM Verifica se o Docker está instalado
docker --version >nul 2>&1
IF ERRORLEVEL 1 (
    echo Docker não está instalado. Por favor, instale o Docker e tente novamente.
    pause
    exit /b 1
)

REM Verifica se o docker-compose está instalado
docker-compose --version >nul 2>&1
IF ERRORLEVEL 1 (
    echo Docker Compose não está instalado. Por favor, instale o Docker Compose e tente novamente.
    pause
    exit /b 1
)

REM Executa o arquivo dsv.yaml com docker-compose
echo Executando docker-compose com o arquivo dsv.yaml...
docker-compose -f dsv.yaml up -d

REM Verifica se o comando foi bem-sucedido
IF ERRORLEVEL 1 (
    echo Ocorreu um erro ao executar o docker-compose.
    pause
    exit /b 1
)

echo Docker Compose executado com sucesso.
pause