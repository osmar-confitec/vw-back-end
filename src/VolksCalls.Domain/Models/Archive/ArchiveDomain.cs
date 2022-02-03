using System;
using System.Collections.Generic;
using System.Text;
using VolksCalls.Domain.Models.Calls;

namespace VolksCalls.Domain.Models.Archive
{

    public enum TypeFile
    {

        RG,
        CPF,
        Picture,
        

    }
    public enum FileLocation
    {

        Folder,
        DataBase,
        Cloud

    }

    public enum Extension
    {
        txt = 1,
        zip = 2,
        jpge = 3,
        word = 4,
        excel = 5,
        jpg = 6,
        noextension = 7,
        bmp = 8,
        gif = 9,
        jpeg = 10,
        png = 11,
        rar = 12,
        doc = 13,
        docx = 14,
        ppt = 15,
        pdf = 16,
        xls = 17,
        xlsx = 18,
        sql = 19,
        na = 20
    }
    public class ArchiveDomain : EntityDataBase
    {
        public string FileName { get; set; }

        public Guid Identity { get; set; }

        public TypeFile? TypeFile { get; set; }

        public long Size { get; set; }

        public virtual CallsDomain CallsDomain { get; set; }
        public Guid? CallsDomainId { get; set; }
        public FileLocation FileLocation { get; set; }

        public string Path { get; set; }

        public string Base64 { get; set; }

        public Extension Extension { get; set; }

        public ArchiveDomain()
        {
            FileLocation = FileLocation.Folder;
            Identity = Guid.NewGuid();

        }


    }
}
