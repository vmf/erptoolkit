' Email.vbs - This file is part of ERPToolkit
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

'ERPToolkit_SendEmail "fromemail@gmail.com", "password", _
'	"ERPToolkit", "sendtoemail@gmail.com", "ERPToolkit", _
'	"Hey", "hey, what's up ?", "smtp.gmail.com", 587, true, false
	
public sub ERPToolkit_SendEmail(byval fromAddress, byval password, _ 
	byval fromDisplayName, byval sendToAddress, byval sendToDisplayName, _ 
	byval subject, byval body, byval host, byval port, byval enableSsl, byval useDefaultCredentials)
	
Dim oEmail
	Set oEmail = CreateObject("ERPToolkit.Class.Email")
	'Assigns to the Values object the returned object
	oEmail.Values = GetBasicValues()
		
    oEmail.FromAddress = fromAddress
    oEmail.Password = password
    oEmail.FromDisplayName = fromDisplayName
    oEmail.SendToAddress = sendToAddress
    oEmail.SendToDisplayName = sendToDisplayName
    oEmail.Subject = subject
    oEmail.Body = body
    oEmail.Host = host
    oEmail.Port = port
    oEmail.EnableSsl = enableSsl
    oEmail.UseDefaultCredentials = useDefaultCredentials
	
	'/// <summary>
    '/// Sends an e-mail
    '/// </summary>
	oEmail.SendEmail
	
	msgbox("Sent!")
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