using Fishbait2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factories
{
    public static class PostFactory
    {
        public static IPost GetPost()
        {
            return new Post();
        }
        public static IPostUpdate GetPostUpdate()
        {
            return new PostUpdate();
        }
        public static IPostUpdate GetNotification()
        {
            return new PostUpdate();
        }
    }
}
