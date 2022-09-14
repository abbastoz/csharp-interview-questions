using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueInterview
{
    public class PhotoBook
    {
        protected int numPages;

        public PhotoBook()
        {
            numPages = 16;            
        }
        public PhotoBook(int numPage)
        {
            numPages = numPage;
        }
        public void GetNumberPages()
        {
            Console.WriteLine(numPages.ToString());
        }
    }
}
