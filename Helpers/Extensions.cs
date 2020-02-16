using Microsoft.AspNetCore.Http;

namespace cruddotnetcore.API.Helpers
{
  public static class Extensions
  {
    public static void AddApplicationError(this HttpResponse responde, string message)
    {
      responde.Headers.Add("Application-Error", message);
      responde.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
      responde.Headers.Add("Access-Control-Allow-Origin", "*");
    }
  }
}