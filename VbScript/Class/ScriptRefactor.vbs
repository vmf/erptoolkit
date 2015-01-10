' ScriptRefactor.vbs - This file is part of ERPToolkit
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

'ERPToolkit_AddSummary "C:\files\from_script.vbs", _
'	"C:\files\to_script.vbs", _
'	 "<example></example>;" & _
'     "<os>145636</os>;" & _
'     "<developer></developer>;" & _
'     "<email></email>;" & _
'     "<created></created>;" & _
'     "<updated></updated>;" & _
'     "<dependeces></dependeces>;"
public sub ERPToolkit_AddSummary(byval fromFilePath, byval toFilePath, byval tags)
Dim oScriptRefactor
	Set oScriptRefactor = CreateObject("ERPToolkit.Class.ScriptRefactor")	
	'Assigns to the Values object the returned object
	oScriptRefactor.Values = GetBasicValues()
	
	'/// <summary>
    '/// Adds summaries to a corresponding vbscript
    '/// </summary>
    '/// <param name="fromFilePath">Path to the file</param>
    '/// <param name="toFilePath">Path to the file</param>
    '/// <param name="tags">Tags</param>
	oScriptRefactor.AddSummary fromFilePath, toFilePath, tags
	msgbox("OK")
end sub

'ERPToolkit_RemoveWhiteSpaceEnd "C:\files\from_script.vbs", "C:\files\to_script.vbs"
public sub ERPToolkit_RemoveWhiteSpaceEnd(byval fromFilePath, byval toFilePath)
Dim oScriptRefactor
	Set oScriptRefactor = CreateObject("ERPToolkit.Class.ScriptRefactor")
	oScriptRefactor.Values = GetBasicValues()
	
	'/// <summary>
    '/// Removes the white spaces of a text file
    '/// </summary>
    '/// <param name="fromFilePath">Path to the file</param>
    '/// <param name="toFilePath">Path to the file</param>
	oScriptRefactor.RemoveWhiteSpaceEnd fromFilePath, toFilePath
    msgbox("OK")
end sub

'ERPToolkit_ChangeBlock _
'	"C:\files\from_script.vbs", _
'	"C:\files\to_script.vbs", _
'	"Test", _
'	"private sub Test2() " & vbCrlf & _
'	"    Dim a" & vbCrlf & _
'	"end function"
public sub ERPToolkit_ChangeBlock(byval fromFilePath, byval toFilePath, byval oldBlockName, byval newBlock)
Dim oScriptRefactor
    Set oScriptRefactor = CreateObject("ERPToolkit.Class.ScriptRefactor")
	oScriptRefactor.Values = GetBasicValues()
	
	'/// <summary>
	'/// Changes a block('sub' or 'function') of a vbscript
	'/// </summary>
	'/// <param name="fromFilePath">Path to the file</param>
	'/// <param name="toFilePath">Path to the file</param>
	'/// <param name="oldBlockName">Name of the old block(block that'll be replaced)</param>
	'/// <param name="newBlock">Entire new block('sub' or 'function')</param>
	oScriptRefactor.ChangeBlock fromFilePath, toFilePath, oldBlockName, newBlock
    msgbox("OK")
end sub

'ERPToolkit_DefineScriptCase "c:\files\from_script.vbs", "c:\files\to_script.vbs"
public sub ERPToolkit_DefineScriptCase(byval fromFilePath, byval toFilePath)
Dim oScriptRefactor
	Set oScriptRefactor = CreateObject("ERPToolkit.Class.ScriptRefactor")
	oScriptRefactor.Values = GetBasicValues()
	
	'Initializes the language
	'If the language wasn't specified through StoreValues object,
	'English will be the default language
	oScriptRefactor.InitializeLanguage
	
	'/// <summary>
    '/// Defines the script case(case of the keywords)
    '/// </summary>
    '/// <param name="fromFilePath"></param>
    '/// <param name="toFilePath"></param>
    '/// <param name="keywordCase">Optional. The case that will be defined for the keywords.
    '/// "D" - Default,
    '/// "L" - Lower Case,
    '/// "U" - Upper Case
    '/// </param>
	oScriptRefactor.DefineScriptCase fromFilePath, toFilePath
    msgbox("OK")
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