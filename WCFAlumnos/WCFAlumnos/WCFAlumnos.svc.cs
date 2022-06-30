using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entidades;
using Negocio;
using Newtonsoft.Json;

namespace WCFAlumnos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WCFAlumnos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WCFAlumnos.svc o WCFAlumnos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WCFAlumnos : IWCFAlumnos
    {
        NAlumno na = new NAlumno();
        NAlumno NAlumno = new NAlumno();

        public AportacionesIMSS CalcularIMSS(int id)
        {


            Alumno alumno = na.Consultar(id);
            Entidades.AportacionesIMSS aportacionesIMSS = na.CalcularIMSS(alumno.sueldo);
            string json = JsonConvert.SerializeObject(aportacionesIMSS);
            AportacionesIMSS IMSS = JsonConvert.DeserializeObject<AportacionesIMSS>(json);
            return IMSS;
            //throw new NotImplementedException();
        }

        public ItemTablaISR CalcularISR(int id)
        {

            Alumno alumno = NAlumno.Consultar(id);
            decimal sueldo = (alumno.sueldo)/2;
            Entidades.ItemTablaISR itemTablaISR = NAlumno.CalcularISR(sueldo);
            string json = JsonConvert.SerializeObject(itemTablaISR);
            ItemTablaISR ISR = JsonConvert.DeserializeObject<ItemTablaISR>(json);
            return ISR;
            //throw new NotImplementedException();
        }



    }
}
