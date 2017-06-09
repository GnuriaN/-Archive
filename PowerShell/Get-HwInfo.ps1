###############################################################################
# Get-HwInfo.ps1 
# Version 1.0 
# 
# Getting basic information about systems hardware 
# 
# Ruslan Prokhorov 
# http://github.com/GnuriaN/
###############################################################################

<#
.SYNOPSIS
Get information about the physical disks and volumes on a system.
 
.DESCRIPTION
Get details about the physical disks and the volumes located on
those disks, to make it easier to identify corresponding vSphere
storage (VMDKs).
 
.EXAMPLE
 
PS C:\> .\Get-DiskInfo.ps1
 
.NOTES
    Author: Geoff Duke <Geoffrey.Duke@uvm.edu>
    Based on http://bit.ly/XowLns and http://bit.ly/XeIqFh
#>

function HDD ($diskdrives)
{
 
    #$diskdrives = get-wmiobject Win32_DiskDrive | sort Index
 
    $colSize = @{Name='Size';Expression={Get-HRSize $_.Size}}
 
    foreach ( $disk in $diskdrives ) {
 
        "--------------------------------------------------------------------"
        $scsi_details = 'SCSI ' + $disk.SCSIBus         + ':' +
                                  $disk.SCSILogicalUnit + ':' +
                                  $disk.SCSIPort        + ':' +
                                  $disk.SCSITargetID
        write $( 'Disk ' + $disk.Index + ' - ' + $scsi_details +
                 ' - ' + ( Get-HRSize $disk.size) +' ( '+ $disk.Caption + ' )')
        Write-Host
        "Serial Number: " + $disk.SerialNumber
        "Fireware revision: " + $disk.FirmwareRevision
        "Interface type: " + $disk.InterfaceType
        "Status: " + $disk.Status
        "DeviceID: " + $disk.DeviceID
        Write-Host
        $part_query = 'ASSOCIATORS OF {Win32_DiskDrive.DeviceID="' +
                      $disk.DeviceID.replace('\','\\') +
                      '"} WHERE AssocClass=Win32_DiskDriveToDiskPartition'
 
        $partitions = @( get-wmiobject -query $part_query | 
                         sort StartingOffset )
        foreach ($partition in $partitions) {
 
            $vol_query = 'ASSOCIATORS OF {Win32_DiskPartition.DeviceID="' +
                         $partition.DeviceID +
                         '"} WHERE AssocClass=Win32_LogicalDiskToPartition'
            $volumes   = @(get-wmiobject -query $vol_query)
 
            write $( '    Partition ' + $partition.Index + '  ' +
                     ( Get-HRSize $partition.Size) + '  ' +
                     $partition.Type
                   )
 
            foreach ( $volume in $volumes) {
                write $( '        ' + $volume.name + 
                         ' ( ' + $volume.VolumeName + ' )' +
                         ' [' + $volume.FileSystem + '] ' + 
                         ( Get-HRSize $volume.Size ) + ' ( ' +
                         ( Get-HRSize $volume.FreeSpace ) + ' free )'
                         
                       )
 
            } # end foreach vol
 
        } # end foreach part
 
        write ''
 
    } # end foreach disk
 
}
 
###############################################################################
function Get-HRSize {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$True, ValueFromPipeline=$True)]
        [INT64] $bytes
    )
    process {
        if     ( $bytes -gt 1pb ) { "{0:N2} PB" -f ($bytes / 1pb) }
        elseif ( $bytes -gt 1tb ) { "{0:N2} TB" -f ($bytes / 1tb) }
        elseif ( $bytes -gt 1gb ) { "{0:N2} GB" -f ($bytes / 1gb) }
        elseif ( $bytes -gt 1mb ) { "{0:N2} MB" -f ($bytes / 1mb) }
        elseif ( $bytes -gt 1kb ) { "{0:N2} KB" -f ($bytes / 1kb) }
        else   { "{0:N} Bytes" -f $bytes }
    }
} # End Function:Get-HRSize
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
    $DiskDrive = Get-WmiObject Win32_DiskDrive -ComputerName $computers | sort Index
    # Logical disk
    # $DiskLogical = Get-WmiObject Win32_LogicalDisk -ComputerName $computers

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
    HDD($DiskDrive)

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
