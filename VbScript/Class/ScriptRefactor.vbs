' ScriptRefactor.vbs - This file is part of ERPToolkit
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

'ERPToolkit_AddSummary "C:\files\test_script.vbs", _
'	"C:\files\myscript01.vbs", _
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