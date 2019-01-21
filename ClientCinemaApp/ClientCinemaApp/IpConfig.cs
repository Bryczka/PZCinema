using System;
using System.IO;

namespace ClientCinemaApp
{

    class IpConfig
    {
        readonly string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "IpConfig.txt");
        readonly string emptyIp = "000.000.0.000";
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
                        return emptyIp;
                    }
                    else
                    {
                        return readValue;
                    }
                }
                else
                {
                    return emptyIp;
                }
            }
            catch
            {
                return emptyIp;
            }
        }

        public void SetIp(string NewIp)
        {
            File.WriteAllText(fileName, NewIp);
        }
    }
}
