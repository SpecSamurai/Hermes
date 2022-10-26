using Hermes.Catalog.API.Infrastructure.Entities;

namespace Hermes.Catalog.API.Infrastructure.Extensions;

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
            catalogContext.Items.AddRange(GetItems(catalogContext));
            await catalogContext.SaveChangesAsync();
        }
    }

    private static IEnumerable<Brand> GetBrands() =>
        new[] {
            new Brand { Name = "Azure", CreatedBy = Creator, LastModifiedBy = Creator },
            new Brand { Name = ".NET", CreatedBy = Creator, LastModifiedBy = Creator },
            new Brand { Name = "Visual Studio", CreatedBy = Creator, LastModifiedBy = Creator },
            new Brand { Name = "SQL Server", CreatedBy = Creator, LastModifiedBy = Creator },
            new Brand { Name = "Other", CreatedBy = Creator, LastModifiedBy = Creator }
        };

    private static IEnumerable<ItemType> GetItemTypes() =>
        new[] {
            new ItemType { Name = "Mug", CreatedBy = Creator, LastModifiedBy = Creator},
            new ItemType { Name = "T-Shirt", CreatedBy = Creator, LastModifiedBy = Creator },
            new ItemType { Name = "Sheet", CreatedBy = Creator, LastModifiedBy = Creator },
            new ItemType { Name = "Pin", CreatedBy = Creator, LastModifiedBy = Creator },
            new ItemType { Name = "USB Memory Stick", CreatedBy = Creator, LastModifiedBy = Creator }
        };

    private static IEnumerable<Item> GetItems(CatalogContext catalogContext) =>
        new[] {
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "T-Shirt").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == ".NET").Id,
                Name = ".NET Bot Black Hoodie",
                Description = ".NET Bot Black Hoodie, and more",
                PictureUri = "https://picsum.photos/320/330",
                Price = 19.5m,
                AvailableStock = 100,
                OnReorder = false,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "Mug").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == ".NET").Id,
                Name = ".NET Black & White Mug",
                Description = ".NET Black & White Mug",
                PictureUri = "https://picsum.photos/320/330",
                Price = 8.50m,
                AvailableStock = 89,
                OnReorder = false,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "T-Shirt").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == "Other").Id,
                Name = "Prism White T-Shirt",
                Description = "Prism White T-Shirt",
                PictureUri = "https://picsum.photos/320/330",
                Price = 12,
                AvailableStock = 56,
                OnReorder = true,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "T-Shirt").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == ".NET").Id,
                Name = ".NET Foundation T-shirt",
                Description = ".NET Foundation T-shirt",
                PictureUri = "https://picsum.photos/320/330",
                Price = 12,
                AvailableStock = 120,
                OnReorder = false,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "Pin").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == "Other").Id,
                Name = "Roslyn Red Pin",
                Description = "Roslyn Red Pin",
                PictureUri = "https://picsum.photos/320/330",
                Price = 8.5m,
                AvailableStock = 55,
                OnReorder = false,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "T-Shirt").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == ".NET").Id,
                Name = ".NET Blue Hoodie",
                Description = ".NET Blue Hoodie",
                PictureUri = "https://picsum.photos/320/330",
                Price = 12m,
                AvailableStock = 17,
                OnReorder = false,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "T-Shirt").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == ".NET").Id,
                Name = "Roslyn Red T-Shirt",
                Description = "Roslyn Red T-Shirt",
                PictureUri = "https://picsum.photos/320/330",
                Price = 12m,
                AvailableStock = 8,
                OnReorder = false,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "T-Shirt").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == "Other").Id,
                Name = "Kudu Purple Hoodie",
                Description = "Kudu Purple Hoodie",
                PictureUri = "https://picsum.photos/320/330",
                Price = 8.5m,
                AvailableStock = 34,
                OnReorder = false,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "Mug").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == "Azure").Id,
                Name = "Azure Cup<T> White Mug",
                Description = "Azure Cup<T> White Mug",
                PictureUri = "https://picsum.photos/320/330",
                Price = 12m,
                AvailableStock = 76,
                OnReorder = false,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "Pin").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == ".NET").Id,
                Name = ".NET Foundation Pin",
                Description = ".NET Foundation Pin",
                PictureUri = "https://picsum.photos/320/330",
                Price = 12m,
                AvailableStock = 11,
                OnReorder = false,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "Pin").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == "Other").Id,
                Name = "Cup<T> Pin",
                Description = "Cup<T> Pin",
                PictureUri = "https://picsum.photos/320/330",
                Price = 8.5m,
                AvailableStock = 3,
                OnReorder = true,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "T-Shirt").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == "Other").Id,
                Name = "Prism White TShirt",
                Description = "Prism White TShirt",
                PictureUri = "https://picsum.photos/320/330",
                Price = 12m,
                AvailableStock = 0,
                OnReorder = true,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "Mug").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == ".NET").Id,
                Name = "Modern .NET Black & White Mug",
                Description = "Modern .NET Black & White Mug",
                PictureUri = "https://picsum.photos/320/330",
                Price = 8.5m,
                AvailableStock = 89,
                OnReorder = false,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
            new Item
            {
                TypeId = catalogContext.ItemTypes.Single(type => type.Name == "Mug").Id,
                BrandId = catalogContext.Brands.Single(brand => brand.Name == "Other").Id,
                Name = "Modern Cup<T> White Mug",
                Description = "Modern Cup<T> White Mug",
                PictureUri = "https://picsum.photos/320/330",
                Price = 12m,
                AvailableStock = 76,
                OnReorder = false,
                CreatedBy = Creator,
                LastModifiedBy = Creator
            },
        };
}