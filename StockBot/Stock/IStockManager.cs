using Contracts;
using MassTransit;
using StockBot.Model;
using System.Threading.Tasks;

namespace StockBot.Stock
{
    public interface IStockManager
    {
        Task<string> StockCode(SendRecieveMessageViewModel model);
    }
}
