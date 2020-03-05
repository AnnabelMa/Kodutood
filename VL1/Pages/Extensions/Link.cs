﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VL1.Pages.Extensions
{
    public class Link
    {
        public Link(string displayName, string url, string propertyName = null)
        {
            DisplayName = displayName;
            Url = url;
            PropertyName = propertyName ?? displayName;
        }
        public string DisplayName { get; }
        public string Url { get; }
        public string PropertyName { get; }
    }
}