//namespace FP.Backend.Services;

//public static class DatabaseSeeder
//{

//    public static async Task SeedDatabaseAsync()
//    {
//        // Ensure the database is created
//        //await context.Database.EnsureCreatedAsync();
//        await SeedErpSettingAsync(context);
//        await SeedErpSettingDefaultAsync(context, ErpSettingDefaultSeedData.GetErpSettings());
//        //await SeedErpCustomerOptionalFieldAsync(context, ErpCustomerOptionalFieldSeedData.GetErpCustomerOptionalFields());
//    }

//    public static async Task SeedErpSettingAsync(ApplicationDbContext context)
//    {
//        // Check if there are any existing students
//        if (!context.ErpSettings.Any())
//        {
//            // Add initial data
//            context.ErpSettings.AddRange(
//                new ErpSetting
//                {
//                    Id = 0,
//                    Code = "Sage-CU",
//                    ErpType = "Sage-300",
//                    Name = "Sage 300 Erp",
//                    Description = "Sage 300 Erp",
//                    IsActivated = true,
//                    BaseUrl = "http://eraphasage.eastus2.cloudapp.azure.com:3083/Sage300WebApi/v1.0/-/CUDAT",
//                },
//                new ErpSetting
//                {
//                    Id = 0,
//                    Code = "Sage-BU",
//                    ErpType = "Sage-300",
//                    Name = "Sage 300 Erp",
//                    Description = "Sage 300 Erp",
//                    IsActivated = false,
//                    BaseUrl = "http://eraphasage.eastus2.cloudapp.azure.com:3083/Sage300WebApi/v1.0/-/BHUDAT",
//                }
//            );

//            await context.SaveChangesAsync();
//        }
//    }

//    public static async Task SeedErpSettingDefaultAsync(ApplicationDbContext context, List<ErpSettingDefault> erpSettings)
//    {
//        // Check if there are any existing students
//        if (!context.ErpSettingDefaults.Any())
//        {

//            // Add initial data
//            context.ErpSettingDefaults.AddRange(erpSettings);

//            await context.SaveChangesAsync();
//        }
//    }

//    public static async Task SeedErpCustomerOptionalFieldAsync(ApplicationDbContext context, List<ErpCustomerOptionalField> erpCustomerOptionalFields)
//    {
//        // Check if there are any existing students
//        if (!context.ErpCustomerOptionalFields.Any())
//        {

//            // Add initial data
//            context.ErpCustomerOptionalFields.AddRange(erpCustomerOptionalFields);

//            await context.SaveChangesAsync();
//        }
//    }
//}