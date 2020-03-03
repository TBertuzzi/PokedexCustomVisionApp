using System;
using System.IO;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace PokedexCustomVisionApp.Services
{
    public interface ICustomVision
    {
        Task<string> GetPrediction(string url);
        Task<string> GetPrediction(byte[] image);
        Task<string> GetClassifyImage(MediaFile photo);
    }
}
