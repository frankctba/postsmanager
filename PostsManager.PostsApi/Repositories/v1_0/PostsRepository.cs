using System.Collections.Generic;
using System.Linq;
using PostsManager.PostsApi.Models.v1_0;

namespace PostsManager.PostsApi.Repositories.v1_0
{
    public class PostsRepository : IPostsRepository
    {
        private List<PostsModel> _posts;
        private readonly object lockObject = new object();
        
        public PostsRepository()
        {
            this._posts = new List<PostsModel>();
        }

        public PostsModel Add(PostsModel post)
        {
            lock (lockObject)
            {
                post.Id = this._posts.Count <= 0 ? 1 : this._posts.Max(p => p.Id) + 1;
                _posts.Add(post);
                return post;
            }
        }

        public PostsModel GetPostById(int postId)
        {
            lock (lockObject)
            {
                return _posts.SingleOrDefault(p => p.Id == postId);
            }
        }

        public IEnumerable<PostsModel> GetPosts()
        {
            lock (lockObject)
            {
                return _posts;
            }
        }

        public void Delete(int postId)
        {
            lock (lockObject)
            {
                var post = this.GetPostById(postId);
                if (post != null)
                    _posts.Remove(post);
            }
        }

        public void Update(int postId, PostsModel post)
        {
            lock (lockObject)
            {
                var currentPost = this.GetPostById(postId);
                if (currentPost != null)
                {
                    currentPost.Title = post.Title;
                    currentPost.Description = post.Description;
                }
            }
        }
    }
}
