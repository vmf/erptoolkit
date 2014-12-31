' SysEnvironment.vbs - This file is part of ERPToolkit
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

'msgbox(ERPToolkit_GetUserSid("Vinícius M. Freitas"))
'msgbox(ERPToolkit_GetUserSid(ERPToolkit_UserName()))
public function ERPToolkit_GetUserSid(byval userName)
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	'Assigns to the Values object the returned object
	oSysEnvironment.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets the user SID
    '/// </summary>
    '/// <param name="userName">User name</param>
    '/// <returns>User SID</returns>
	ERPToolkit_GetUserSid = oSysEnvironment.GetUserSid(userName)
end function

'msgbox(ERPToolkit_UserName())
public function ERPToolkit_UserName()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets the current user name
    '/// </summary>
    '/// <returns>User name</returns>
	ERPToolkit_UserName = oSysEnvironment.UserName()
end function

'msgbox(ERPToolkit_CurrentDirectory())
public function ERPToolkit_CurrentDirectory()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()

	ERPToolkit_CurrentDirectory = oSysEnvironment.CurrentDirectory()
end function

'msgbox(ERPToolkit_HasShutdownStarted())
public function ERPToolkit_HasShutdownStarted()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// If shutdown has started
    '/// </summary>
    '/// <returns>The truth</returns>
	ERPToolkit_HasShutdownStarted = oSysEnvironment.HasShutdownStarted()
end function

'msgbox(ERPToolkit_Is64BitOperatingSystem)
public function ERPToolkit_Is64BitOperatingSystem()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// Is it a 64-bit OS ?
    '/// </summary>
    '/// <returns>The truth</returns>
	ERPToolkit_Is64BitOperatingSystem = oSysEnvironment.Is64BitOperatingSystem()
end function

'msgbox(ERPToolkit_Is64BitProcess())
public function ERPToolkit_Is64BitProcess()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// Is it a 64-bit process ?
    '/// </summary>
    '/// <returns>The truth</returns>
	ERPToolkit_Is64BitProcess = oSysEnvironment.Is64BitProcess()
end function

'msgbox(ERPToolkit_MachineName())
public function ERPToolkit_MachineName()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// Gets the Machine Name
    '/// </summary>
    '/// <returns>Machine Name</returns>
	ERPToolkit_MachineName = oSysEnvironment.MachineName()
end function

'msgbox(ERPToolkit_OSVersion())
public function ERPToolkit_OsVersion()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// Gets the OS Version
    '/// </summary>
    '/// <returns>OSVersion</returns>
	ERPToolkit_OsVersion = oSysEnvironment.OsVersion()
end function

'msgbox(ERPToolkit_ProcessorCount())
public function ERPToolkit_ProcessorCount()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// Gets the number of processors on the current machine
    '/// </summary>
    '/// <returns></returns	
	ERPToolkit_ProcessorCount = oSysEnvironment.ProcessorCount()
end function

'msgbox(ERPToolkit_SystemDirectory())
public function ERPToolkit_SystemDirectory()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
	
	'/// <summary>
    '/// Gets the fully qualified path of the system directory
    '/// </summary>
    '/// <returns>System Directory</returns>
	ERPToolkit_SystemDirectory = oSysEnvironment.SystemDirectory()
end function

'msgbox(ERPToolkit_SystemPageSize())
public function ERPToolkit_SystemPageSize()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// Gets the amount of memory for an operation system's page file
    '/// </summary>
    '/// <returns>System Page Size</returns>	
	ERPToolkit_SystemPageSize = oSysEnvironment.SystemPageSize()
end function

'msgbox(ERPToolkit_TickCount())
public function ERPToolkit_TickCount()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// Gets the number of milliseconds elapsed since the system started
    '/// </summary>
    '/// <returns>Tick Count</returns>
	ERPToolkit_TickCount = oSysEnvironment.TickCount()
end function

'msgbox(ERPToolkit_UserDomainName())
public function ERPToolkit_UserDomainName()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// Gets the network domain name associated with the current user
    '/// </summary>
    '/// <returns>User Domain Name</returns>
	ERPToolkit_UserDomainName = oSysEnvironment.UserDomainName()
end function

'msgbox(ERPToolkit_UserInteractive())
public function ERPToolkit_UserInteractive()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// Gets a value indicating whether the current process is running in user interactive mode
    '/// </summary>
    '/// <returns>The truth</returns>
	ERPToolkit_UserInteractive = oSysEnvironment.UserInteractive()
end function

'msgbox(ERPToolkit_Version())
public function ERPToolkit_Version()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// Gets the version of the common language runtime
    '/// </summary>
    '/// <returns>Version</returns>
	ERPToolkit_Version = oSysEnvironment.Version()
end function

'msgbox(ERPToolkit_WorkingSet())
public function ERPToolkit_WorkingSet()
Dim oSysEnvironment
	Set oSysEnvironment = CreateObject("ERPToolkit.Class.SysEnvironment")
	oSysEnvironment.Values = GetBasicValues()
		
	'/// <summary>
    '/// Gets the amount of the physical memory mapped to the process context
    '/// </summary>
    '/// <returns>Working set</returns>
	ERPToolkit_WorkingSet = oSysEnvironment.WorkingSet()
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