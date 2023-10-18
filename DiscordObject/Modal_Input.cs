using DSharpPlus.Entities;
using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GOD_Assistant.DiscordObject
{
    internal class Modal_Input(string title, string content, string customID)
    {
        DiscordInteractionResponseBuilder window = new();
        public string Title = title;
        public string Content = content;
        public string CustomId = customID;
        public List<DiscordEmbed> embeds = new();
        public List<DiscordComponent> components = new();

        public void Init()
        {
            window.WithTitle(Title)
                  .WithCustomId(CustomId)
                  .WithContent(Content)
                  .AddComponents(components);                                    
        }

        public void AddComponent(string lableS, string customIDS, string placeholderS = "", int minLength = 0, int maxLength = 128, bool requiredS = true) =>
            components.Add(new TextInputComponent(label: lableS, customId: customIDS, placeholder: placeholderS, min_length: minLength, max_length: maxLength, required: requiredS));
    }
}
