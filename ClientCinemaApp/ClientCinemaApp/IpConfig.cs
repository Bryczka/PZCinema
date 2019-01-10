using System;
using System.IO;

namespace ClientCinemaApp
{

    class IpConfig
    {

        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "IpConfig.txt");

        string readValue;

        public string GetIpAsync()
        {
            try
            {

                if (File.Exists(fileName))
                {
                    readValue = File.ReadAllText(fileName);

                    if (readValue.Equals(""))
                    {

                        return "000.000.0.000";
                    }
                    else
                    {

                        return readValue;
                    }
                }
                else
                {
                    return "000.000.0.000";
                }
            }
            catch
            {
                return "000.000.0.000";
            }

        }

        public void SetIp(string NewIp)
        {
            File.WriteAllText(fileName, NewIp);
            
        }
    }
}
