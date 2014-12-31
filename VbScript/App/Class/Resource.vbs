' Resource.vbs - This file is part of ERPToolkit
' Copyright (C) 2014  Vinícius M. Freitas
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

'ERPToolkit_ExtractResource "C:\files\FontReg_x86-32.exe", "ERPToolkit.FontReg.FontReg_x86-32.exe"
public sub ERPToolkit_ExtractResource(byval filePath, byval resource)
Dim oRes
	Set oRes = CreateObject("ERPToolkit.App.Class.Resource")
	oRes.Values = GetBasicValues()
	
	'/// <summary>
    '///     Extract a resource from ERPToolkit
    '/// </summary>
    '/// <param name="path">The file path that the resource will be extracted</param>
    '/// <param name="resource">Resource path</param>
	oRes.ExtractResource filePath, resource
end sub	

public function GetBasicValues()
Dim oStoreValues
	
	'Creates a new object
	'The ERPToolkit.App.Class.StoreValues object is the ERPToolkit's way to pass information
	'through classes
	Set oStoreValues = CreateObject("ERPToolkit.App.Class.StoreValues")
	'Defines the language
	oStoreValues.Language = "en-US"
    oStoreValues.ResourceManager = "ERPToolkit.Lang.res_en_us"	
		
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