﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LanchesWeb.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string MailTo { get; set; }
        public string Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto: " + MailTo);
            output.Content.SetContent(Content);  
        }
    }
}
