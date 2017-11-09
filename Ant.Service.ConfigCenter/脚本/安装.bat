@echo off

cd /d %~dp0
cd ..

call Ant.Service.ConfigCenter.exe install

echo; 

echo success

echo; 
echo; 


pause