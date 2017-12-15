using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace rssssss
{
    public class Reader
    {

        //public void Okuma(string yuarel )
        //{
        //    this.url = yuarel;
        //    xDoc = new XmlDocument();
        //}
        string url = "http://spor.mynet.com/rss.aspx?cat=Football";
        XmlDocument xDoc = new XmlDocument();


        private void VeriDoldur()
        {
            
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string xData=wc.DownloadString(url);
            xDoc.LoadXml(xData);
            
        }

        public List<Haberler> News()
        {
            List<Haberler> gundemlistesi = new List<Haberler>();
            VeriDoldur();
            XmlNodeList nodelst = xDoc.DocumentElement.GetElementsByTagName("item");
            foreach (XmlNode node in nodelst)
            {
                Haberler h = new Haberler();
                h.haber = node.SelectSingleNode("title").InnerText;
                h.link = node.SelectSingleNode("link").InnerText;
                gundemlistesi.Add(h);

            }


            return gundemlistesi;
        }


    }
}
