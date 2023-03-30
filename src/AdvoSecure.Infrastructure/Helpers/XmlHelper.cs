using Serilog;
using System.Xml.Serialization;

namespace AdvoSecure.Infrastructure.Helpers
{
    public class XmlHelper<T> where T : class
    {        
        public async Task<T> Read(string path)
        {            
            var numRetries = 10;

            for (int n = 0; n < numRetries; n++)
            {
                Log.Logger.Here(this).Information($"{path} attempt {n}");

                try
                {
                    using (var reader = new StreamReader(path))
                    {
                        var serializer = new XmlSerializer(typeof(T));
                        var xml = (T)serializer.Deserialize(reader);

                        return xml;                                             
                    }
                }
                catch(IOException ex)
                {
                    Log.Logger.Here(this).Information($"{path} cannot be read. {ex.Message}");

                    await Task.Delay(1000);                    
                }
            }

            throw new InvalidOperationException();
        }

        public T ReadXml(string s)
        {
            using (TextReader reader = new StringReader(s))
            {
                var serializer = new XmlSerializer(typeof(T));
                var xml = (T)serializer.Deserialize(reader);

                return xml;
            }
        }
    }
}
