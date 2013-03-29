using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgPort.Data
{
    public interface IImageRepository
    {
        string GetDirectImageUrl(string imageName);
        string SaveImage(byte[] image);
        string SaveImage(byte[] image, string name);
    }
}
