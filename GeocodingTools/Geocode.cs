using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeocodingTools
{
    class Geocode
    {
        public static string GeoEncoding(string address, string key)
        {
            string json = "";
            try
            {

                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string url = String.Format("https://restapi.amap.com/v3/geocode/geo?key={0}&address={1}&output=json", key, address);

                // 解决WebClient不能通过https下载内容问题
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                             System.Security.Cryptography.X509Certificates.X509Chain chain,
                             System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true; // **** Always accept
                    };

                //将返回的json数据转为JSON对象
                JObject jo = ((JObject)JsonConvert.DeserializeObject(client.DownloadString(url)));
                string status = jo["status"].ToString();
                if (status == "1")
                {
                    {
                        //返回需要的字段
                        json = jo["geocodes"][0]["city"].ToString()+","+ jo["geocodes"][0]["district"].ToString() + "," + jo["geocodes"][0]["location"].ToString() + "," + jo["geocodes"][0]["location"].ToString();
                    }
                }
                else
                {
                    json = "null,null,null,null";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return json;
        }

        public static string GeoEncoding(string address,string city, string key)
        {
            string json = "";


            try
            {

                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string url = String.Format("https://restapi.amap.com/v3/geocode/geo?key={0}&address={1}&city={2}&output=json", key, address,city);

                // 解决WebClient不能通过https下载内容问题
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                             System.Security.Cryptography.X509Certificates.X509Chain chain,
                             System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true; // **** Always accept
                    };

                //将返回的json数据转为JSON对象
                JObject jo = ((JObject)JsonConvert.DeserializeObject(client.DownloadString(url)));
                string status = jo["status"].ToString();
                if (status == "1")
                {
                    {
                        //正常返回
                        json = jo["geocodes"][0]["city"].ToString() + "," + jo["geocodes"][0]["district"].ToString() + "," + jo["geocodes"][0]["location"].ToString() + "," + jo["geocodes"][0]["location"].ToString();
                    }
                }
                else
                {
                    json = "null,null,null,null";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return json;
        }
        public static string GeoareaEncoding(string address, string area, string key)
        {
            string json = "";


            try
            {

                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string url = String.Format("https://restapi.amap.com/v3/geocode/geo?key={0}&address={1}&city={2}&output=json", key, address, area);

                // 解决WebClient不能通过https下载内容问题
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                             System.Security.Cryptography.X509Certificates.X509Chain chain,
                             System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true; // **** Always accept
                    };

                //将返回的json数据转为JSON对象
                JObject jo = ((JObject)JsonConvert.DeserializeObject(client.DownloadString(url)));
                string status = jo["status"].ToString();
                if (status == "1")
                {
                    {
                        //正常返回
                        json = jo["geocodes"][0]["city"].ToString() + "," + jo["geocodes"][0]["district"].ToString() + "," + jo["geocodes"][0]["location"].ToString() + "," + jo["geocodes"][0]["location"].ToString();
                    }
                }
                else
                {
                    json = "null,null,null,null";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return json;
        }
        public static string GeoEncoding(string address, string city, string area, string key)
        {
            string json = "";


            try
            {

                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string url = String.Format("https://restapi.amap.com/v3/geocode/geo?key={0}&address={1}&city={2}&district={3}&output=json", key, address, city, area);

                // 解决WebClient不能通过https下载内容问题
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                             System.Security.Cryptography.X509Certificates.X509Chain chain,
                             System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true; // **** Always accept
                    };

                //将返回的json数据转为JSON对象
                JObject jo = ((JObject)JsonConvert.DeserializeObject(client.DownloadString(url)));
                string status = jo["status"].ToString();
                if (status == "1")
                {
                    {
                        //正常返回
                        json = jo["geocodes"][0]["city"].ToString() + "," + jo["geocodes"][0]["district"].ToString() + "," + jo["geocodes"][0]["location"].ToString() + "," + jo["geocodes"][0]["location"].ToString();
                    }
                }
                else
                {
                    json = "null,null,null,null";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return json;
        }
    }
}
