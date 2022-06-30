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
       
       

       
        
        public   async Task<string> StockCode(SendRecieveMessageViewModel model) {


            string[] code = model.Message.Split('=');
            DataTable stockTable = ReadCSVData(@"CSV\stock.csv");
            DataRow[] rslt = stockTable.Select("symbol=" + "'"+ (code.Length > 1 ? code[1]: "" ) +"'");
            string message = "Bot command is not sent in proper format";
            if (rslt.Length >= 1)
            {
                message = "Bot " + rslt[0][3].ToString();
            }
           


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
