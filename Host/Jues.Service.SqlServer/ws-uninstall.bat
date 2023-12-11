@echo off
echo 正在卸载Jues.Service服务
sc stop Jues.Service
sc delete Jues.Service
pause