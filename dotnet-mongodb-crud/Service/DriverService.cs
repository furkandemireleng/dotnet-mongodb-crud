using dotnet_mongodb_crud.Configuration;
using dotnet_mongodb_crud.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace dotnet_mongodb_crud.Service;

public class DriverService
{
    private readonly IMongoCollection<Driver> _driverCollection;

    public DriverService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabeseName);
        _driverCollection = mongoDb.GetCollection<Driver>(databaseSettings.Value.CollectionName);
    }


    public async Task<List<Driver>> GetDrivers() => await _driverCollection.Find(_ => true).ToListAsync();

    public async Task<Driver> GetDriver(string id) =>
        await _driverCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task Create(Driver driver) => await _driverCollection.InsertOneAsync(driver);

    public async Task Update(Driver driver) =>
        await _driverCollection.ReplaceOneAsync(x => x.Id == driver.Id, driver);

    public async Task Remove(string id) => await _driverCollection.DeleteOneAsync(x => x.Id == id);
}