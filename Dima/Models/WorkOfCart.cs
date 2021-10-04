using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Models
{
    public class WorkOfCart
    {

        private readonly AppDBContent appDBContent;

        public WorkOfCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string CartId { get; set; }

        public List<Cart> listOfCart { get; set; }

        public static WorkOfCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new WorkOfCart(context) { CartId = cartId };
            // дописати карт (відос на 17:30)
        }

        public void AddToCart(Product product)
        {
            appDBContent.Carts.Add(new Cart {
                CartId = CartId,
                product = product,
                price = product.price
            });

            appDBContent.SaveChanges();

        }

        public List<Cart> getItems()
        {
            return appDBContent.Carts.Where(c => c.CartId == CartId).Include(s => s.product).ToList();
        }

    }
}
