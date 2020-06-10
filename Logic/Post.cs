﻿using System;
using Fishbait2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DALFactories;
using Microsoft.Extensions.Logging;

namespace Fishbait2.Models
{
    public class Post : IPost
    {
        private readonly IPostDBAccesLayer postDB;
        private readonly IPost post;
        private List<IPost> posts { get; set; }
        //  PostDBAccesLayer postDB = new PostDBAccesLayer();

        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public string image { get; set; }
        public string tag { get; set; }
        public Post(IPostDBAccesLayer _dependencyDB)
        {
            postDB = _dependencyDB;
        }
        public string AddPost(IPost model) //DONE
        {
            IPostDto postDto = PostDBFactory.GetPost(); //Maakt een nieuw model aan.
            postDto.id = model.id;
            postDto.title = model.title;
            postDto.description = model.description;
            postDto.image = model.image;
            postDto.tag = model.tag;
            string resp = postDB.AddPost(postDto);
            return (resp);
        }
        public List<IPost> GetPosts() //DONE
        {
            posts = new List<IPost>();
            List<IPostDto> AllPosts = postDB.GetPosts(); //Returnt alle posts van de database
            foreach (IPostDto model in AllPosts)
            {
                posts.Add(new Post(postDB) //Zet alle IPostDtos om in IPost
                {
                    id = model.id,
                    title = model.title,
                    description = model.description,
                    image = model.image,
                    tag = model.tag
                });
            }
            return (posts);
        }
        public string DeletePost(int id) //DONE
        {
            string resp = postDB.DeletePost(id);
            return (resp);
        }
        public string EditPost(IPost model) //DONE
        {
            IPostDto realmodel = PostDBFactory.GetPost();
            realmodel.id = model.id;
            realmodel.title = model.title;
            realmodel.description = model.description;
            realmodel.image = model.image;
            realmodel.tag = model.tag;
            string resp = postDB.EditPost(realmodel);
            return (resp);
        }
        public IPost GetPostID(int id)
        {
            List<IPost> DBPosts = GetPosts();
            List<IPost> IDPosts = DBPosts.Where(x => x.id == id).ToList();
            return IDPosts[0];
        }
        public IPost GetEditID(int id)
        {
            List<IPost> DBPosts = GetPosts();
            List<IPost> IDPosts = DBPosts.Where(x => x.id == id).ToList();
            return IDPosts[0];
        }
        public List<IPost> Search(string result)
        {
            List<IPost> SearchPosts = GetPosts().Where(s => s.title.Contains(result)).ToList();
            return SearchPosts;
        }
        public List<IPost> Filter(string tag)
        {
            List<IPost> FilterPosts = GetPosts().Where(s => s.tag.Equals(tag)).ToList();
            return FilterPosts;
        }


    }


}
