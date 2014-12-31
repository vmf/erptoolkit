' General.vbs - This file is part of ERPToolkit
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


'msgbox(ERPToolkit_Filter("banana", "na", true, false))
public function ERPToolkit_Filter(byval item, byval filter, byval matchCase, byval matchWhole)
Dim oGeneral
	Set oGeneral = CreateObject("ERPToolkit.Class.General")
	'Assigns to the Values object the returned object
	oGeneral.Values = GetBasicValues()
	
	'/// <summary>
    '/// Filter
    '/// </summary>
    '/// <param name="item">Item</param>
    '/// <param name="filter">Filter</param>
    '/// <param name="matchCase">Is it a match case search ?</param>
    '/// <param name="matchWhole">Is it a math whole word only search ?</param>
    '/// <returns>'true' - it was found. 'false' - it wasn't found</returns>
	ERPToolkit_Filter = oGeneral.Filter(item, filter, matchCase, matchWhole)
end function

'msgbox(ERPToolkit_IsTherePrefix("sym_test", "sym"))
public function ERPToolkit_IsTherePrefix(byval str, byval prefix)
Dim oGeneral
	Set oGeneral = CreateObject("ERPToolkit.Class.General")
	'Assigns to the Values object the returned object
	oGeneral.Values = GetBasicValues()
	
	'/// <summary>
    '/// Checks if the string has the prefix
    '/// </summary>
    '/// <param name="str">String</param>
    '/// <param name="prefix">Prefix</param>
    '/// <returns>The truth</returns>
	ERPToolkit_IsTherePrefix = oGeneral.IsTherePrefix(str, prefix)
end function

'msgbox(ERPToolkit_GetRootPath("\\test\subfolder\"))
public function ERPToolkit_GetRootPath(byval path)
Dim oGeneral
	Set oGeneral = CreateObject("ERPToolkit.Class.General")
	'Assigns to the Values object the returned object
	oGeneral.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets the Root path
    '/// </summary>
    '/// <param name="path">Path that we will be used to get the root path</param>
    '/// <returns>Root path</returns>
	ERPToolkit_GetRootPath = oGeneral.GetRootPath(path)
end function

'msgbox(ERPToolkit_GetMappedPath("c:\files\sub-files\"))
public function ERPToolkit_GetMappedPath(byval localPath) 'Review
Dim oGeneral
	Set oGeneral = CreateObject("ERPToolkit.Class.General")
	'Assigns to the Values object the returned object
	oGeneral.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets the mapped path from a local path
    '/// </summary>
    '/// <param name="localPath">The local path</param>
    '/// <returns>Mapped path</returns>
	ERPToolkit_GetMappedPath = oGeneral.GetMappedPath(localPath)
end function

'msgbox(ERPToolkit_GetWorkingDirectory("C:\files\test.vbs"))
public function ERPToolkit_GetWorkingDirectory(byval path)
Dim oGeneral
	Set oGeneral = CreateObject("ERPToolkit.Class.General")
	'Assigns to the Values object the returned object
	oGeneral.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets the working directory of a file
    '/// </summary>
    '/// <param name="path">Path to the file</param>
    '/// <returns>Working directory</returns>
	ERPToolkit_GetWorkingDirectory = oGeneral.GetWorkingDirectory(path)
end function

'msgbox(ERPToolkit_CombinePath("c:\files", "sub-files\myfiles"))
public function ERPToolkit_CombinePath(byval path1, byval path2)
Dim oGeneral
	Set oGeneral = CreateObject("ERPToolkit.Class.General")
	'Assigns to the Values object the returned object
	oGeneral.Values = GetBasicValues()
	
	'/// <summary>
    '/// Combine 2 paths
    '/// </summary>
    '/// <param name="path1">Path 1</param>
    '/// <param name="path2">Path 2</param>
    '/// <returns>Combined path</returns>
	ERPToolkit_CombinePath = oGeneral.CombinePath(path1, path2)
end function

'msgbox(ERPToolkit_GetWithoutString("testmytext", "my"))
public function ERPToolkit_GetWithoutString(byval str, byval without)
Dim oGeneral
	Set oGeneral = CreateObject("ERPToolkit.Class.General")
	'Assigns to the Values object the returned object
	oGeneral.Values = GetBasicValues()
	
	'/// <summary>
    '/// Returns a string without another string. It can be a prefix, sufix
    '/// os in the middle of the string
    '/// </summary>
    '/// <param name="str">string to be updated</param>
    '/// <param name="without">string to be removed</param>
    '/// <returns>string replaced(if 'without' found) | string untouched(if 'without' not found)</returns>
	ERPToolkit_GetWithoutString = oGeneral.GetWithoutString(str, without)
end function

'msgbox(ERPToolkit_UpdateFileExtension("c:\files\myfile.txt", "vbs"))
public function ERPToolkit_UpdateFileExtension(byval filePath, byval newFileExtension)
Dim oGeneral
	Set oGeneral = CreateObject("ERPToolkit.Class.General")
	'Assigns to the Values object the returned object
	oGeneral.Values = GetBasicValues()
	
	'/// <summary>
    '/// Updates the file Extension
    '/// </summary>
    '/// <param name="filePath">File path</param>
    '/// <param name="newFileExtension">New file extension</param>
    '/// <returns>Returns file with the new extension</returns>
	ERPToolkit_UpdateFileExtension = oGeneral.UpdateFileExtension(filePath, newFileExtension)
end function

'msgbox(ERPToolkit_GetCharPosition("abc", "b"))
public function ERPToolkit_GetCharPosition(byval str, byval ch)
Dim oGeneral
	Set oGeneral = CreateObject("ERPToolkit.Class.General")
	'Assigns to the Values object the returned object
	oGeneral.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets a char in a corresponding string
    '/// </summary>
    '/// <param name="str">string that we want to get the char</param>
    '/// <param name="ch">char</param>
    '/// <returns>Char position in the string or -1</returns>
	ERPToolkit_GetCharPosition = oGeneral.GetCharPosition(str, ch)
end function

'ERPToolkit_GetStringFromList
public sub ERPToolkit_GetStringFromList()
Dim oGeneral, oMethodInfo, oSysEnv
	Set oGeneral = CreateObject("ERPToolkit.Class.General")
	oGeneral.Values = GetBasicValues()
	
	'Class responsible for getting method informations from a type
	Set oMethodInfo = CreateObject("ERPToolkit.App.Class.MethodInformation")
	oMethodInfo.Values = GetBasicValues()
	
	'Object(type) that we want to get method informations
	Set oSysEnv = CreateObject("ERPToolkit.Class.SysEnvironment")
	
	'Gets the string list from a generic list 'List<string>'
	msgbox(oGeneral.GetStringFromList(oMethodInfo.GetPublicMethodInfoList(oSysEnv.GetType), ";"))
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