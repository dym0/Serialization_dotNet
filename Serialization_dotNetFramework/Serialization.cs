using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Serialization_dotNetFramework
{
    public class Serialization
    {

        BinaryFormatter formatter = new BinaryFormatter();
        //Guy _guy;
        //List<Guy> _guysList; 

        string _path;

        public Serialization( string path)
        {
           
            _path = path;
        }

      


        public void Serialize(Guy guy)
        {
            if(!File.Exists(_path))
            {
                using (Stream output = File.Create(_path))
                {
                    formatter.Serialize(output, guy);
                }
            }
            else
            {
                using (Stream output = File.OpenWrite(_path))
                {
                    formatter.Serialize(output, guy);
                }
            }
           
        }

        public void Serialize(List<Guy> guysList)
        {
            if(!File.Exists(_path))
            {
                using (Stream output = File.Create(_path))
                {
                    foreach(Guy guys in guysList )
                    {
                        formatter.Serialize(output, guys);
                    }
                }
            }
            else
            {
                using (Stream output = File.OpenWrite(_path))
                {
                    foreach (Guy guys in guysList)
                    {
                        formatter.Serialize(output, guys);
                    }
                }
            }
        }

        public Guy Deserialize(Guy testerII)
        {
            FileStream stream = new FileStream(_path, (FileMode)FileAccess.ReadWrite);
            Guy deserGuy = (Guy)formatter.Deserialize(stream);

            stream.Dispose();
            return deserGuy;
        }

        public List<Guy> DeserializeAll()
        {
            List<Guy> listGuys = new List<Guy>();
            FileStream stream = new FileStream(_path, (FileMode)FileAccess.ReadWrite);
            for (int i = 0; i < 3; i++)
            {
                listGuys.Add((Guy)formatter.Deserialize(stream));
            }
                

            stream.Dispose();
            return listGuys;

        }
    }
}
