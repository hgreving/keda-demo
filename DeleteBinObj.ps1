#####################################################################
# Deletes all obj and bin directories the 'clean solution'
# command sometimes misses
#
# Execute in Powershell commandline or install VS Powershell tools
# and right-click + 'Excecute as Script'
# 
# (effects only visible after project refresh)
#####################################################################
$workingdir = (Get-Item -Path ".\" -Verbose).FullName
$question = "Delete all Bin and Obj dirs from " + $workingdir
$Readhost = Read-Host $question " ( y / N ) " 
Switch ($ReadHost) 
{ 
    Y {Get-ChildItem .\ -include bin,obj -recu -Force | remove-item -force -recurse}
    Default {}
}
