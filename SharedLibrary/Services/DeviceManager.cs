using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SharedLibrary.Models.Devices;
using System.Diagnostics;
using System.Text;


namespace SharedLibrary.Services
{
    public class DeviceManager
    {
        private readonly DeviceConfiguration _config;
        private readonly DeviceClient _client;
        private readonly ServiceClient _serviceClient;

        public DeviceManager(DeviceConfiguration config)
        {
            _config = config;
            _client = DeviceClient.CreateFromConnectionString(_config.ConnectionString);
            _serviceClient = ServiceClient.CreateFromConnectionString("HostName=AlexA-IoTHub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=mqLguqPSuasiLIMHkxFmPX2Gl/jjB8A1tAIoTMTt8pE=");

            Task.FromResult(StartAsync());
        }

        


        public bool AllowSending() => _config.AllowSending;

        private async Task StartAsync()
        {
            await _client.SetMethodDefaultHandlerAsync(DirectMethodDefaultCallback, null);
        }


        public async Task SendDirectMethodAsync(string deviceId, string methodName)
        {
            try
            {
                var methodInvocation = new CloudToDeviceMethod(methodName) { ResponseTimeout = TimeSpan.FromSeconds(30) };

                var response = await _serviceClient.InvokeDeviceMethodAsync(deviceId, methodInvocation);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
            

        }


        private async Task<MethodResponse> DirectMethodDefaultCallback(MethodRequest req, object userContext)
        {
            var res = new DirectMethodDataResponse
            {
                Message = $"Executed Method {req.Name} successfully.",
            };

            switch (req.Name.ToLower())
            {
                case "start":
                    {
                        _config.AllowSending = true;
                        break;
                    }

                case "stop":
                    {
                        _config.AllowSending = false;
                        break;
                    }

                case "interval":
                    {
                        break;
                    }

                default:
                    {
                        res.Message = $"Direct method {req.Name} not found.";
                        return new MethodResponse(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)), 404);
                    }

            }

            return new MethodResponse(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)), 200);
        }
    }
}
