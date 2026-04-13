using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.Data;
using WebAPIDemo.Model.Repositories;

namespace WebAPIDemo.Filters.ExceptionFilter
{
    public class Shirt_HandleUpdateExpectionFilterAttribute : ExceptionFilterAttribute
    {
        private ApplicationDbContext dbContext;

        public Shirt_HandleUpdateExpectionFilterAttribute(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strShirtId = context.RouteData.Values["id"] as string;
            if(int.TryParse(strShirtId, out int shirtId))
            {
                if(dbContext.Shirts.FirstOrDefault(s => s.ShirtId == shirtId) == null)
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
