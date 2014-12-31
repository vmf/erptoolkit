' SysIo.vbs - This file is part of ERPToolkit
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

'ERPToolkit_WriteToFile "c:\files\mytext.txt", "abc"
public sub ERPToolkit_WriteToFile(byval filePath, byval content)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Write a content to a text file
    '/// </summary>
    '/// <param name="filePath">Path to the file</param>
    '/// <param name="content">Content</param>
	oSysIo.WriteToFile filePath, content
end sub

'msgbox(ERPToolkit_ChooseFile("c:\files", "XML Files (*.xml)|*.xml", ""))
public function ERPToolkit_ChooseFile(byval strCurrentPath, byval strFilter, byval initialDir)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Used to choose a file and gets its path
    '/// </summary>
    '/// <param name="strCurrentPath">Will be returned if user cancels the dialog</param>
    '/// <param name="strFilter">Filter(kind of file)</param>
    '/// <param name="initialDir">Initial Directory(Can be ommited)</param>
    '/// <returns>file path if selected or the current path if dialog be canceled</returns>
	ERPToolkit_ChooseFile = oSysIo.ChooseFile(strCurrentPath, strFilter, initialDir)
end function

'msgbox(ERPToolkit_ChoosePath("c:\files"))
public function ERPToolkit_ChoosePath(byval strCurrentPath)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Opens the dialog to choose a folder and return its path
    '/// </summary>
    '/// <param name="strCurrentPath">The current data field</param>
    '/// <returns>Returns the current data field if the dialog be canceled</returns>
	ERPToolkit_ChoosePath = oSysIo.ChoosePath(strCurrentPath)
end function

'msgbox(ERPToolkit_SaveFile("c:\files", "Applications (*.exe)|*.exe", ""))
public function ERPToolkit_SaveFile(byval strCurrentPath, byval strFilter, byval initialDir)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Opens a dialog to choose where to save the file
    '/// </summary>
    '/// <param name="strCurrentPath">Current path</param>
    '/// <param name="strFilter">Kind of file(Filter)</param>
    '/// <param name="initialDir">Initial directory</param>
    '/// <returns>Selected path or the current path</returns>
	ERPToolkit_SaveFile = oSysIo.SaveFile(strCurrentPath, strFilter, initialDir)
end function

'ERPToolkit_CopyTo "c:\files", "c:\files\sub-files", "*.txt"
public sub ERPToolkit_CopyTo(byval sourceDir, byval destDir, byval pattern)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Copy files to another directory
    '/// </summary>        
    '/// <param name="sourceDir">Directory that contains the files</param>
    '/// <param name="destDir">Directory of destination</param>
    '/// <param name="pattern">File extension that we want to copy</param>
	oSysIo.CopyTo sourceDir, destDir, pattern
end sub

'msgbox(ERPToolkit_IsValidFile("c:\files\myfile.txt", "txt"))
public function ERPToolkit_IsValidFile(byval path, byval extension)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Used to validate the file existence and extension
    '/// </summary>
    '/// <param name="path">Path to the file</param>
    '/// <param name="extension">File extension</param>
    '/// <returns>The truth</returns>
	ERPToolkit_IsValidFile = oSysIo.IsValidFile(path, extension)
end function

'ERPToolkit_ReplaceText "c:\files\myfile.txt", "abc", "def"
public sub ERPToolkit_ReplaceText(byval filePath, byval findWhat, byval replaceWith)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Replaces(Refactor)
    '/// </summary>
    '/// <param name="filePath">Path to the file</param>
    '/// <param name="findWhat">Text to find</param>
    '/// <param name="replaceWith">Text to replace if found</param>
	oSysIo.ReplaceText filePath, findWhat, replaceWith
end sub

'msgbox(ERPToolkit_GetFileText("c:\files\myfile.txt"))
public function ERPToolkit_GetFileText(byval filePath)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets a text(content) of a text file
    '/// </summary>
    '/// <param name="filePath">Path to the file</param>
    '/// <returns>Content of the file</returns>
	ERPToolkit_GetFileText = oSysIo.GetFileText(filePath)
end function

'ERPToolkit_DeleteDirectory "c:\files\sub-files"
public sub ERPToolkit_DeleteDirectory(byval directoryPath)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Delete the subdirectories, files and the directory itself
    '/// </summary>
    '/// <param name="directoryPath">Path to the directory</param>
	oSysIo.DeleteDirectory directoryPath
end sub

'msgbox(ERPToolkit_GetProductName("c:\files\pEngineCode.exe"))
public function ERPToolkit_GetProductName(byval filePath)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets the product name of some package
    '/// </summary>
    '/// <param name="filePath">Path to the file</param>
    '/// <returns>Product name</returns>
	ERPToolkit_GetProductName = oSysIo.GetProductName(filePath)
end function

'msgbox(ERPToolkit_GetFileName("c:\files\pEngineCode.exe"))
public function ERPToolkit_GetFileName(byval filePath)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets the file name of some file
    '/// </summary>
    '/// <param name="filePath">Path to the file</param>
    '/// <returns>File name</returns>
	ERPToolkit_GetFileName = oSysIo.GetFileName(filePath)
end function

'msgbox(ERPToolkit_GetLegalTrademarks("C:\symphony_packs\SYMFP2014R2\Install\Comercial_Vendas.exe"))
public function ERPToolkit_GetLegalTrademarks(byval filePath)
Dim oSysIo
    Set oSysIo = CreateObject("ERPToolkit.Class.SysIo")
	'Assigns to the Values object the returned object
	oSysIo.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets the legal trademarks
    '/// </summary>
    '/// <param name="filePath">File path</param>
	ERPToolkit_GetLegalTrademarks = oSysIo.GetLegalTrademarks(filePath)
end function

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