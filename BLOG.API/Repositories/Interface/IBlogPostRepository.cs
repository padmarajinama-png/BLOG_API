using BLOG.API.Models.Domain;

namespace BLOG.API.Repositories.Interface
{
    public interface IBlogPostRepository
    {
       
            Task<BlogPost> CreateAsync(BlogPost blogpost);

            Task<IEnumerable<BlogPost>> GetAllAsync();

            Task<BlogPost?> GetByIdAsync(Guid id);

            Task<BlogPost?> UpdateAsync(BlogPost blogPost);

            Task<BlogPost?> DeleteAsync(Guid id);
            Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);

        }
    }

