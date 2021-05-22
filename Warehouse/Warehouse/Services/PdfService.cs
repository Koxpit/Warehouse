using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse.Services
{
    public static class PdfService
    {
        private static readonly string FONT = Environment.CurrentDirectory + "/wwwroot/lib/fonts/HelveticaRegular/HelveticaRegular.ttf";
        private static readonly Font fntHead = FontFactory.GetFont(FONT, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED, 20, Font.ITALIC, BaseColor.GREEN);


        public static void ExportToPDF(ref List<Product> items)
        {
            Document document = new Document();
            document.SetPageSize(PageSize.A4);
            FileStream fs = CreateAndOpenFile();
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();

            //Report Header
            document.Add(GetHeader());

            //Add a line seperation
            document.Add(GetLineSeparetion());

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            document.Add(CreateTableInfo(ref items));

            document.Close();
            writer.Close();
            fs.Close();
        }

        private static FileStream CreateAndOpenFile()
        {
            string directoryPath = Environment.CurrentDirectory + "/Reports";
            DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);

            if (!dirInfo.Exists)
                dirInfo.Create();

            string createTime = DateTime.Now.ToString();
            createTime = createTime.Replace(@":", @"_");

            return new FileStream(directoryPath + $"/Report {createTime}.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
        }

        private static Paragraph GetHeader()
        {
            string headerStr = "Отчет";
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(headerStr.ToUpper(), fntHead));

            return prgHeading;
        }

        private static Paragraph GetLineSeparetion()
        {
            return new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
        }

        private static PdfPTable CreateTableInfo(ref List<Product> products)
        {
            DataTable dataTable = MakeDataTable(ref products);
            //Write the table
            PdfPTable table = new PdfPTable(dataTable.Columns.Count);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(FONT, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, BaseColor.WHITE);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dataTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }

            //table Data
            Font fntRow = new Font(btnColumnHeader, 8, 1, BaseColor.GRAY);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BackgroundColor = BaseColor.WHITE;
                    cell.AddElement(new Chunk(dataTable.Rows[i][j].ToString(), fntRow));
                    table.AddCell(cell);
                }
            }

            return table;
        }

        private static DataTable MakeDataTable(ref List<Product> items)
        {
            DataTable data = new DataTable();

            data.Columns.Add("Склад");
            data.Columns.Add("Сектор");
            data.Columns.Add("Ряд");
            data.Columns.Add("Код");
            data.Columns.Add("Партия");
            data.Columns.Add("Срок");
            data.Columns.Add("Кол-во");
            data.Columns.Add("Прим");
            data.Columns.Add("Коробок");

            for (int i = 0; i < items.Count; i++)
            {
                data.Rows.Add(items[i].Place.Storage.Name, items[i].Place.Sector, items[i].Place.Number,
                    items[i].Code, items[i].Party, items[i].Term.ToShortDateString(), items[i].NumOfPalletes,
                    items[i].Comment, items[i].BoxesInPallete);
            }

            return data;
        }
    }
}
