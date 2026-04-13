using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.Data;
using WebAPIDemo.Model;
using WebAPIDemo.Model.Repositories;

namespace WebAPIDemo.Filters.ActionFilter
{
    public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
    {
        private ApplicationDbContext dbContext;

        public Shirt_ValidateCreateShirtFilterAttribute(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirt = context.ActionArguments["shirt"] as Shirt;

            if (shirt == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var shirtExists = dbContext.Shirts.FirstOrDefault(s =>
                !string.IsNullOrWhiteSpace(shirt.Brand) && !string.IsNullOrWhiteSpace(s.Brand) && s.Brand.ToLower() == shirt.Brand.ToLower() &&
                !string.IsNullOrWhiteSpace(shirt.Gender) && !string.IsNullOrWhiteSpace(s.Gender) && s.Gender.ToLower() == shirt.Gender.ToLower() &&
                !string.IsNullOrWhiteSpace(shirt.Color) && !string.IsNullOrWhiteSpace(s.Color) && s.Color.ToLower() == shirt.Color.ToLower() &&
                shirt.Size.HasValue && s.Size.HasValue && shirt.Size.Value == s.Size.Value);

                if (shirtExists != null)
                {
                    context.ModelState.AddModelError("Shirt", "A shirt with the same properties already exists");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
