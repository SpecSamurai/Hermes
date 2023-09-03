using Fintech;
using Fintech.Serialization;
using Hermes.Client.Web.Constants;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;

namespace Hermes.Client.Web.Extensions.ModelBinders;

public class MoneyBinder : IModelBinder
{
    private readonly IStringLocalizer<MoneyBinder> stringLocalizer;

    public MoneyBinder(IStringLocalizer<MoneyBinder> stringLocalizer)
    {
        this.stringLocalizer = stringLocalizer;
    }

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var modelName = bindingContext.ModelName;
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

        var value = valueProviderResult.FirstValue;
        if (string.IsNullOrEmpty(value))
        {
            return Task.CompletedTask;
        }

        if (MoneySerializer.Serialize(value) is Money model)
            bindingContext.Result = ModelBindingResult.Success(model);
        else
            bindingContext.ModelState.TryAddModelError(modelName, stringLocalizer[Resources.Common.InvalidMoneyError]);

        return Task.CompletedTask;
    }
}