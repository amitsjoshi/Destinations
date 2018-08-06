#############################################
# am I running in 32 bit shell?
#############################################
if ($pshome -like "*syswow64*") {
 
  Write-Warning "Restarting script under 64 bit powershell"
 
  # relaunch this script under 64 bit shell
  & (join-path ($pshome -replace "syswow64", "sysnative") powershell.exe) -file `
    (join-path $psscriptroot $myinvocation.mycommand) @args
 
  # exit 32 bit script
  exit
}

Import-Module WebAdministration
Stop-WebSite 'Default Web Site'
Remove-Item -Path C:\inetpub\wwwroot\*.* -Force