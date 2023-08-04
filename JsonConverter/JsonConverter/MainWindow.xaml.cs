using System;
using System.Windows;
using Newtonsoft.Json;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using Microsoft.Win32;
using System.Collections.Generic;

namespace JsonConverter
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filename;
        private string xmlFile;
        private string jsonFile;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// Butona basıldığında .json uzantılı bir dosyayı açmak üzere dosya seçimi aktif oluyor.
        /// Ardından seçilen bu dosyayı filename bir değişkende kullanmak üzere tutuyoruz.
        /// </summary>      
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.ItemsSource = "";
            ListBox2.ItemsSource = "";

            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".json | .xml";
            dlg.Filter = "JSON files (*.json)|*.json| XML files (*.xml)|*.xml";

            //kullanıcı dosya seçip tamam' a basarsa.
            if (dlg.ShowDialog() == true)
            {
                filename = dlg.FileName;
                lbLoadFile.Content = filename;
            }

            //** Extra Yöntem ** bir düğmeye tıklandıysa işlem yap diyebilmek için Nullable kullanıldı.
            //Nullable<bool> result = dlg.ShowDialog();
            //if (result == true)
            //{  
            //filename = dlg.FileName;
            //lbYukluDosya.Content = filename;                          
            //}

            //Listeye aktarma işlemleri.
            var aktarilacak = new List<string>();
            using (var streamReader = File.OpenText(filename))
            {
                var s = string.Empty;
                while ((s = streamReader.ReadLine()) != null)
                    aktarilacak.Add(s);
            }
            ListBox1.ItemsSource = aktarilacak;

        } 
        /// <summary>
        /// Dosyayı okuyup dosya içeriğini JSON formattan XML hale çeviren kod.
        /// </summary>
        private void btnConvertJsonToXml_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
            {
               
                string jsonIcerik = File.ReadAllText(filename);             
                XDocument xdocument = JsonConvert.DeserializeXNode(jsonIcerik);
                XmlDocument xmlDocument = new XmlDocument();
                
                using (var xmlReader = xdocument.CreateReader())
                {
                    xmlDocument.Load(xmlReader);
                }
                xmlFile = Path.ChangeExtension(filename, ".xml");
                xmlDocument.Save(xmlFile);
                ProgressBar.Value = ProgressBar.Maximum;

                //Dönüşen listesine aktarma işlemi.
                var aktarilacak = new List<string>();
                using (var streamReader = File.OpenText(xmlFile))
                {
                    var s = string.Empty;
                    while ((s = streamReader.ReadLine()) != null)
                        aktarilacak.Add(s);
                }
                ListBox2.ItemsSource = aktarilacak;
                lbConvertingFile.Content = xmlFile;
            }
            else
            {
                MessageBox.Show("Önce dosyayı seç");
            }
        }
        /// <summary>
        /// Dosyayı okuyup dosya içeriğini XML formattan JSON hale çeviren kod.
        /// </summary>
        private void btnConvertXmlToJson_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
            {
                //filename dosya içeriğinin tamamını bir değişkene alıyoruz.
                string xmlIcerik = File.ReadAllText(filename);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlIcerik);
                XDocument xdocument = XDocument.Parse(xmlIcerik);          
                string jsonIcerik = JsonConvert.SerializeObject(xdocument, Newtonsoft.Json.Formatting.Indented);

                jsonFile = Path.ChangeExtension(filename, ".json");
                File.WriteAllText(jsonFile, jsonIcerik);

                ProgressBar.Value = ProgressBar.Maximum;
                lbDegisen.Content = "Dönüştürülen Json Dosyası :";
                
                var aktarilacak = new List<string>();
                using (var streamReader = File.OpenText(jsonFile))
                {
                    var s = string.Empty;
                    while ((s = streamReader.ReadLine()) != null)
                        aktarilacak.Add(s);
                }
                ListBox2.ItemsSource = aktarilacak;
                lbConvertingFile.Content = jsonFile;
            }
            else
            {
                MessageBox.Show("Önce dosyayı seç");
            }
        }
        /// <summary>
        /// JSON formata dönüştürülmüş dosyayı indirmek için kullanılan kod.
        /// </summary>
        private void btnDownloadJson_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(jsonFile))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "JSON Files (*.json)|*.json";
                saveFileDialog.FileName = Path.GetFileName(jsonFile);              
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if(saveFileDialog.ShowDialog()==true)
                {
                    File.Copy(jsonFile, saveFileDialog.FileName, true);
                }
            }
            else
            {
                MessageBox.Show("Önce Dönüşüm Yapın.");
            }
        }

        /// <summary>
        /// XML formata dönüştürülmüş dosyayı indirmek için kullanılan kod.
        /// </summary>
        private void btnDownloadXML_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(xmlFile))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
                saveFileDialog.FileName = Path.GetFileName(xmlFile);
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.Copy(xmlFile, saveFileDialog.FileName, true);
                }
            }
            else
            {
                MessageBox.Show("Önce Dönüşüm Yapın.");
            }
        }
    }
}
