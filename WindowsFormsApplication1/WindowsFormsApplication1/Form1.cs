using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Collections.Specialized;
using System.Web;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Timers;

namespace WindowsFormsApplication1
{



    public partial class Form1 : Form
    {


        //0 aggiunto al carrello
        //1 insrire dati spedizione
        //2 inserire dati pagamento


        WebBrowser wb1;
        Label label;

        
        string urlCarrello = "https://www.adidas.it/on/demandware.store/Sites-adidas-IT-Site/it_IT/Cart-Show";
        string urlCheckout = "https://www.adidas.it/on/demandware.store/Sites-adidas-IT-Site/it_IT/CODelivery-Start";
        string urlCarta = "https://www.adidas.it/on/demandware.store/Sites-adidas-IT-Site/it_IT/COSummary-Start";


        string urlModello = "http://www.adidas.it/BB1826.html";
        string sizeAttributeKey = "size-select-BB5039";
        string sizeAttributeValue = "BB5039_630";
        string sizeAttributeKeyaaaa = "size-select-BB1826";
        string sizeAttributeValueaa = "BB1826_640";

        Stopwatch stopwatch;
        private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        public Form1()
        {

            InitializeComponent();
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            wb1 = this.webBrowser1;
            label = this.label1;
            wb1.sc
            wb1.ScriptErrorsSuppressed = true;
            stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();
            var size4023 = Tuple.Create("40 2/3", "600");
            var size4113 = Tuple.Create("41 1/3", "610");
            var size42 = Tuple.Create("42", "620");
            var size4223 = Tuple.Create("42 2/3", "630");
            var size4313 = Tuple.Create("43 1/3", "640");



            //this.checkPagesDifference();






            //
            wb1.Navigate(urlModello);

           
            wb1.DocumentCompleted += (object sender, WebBrowserDocumentCompletedEventArgs e) =>

            {
                Console.WriteLine("absolute path : {0}, absolute uri : {1}, toString() : {2}", e.Url.AbsolutePath, e.Url.AbsoluteUri, e.Url.ToString());

                
                if (e.Url.ToString() == urlCarrello)
                {




                    //var carrelloCount = wb1.Document.GetElementsByTagName("select").GetElementsByName("dwfrm_cart_shipments_i0_items_i0_quantity");
                    //carrelloCount[0].GetElementsByTagName("option")[0].SetAttribute("selected","selected");


                    HtmlElementCollection cartButton = ((WebBrowser)sender).Document.GetElementsByTagName("button").GetElementsByName("dwfrm_cart_checkoutCart");
                    cartButton[0].InvokeMember("Click");




                    /*HtmlElementCollection elc = ((WebBrowser)sender).Document.GetElementsByTagName("input");
                    HtmlElementCollection elc1 = ((WebBrowser)sender).Document.GetElementsByTagName("button");
                    //var asd = ((WebBrowser)sender).Document.GetElementsByTagName("input").GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_firstName");
                    elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_firstName")[0].SetAttribute("value", "Stefano");
                    elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_lastName")[0].SetAttribute("value", "Carioni");
                    elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_address1")[0].SetAttribute("value", "Via Rovigo");
                    elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_houseNumber")[0].SetAttribute("value", "13");
                    elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_zip")[0].SetAttribute("value", "20093");
                    elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_city")[0].SetAttribute("value", "Cologno Monzese");
                    elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_phone")[0].SetAttribute("value", "+393337599826");
                    elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_email_emailAddress")[0].SetAttribute("value", "phoenixxperia@gmail.com");


                    foreach (HtmlElement el in elc1)
                    {

                            if (el.GetAttribute("name").Equals("dwfrm_delivery_savedelivery"))
                            {
                                el.InvokeMember("Click");
                            }

                    }*/
                }
                else if (e.Url.ToString() == urlCheckout)
                {





                    ((WebBrowser)sender).Document.GetElementById("dwfrm_delivery_singleshipping_shippingAddress_addressFields_firstName").SetAttribute("value", "Stefano");
                    ((WebBrowser)sender).Document.GetElementById("dwfrm_delivery_singleshipping_shippingAddress_addressFields_lastName").SetAttribute("value", "Carioni");
                    ((WebBrowser)sender).Document.GetElementById("dwfrm_delivery_singleshipping_shippingAddress_addressFields_address1").SetAttribute("value", "Via Rovigo");
                    ((WebBrowser)sender).Document.GetElementById("dwfrm_delivery_singleshipping_shippingAddress_addressFields_houseNumber").SetAttribute("value", "13");
                    ((WebBrowser)sender).Document.GetElementById("dwfrm_delivery_singleshipping_shippingAddress_addressFields_zip").SetAttribute("value", "20093");
                    ((WebBrowser)sender).Document.GetElementById("dwfrm_delivery_singleshipping_shippingAddress_addressFields_city").SetAttribute("value", "Cologno Monzese");
                    ((WebBrowser)sender).Document.GetElementById("dwfrm_delivery_singleshipping_shippingAddress_addressFields_phone").SetAttribute("value", "+393337599826");
                    ((WebBrowser)sender).Document.GetElementById("dwfrm_delivery_singleshipping_shippingAddress_email_emailAddress").SetAttribute("value", "phoenixxperia@gmail.com");

                    HtmlElementCollection cartButton = ((WebBrowser)sender).Document.GetElementsByTagName("button").GetElementsByName("dwfrm_delivery_savedelivery");
                    cartButton[0].InvokeMember("Click");

                    /* elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_lastName")[0].SetAttribute("value", "Carioni");
                     elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_address1")[0].SetAttribute("value", "Via Rovigo");
                     elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_houseNumber")[0].SetAttribute("value", "13");
                     elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_zip")[0].SetAttribute("value", "20093");
                     elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_city")[0].SetAttribute("value", "Cologno Monzese");
                     elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_addressFields_phone")[0].SetAttribute("value", "+393337599826");
                     elc.GetElementsByName("dwfrm_delivery_singleshipping_shippingAddress_email_emailAddress")[0].SetAttribute("value", "phoenixxperia@gmail.com");*/


                    /* foreach (HtmlElement el in elc1)
                     {

                         if (el.GetAttribute("name").Equals("dwfrm_delivery_savedelivery"))
                         {
                             el.InvokeMember("Click");
                         }

                     }*/
                }
                else if (e.Url.ToString() == urlCarta)
                {


                    ((WebBrowser)sender).Document.GetElementById("dwfrm_adyenencrypted_number").SetAttribute("value", "ehvolevi");
                    ((WebBrowser)sender).Document.GetElementById("dwfrm_adyenencrypted_holderName").SetAttribute("value", "Stefano Carioni");
                    ((WebBrowser)sender).Document.GetElementById("dwfrm_adyenencrypted_cvc").SetAttribute("value", "7");
                    wb1.Document.GetElementById("dwfrm_adyenencrypted_expiryMonth").SetAttribute("value", "");
                    wb1.Document.GetElementById("dwfrm_adyenencrypted_expiryYear").SetAttribute("value", "");
                    finalize(wb1, stopwatch);









                }
                else {
                    
              

                        wb1.Document.GetElementById(sizeAttributeKey).SetAttribute("value", sizeAttributeValue);
                        //((WebBrowser)sender).Document.GetElementById("dwfrm_delivery_singleshipping_shippingAddress_addressFields_firstName").SetAttribute("value", "Stefano");
                        HtmlElementCollection cartButton = ((WebBrowser)sender).Document.GetElementsByTagName("button").GetElementsByName("add-to-cart-button");
                        cartButton[0].InvokeMember("Click");
                        wb1.Navigate("https://www.adidas.it/on/demandware.store/Sites-adidas-IT-Site/it_IT/Cart-Show");


                    
                }
            };
        }




        public void checkPagesDifference() {

            var myTimer = new System.Timers.Timer();
            // Tell the timer what to do when it elapses
            myTimer.Elapsed += (object source, ElapsedEventArgs e) => {

                using (WebClient client = new WebClient())
                {
                    myTimer.Stop();
                    client.Headers.Add("User-Agent:Edge / 13.10586");
                    string htmlCode = client.DownloadString(urlModello);

                    File.Delete("D:\\sitoafter.html");
                    if (!File.Exists("D:\\sitobefore.html")) {

                        File.AppendAllText("D:\\sitobefore.html", "");
                    }

                    File.AppendAllText("D:\\sitoafter.html", htmlCode);
                    if (Form1.FilesAreEqual(new FileInfo("D:\\sitobefore.html"), new FileInfo("D:\\sitoafter.html")))
                    {

                        // NO UPDATE
                       // File.Delete("D:\\sitoafter.html");
                        Console.WriteLine("nessun aggiornamento, riprovo tra 10 secondi");
                        myTimer.Start();
                        
                    }
                    else
                    {
                        //UPDATE ( FORSE )
                        
                        File.Delete("D:\\sitoafter.html");
                        File.Delete("D:\\sitobefore.html");
                        File.AppendAllText("D:\\sitobefore.html", htmlCode);
                        wb1.Navigate(urlModello);
                    }

                }

            };
            // Set it to go off every five seconds
            myTimer.Interval = 10000;
            // And start it        
            myTimer.Start();
           
        }

        const int BYTES_TO_READ = sizeof(Int64);

        static bool FilesAreEqual(FileInfo first, FileInfo second)
        {
            
            if (first.Length != second.Length)
                return false;

            int iterations = (int)Math.Ceiling((double)first.Length / BYTES_TO_READ);

            using (FileStream fs1 = first.OpenRead())
            using (FileStream fs2 = second.OpenRead())
            {
                byte[] one = new byte[BYTES_TO_READ];
                byte[] two = new byte[BYTES_TO_READ];

                for (int i = 0; i < iterations; i++)
                {
                    fs1.Read(one, 0, BYTES_TO_READ);
                    fs2.Read(two, 0, BYTES_TO_READ);

                    if (BitConverter.ToInt64(one, 0) != BitConverter.ToInt64(two, 0))
                        return false;
                }
            }

            return true;
        }



        private async void finalize(WebBrowser webBrowser, Stopwatch watch)
        {

            await Task.Delay(500);
            HtmlElementCollection cartButton = webBrowser.Document.GetElementsByTagName("button");
            cartButton[0].InvokeMember("Click");
            // Write result.
            watch.Stop();

            MessageBox.Show("Ordine completato in : " + watch.Elapsed.ToString(), "ORDINE COMPLETATO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
            //Console.WriteLine("Time elapsed: {0}", watch.Elapsed);



        }

        




        /* var request = (HttpWebRequest)WebRequest.Create("http://www.adidas.it/on/demandware.store/Sites-adidas-IT-Site/it_IT/Cart-MiniAddProduct");

         var postData = "layer=Add To Bag overlay";
         postData += "&pid=S76721_600";
         postData += "&Quantity=1";
         postData += "&masterPid=S76721";
         postData += "&ajax=true";
         var data = Encoding.ASCII.GetBytes(postData);








         request.Method = "POST";
         //request.Accept = "* /*\r\n";   TOGLIERE LO SPAZIO
         request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
         request.Referer = "http://www.adidas.it/scarpe-tubular-radial/S76721.html";
         request.AllowAutoRedirect = true;

         request.Headers.Add("Accept-Language", " it-IT,it;q=0.5");
         request.Headers.Add("Accept-Encoding", "gzip, deflate");
         request.Headers.Add("X-Requested-With", "XMLHttpRequest");
         request.Host = "www.adidas.it";
         request.UserAgent = "User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 46.0.2486.0 Safari / 537.36 Edge / 13.10586";
         request.ContentLength = data.Length;

         using (var stream = request.GetRequestStream())
         {
             stream.Write(data, 0, data.Length);
         }


         var response = (HttpWebResponse)request.GetResponse();
         var prova = response.ToString();
         foreach (Cookie cook in response.Cookies)
         {
             cookieColl.Add(cook);
             InternetSetCookie("http://www.adidas.it/scarpe-tubular-radial/S76721.html", cook.Name, cook.Value);

         }


         var gzipstream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);

         StreamReader readerext = new StreamReader(gzipstream);

         var code = readerext.ReadToEnd();


         using (StreamReader reader = new StreamReader(gzipstream))
         {
             // use whatever method you want to save the data to the file...
             //File.AppendAllText("D:\\test.html", response.Headers.ToString());
             //byte[] bytes = Encoding.Default.GetBytes(reader.ReadToEnd());
             //var decode = Encoding.UTF8.GetString(bytes);
             File.Delete("D:\\test.html"); 
             File.AppendAllText("D:\\test.html", code);
             //File.AppendAllText("D:\\teststring.html", );
             //File.AppendAllText("D:\\testprova.html", prova);
             //File.AppendAllText("D:\\test.html", Encoding.UTF8.(reader.ReadToEnd());
         }

         if (code != null)
         {
             //browser.DocumentText = code;
             runBrowserThread(code);
             Console.WriteLine("dentro");
             //browser.Show();

         }


 */
        // https://www.adidas.it/on/demandware.store/Sites-adidas-IT-Site/it_IT/CODelivery-Start
        //Application.Run(new Form1());






    }

    /* private void runBrowserThread(string code)
     {
         var th = new Thread(() => {
             //var br = new WebBrowser();


             wb1.DocumentCompleted += browser_DocumentCompleted;
             //wb1.Navigate("http://www.adidas.it/scarpe-tubular-radial/S76721.html");
             //wb1.DocumentText = code;
             Application.Run();
         });

         th.SetApartmentState(ApartmentState.STA);
         th.Start();
     }

     void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
     {
         var br = sender as WebBrowser;

         if (br.Url == e.Url)
         {
             Console.WriteLine("Navigated to {0}", e.Url);
             if (counter == 0)
             {
                 wb1.Navigate("https://www.adidas.it/on/demandware.store/Sites-adidas-IT-Site/it_IT/CODelivery-Start");
                 //wb1.Navigate("https://www.adidas.it/on/demandware.store/Sites-adidas-IT-Site/it_IT/Cart-Show");
             }
             else if (counter == 1)
             {

             }
             //File.WriteAllText("D:\\"+counter+".html", wb1.Document.Body.Parent.OuterHtml, Encoding.GetEncoding(wb1.Document.Encoding));
             counter++;
             //Application.ExitThread();   // Stops the thread
         }
     }*/

}





