using practice_falconsoft_B_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace practice_falconsoft_B_2.Services
{
    public interface IDownloadService
    {
        public List<Sample> DownloadJson();
        public void SaveJsonToFile(List<Sample> lista);
        public Task<int> GetTotalQty();
    }
}
