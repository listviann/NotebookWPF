using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace NotebookWPF
{
    public class JsonFileService : IFileService
    {
        public List<PersonContact> Open(string filename)
        {
            List<PersonContact> contacts = new List<PersonContact>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<PersonContact>));

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                contacts = jsonFormatter.ReadObject(fs) as List<PersonContact>;
            }

            return contacts;
        }

        public void Save(string filename, List<PersonContact> contactsList)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<PersonContact>));

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, contactsList);
            }
        }
    }
}
