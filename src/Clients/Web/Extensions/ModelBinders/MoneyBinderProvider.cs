using Fintech;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Hermes.Client.Web.Extensions.ModelBinders;

public class MoneyBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context) =>
        context.Metadata.ModelType == typeof(Money)
            ? new BinderTypeModelBinder(typeof(MoneyBinder))
            : null;
}