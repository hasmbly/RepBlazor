using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace RepBlazor.WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Register Syncfusion license 
            //Syncfusion.Licensing.SyncfusionLicenseProvider
            //    .RegisterLicense($"MzIzNDQ2QDMxMzgyZTMyMmUzMFF1MXNEdTNWcldHS3IrZW96Y2RCZ2pod0h5ZTVtM0FMQ3dtUXErbzNHbDg9;MzIzNDQ3QDMxMzgyZTMyMmUzMFo3ZnZ1T0VJZEFRV21ZSEh2ZFl4N1JscTNKVmE1RDdNNElQZnlPSmR1TFk9;MzIzNDQ4QDMxMzgyZTMyMmUzMGh1VVg1UmU1b0Z3Rjh2UlNBNlI4TVVweVJOcFZEUExTV1RHdW8vdXZEU1k9;MzIzNDQ5QDMxMzgyZTMyMmUzMEpXbXdxR0l1NFNFWTdOZGFZbk5OcjJjNE95bm9pUnpMamFDOFJOUDZPUGc9;MzIzNDUwQDMxMzgyZTMyMmUzMEhaYzg2UUd3Zm1YWGpoRCt0ak1xbXFWbkZuZzJTWEt1K05kSStnNVFIajQ9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddSyncfusionBlazor();

            await builder.Build().RunAsync();
        }
    }
}
