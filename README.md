<h2 align="center">Lyric Finder API</h2>

<p align="center">
A .NET 7 WebAPI for finding lyrics from web providers.
</p>

![](https://raw.githubusercontent.com/russkyc/lyric-finder-api/master/.resources/images/Swagger%20UI.png)

### Supported Providers
- AZLyrics
- Genius
- Musixmatch

### Get Docker Container from DockerHub
```
docker pull russkyc/web-apis:lyricfinderapi
```

### Run Docker Container

```
docker run -p 5000:80 russkyc/web-apis:lyricfinderapi
```

### API

---

#### GET Endpoint

Find on All Providers: `/api/LyricFinder/{artist}/{song}`
  - finds song from all providers

Find on Specific Providers: `/api/LyricFinder/{providers}/{artist}/{song}`
  - finds song from defined providers eg; `genius` or `genius&azlyrics` etc

#### POST Endpoint
Find using Request: `/api/LyricFinder/{request}`
  - finds song based on post body content:
```json
{
  "artist": "string",
  "song": "string"
}
```