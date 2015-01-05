' Process.vbs - This file is part of ERPToolkit
' Copyright (C) 2014  Vinícius M. Freitas
' Copyright (C) 2015  Vinícius M. Freitas
' 
' This program is free software; you can redistribute it and/or
' modify it under the terms of the GNU General Public License
' as published by the Free Software Foundation; either version 2
' of the License, or (at your option) any later version.
' 
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
' 
' You should have received a copy of the GNU General Public License
' along with this program; if not, write to the Free Software
' Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

'Sets basic values
SetBasicValues

'ERPToolkit_LaunchMsiPackage "C:\PathToMsiFile\sqlncli32.msi", _
'	"C:\files", "i"
public sub ERPToolkit_LaunchMsiPackage(byval packagePath, byval logPath, byval command)
Dim oProcess
	Set oProcess = CreateObject("ERPToolkit.Class.Process")
	'Assigns to the Values object the returned object
	oProcess.Values = GetBasicValues()

	'/// <summary>
    '/// Launch Msi packages
    '/// </summary>
    '/// <param name="packagePath">Package path that'll be called to execution</param>
    '/// <param name="logPath">Log file path</param>
    '/// <param name="command">Command(parameter that'll be passed to msiexec)</param>
	oProcess.LaunchMsiPackage packagePath, logPath, command
end sub

public function GetBasicValues()
Dim oStoreValues
	
	'Creates a new object
	'The ERPToolkit.App.Class.StoreValues object is the ERPToolkit's way to pass information
	'through classes
	Set oStoreValues = CreateObject("ERPToolkit.App.Class.StoreValues")	
	'Defines the language
	oStoreValues.Language = "en-US"
    oStoreValues.ResourceManager = "ERPToolkit.Resources.Lang.res_en_us"
	
	'ERP Software information
	oStoreValues.ErpName = "ERPName"
	oStoreValues.ErpPack = "ReleaseDefinition"
	oStoreValues.ErpPath = "ERPPath"
		
	Set GetBasicValues = oStoreValues
end function

public sub SetBasicValues()	
	'Creates a new object that'll help us with visual resources
	Set oEnableVisualS = CreateObject("ERPToolkit.App.Class.VisualStyles")	
	
	'/// <summary>
    '/// Enables the visual styles
    '/// </summary>        
	oEnableVisualS.EnableVisualStyles
	
	'/// <summary>
    '/// Sets the compatibility of the text rendering
    '/// </summary>
    '/// <param name="enabled">'false' for good looking.</param>
	oEnableVisualS.SetCompatibleTextRenderingDefault false
end sub