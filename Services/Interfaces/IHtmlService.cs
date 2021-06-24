using System.Threading.Tasks;

namespace VkursiCurrency.Services.Interfaces
{
    public interface IHtmlService
    {
        public Task<double> GetResult(string courseType);
    }
}