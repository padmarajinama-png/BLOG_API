using BLOG.API.Data;
using BLOG.API.Models.Domain;
using BLOG.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace BLOG.API.Repositories.Implementation
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext dbContext;

        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly IHttpContextAccessor httpContextAccessor;


        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)

        {

            this.webHostEnvironment = webHostEnvironment;

            this.httpContextAccessor = httpContextAccessor;

            this.dbContext = dbContext;

        }
        public async Task<IEnumerable<BlogImage>> GetAll()

        {

            return await dbContext.BlogImages.ToListAsync();

        }
        public async Task<BlogImage> Upload(IFormFile file, BlogImage blogImage)
        {
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{blogImage.FileName}{blogImage.FileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{blogImage.FileName}{blogImage.FileExtension}";
            blogImage.Url = urlPath;

            await dbContext.BlogImages.AddAsync(blogImage);
            await dbContext.SaveChangesAsync();

            return blogImage;
        }



    }
}
