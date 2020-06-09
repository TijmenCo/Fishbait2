using DALFactories;
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
            return new Post(PostDBFactory.GetPostDB());
        }
    //    public static IPostUpdate GetPostUpdate()
    //    {
    //        return new PostUpdate();
    //    }
    }
}
