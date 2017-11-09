@echo off

cd /d %~dp0
cd ..

call Ant.Service.ConfigCenter.exe start

echo; 

echo success

echo; 
echo; 


pause