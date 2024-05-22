# Set location
Push-Location
Set-Location $PSScriptRoot\ActivusX.Shared

# Build new DLL library
dotnet restore
dotnet build -c Release

# Copy DLL
Remove-Item -Path ../ActivusX.API/lib/ActivusX.Shared.dll -Force -Confirm:$false
Copy-Item -Path ./bin/Release/net8.0/ActivusX.Shared.dll -Destination ../ActivusX.API/lib/ -Force -Confirm:$false
Copy-Item -Path ./bin/Release/net8.0/ActivusX.Shared.dll -Destination ../ActivusX.WebApp/lib/ -Force -Confirm:$false

# Move back to main directory
Pop-Location
