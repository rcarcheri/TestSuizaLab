using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSuizaLab.MODEL;
using TestSuizaLab.CONTROLLLER;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TestSuizaLab.ApiControlller
{
    [Produces("application/json")]
    [Route("api/Citas")]
    public class UserController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public UserController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        [Route("GetCitasPaciente"),Authorize]
        public IActionResult GetCitasPaciente(Int documentoPaciente)
        {
            var data = TestSuizaLab.CONTROLLLER.DbCitasPacientes.ListarCitas(documentoPaciente);
            return Ok(data);
        }

        [HttpPost]
        [Route("SaveCitaPaciente")]
        public IActionResult SaveCitaPaciente(Int documentoPaciente,int tipodocP, string EspecialidadP,string fechaP)
        {
            string msg = ''
            var data = TestSuizaLab.CONTROLLLER.DbCitasPacientes.RegistrarActualizarCita(0,documentoPaciente, tipodocP,EspecialidadP,fechaP);
            if (data == "0")
            {
                    msg = "Cita registrada correctamente.";
            }
            else if (data == "3")
            {
                    msg = "Cita existente.";
            }
            return Ok(msg);
        }

        [HttpPut]
        [Route("UpdateCitaPaciente")]
        public IActionResult UpdateCitaPaciente(Int documentoPaciente,int tipodocP, string EspecialidadP,string fechaP)
        {
            string msg = ''
            var data = TestSuizaLab.CONTROLLLER.DbCitasPacientes.RegistrarActualizarCita(1,documentoPaciente, tipodocP,EspecialidadP,fechaP);
            if (data == "1")
            {
                    msg = "Cita actualizada correctamente.";
            }
            else if (data == "2")
            {
                    msg = "No existe cita registrada.";
            }
            return Ok(msg);
        }

        [HttpDelete]
        [Route("DeleteCitaPaciente")]
        public IActionResult DeleteCitaPaciente(Int documentoPaciente,int tipodocP, string EspecialidadP,string fechaP)
        {
            string msg = ''
            var data = TestSuizaLab.CONTROLLLER.DbCitasPacientes.EliminarCita(1,documentoPaciente, tipodocP,EspecialidadP,fechaP);
            if (data == "1")
            {
                    msg = "Cita no existe";
            }
            else if (data == "0")
            {
                    msg = "Cita eliminada correctamente";
            }
            return Ok(msg);
        }
    }
}