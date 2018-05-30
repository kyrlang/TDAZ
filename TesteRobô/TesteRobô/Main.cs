using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotTest
{
    public partial class TestForm : Form
    {
        List<SearchResult> SearchResultsData = new List<SearchResult>();
        string bingUrl = "http://www.bing.com/";

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (TestBrowser.Document.Url.Equals(bingUrl)) //URL setada na propriedade do objeto, se igual a ela SearchForABSCard
                    SearchForABSCard();
                else if (TestBrowser.Document.Url.ToString().Contains("http://www.bing.com/search?q=")) //se contem essa url na propriedade
                {
                    var resultsElements = TestBrowser.Document.GetElementById("b_results").Children;

                    foreach (HtmlElement result in resultsElements)
                    {
                        if (result.OuterHtml.Contains("b_algo"))
                        {
                            HtmlElement body = result.Children[1];

                            var title = result.Children[0].InnerText.Trim();
                            var url = body.Children[0].InnerText.Trim();
                            var description = body.Children[1].InnerText.Trim();

                            SearchResultsData.Add(new SearchResult
                            {
                                Title = title,
                                Description = description,
                                Url = url
                            });
                        }
                    }

                    WriteDataInCsv();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao realizar essa tarefa. A aplicação será fechada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        public void SearchForABSCard()
        {
            var searchBox = TestBrowser.Document.GetElementById("sb_form_q"); // busca o elemento responsável por realizar a pesquisa no navegador
            searchBox.InnerText = "ABSCard Gestão de Benefícios"; // com essa informação

            var searchButton = TestBrowser.Document.GetElementById("sb_form_go"); // encontra o elemento responsável por iniciar a busca
            searchButton.InvokeMember("click"); //executa ela atravé do click
        }

        public void WriteDataInCsv()
        {
            string localPath = Application.StartupPath + @"\SearchResults.csv";
            var sw = new StreamWriter(localPath);

            foreach (var searchResult in SearchResultsData)
            {
                sw.WriteLine(searchResult.Title);
                sw.WriteLine(searchResult.Url);
                sw.WriteLine(searchResult.Description);
                sw.WriteLine();
            }

            sw.Flush();
            sw.Dispose();

            Process.Start("notepad.exe", localPath);
            Close();
        }
    }
}
