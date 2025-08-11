@echo off
echo 开始重命名文件...

:: 遍历当前目录下所有以Mcpe开头的.cs文件
for %%f in (Mcpe*.cs) do (
    :: 获取文件名（不包括扩展名）
    set "filename=%%~nf"
    :: 获取文件扩展名
    set "extension=%%~xf"
    :: 获取文件所在目录
    set "filepath=%%~dpf"
    
    :: 使用延迟变量扩展
    setlocal enabledelayedexpansion
    
    :: 将Mcpe替换为Mcbe
    set "newname=!filename:Mcpe=Mcbe!"
    
    :: 重命名文件
    ren "%%f" "!newname!!extension!"
    
    :: 显示重命名信息
    echo 将 "%%f" 重命名为 "!newname!!extension!"
    
    endlocal
)

echo.
echo 文件重命名完成！
echo.
pause