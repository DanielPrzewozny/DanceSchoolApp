@echo off
echo "[1] Starting a Docker ... "
:repeat
docker ps -a > output.txt || ( timeout /t 5 && goto :repeat; )
echo " ... Docker started ... "
timeout /t 5
call docker-compose up -d
pause >nul
echo " ... Docker started ... "