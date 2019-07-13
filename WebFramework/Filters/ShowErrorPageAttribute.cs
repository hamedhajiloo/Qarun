using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;

namespace WebFramework.Filters
{
    public class ShowErrorPageAttribute : Attribute, IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public ShowErrorPageAttribute(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }
        public void OnException(ExceptionContext context)
        {
            ViewResult view = new ViewResult { ViewName = "Error" };
            view.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            context.Result = view;
        }
    }
    public class ShowErrorPageTypeAttribute : TypeFilterAttribute
    {
        public ShowErrorPageTypeAttribute() : base(typeof(ShowErrorPageAttribute))
        {

        }
    }
}
