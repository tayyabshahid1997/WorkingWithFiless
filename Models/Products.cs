using System.Collections.Generic;
using System.Web;

namespace WorkingWithFiles.Models
{
    public class Products
    {
        public string FileN { get; set; }
        public string FilePath { get; set; }
        public HttpPostedFileBase UploadFile { get; set; }
        public List<Products> lstProducts { get; set; }
    }
}