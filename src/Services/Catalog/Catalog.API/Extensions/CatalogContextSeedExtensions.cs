using Bogus;
using Hermes.Catalog.API.Entities;

namespace Hermes.Catalog.API.Extensions;

public static class CatalogContextSeedExtensions
{
    private const string Creator = nameof(CatalogContextSeedExtensions);

    public static async Task SeedAsync(this CatalogContext catalogContext)
    {
        if (catalogContext.Brands.Any() is false)
        {
            catalogContext.Brands.AddRange(GetBrands());
            await catalogContext.SaveChangesAsync();
        }
        if (catalogContext.ItemTypes.Any() is false)
        {
            catalogContext.ItemTypes.AddRange(GetItemTypes());
            await catalogContext.SaveChangesAsync();
        }
        if (catalogContext.Items.Any() is false)
        {
            var items = GetItems(catalogContext.Brands.ToList(), catalogContext.ItemTypes.ToList());
            catalogContext.Items.AddRange(items);
            await catalogContext.SaveChangesAsync();
        }
    }

    private static IEnumerable<Brand> GetBrands() =>
        new Faker<Brand>()
            .RuleFor(brand => brand.Name, setter => $"{setter.Company.CompanyName()} {setter.IndexFaker}")
            .RuleFor(brand => brand.CreatedBy, Creator)
            .RuleFor(brand => brand.LastModifiedBy, Creator)
            .Generate(10);

    private static IEnumerable<ItemType> GetItemTypes() =>
        new Faker<ItemType>()
            .RuleFor(itemType => itemType.Name, setter => $"{setter.Commerce.ProductAdjective()} {setter.IndexFaker}")
            .RuleFor(itemType => itemType.CreatedBy, Creator)
            .RuleFor(itemType => itemType.LastModifiedBy, Creator)
            .Generate(10);

    private static IEnumerable<Item> GetItems(IEnumerable<Brand> brands, IEnumerable<ItemType> itemTypes) =>
        new Faker<Item>()
            .RuleFor(item => item.Brand, setter => setter.PickRandom(brands))
            .RuleFor(item => item.Type, setter => setter.PickRandom(itemTypes))
            .RuleFor(item => item.Name, setter => $"{setter.Commerce.Product()} {setter.IndexFaker}")
            .RuleFor(item => item.Description, setter => setter.Commerce.ProductDescription())
            .RuleFor(item => item.PictureFileName, "Picture")
            .RuleFor(item => item.PictureUri, setter => @$"https://picsum.photos/id/{setter.Random.Int(0, 1000)}/320/330")
            .RuleFor(item => item.Price, setter => decimal.Parse(setter.Commerce.Price(min: 10, max: 100)))
            .RuleFor(item => item.AvailableStock, setter => setter.Random.Int(0, 100))
            .RuleFor(item => item.OnReorder, false)
            .RuleFor(item => item.CreatedBy, Creator)
            .RuleFor(item => item.LastModifiedBy, Creator)
            .Generate(50);
}