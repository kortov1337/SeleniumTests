using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverTests
{
    public class PostData
    {
        string header;
        string tag;
        string text;
        string picturePath;

        public PostData(string header, string tag, string text, string picturePath)
        {
            this.Header = header;
            this.Tag = tag;
            this.Text = text;
            this.PicturePath = picturePath;
        }

        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
            }
        }

        public string Tag
        {
            get
            {
                return tag;
            }

            set
            {
                tag = value;
            }
        }

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        public string PicturePath
        {
            get
            {
                return picturePath;
            }

            set
            {
                picturePath = value;
            }
        }
    }
}
