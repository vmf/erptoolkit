@echo -------------------------------------
@echo REGISTERING DLL...
@echo -------------------------------------
C:\Windows\Microsoft.NET\Framework\v4.0.30319\regasm bin/Debug/ERPToolkit.dll /codebase /regfile

@echo -------------------------------------
@echo MOVING GENERATED REGFILE
@echo -------------------------------------
move bin\Debug\ERPToolkit.reg

@echo -------------------------------------
@echo EXECUTING THE REGFILE
@echo -------------------------------------
ERPToolkit.reg

@echo -------------------------------------
@echo DONE! THANK YOU FOR USING ERPTOOLKIT
@echo -------------------------------------

pause
