using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace WpfApp_labo_StringZoekenBestand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> emails = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void openBttn_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                OpenFileDialog ofd = new OpenFileDialog
                {
                    InitialDirectory = Environment.CurrentDirectory,

                };

                if (ofd.ShowDialog() == true)
                {
                    fileTextBox.Text = ofd.FileName;

                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            emails.Add(sr.ReadLine());
                        }
                        resultTextBx.Text = sr.ReadToEnd();
                    }
                }

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
            
            
         
        }

        private void seachrBtnn_Click(object sender, RoutedEventArgs e)
        {
            resultTextBx.Clear();
            string gezocht = stringTxtBox.Text;
            int counter = 0;

            for (int i = 0; i < emails.Count; i++)
            {

                if (emails[i].Contains(gezocht))
                {
                    counter++;

                    resultTextBx.Text += $"Email.txt: regel : {i +1} - {emails[i]}\n" ;                 

                }
            }

            resultTextBx.Text += $"{gezocht} gevonden in {counter} regels (totaal {emails.Count} regels)";
        }
    }
}
