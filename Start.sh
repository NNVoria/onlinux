#!/bin/bash
# Dual screen script
 
dir="$( cd "$(dirname "$0")" ;pwd -P )"         # Remember current directory.
 
screen -dmSL "LoginServer" "mono" "$dir/OpenNos.Login/bin/DE/./OpenNos.Login.exe"

screen -dmSL "MasterServer" "mono" "$dir/OpenNos.Master.Server/bin/Release/./OpenNos.Master.Server.exe"

screen -dmSL "WorldServer" "mono" "$dir/OpenNos.World/bin/DE/./OpenNos.World.exe"


