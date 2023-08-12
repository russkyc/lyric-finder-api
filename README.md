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

#### POST
endpoint: `/api/LyricFinder/{request}`
body schema:
```json
{
  "artist": "string",
  "song": "string"
}
```