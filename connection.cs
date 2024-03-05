using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace deep
{
    public class connection
    {
        public static string getconnectionstring()
        {
           return ConfigurationManager.ConnectionStrings["CS"].ConnectionString;


        }
    }
    public class utils
    {


        public static bool isvalidextension(string fileName)
        {
            bool isValid = false;
            string[] fileExtention = { ".jpg", ".png", ".jpg" };
            for (int i = 0; i < fileExtention.Length - 1; i++)
            {
                if (fileName.Contains(fileExtention[i]))
                {
                    isValid = true;
                    break;

                }
            }
            return isValid;
        }
        public static string getimageurl(object url)
        {
            string url1 = "";
            if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                url1 = "..Image/no-image.png";
            }
            else
            {
                url1 = string.Format("../{0}", url);
            }
            return url1;
        }



    }


}