using Grpc.Net.Client;
using Nikan.Services.Reports.WebApi.Adaptors;
using Nikan.Services.Reports.WebApi.Adaptors.AccountAdaptor;

// The port number must match the port of the gRPC server.
// Get an array with the values of ConsoleColor enumeration members.
ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
// Save the current background and foreground colors.
ConsoleColor currentBackground = Console.BackgroundColor;
ConsoleColor currentForeground = Console.ForegroundColor;
var i = 0;
while (i == 0)
{
  Console.Clear();
  try
  {
    using var channel = GrpcChannel.ForAddress("http://localhost:5107/");
    var metadata = new Grpc.Core.Metadata();
    metadata.Add("x-api-key", "test_service_key");
    var client = new AccountService.AccountServiceClient(channel);
    var accoutnId = Guid.NewGuid().ToString();
    var compnayId = Guid.NewGuid().ToString();

    var reply = client.AddAccount(new AddAccountRequest
    {
      AccountId = accoutnId,
      AccountNumber = 1000001,
      CompanyId = compnayId,
      CreatedBy = "omid kheiri",
      CreatedById = Guid.NewGuid().ToString(),
      DateCreated = new Google.Protobuf.WellKnownTypes.Timestamp(),
      DateModified = new Google.Protobuf.WellKnownTypes.Timestamp(),
      EmailAddress = "test@test.com",
      IsCustomer = false,
      IsSupplier = false,

      Phone = "09127388214",
      PostalAddress = "asdasdasd",
      Title = "asdasda"

    });
    Console.WriteLine("Greeting: " + reply.Message);














    var reply1 = client.SetAccountIsCustomer(new SetAccountIsCustomerRequest
    {
      AccountId = accoutnId,

      CompanyId = compnayId,
      IsCustomer = true

    });
    Console.WriteLine("Is Customer: " + reply1.Message);
    var reply2 = client.SetAccountIsSupplier(new SetAccountIsSupplierRequest
    {
      AccountId = accoutnId,

      CompanyId = compnayId,
      IsSupplier = true

    });
    Console.WriteLine("Is Supplier: " + reply2.Message);
















    i = Convert.ToInt32(Console.ReadLine());
  }
  catch (Exception ex)
  {
    Console.WriteLine(ex.Message);
    Console.WriteLine("\"0\" To retry");
    i = Convert.ToInt32(Console.ReadLine());
  }
}
