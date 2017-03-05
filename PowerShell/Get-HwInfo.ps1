###############################################################################
# Get-HwInfo.ps1 
# Version 1.0 
# 
# Getting basic information about systems hardware 
# 
# Ruslan Prokhorov 
# http://github.com/GnuriaN/
###############################################################################

###############################################################################
function OnDate($param) 
{
    return ($param.Substring(6,2) + "." + $param.Substring(4,2) + "." + $param.Substring(0,4) +  
    " " + $param.Substring(8,2) + ":" + $param.Substring(10,2) + ":" + $param.Substring(12,2))
}
###############################################################################
function Get-HwInfo ($computers = ".") 
{
    cls
    "Load information ..."
    
    # Obtaining data on the system using the WinAPI
    # MatherBoard
    $BaseBoard = Get-WmiObject Win32_BaseBoard -ComputerName $computers
    # BIOS
    $BIOS = Get-WmiObject Win32_BIOS -ComputerName $computers
    # Processor
    $CPU = Get-WmiObject Win32_Processor -ComputerName $computers
    # Random Access Memory
    $RAM = Get-WmiObject Win32_MemoryDevice -ComputerName $computers
    # Video Adapter
    $Video = Get-WmiObject Win32_VideoController -ComputerName $computers
    # Disk media
    $DiskDrive = Get-WmiObject Win32_DiskDrive -ComputerName $computers
    # Logical disk
    $DiskLogical = Get-WmiObject Win32_LogicalDisk -ComputerName $computers
    # NetworkAdapter
    $NIC = Get-WmiObject Win32_NetworkAdapter -ComputerName $computers | ?{$_.NetConnectionID -ne $null}
    # Operation System
    $OS = Get-WmiObject Win32_OperatingSystem -ComputerName $computers
    ###############################################################################
    
    cls

    "Operation system: " + $OS.Caption
    "Type: " + $OS.BuildType
    "Version: " + $OS.Version
    "Build: " + $OS.BuildNumber
    "Architecture: " + $OS.OSArchitecture
    "Name PC:" + $OS.CSName
    "User: " + $OS.RegisteredUser
    "Description: " + $OS.Description
    "Instal date: " + (OnDate -param $OS.InstallDate)
    "LastBootUpTime: " + (OnDate -param $OS.LastBootUpTime)
    Write-Host
    "BaseBoard:"
    "Manufacturer: " + $BaseBoard.Manufacturer
    "Product: " + $BaseBoard.Product
    "Version: " + $BaseBoard.Version
    "SerialNumber: " + $BaseBoard.SerialNumber
    Write-Host
    
    "BIOS:"
    foreach ($objItem in $BIOS)
    {
        "Manufacturer: " + $objItem.Manufacturer
        "Version: " + $objItem.Description
        "Primary: " + $objItem.PrimaryBIOS
        Write-Host
    }

    "CPU: "
    foreach ($objItem in $CPU)
    {
        "DeviceID: " + $objItem.DeviceID
        "Manufacturer: " + $objItem.Name
        $temp = switch($objItem.Architecture) {0 {"x86"}; 1 {"MIPS"}; 2 {"Alpha"}; 3 {"PowerPC"}; 6 {"Intel Itanium"}; 9 {"x64"}}
        "Architecture: " + $temp
        "Socet: " + $objItem.SocketDesignation
        "Max Clock Speed: " + $objItem.MaxClockSpeed + " MHz"
        "Cores: " + $objItem.NumberOfCores
        "Logical Processors: " + $objItem.NumberOfLogicalProcessors
        "L2 Cache: " + $objItem.L2CacheSize + " byte"
        "L3 Cache: " + $objItem.L3CacheSize + " byte"
      Write-Host
    }

    "Memory:"
    foreach ($objItem in $RAM)
    {
        "Memory ID: " + $objItem.DeviceID
        "Size: " + (($objItem.EndingAddress - $objItem.StartingAddress + 1) /1024) + " Mbyte"
        Write-Host
    }
    
    "Video:"
    foreach ($objItem in $Video)
    {
        "AdapterCompatibility: " + $objItem.AdapterCompatibility
        "Caption: " + $objItem.Caption
        "Memory Size: " + (($objItem.AdapterRAM) /1024 /1024) + " Mbyte"
        "Driver Version: " + $objItem.DriverVersion
        "VideoMode: " + $objItem.VideoModeDescription
        Write-Host
    }

    "Hard disk:"
    foreach ($objItem in $DiskDrive)
    {
        "Manufacturer: " + $objItem.Caption
        "Serial Number: " + $objItem.SerialNumber
        "Fireware revision: " + $objItem.FirmwareRevision
        "Interface type: " + $objItem.InterfaceType
        "Size: " + $objItem.Size / 1024 /1024 /1024 + " Gbyte"
        Write-Host
    }

    "Logical disk:"
    foreach ($objItem in $DiskLogical)
    {
        "Logic disk: " + $objItem.Caption
        "File system: " + $objItem.FileSystem
        "Description: " + $objItem.Description
        "Free Space: " + ($objItem.FreeSpace / 1024 /1024 /1024)  + " (" + (($objItem.FreeSpace /$objItem.Size * 100).ToString()).Substring(0,5) + "%)" + " Gbyte"
        "Free Space (%): " + (($objItem.FreeSpace /$objItem.Size * 100).ToString()).Substring(0,5)
        "Size: " + $objItem.Size /1024 /1024 /1024 + " Gbyte" 
        "Volume: " + $objItem.VolumeName
        Write-Host
    }

    "Network"
    foreach ($objItem in $NIC)
    { 
        "Manufacturer: " + $objItem.Manufacturer
        "Description" + $objItem.Description
        "MAC: " + $objItem.MACAddress
        "NetConnectionID: " + $objItem.NetConnectionID
        "NetConnectionStatus: " + $objItem.NetConnectionStatus
        Write-Host
    }
}

Get-HwInfo
