using System.Collections.Generic;
using PostsManager.PostsApi.Models.v1_0;

namespace PostsManager.PostsApi.Repositories.v1_0
{
    public interface IPostsRepository
    {
        PostsModel Add(PostsModel post);
        void Delete(int postId);
        void Update(int postId, PostsModel post);
        PostsModel GetPostById(int postId);
        IEnumerable<PostsModel> GetPosts();
    }
}