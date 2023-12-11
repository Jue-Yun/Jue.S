@echo off
echo 正在安装Jues.Service服务
sc create Jues.Service binPath=".\Jues.Service.exe" displayname="决云后端服务"
pause