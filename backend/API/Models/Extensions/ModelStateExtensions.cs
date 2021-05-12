using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace InModeration.Backend.API.Models.Extensions
{
    public static class ModelStateExtensions
    {
        public static string GetErrors(this ModelStateDictionary dictionary)
        {
            var errors = dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage);

            return string.Join(", ", errors);
        }
    }
}
