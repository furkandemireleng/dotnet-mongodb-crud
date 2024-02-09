namespace dotnet_mongodb_crud.Configuration;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = null;
    public string DatabeseName { get; set; } = null;
    public string CollectionName { get; set; } = null;
}