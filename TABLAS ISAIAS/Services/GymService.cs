using FitLife.Models;
using FitLife.Repositories;
using System.Collections.Generic;

namespace FitLife.Services
{
    public class GymService
    {
        private readonly MiembroRepository _miembroRepo;

        public GymService(MiembroRepository mRepo)
        {
            _miembroRepo = mRepo;
        }

        public List<Miembro> ObtenerTodos() => _miembroRepo.GetAll();
        public Miembro? BuscarPorCedula(string cedula) => _miembroRepo.GetByCedula(cedula);
        public void Registrar(Miembro m) => _miembroRepo.Add(m);
        public void ActualizarTelefono(string cedula, string tel) => _miembroRepo.UpdatePhone(cedula, tel);
        public void Eliminar(string cedula) => _miembroRepo.Delete(cedula);
    }
}
