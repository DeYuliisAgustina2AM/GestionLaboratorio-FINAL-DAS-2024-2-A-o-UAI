﻿using Entidades;
using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraTecnico
    {
        Context context;

        private ControladoraTecnico()
        {
            context = new Context();
        }

        private static ControladoraTecnico instancia;

        public static ControladoraTecnico Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new ControladoraTecnico();
                return instancia;
            }
        }

        public ReadOnlyCollection<Tecnico> RecuperarTecnicos()
        {
            try
            {
                return context.Tecnicos.ToList().AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarTecnico(Tecnico tecnico)
        {
            try
            {
                var listaTecnicos = context.Tecnicos.ToList().AsReadOnly();
                var tecnicoEncontrado = listaTecnicos.FirstOrDefault(t => t.TecnicoId == tecnico.TecnicoId && t.NombreyApellido.ToLower() == tecnico.NombreyApellido.ToLower());
                if (tecnicoEncontrado == null)
                {
                    context.Tecnicos.Add(tecnico);
                    int agregados = context.SaveChanges();
                    if (agregados > 0)
                    {
                        return $"El tecnico se agregó correctamente";
                    }
                    else return $"El tecnico no se ha podido agregar";
                }
                else return $"El tecnico ya existe";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el tecnico", ex);
            }
        }

        public string ModificarTecnico(Tecnico tecnico)
        {
            try
            {
                var listaTecnicos = context.Tecnicos.ToList().AsReadOnly();
                var tecnicoEncontrado = listaTecnicos.FirstOrDefault(t => t.TecnicoId == tecnico.TecnicoId && t.NombreyApellido.ToLower() == tecnico.NombreyApellido.ToLower());
                if (tecnicoEncontrado != null)
                {
                    tecnicoEncontrado.NombreyApellido = tecnico.NombreyApellido;
                    tecnicoEncontrado.Dni = tecnico.Dni;
                    tecnicoEncontrado.Legajo = tecnico.Legajo;

                    int modificados = context.SaveChanges(); //guardo los cambios

                    if (modificados > 0)
                    {
                        return $"El tecnico se modificó correctamente";
                    }
                    else return $"El tecnico no se ha podido modificar";
                }
                else return $"El tecnico no existe";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el tecnico", ex);
            }
        }

        public string EliminarTecnico(Tecnico tecnico)
        {
            try
            {
                var listaTecnicos = context.Tecnicos.ToList().AsReadOnly();
                var tecnicoEncontrado = listaTecnicos.FirstOrDefault(t => t.TecnicoId == tecnico.TecnicoId && t.NombreyApellido.ToLower() == tecnico.NombreyApellido.ToLower());
                if (tecnicoEncontrado != null)
                {
                    context.Tecnicos.Remove(tecnicoEncontrado);
                    int eliminados = context.SaveChanges();
                    if (eliminados > 0)
                    {
                        return $"El tecnico se eliminó correctamente";
                    }
                    else return $"El tecnico no se ha podido eliminar";
                }
                else return $"El tecnico no existe";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el tecnico", ex);
            }
        }
    }
}
