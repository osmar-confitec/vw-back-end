using System;
using System.Collections.Generic;
using System.Text;

namespace VolksCalls.Infra.CrossCutting.Documents
{
   public class DocumentRead<T>
    {

        public T FileRead { get; set; }

        public DocumentRead(T fileRead)
        {
            FileRead = fileRead;
        }
        

    }
}
