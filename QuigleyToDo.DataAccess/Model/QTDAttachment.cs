using System;
using System.Collections.Generic;
using System.Text;

namespace QuigleyToDo.DataAccess.Model
{
    public class QTDAttachment
    {
        public int TaskID { get; set; }
        public string TaskAttachmentLink { get; set; }
        public string TaskAttachmentLinkFriendly { get; set; }
        public string TaskAttachmentFileName { get; set; }
        public int TaskAttachmentID { get; set; }
        public DateTime DateCreated { get; set; }
        public string TaskFileLocation { get; set; }
        public byte[] ContentBytes { get; set; }     
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public byte[] ImageBytes { get; set; }
        public string Thumbnail
        {
            get 
            {
                if (ContentBytes != null)
                    return string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(ContentBytes));
                else
                    return null;
            }
        }
        public string SizePlusTypeummary
        {
            get
            {
                return string.Format("{0}{1}{2}{3}", (FileSize/1000).ToString(), " KB", " - ", FileType);
            }
        }
        public string AttachmentUrl 
        {
            get
            {
                return string.Format("{0}{1}{2}{3}{4}{5}", TaskAttachmentLink, ", ", (FileSize / 1000).ToString(), " KB", " - ", FileType);
            }
        }
        public bool IsImage
        {
            get
            {
                string extensions = "ai;bmp;gif;ico;jpeg;jpg;png;ps;psd;svg;tif;tiff;image/png";
                return extensions.Contains(FileType) ? true : false;
            }
        }


    }
}
