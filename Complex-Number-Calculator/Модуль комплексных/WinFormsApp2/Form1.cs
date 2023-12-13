using System.Numerics;
using System.Drawing;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Diagnostics;

namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        public double realPart, imaginaryPart, modulus, argument;

        public MainForm()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(realTextBox.Text, out realPart) || !double.TryParse(imaginaryTextBox.Text, out imaginaryPart))
                {
                    MessageBox.Show("Введите числа");
                    return;
                }

                if (realTextBox.Text.Length > realTextBox.MaxLength || imaginaryTextBox.Text.Length > imaginaryTextBox.MaxLength)
                {
                    MessageBox.Show("Превышено максимальное количество символов.");
                    return;
                }

                Complex complexNumber = new(realPart, imaginaryPart);

                modulus = Complex.Abs(complexNumber);
                argument = Math.Atan2(complexNumber.Imaginary, complexNumber.Real);

                modulusLabel.Text = "Модуль: " + modulus.ToString();
                argumentLabel.Text = "Главный аргумент: " + argument.ToString();

                if (double.IsInfinity(modulus) || double.IsInfinity(argument))
                {
                    modulusLabel.Text = "На ноль делить нельзя";
                    argumentLabel.Text = "На ноль делить нельзя";
                    MessageBox.Show("На ноль делить нельзя");
                }

                realTextBox.ForeColor = Color.Black;
                imaginaryTextBox.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            realPart = imaginaryPart = modulus = argument = 0.0;
            realTextBox.Text = imaginaryTextBox.Text = string.Empty;
            modulusLabel.Text = "";
            argumentLabel.Text = "";
        }

        private void wordButton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new();
            Microsoft.Office.Interop.Word.Document doc = word.Documents.Add();
            if (modulusLabel.Text == "На ноль делить нельзя" || argumentLabel.Text == "На ноль делить нельзя")
            {
                doc.Paragraphs[1].Range.Text = "На ноль делить нельзя";
            }
            else
            {
                doc.Paragraphs[1].Range.Text = "Реальная часть: " + realPart + "\nМнимая часть: " + imaginaryPart + "\nМодуль: " + modulus + "\nАргумент: " + argument; // вывод текста
            }
            word.Visible = true;
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
            if (modulusLabel.Text == "На ноль делить нельзя" || argumentLabel.Text == "На ноль делить нельзя")
            {
                sheet.Cells[1, 1].Value = "На ноль делить нельзя";
            }
            else
            {
                sheet.Cells[1, 1].Value = "Реальная часть: ";
                sheet.Cells[2, 1].Value = "Мнимая часть: ";
                sheet.Cells[3, 1].Value = "Модуль: ";
                sheet.Cells[4, 1].Value = "Аргумент: ";
                sheet.Cells[1, 2].Value = realPart;
                sheet.Cells[2, 2].Value = imaginaryPart;
                sheet.Cells[3, 2].Value = modulus;
                sheet.Cells[4, 2].Value = argument;
            }
            sheet.Columns.AutoFit();
            sheet.Rows.AutoFit();
            excel.Visible = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void realTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                imaginaryTextBox.Focus();
            }
        }

        private void imaginaryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                calculateButton.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string pdfFilePath = "ComplexNumberResults.pdf";

                using (var writer = new PdfWriter(pdfFilePath))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);

                        document.Add(new Paragraph($"The real part: {realPart}"));
                        document.Add(new Paragraph($"Imaginary part: {imaginaryPart}"));
                        document.Add(new Paragraph($"Module: {modulus}"));
                        document.Add(new Paragraph($"Main argument: {argument}"));

                        if (modulusLabel.Text.Contains("\u221E") || argumentLabel.Text.Contains("\u221E"))
                        {
                            document.Add(new Paragraph("You can't divide by zero!"));
                        }

                        document.Close();
                    }
                }

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                Process process = new Process { StartInfo = psi };
                process.Start();
                process.StandardInput.WriteLine($"start {pdfFilePath}");
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}