// MIT License
// 
// Copyright (c) 2023 Russell Camo (Russkyc)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using LyricFinderAPI.Models;
using LyricsScraperNET;
using LyricsScraperNET.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LyricFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LyricFinderController : ControllerBase
    {
        [HttpGet("{providers}/{artist}/{song}")]
        public async Task<IActionResult> GetLyricsFromProvider(ILyricsScraperClient client, string providers, string artist, string song)
        {
            if (providers.Contains("azlyrics"))
            {
                client
                    .WithAZLyrics();
            }
            
            if (providers.Contains("genius"))
            {
                client
                    .WithGenius();
            }
            
            if (providers.Contains("musixmatch"))
            {
                client
                    .WithMusixmatch();
            }
            
            var request = new ArtistAndSongSearchRequest(artist: artist, song: song);
            var searchResult = await client.SearchLyricAsync(request);

            if (searchResult.IsEmpty())
            {
                return NotFound();
            }
            
            var lyricInfo = new LyricInfo
            {
                Title = request.Song,
                Author = request.Artist,
                Lyric = searchResult.LyricText
            };
            
            return Ok(lyricInfo);
        }
        
        [HttpGet("{artist}/{song}")]
        public async Task<IActionResult> GetLyrics(ILyricsScraperClient client, string artist, string song)
        {
            client.WithAZLyrics()
                .WithGenius()
                .WithMusixmatch();
            
            var request = new ArtistAndSongSearchRequest(artist: artist, song: song);
            var searchResult = await client.SearchLyricAsync(request);

            if (searchResult.IsEmpty())
            {
                return NotFound();
            }
            
            var lyricInfo = new LyricInfo
            {
                Title = request.Song,
                Author = request.Artist,
                Lyric = searchResult.LyricText
            };
            
            return Ok(lyricInfo);
        }
        [HttpPost("{request}")]
        public async Task<IActionResult> PostSearchRequest(ILyricsScraperClient client, ArtistAndSongSearchRequest request)
        {
            client.WithAZLyrics()
                .WithGenius()
                .WithMusixmatch();
            
            var searchResult = await client.SearchLyricAsync(request);

            if (searchResult.IsEmpty())
            {
                return NotFound();
            }
            
            var lyricInfo = new LyricInfo
            {
                Title = request.Song,
                Author = request.Artist,
                Lyric = searchResult.LyricText
            };
            
            return Ok(lyricInfo);
        }
    }
}
