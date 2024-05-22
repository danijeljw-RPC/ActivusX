# Turn off orchestration (if running)
docker compose down | Out-Null

# Remove DB volume
docker volume rm activusx_activusx-db-data | Out-Null

# Start DB only
docker compose up -d db

# Remove Migrations folder
Remove-Item -Path $PSScriptRoot\ActivusX.API\Migrations -Recurse -Force -Confirm:$false

# Set location
Push-Location
Set-Location $PSScriptRoot\ActivusX.API

# Define the file path
$filePath = ".\appsettings.json"

# Read the file content
$fileContent = Get-Content $filePath

# Define the old and new connection strings
$oldString = '"DefaultConnection": "Host=db;Port=5432;Database=example;Username=postgres;Password=ActivusX@123!"'
$newString = '"DefaultConnection": "Host=localhost;Port=5432;Database=example;Username=postgres;Password=ActivusX@123!"'

# Replace the old string with the new string
$fileContent = $fileContent -replace [regex]::Escape($oldString), $newString

# Write the updated content back to the file
Set-Content -Path $filePath -Value $fileContent

# Create migrations
dotnet ef migrations add initDb
dotnet ef database update

# Read the file content
$fileContent = Get-Content $filePath

# Define the old and new connection strings
$oldString = '"DefaultConnection": "Host=localhost;Port=5432;Database=example;Username=postgres;Password=ActivusX@123!"'
$newString = '"DefaultConnection": "Host=db;Port=5432;Database=example;Username=postgres;Password=ActivusX@123!"'

# Replace the old string with the new string
$fileContent = $fileContent -replace [regex]::Escape($oldString), $newString

# Write the updated content back to the file
Set-Content -Path $filePath -Value $fileContent

# Move back to main directory
Pop-Location

# Start the rest of the docker containers
docker compose up -d
