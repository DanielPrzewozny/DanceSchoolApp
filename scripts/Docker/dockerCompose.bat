@echo on
echo "[1] Start-and-poll Docker in the background till it can be started... "
start /B docker-polling-start.bat
echo "[2] Start Docker in the background ... "
"C:\Program Files\Docker\Docker\Docker Desktop.exe"
set /p id="Finish"
pause >nul