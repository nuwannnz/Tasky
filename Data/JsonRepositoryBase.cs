using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Data
{
    public abstract class JsonRepositoryBase<Ttype>
    {
        
        private static string _fileName = "tasky.json";
        private static  List<Ttype> _entityList = new List<Ttype>();
      
        protected  List<Ttype> GetEntityList()
        {
            return  _entityList;
        }

        protected  void SetEntityList(ref List<Ttype> list)
        {
            _entityList = list;
        }

        protected static string GetFilePath()
        {
            return string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, _fileName);
        }


        protected static  void WriteStringToFile(string filePath, string contentToWrite)
        {

           System.IO.File.WriteAllText(filePath, contentToWrite);
           
        }

        protected static async Task<string> GetFileAsString(string filePath)
        {
            string content = string.Empty;

            using (var stream = new FileStream(GetFilePath(), FileMode.OpenOrCreate))
            {
                byte[] buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer, 0, buffer.Length);
                content = Encoding.ASCII.GetString(buffer);
               
            }
           
            return content;
        }

        protected static List<Ttype> DesirializeJson(string jsonContent)
        {
            List<Ttype> desirializedList = new List<Ttype>();
            try
            {
                if (!string.IsNullOrEmpty(jsonContent))
                    desirializedList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ttype>>(jsonContent);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error occured in Json repo. DesirializeJson() ." + ex.Message.ToString());
            }
            return desirializedList;
        }

        protected static string SerializeJson(List<Ttype> list)
        {
            string jsonContent = string.Empty;

            try
            {
                jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error occured in Json repo. SerializeJson()." + ex.ToString());
            }
            return jsonContent;
        }
    }
}
