using BLOG.API.Models.Domain;

namespace BLOG.API.Repositories.Interface
{
    public interface IImageRepository
    {
        Task<BlogImage>Upload(IFormFile file, BlogImage blogImage);
        Task<IEnumerable<BlogImage>> GetAll();
    }
}
