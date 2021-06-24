using System.Threading.Tasks;
using VkursiCurrency.Models;

namespace VkursiCurrency.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<double> GetCourse(CurrencyInfoModel model);
    }
}