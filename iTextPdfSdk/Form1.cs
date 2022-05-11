using iText.Licensing.Base;
using iText.Pdf2Data;
using iText.Pdf2Data.Result;
using iText.Pdf2Data.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTextPdfSdk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.FileInfo info = new System.IO.FileInfo("iTextPdf2Data-License.json");
            // Make sure to load license file before invoking any code
            LicenseKey.LoadLicenseFile(info);
            // Parse template into an object that will be used later on
            Template template = Pdf2DataExtractor.ParseTemplateFromPDF("GitHub-InvoiceTemplate.pdf");
            // Create an instance of Pdf2DataExtractor for the parsed template
            Pdf2DataExtractor extractor = new Pdf2DataExtractor(template);
            // Feed file to be parsed against the template. Can be called multiple times for different files
            ParsingResult result = extractor.Recognize("GitHub-Invoice1.pdf");
            // Save result to XML or explore the ParsingResult object to fetch information programmatically
            result.SaveToXML("result.xml");
        }
    }
}
