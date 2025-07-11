namespace FP.Backend.Base.Domain.Common;

public class MongoDbSettings
{
    public string Host { get; init; }

    public int Port { get; init; }

    //public string ConnectionString => $"mongodb+srv://holutahyour01:Holutahyour01@prepdom.ibrrgjx.mongodb.net/?retryWrites=true&w=majority&appName=prepdom";
    public string ConnectionString => $"mongodb://{Host}:{Port}";
}
