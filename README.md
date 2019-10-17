# DOTNET Authorization POC

```
Example jwt:
eyJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczovL2plcnJpZS5hdXRoMC5jb20vIiwic3ViIjoiYXV0aDB8NThiMy4uLiIsImF1ZCI6WyJodHRwczovL2FwaS5teWNvbXBhbnkuY29tL21lc3NhZ2VzIiwiaHR0cHM6Ly9qZXJyaWUuYXV0aDAuY29tL3VzZXJpbmZvIl0sImlhdCI6MTUxMTE1OTQ1MiwiZXhwIjoxNTExMTY2NjUyLCJhenAiOiJzQWxaLi4uIiwic2NvcGUiOiJyZWFkIn0.4vYhQZMN_tE_lGAGWmn00hVaM_dJfuns4dIolttSnGI

Header:
{
  "alg": "HS256"
}

Payload:
{
  "iss": "https://jerrie.auth0.com/",
  "sub": "auth0|58b3...",
  "aud": [
    "https://api.mycompany.com/messages",
    "https://jerrie.auth0.com/userinfo"
  ],
  "iat": 1511159452,
  "exp": 1511166652,
  "azp": "sAlZ...",
  "scope": "read"
}
```