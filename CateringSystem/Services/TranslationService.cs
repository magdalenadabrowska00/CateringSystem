using CateringSystem.Data.Models;
using CateringSystem.ServicesInterfaces;
using DeepL;
using DeepL.Model;
using System.Threading.Tasks;

namespace CateringSystem.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly DeepLAuthorizationModel _deepLAuthorizationModel;

        public TranslationService(DeepLAuthorizationModel deepLAuthorizationModel)
        {
            _deepLAuthorizationModel = deepLAuthorizationModel;
        }

        public async Task<string> Translate(string text, string fromLanguage, string toLanguage)
        {
            var translationModel = Configuration();
            var translator = translationModel.Translator;

            var result = await translator.TranslateTextAsync(
                text,
                fromLanguage,
                toLanguage);

            return result.Text;
        }

        private TranslationModel Configuration()
        {
            var translator = new Translator(_deepLAuthorizationModel.AuthorizationKey);
            return new TranslationModel { Translator = translator };
        }
    }
}
