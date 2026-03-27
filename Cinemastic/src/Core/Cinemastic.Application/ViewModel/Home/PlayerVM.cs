using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Home
{
    public class PlayerVM
    {
        public string CoverUrl { get; set; }
        public string VideoUrl {  get; set; }
        public string? ReturnUrl { get; set; }
        public bool IsYouTube => !string.IsNullOrEmpty(VideoUrl) && VideoUrl.Length == 11; 

        public string YouTubeEmbedUrl => $"https://www.youtube.com/embed/{VideoUrl}";
    }
}
