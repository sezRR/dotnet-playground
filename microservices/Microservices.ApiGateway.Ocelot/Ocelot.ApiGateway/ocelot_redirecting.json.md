## Redirecting with Parameters

```json
{
  "DownStreamPathTemplate": "/api/v1/products/{id}",
  "DownstreamScheme": "https",
  "DownstreamHostAndPorts": [
    {
      "Host": "localhost",
      "Port": 5001
    }
  ],
  "UpstreamPathTemplate": "/products/{id}",
  "UpstreamHttpMethod": [
    "GET",
    "POST"
  ]
}
```

## Redirecting all URL

```json
{
  "DownStreamPathTemplate": "/{url}",
  "DownstreamScheme": "https",
  "DownstreamHostAndPorts": [
    {
      "Host": "localhost",
      "Port": 5001
    }
  ],
  "UpstreamPathTemplate": "/{url}",
  "UpstreamHttpMethod": [
    "GET",
    "POST"
  ]
}
```