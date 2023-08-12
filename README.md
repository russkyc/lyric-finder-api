<h2 align="center">Lyric Finder API</h2>

<p align="center">
A .NET 7 WebAPI for finding lyrics from web providers.
</p>

### Supported Providers
- AZLyrics
- Genius
- Musixmatch

### Build Docker Container

```
dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer
```

### Run Docker Container

```
docker run -p 5000:80 lyricfinderapi:1.0.4
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