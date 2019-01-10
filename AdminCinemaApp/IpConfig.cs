using System.IO;

namespace AdminCinemaApp
{
    class IpConfig
    {



        public string GetIp()
        {
            try
            {
                FileStream fileStream = new FileStream(Directory.GetCurrentDirectory() + "\\IpConfig.txt", FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fileStream);
                string readValue = streamReader.ReadLine();
                if (readValue.Equals(""))
                {
                    fileStream.Close();
                    streamReader.Close();
                    return "000.000.0.000";
                }
                else
                {
                    fileStream.Close();
                    streamReader.Close();
                    return readValue;
                }

            }
            catch
            {
                return "000.000.0.000";
            }

        }

        public void SetIp(string NewIp)
        {

            FileStream fileStream = new FileStream(Directory.GetCurrentDirectory() + "\\IpConfig.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(NewIp);
            streamWriter.Close();

        }
    }
}
