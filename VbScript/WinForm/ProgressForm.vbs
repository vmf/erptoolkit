' ProgressForm.vbs - This file is part of ERPToolkit
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

Dim oProgressF

'Sets basic values
SetBasicValues

'Create the object
Set oProgressF = CreateObject("ERPToolkit.WinForm.ProgressForm")
oProgressF.Values = GetBasicValues()

ERPToolkit_ProgressForm
public sub ERPToolkit_ProgressForm()
Dim index, jIndex	

    'Initialize the progress form.
	'It means that the progress form will be
	'shown and the basic values for the progress
	'control will be defined
	InitializeProgress oProgressF, 3, 0, 2000, 0, "mytitle"
		
	'Main process message
    oProgressF.MainMessage = "Main Process..."
		
	'Main process
	for index = 1 to oProgressF.MainMaximum
			
		'Sub-process
		for jIndex = 0 to oProgressF.SubMaximum			
			'Increment the sub-progress bar(sub-process)
			oProgressF.IncrementSub			
			'Sub-process message
			oProgressF.SubMessage = "Sub-Process A..."
		next
		
		'Sub-process
		oProgressF.SubValue = oProgressF.SubMinimum
		for jIndex = 0 to oProgressF.SubMaximum			
			'Increment the sub-progress bar(sub-process)
			oProgressF.IncrementSub
			'Sub-process message
			oProgressF.SubMessage = "Sub-Process B..."
		next
		
		'Increment the main progress bar(main process)
		oProgressF.IncrementMain
		'Main process message
		oProgressF.MainMessage = "Main Process..."
	next
end sub

public sub InitializeProgress(byref oProgressF, byval mainMax, byval mainMin, byval subMax, byval subMin, byval title)	

	'Define the progress properties
	'Show the form
	oProgressF.Show    
	
	'Maximum number for the main process
	oProgressF.MainMaximum = mainMax    
	
	'Minimum number for the main process
	oProgressF.MainMinimum = mainMin    
	
	'Maximum number for the sub-process
	oProgressF.SubMaximum = subMax
	    
	'Minimum number for the sub-process
	oProgressF.SubMinimum = subMin
	    
	'Window's title
    oProgressF.Title = title
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