using System.Numerics;
using System.Drawing;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Diagnostics;
using iText.IO.Font;
using iText.Kernel.Font;

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
                if (realTextBox.Text == "")
                {
                    realTextBox.Text = 0.ToString();
                }
                if (imaginaryTextBox.Text == "")
                {
                    imaginaryTextBox.Text = 0.ToString();
                }
                if (!double.TryParse(realTextBox.Text, out realPart) || !double.TryParse(imaginaryTextBox.Text, out imaginaryPart))
                {
                    MessageBox.Show("Введите числа");
                    realTextBox.Text = "";
                    imaginaryTextBox.Text = "";
                    return;
                }

                if (realTextBox.Text.Length > realTextBox.MaxLength || imaginaryTextBox.Text.Length > imaginaryTextBox.MaxLength)
                {
                    MessageBox.Show("Введено слишком большое число");
                    realTextBox.Text = "";
                    imaginaryTextBox.Text = "";
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
            string phiSymbol = "\u03C6";
            Microsoft.Office.Interop.Word.Application word = new();
            Microsoft.Office.Interop.Word.Document doc = word.Documents.Add();

            if (modulusLabel.Text == "На ноль делить нельзя" || argumentLabel.Text == "На ноль делить нельзя")
            {
                doc.Paragraphs[1].Range.Text = "На ноль делить нельзя";
            }
            else
            {
                // Вычисление модуля и аргумента
                Complex complexNumber = new(realPart, imaginaryPart);
                double modulus = Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart);
                argument = Math.Atan2(complexNumber.Imaginary, complexNumber.Real);

                // Формирование строки с вычислениями
                string formulaModulus = $"|z| = √a² + b² = √({realPart}² + {imaginaryPart}²) = √({realPart * realPart} + {imaginaryPart * imaginaryPart}) = √({modulus * modulus}) = {modulus}";
                string formulaArgument = "";
                if (realPart > 0)
                {
                    formulaArgument = $"Теперь вычисляем аргумент. Так как a = {realPart} > 0, то получаем аргумент:\n{phiSymbol} = arctan(b / a) = arctan({imaginaryPart} / {realPart}) = arctan({argument})";
                }
                else if (realPart < 0 && imaginaryPart >= 0)
                {
                    formulaArgument = $"Теперь вычисляем аргумент. Так как a = {realPart} < 0, b = {imaginaryPart} >= 0, то получаем аргумент:\n{phiSymbol} = π + arctan(b / a) = π + arctan({imaginaryPart} / {realPart}) = π + arctan({argument})";
                }
                else if (realPart < 0 && imaginaryPart < 0)
                {
                    formulaArgument = $"Теперь вычисляем аргумент. Так как a = {realPart} < 0, b = {imaginaryPart} < 0, то получаем аргумент:\n{phiSymbol} = -π + arctan(b / a) = -π + arctan({imaginaryPart} / {realPart}) = -π + arctan({argument})";
                }
                else if (realPart == 0 && imaginaryPart > 0)
                {
                    formulaArgument = $"Теперь вычисляем аргумент. Так как a = {realPart} = 0, b = {imaginaryPart} > 0, то получаем аргумент:\n{phiSymbol} = π/2";
                }
                else if (realPart == 0 && imaginaryPart < 0)
                {
                    formulaArgument = $"Теперь вычисляем аргумент. Так как a = {realPart} = 0, b = {imaginaryPart} < 0,то получаем аргумент:\n{phiSymbol} = -π/2";
                }

                // Вывод текста и формул в документ Word
                doc.Paragraphs[1].Range.Text = $"Реальная часть: {realPart}\nМнимая часть: {imaginaryPart}\nКомплексное число состоит из действительной и мнимой части:\na=Rez={realPart}\nb=Imz={imaginaryPart}\nПрименяя формулу вычисления модуля получаем:\n{formulaModulus}\n{formulaArgument}";
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
                sheet.Cells[3, 2].Value = $"Модуль: √({realPart}^2 + {imaginaryPart}^2) = {modulus}";
                sheet.Cells[4, 2].Value = $"Аргумент: arctan({imaginaryPart} / {realPart}) = {argument} градусов";
            }
            sheet.Columns.AutoFit();
            sheet.Rows.AutoFit();
            excel.Visible = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        string phiSymbol = "\u03C6";
                        Complex complexNumber = new(realPart, imaginaryPart);
                        double modulus = Math.Sqrt(realPart * realPart + imaginaryPart * imaginaryPart);
                        argument = Math.Atan2(complexNumber.Imaginary, complexNumber.Real);
                        string formulaModulus = $"|z| = √a² + b² = √({realPart}² + {imaginaryPart}²) = √({realPart * realPart} + {imaginaryPart * imaginaryPart}) = √({modulus * modulus}) = {modulus}";
                        PdfFont timesFont = PdfFontFactory.CreateFont("c:/windows/fonts/times.ttf", PdfEncodings.IDENTITY_H, true);
                        var document = new Document(pdf);
                        document.Add(new Paragraph($"Реальная часть: {realPart}").SetFont(timesFont));
                        document.Add(new Paragraph($"Мнимая часть: {imaginaryPart}").SetFont(timesFont));
                        document.Add(new Paragraph($"Комплексное число состоит из действительной и мнимой части:").SetFont(timesFont));
                        document.Add(new Paragraph($"a=Rez={realPart}").SetFont(timesFont));
                        document.Add(new Paragraph($"b=Imz={imaginaryPart}").SetFont(timesFont));

                        document.Add(new Paragraph($"Применяя формулу вычисления модуля получаем: {formulaModulus}").SetFont(timesFont));

                        string formulaArgument = "";
                        if (realPart > 0)
                        {
                            formulaArgument = $"Теперь вычисляем аргумент. Так как a = {realPart} > 0, то получаем аргумент:\n{phiSymbol} = arctan(b / a) = arctan({imaginaryPart} / {realPart}) = arctan({argument})";
                        }
                        else if (realPart < 0 && imaginaryPart >= 0)
                        {
                            formulaArgument = $"Теперь вычисляем аргумент. Так как a = {realPart} < 0, b = {imaginaryPart} >= 0, то получаем аргумент:\n{phiSymbol} = π + arctan(b / a) = π + arctan({imaginaryPart} / {realPart}) = π + arctan({argument})";
                        }
                        else if (realPart < 0 && imaginaryPart < 0)
                        {
                            formulaArgument = $"Теперь вычисляем аргумент. Так как a = {realPart} < 0, b = {imaginaryPart} < 0, то получаем аргумент:\n{phiSymbol} = -π + arctan(b / a) = -π + arctan({imaginaryPart} / {realPart}) = -π + arctan({argument})";
                        }
                        else if (realPart == 0 && imaginaryPart > 0)
                        {
                            formulaArgument = $"Теперь вычисляем аргумент. Так как a = {realPart} = 0, b = {imaginaryPart} > 0, то получаем аргумент:\n{phiSymbol} = π/2";
                        }
                        else if (realPart == 0 && imaginaryPart < 0)
                        {
                            formulaArgument = $"Теперь вычисляем аргумент. Так как a = {realPart} = 0, b = {imaginaryPart} < 0,то получаем аргумент:\n{phiSymbol} = -π/2";
                        }

                        document.Add(new Paragraph(formulaArgument).SetFont(timesFont));

                        if (modulusLabel.Text.Contains("\u221E") || argumentLabel.Text.Contains("\u221E"))
                        {
                            document.Add(new Paragraph("На ноль делить нельзя!"));
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