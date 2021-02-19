using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Domain.ViewModel;

namespace Shop.Application.Service
{
    public class CustomerInfoService
    {
        private readonly ISession _session;
        private readonly string _sessionKey = "customer-info";

        public CustomerInfoService(ISession session)
        {
            _session = session;
        }

        public CustomerInfoViewModel Get()
        {
            var stringObject = _session.GetString(_sessionKey);
            if (string.IsNullOrEmpty(stringObject))
                return null;

            var response = JsonConvert.DeserializeObject<CustomerInfoViewModel>(stringObject);
            return response;
        }

        public void Post(CustomerInfoViewModel request)
        {
            var stringObject = JsonConvert.SerializeObject(request);
            _session.SetString(_sessionKey, stringObject);
        }
    }
}