using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;

namespace Faktury.Biz
{
    public class PDFCreator
    {
        Invoice invoice;
        Client client;
        Owner owner;
        List<Product> products;
        decimal totalNettoValue;
        decimal totalBruttoValue;
        decimal totalVatValue;


        public PDFCreator(Invoice invoice)
        {
            this.invoice = invoice;
            this.client = invoice.Client;
            this.owner = invoice.Owner;
            this.products = invoice.products;
        }

        /// <summary>
        /// Calculating total values (netto/brutto/vat value)
        /// </summary>
        private void CalculateTotalValues()
        {
            foreach (Product product in products)
            {
                totalNettoValue += product.TotalNettoPrice;
                totalBruttoValue += product.TotalBruttoPrice;
                totalVatValue += product.VATValue;
            }
        }
        
        public void CreatePDF()
          {

              Document doc = new Document(PageSize.LETTER, 10, 10, 42, 35);
              BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\ARIALUNI.TTF", BaseFont.IDENTITY_H, true);
              Font f = new iTextSharp.text.Font(bf, 12, Font.NORMAL);
            

              //int count = 1;
              string fullPath = "Faktura " + invoice.Date + ".pdf";
              //Old saving style
              //string fileNameOnly = Path.GetFileNameWithoutExtension(fullPath);
              //string extension = Path.GetExtension(fullPath);
              //string path = Path.GetDirectoryName(fullPath);
              //string newFullPath = fullPath;

              //while (File.Exists(newFullPath))
              //{
              //    string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
              //    newFullPath = Path.Combine(path, tempFileName + extension);
              //}

              PdfPTable saleTable = SaleTable();

              
              //PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(newFullPath, FileMode.Create));
              SaveFileDialog dialog = new SaveFileDialog();
              dialog.Title = "Save file as...";
              dialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
              dialog.FileName = fullPath;
              dialog.RestoreDirectory = true;

              if (dialog.ShowDialog() == DialogResult.OK)
              {
                  PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(dialog.FileName, FileMode.Create));
                  MessageBox.Show("Utworzono plik PDF");
              }
              doc.Open();
              
              //Title
              Paragraph title = new Paragraph("Faktura: " + invoice.NumberOfInvoice, f);
              title.Alignment = 2;
            
              Paragraph date = new Paragraph("Data: " + invoice.Date, f);
              date.Alignment = 2;

              doc.Add(title);
              doc.Add(date);

              //Dane sprzedawcy
              Paragraph companyName = new Paragraph(owner.Name, f);


              doc.Add(companyName);
              doc.Add(new Paragraph(owner.Address, f));
              doc.Add(new Paragraph(owner.City, f));
              doc.Add(new Paragraph(owner.PostCode, f));
              doc.Add(new Paragraph(owner.NIP, f));
              doc.Add(new Paragraph("__________________________", f));

              //Dane kupca
              doc.Add(new Paragraph("Faktura dla:"));
              doc.Add(new Paragraph(client.Name, f));
              doc.Add(new Paragraph(client.Address, f));
              doc.Add(new Paragraph(client.City, f));
              doc.Add(new Paragraph(client.PostCode, f));
              doc.Add(new Paragraph(client.NIP, f));

              Paragraph separator = new Paragraph("__________________________", f);
              doc.Add(new Paragraph());
              doc.Add(new Paragraph());
              separator.SpacingAfter = 5.5f;
              doc.Add(separator);


              //Table and total
              doc.Add(saleTable);
              doc.Close();
        }
 
        private PdfPTable SaleTable()
        {
            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\ARIALUNI.TTF", BaseFont.IDENTITY_H, true);
            Font f = new iTextSharp.text.Font(bf, 12, Font.NORMAL);

            CalculateTotalValues();
            //Tabela produktów
            PdfPTable table = new PdfPTable(5);
            table.TotalWidth = 1000f;
            float[] widths = new float[] { 0.5f, 4f, 1f, 0.5f, 1f };
            table.SetWidths(widths);


            //Nagłówki tabeli
            table.AddCell(HeaderCell("Lp."));
            table.AddCell(HeaderCell("Produkt"));
            table.AddCell(HeaderCell("Cena netto"));
            table.AddCell(HeaderCell("Ilość"));
            table.AddCell(HeaderCell("Kwota netto"));

            //Dodaje produkty
            foreach (var product in products)
            {
                table.AddCell(QuantityCell(product.Id + "."));
                table.AddCell(new Phrase(product.Name, f));
                table.AddCell(new Phrase(product.NettoPrice.ToString("c"), f));
                table.AddCell(new Phrase(product.Quantity.ToString(), f));
                table.AddCell(PriceCell(product.TotalNettoPrice.ToString("c")));
            }



            // Kwota netto
            PdfPCell subtotal = new PdfPCell(new Phrase(totalNettoValue.ToString("c"), f));
            subtotal.Border = Rectangle.TOP_BORDER;
            subtotal.HorizontalAlignment = 2;

            PdfPCell stText = new PdfPCell(new Phrase("Suma netto:", f));
            stText.HorizontalAlignment = 2;
            stText.Colspan = 2;
            stText.Border = Rectangle.TOP_BORDER;


            table.AddCell(BlankCell());
            table.AddCell(BlankCell());
            table.AddCell(stText);
            table.AddCell(subtotal);

            PdfPCell vatCell = new PdfPCell(new Phrase(totalVatValue.ToString("c"), f));
            vatCell.Border = Rectangle.TOP_BORDER;
            vatCell.HorizontalAlignment = 2;

            PdfPCell vatText = new PdfPCell(new Phrase("Suma VAT:", f));
            vatText.HorizontalAlignment = 2;
            vatText.Colspan = 2;
            vatText.Border = Rectangle.TOP_BORDER;

            table.AddCell(BlankCell());
            table.AddCell(BlankCell());
            table.AddCell(vatText);
            table.AddCell(vatCell);

            PdfPCell grandTotal = new PdfPCell(new Phrase(totalBruttoValue.ToString("c"), f));
            grandTotal.Border = Rectangle.TOP_BORDER;
            grandTotal.HorizontalAlignment = 2;

            PdfPCell gtText = new PdfPCell(new Phrase("Suma Brutto:", f));
            gtText.HorizontalAlignment = 2;
            gtText.Colspan = 2;
            gtText.Border = Rectangle.TOP_BORDER;

            table.AddCell(BlankCell());
            table.AddCell(BlankCell());
            table.AddCell(gtText);
            table.AddCell(grandTotal);
 
 
            return table;
        }

        private PdfPHeaderCell HeaderCell(string CellContent)
        {

            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\ARIALUNI.TTF", BaseFont.IDENTITY_H, true);
            Font f = new iTextSharp.text.Font(bf, 12, Font.NORMAL);
            PdfPHeaderCell cell = new PdfPHeaderCell();
            cell.BackgroundColor = CMYKColor.LIGHT_GRAY;
            cell.HorizontalAlignment = 1;
            cell.Phrase = new Phrase(CellContent, f);
            return cell;
        }
 
        private PdfPCell PriceCell(string price)
        {
            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\ARIALUNI.TTF", BaseFont.IDENTITY_H, true);
            Font f = new iTextSharp.text.Font(bf, 12, Font.NORMAL);
            PdfPCell cell = new PdfPCell();
            cell.HorizontalAlignment = 2;
            cell.Phrase = new Phrase(price, f);
 
            return cell;
        }
 
        private PdfPCell QuantityCell(string quantity)
        {
            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\ARIALUNI.TTF", BaseFont.IDENTITY_H, true);
            Font f = new iTextSharp.text.Font(bf, 12, Font.NORMAL);
            PdfPCell cell = new PdfPCell();
            cell.HorizontalAlignment = 1;
            cell.Phrase = new Phrase(quantity, f);
 
            return cell;
        }
 
        private PdfPCell BlankCell()
        {

            PdfPCell cell = new PdfPCell(new Phrase(""));
            cell.Border = Rectangle.TOP_BORDER;
 
            return cell;
        }
            
    }
}
