using FitLife.Services;
using FitLife.Repositories;
using FitLife.Screens;
using FitLife.Database;

namespace FitLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicializar BD
            DbInitializer.Initialize();

            // Dependencias
            var mRepo = new MiembroRepository();
            var service = new GymService(mRepo);

            // Iniciar UI
            var menu = new MenuPrincipal(service);
            menu.Mostrar();
        }
    }
}
