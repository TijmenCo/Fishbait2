using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALFactories
{
    public static class PostDBFactory
    {
        public static IPostDto GetPost()
        {
            return new PostDto();
        }
    }
}
