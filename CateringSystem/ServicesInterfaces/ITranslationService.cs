using System.Threading.Tasks;

namespace CateringSystem.ServicesInterfaces
{
    public interface ITranslationService
    {
        Task<string> Translate(string text, string fromLanguage, string toLanguage);
    }
}
