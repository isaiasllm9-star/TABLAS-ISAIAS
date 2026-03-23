using Spectre.Console;
using FitLife.Services;
using FitLife.Models;
using System.Linq;

namespace FitLife.Screens
{
    public class MenuPrincipal
    {
        private readonly GymService _service;

        public MenuPrincipal(GymService service)
        {
            _service = service;
        }

        public void Mostrar()
        {
            var logo = new FigletText("FitLife").Color(Color.Green);
            AnsiConsole.Write(logo);

            while (true)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("SISTEMA DE GESTIÓN DE MIEMBROS - [cyan]FITLIFE[/]")
                        .PageSize(10)
                        .AddChoices(new[] {
                            "Registrar un nuevo miembro",
                            "Listar todos los miembros",
                            "Buscar un miembro por cédula",
                            "Actualizar el teléfono de un miembro",
                            "Eliminar un miembro",
                            "Salir"
                        }));

                switch (choice)
                {
                    case "Registrar un nuevo miembro": Registrar(); break;
                    case "Listar todos los miembros": Listar(); break;
                    case "Buscar un miembro por cédula": Buscar(); break;
                    case "Actualizar el teléfono de un miembro": Actualizar(); break;
                    case "Eliminar un miembro": Eliminar(); break;
                    case "Salir": return;
                }
            }
        }

        private void Registrar()
        {
            AnsiConsole.MarkupLine("[bold cyan]REGISTRAR NUEVO MIEMBRO[/]");
            var ced = AnsiConsole.Ask<string>("Cédula:");
            var nom = AnsiConsole.Ask<string>("Nombre completo:");
            var tel = AnsiConsole.Ask<string>("Teléfono:");

            _service.Registrar(new Miembro { cedula = ced, nombre_completo = nom, telefono = tel });
            AnsiConsole.MarkupLine("[green]¡Miembro registrado con éxito![/]");
        }

        private void Listar()
        {
            var table = new Table().Border(TableBorder.Rounded);
            table.AddColumn("Cédula");
            table.AddColumn("Nombre completo");
            table.AddColumn("Teléfono");

            var miembros = _service.ObtenerTodos();
            foreach (var m in miembros)
            {
                table.AddRow(m.cedula, m.nombre_completo, m.telefono);
            }
            AnsiConsole.Write(table);
        }

        private void Buscar()
        {
            var ced = AnsiConsole.Ask<string>("Ingrese la cédula a buscar:");
            var m = _service.BuscarPorCedula(ced);

            if (m != null)
            {
                AnsiConsole.MarkupLine($"[green]Encontrado:[/] {m.nombre_completo} - Tel: {m.telefono}");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Miembro no encontrado.[/]");
            }
        }

        private void Actualizar()
        {
            var ced = AnsiConsole.Ask<string>("Ingrese la cédula del miembro a actualizar:");
            var m = _service.BuscarPorCedula(ced);

            if (m != null)
            {
                var newTel = AnsiConsole.Ask<string>("Nuevo teléfono:");
                _service.ActualizarTelefono(ced, newTel);
                AnsiConsole.MarkupLine("[green]¡Teléfono actualizado![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Miembro no encontrado.[/]");
            }
        }

        private void Eliminar()
        {
            var ced = AnsiConsole.Ask<string>("Ingrese la cédula del miembro a eliminar:");
            var m = _service.BuscarPorCedula(ced);

            if (m != null)
            {
                if (AnsiConsole.Confirm($"¿Está seguro de eliminar a {m.nombre_completo}?"))
                {
                    _service.Eliminar(ced);
                    AnsiConsole.MarkupLine("[green]Miembro eliminado.[/]");
                }
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Miembro no encontrado.[/]");
            }
        }
    }
}
