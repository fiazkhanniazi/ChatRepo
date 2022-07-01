using Contracts;
using IronXL;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using StockBot.Model;
using StockBot.Stock;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace StockBot.Stock
{
    public class StockManager: IStockManager
    {
        private IBus _bus;
       public StockManager(IBus bus)
        {
            _bus = bus;
        }



        public   async Task<string> StockCode(SendRecieveMessageViewModel model) {


            string[] code = model.Message.Split('=');
            DataTable stockTable = ReadCSVData(@"CSV\stock.csv");
            DataRow[] rslt = stockTable.Select("symbol=" + "'"+ (code.Length > 1 ? code[1]: "" ) +"'");
            string message = "command is not sent in proper format";
            if (rslt.Length >= 1)
            {
                message =  rslt[0][3].ToString();
            }

            model.Message = message;
            model.TargetUserName = "Bot";
           
            Uri uri = new Uri("rabbitmq://localhost/chatQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send<SendRecieveMessageViewModel>(model);

            return message;



        }

        private  DataTable ReadExcel(string fileName)
        {
            WorkSheet sheet =null;
            try
            {
              
               
                WorkBook workbook = WorkBook.Load(fileName);
                sheet = workbook.DefaultWorkSheet;
                
               
            }catch(Exception ex)
            {

            }
            return sheet.ToDataTable(true);
        }

        private  DataTable ReadCSVData(string csvFileName)
        {
           
          return   ReadExcel(csvFileName);
        }
    }
}
