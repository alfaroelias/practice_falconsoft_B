using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using practice_falconsoft_B_2.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace practice_falconsoft_B_2.Services
{
    public class DownloadService : IDownloadService
    {

        private readonly IOptions<MyAppSettings> _options;

        public DownloadService(IOptions<MyAppSettings> options)
        {
            _options = options;
        }
                
        public List<Sample> DownloadJson()
        {
            string urlSample = _options.Value.UrlSample;

            string json = (new WebClient()).DownloadString(urlSample);
            
            List<Sample> listaDescargada = JsonConvert.DeserializeObject<List<Sample>>(json);
            return listaDescargada;
        }

        public void SaveJsonToFile(List<Sample> lista)
        {
            string folderPath = _options.Value.FolderPath;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            File.WriteAllText(folderPath + @"\descarga.json", JsonConvert.SerializeObject(lista));
        }

        public async Task<int> GetTotalQty()
        {
            int total = 0;

            await Task.Run(() =>
            {                
                List<Sample> listaDescargada = DownloadJson();
    
                Task.Delay(500);

                foreach (var item in listaDescargada)
                {  
                    total += item.Qty;
                }                
            });

            return total;
        }
    }
}
