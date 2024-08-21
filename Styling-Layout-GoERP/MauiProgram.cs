using Microsoft.Extensions.Logging;

namespace Styling_Layout_GoERP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Roboto_Thin.ttf", "RobotoThin");
                    fonts.AddFont("Roboto_Light.ttf", "RobotoLight"); 
                    fonts.AddFont("Roboto_Regular.ttf", "RobotoRegular");
                    fonts.AddFont("Roboto_Medium.ttf", "RobotoMedium");
                    fonts.AddFont("Roboto_Bold.ttf", "RobotoBold");
                    fonts.AddFont("Roboto_Black.ttf", "RobotoBlack");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
