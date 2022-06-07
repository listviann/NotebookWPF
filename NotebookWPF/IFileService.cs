using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookWPF
{
    public interface IFileService
    {
        List<PersonContact> Open(string filename);
        void Save(string filename, List<PersonContact> contactsList);
    }
}
