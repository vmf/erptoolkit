' Odbc.vbs - This file is part of ERPToolkit
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

'ERPToolkit_CreateDsn "dsnname", "master", "ERPToolkit", "freitas-pc"
public sub ERPToolkit_CreateDsn(byval dsnName, byval database, byval description, byval server)
Dim oOdbc
	Set oOdbc = CreateObject("ERPToolkit.Class.Odbc")
	'Assigns to the Values object the returned object
	oOdbc.Values = GetBasicValues()
	
	'/// <summary>
    '/// Creates a DSN
    '/// </summary>
    '/// <param name="dsnName">DSN name</param>
    '/// <param name="database">Database</param>
    '/// <param name="description">Description</param>
    '/// <param name="server">Server</param>
	oOdbc.CreateDsn dsnName, database, description, server
end sub

'msgbox(ERPToolkit_GetDsnProperty("dsnname", "Database"))
public function ERPToolkit_GetDsnProperty(byval dsnName, byval property)
Dim oOdbc
	Set oOdbc = CreateObject("ERPToolkit.Class.Odbc")
	'Assigns to the Values object the returned object
	oOdbc.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets a property of a DSN
    '/// </summary>
    '/// <param name="dsnName">DSN name</param>
    '/// <param name="property">Property name that we want to get</param>
    '/// <returns></returns>
	ERPToolkit_GetDsnProperty = oOdbc.GetDsnProperty(dsnName, property)
end function

'msgbox(ERPToolkit_GetDsnList(";"))
public function ERPToolkit_GetDsnList(byval separator)
Dim oOdbc
	Set oOdbc = CreateObject("ERPToolkit.Class.Odbc")
	'Assigns to the Values object the returned object
	oOdbc.Values = GetBasicValues()

	'/// <summary>
    '/// Gets all DSNs
    '/// </summary>
    '/// <param name="separator">Separator</param>
    '/// <returns>List</returns>	
	 ERPToolkit_GetDsnList = oOdbc.GetDsnList(separator)
end function


'msgbox(ERPToolkit_IsValidDsn("dsnname"))
public function ERPToolkit_IsValidDsn(byval dsnName)
Dim oOdbc
	Set oOdbc = CreateObject("ERPToolkit.Class.Odbc")
	'Assigns to the Values object the returned object
	oOdbc.Values = GetBasicValues()
	
	'/// <summary>
    '/// Checks if the DSN name is valid(Exists)
    '/// </summary>
    '/// <param name="dsnName">Dsn name</param>
    '/// <returns>The truth</returns>
	ERPToolkit_IsValidDsn = oOdbc.IsValidDsn(dsnName)
end function

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