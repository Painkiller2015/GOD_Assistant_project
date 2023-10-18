using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static DSharpPlus.Entities.DiscordEmbedBuilder;

namespace GOD_Assistant.DiscordObject
{
    //public static class Embed
    //{
    //    internal interface IEmbedBuilder
    //    {
    //        public IEmbedBuilder SetTitle(string title);
    //        public IEmbedBuilder SetDescription(string description);
    //        public IEmbedBuilder SetAuthor(string name, string iconUrl, string Url);
    //        public IEmbedBuilder SetColor(DiscordColor color);
    //        public IEmbedBuilder SetImage(string imageUrl);
    //        public IEmbedBuilder SetThumbnail(string imageUrl);
    //        public IEmbedBuilder SetTimeStamp();
    //        public IEmbedBuilder SetFooter(string text, string iconUrl);
    //        public IEmbedBuilder AddField(string name, string value, bool inLine);
    //        public DiscordEmbed Build();
    //    }
    //    internal class EmbedBuilder : IEmbedBuilder
    //    {
    //        private readonly DiscordEmbedBuilder _embedBuilder;
    //        public EmbedBuilder()
    //        {
    //            _embedBuilder = new();
    //        }
    //        public IEmbedBuilder SetTitle(string title)
    //        {
    //            _embedBuilder.Title = title;
    //            return this;
    //        }
    //        public IEmbedBuilder SetDescription(string description)
    //        {
    //            _embedBuilder.Description = description;
    //            return this;
    //        }
    //        public IEmbedBuilder SetColor(DiscordColor color)
    //        {
    //            _embedBuilder.Color = color;
    //            return this;
    //        }
    //        public IEmbedBuilder SetImage(string imageUrl)
    //        {
    //            _embedBuilder.ImageUrl = imageUrl;
    //            return this;
    //        }
    //        public IEmbedBuilder SetTimeStamp()
    //        {
    //            _embedBuilder.Timestamp = DateTime.Now;
    //            return this;
    //        }
    //        public IEmbedBuilder SetAuthor(string name = "", string IconUrl = "", string Url = "")
    //        {
    //            _embedBuilder.Author = new EmbedAuthor()
    //            {
    //                Name = name,
    //                IconUrl = IconUrl,
    //                Url = Url
    //            };
    //            return this;
    //        }
    //        public IEmbedBuilder SetThumbnail(string imageUrl)
    //        {
    //            _embedBuilder.Thumbnail = new EmbedThumbnail()
    //            {
    //                Url = imageUrl
    //            };
    //            return this;
    //        }
    //        public IEmbedBuilder SetFooter(string text = "", string IconUrl = "")
    //        {
    //            _embedBuilder.Footer = new EmbedFooter()
    //            {
    //                Text = text,
    //                IconUrl = IconUrl
    //            };
    //            return this;
    //        }
    //        public IEmbedBuilder AddField(string name, string value, bool inLine = false)
    //        {
    //            _embedBuilder.AddField(name, value, inLine);
    //            return this;
    //        }
    //        public DiscordEmbed Build()
    //        {
    //            return _embedBuilder.Build();
    //        }
    //    }
    //}
}
