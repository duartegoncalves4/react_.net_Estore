Add-Type -AssemblyName System.Windows.Forms
$myshell = New-Object -com "Wscript.Shell"
while ($true)
{
  $myshell.sendkeys("{F13}")
  Start-Sleep -Seconds 60
}