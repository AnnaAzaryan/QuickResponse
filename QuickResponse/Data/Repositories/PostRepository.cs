using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Contexts;
using QuickResponse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private AppIdentityDBContext _context;

        public PostRepository(AppIdentityDBContext context)
        {
            this._context = context;
        }

        public bool Delete(Post entity)
        {
            this._context.Find<Post>(entity).IsDeleted = true;
            this._context.SaveChanges();
            return true;
        }

        public bool DeleteById(int id)
        {
            GetByID(id).IsDeleted = true;
            this._context.SaveChanges();
            return true;
        }

        public Post GetByID(int id)
        {
            return _context.Find<Post>(id);
        }

        public IEnumerable<Post> List()
        {
            return _context.Posts;
        }

        public bool Save(Post entity)
        {
            if (entity.Body == null)
            {
                return false;
            }
            else
            {
                entity.IsDeleted = false;
                _context.Posts.Add(entity);
                _context.SaveChanges();
                return true;
            }
            
        }

        public bool Update(Post entity)
        {
            var post = this._context.Posts.Find(entity.PostId);
            this._context.Products.Find(post.ProductId).Count = entity.Product.Count;
            post.PostName = entity.PostName;
            post.Price = entity.Price;
            post.Body = entity.Body;
            this._context.SaveChanges();
            return true;
        }
    }
}
