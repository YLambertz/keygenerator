using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace SHA256_Keygenerator
{

    public partial class MainWindow : Window
    {


            private string Code { get; set; }
            private string Filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/SHA256_Key";

            public string key { get; set; }



        public MainWindow()
        {
            InitializeComponent();
        }


        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            Code = tbxCode.Text;


                try
                {
                    if (File.Exists(Filepath))     //Datei löschen, wenn Sie bereits exisitert
                        File.Delete(Filepath);

                    TextWriter file = new StreamWriter(Filepath, true);

                    key = SHA256Generator.CreateSHA256(Code);

              

                    file.WriteLine(key);
                    file.WriteLine("");
                  


                    file.Close();
                    MessageBox.Show("Datei auf dem Desktop erstellt", "Erstellt", MessageBoxButton.OK, MessageBoxImage.Information);



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler: " + ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            





        }

    }

}
