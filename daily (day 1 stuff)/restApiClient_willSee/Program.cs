using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace restApiClient_willSee
{
    class RestClient
    {
        public enum HttpVerb
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public string EndPoint { get; set; }
        public HttpVerb httpMethod { get; set; }

        public RestClient()
        {
            EndPoint = string.Empty;
            httpMethod = HttpVerb.GET;
        }


        public string MakeRequest()
        {
            string strResponse = string.Empty;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(EndPoint);
            req.Method = httpMethod.ToString();
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                if (resp.StatusCode != HttpStatusCode.OK)
                {
                    //thow error
                    Console.WriteLine("There was a problem, no response");
                }

                //the response could be in any format, it returns a stream
                using (Stream _stream = resp.GetResponseStream())
                {
                    if (_stream != null)
                    {
                        using (StreamReader sr = new StreamReader(_stream))
                        {
                            strResponse = sr.ReadToEnd();
                        }
                    }
                }
            }

            return strResponse;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            RestClient rc = new RestClient();
            //rc.EndPoint = "http://dry-cliffs-19849.herokuapp.com/users.json";
            rc.EndPoint = @"http://localhost:1234/test";
            Console.WriteLine(rc.MakeRequest());


            //mrl
            Console.ReadLine();
        }
    }
}
