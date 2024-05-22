# Define the API endpoint and API key
$apiUrl = "http://localhost:5000/api/System/Health"
$apiKey = "your-secure-api-key" # Replace with your actual API key

# Set up the headers with the API key
$headers = @{
    "X-API-KEY" = $apiKey
}

# Make the GET request to the API
$response = Invoke-RestMethod -Uri $apiUrl -Method Get -Headers $headers

# Output the response
$response