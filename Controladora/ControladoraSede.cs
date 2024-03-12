using Entidades;
using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraSede
    {
        Context context;

        private ControladoraSede()
        {
            context = new Context();
        }

        private static ControladoraSede instancia;

        public static ControladoraSede Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new ControladoraSede();
                return instancia;
            }
        }

        public Universidad RecuperarUniversidad()
        {
            try
            {
                return context.Universidades.FirstOrDefault(u => u.NombreUniversidad == "UAI");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReadOnlyCollection<Sede> RecuperarSedes()
        {
            try
            {
                return context.Sedes.ToList().AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarSede(Sede sede)
        {
            try
            {
                var listaSedes = context.Sedes.ToList().AsReadOnly();
                var sedeEncontrada = listaSedes.FirstOrDefault(s => s.DireccionSede == sede.DireccionSede || s.NombreSede.ToLower() == sede.NombreSede.ToLower()); //busco la sede por nombre en la lista de sedes para evitar que se repitan
                if (sedeEncontrada == null) //si no se encuentra la sede, la agrego
                {
                    context.Sedes.Add(sede);
                    int insertados = context.SaveChanges(); //guardo los cambios
                    if (insertados > 0) //insertados es la cantidad de registros afectados
                    {
                        return $"La sede se agregó correctamente";
                    }
                    else return $"La sede no se ha podido agregar";
                }
                else
                {
                    return $"La sede ya existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarSede(Sede sede)
        {
            try
            {
                var listaSedes = context.Sedes.ToList().AsReadOnly();
                var sedeEncontrada = listaSedes.FirstOrDefault(s => s.SedeId == sede.SedeId || s.NombreSede.ToLower() == sede.NombreSede.ToLower());
                if (sedeEncontrada != null)
                {
                    sedeEncontrada.NombreSede = sede.NombreSede;
                    sedeEncontrada.DireccionSede = sede.DireccionSede;
                    int insertados = context.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"La sede se modificó correctamente";
                    }
                    else return $"La sede no se ha podido modificar";
                }
                else
                {
                    return $"La sede no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }

        }

        public string EliminarSede(Sede sede)
        {
            try
            {
                var listaSedes = context.Sedes.ToList().AsReadOnly();
                var sedeEncontrada = listaSedes.FirstOrDefault(s => s.NombreSede.ToLower() == sede.NombreSede.ToLower());
                if (sedeEncontrada != null) //si la sede existe, la elimino
                {
                    context.Sedes.Remove(sede);
                    int insertados = context.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"La sede se eliminó correctamente";
                    }
                    else return $"La sede no se ha podido eliminar";
                }
                else
                {
                    return $"La sede no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
    }
}
