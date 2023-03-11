# ASP React SPA

Creating a React SPA with AspNetCore and React-Redux

## Helpful Commands

Generate development JWTs

```bash
dotnet user-jwts create --scope "admin-scope" --role "admin"
```

Generated JWT has the following decoded payload:

```json
{
  "unique_name": "sushrit_lawliet",
  "sub": "sushrit_lawliet",
  "jti": "ff2e83e3",
  "scope": "admin-scope",
  "role": "admin",
  "aud": [
    "http://localhost:30288",
    "https://localhost:44368",
    "http://localhost:5019",
    "https://localhost:7040"
  ],
  "nbf": 1678540391,
  "exp": 1686489191,
  "iat": 1678540391,
  "iss": "dotnet-user-jwts"
}
```
