using Ecommerce.ReadModels.Dtos;
using MongoDB.Driver;

public class ProductCreatedConsumerService(IMongoCollection<ProductDto> collection) : MongoMessageConsumer<ProductDto>(collection, "product.created")
{
    public override async Task HandleMessageAsync(ProductDto message)
    {
        await _collection.InsertOneAsync(message);
    }
}
