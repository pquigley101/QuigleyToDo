using System;
using System.Collections.Generic;
using System.Text;

namespace QuigleyToDo.DataAccess.Model
{
    public class QTDAttachmentContent
    {
        public int TaskAttachmentID { get; set; }
        public byte[] ContentBytes { get; set; }
    }
}
