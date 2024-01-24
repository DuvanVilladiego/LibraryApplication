﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL
{
    internal class Constants
    {
        public class Messages
        {
            //general messages
            public const string SuccessMessage = "Operación exitosa";
            public const string ErrorMessage = "Error en la operación";
            public const string WarningMessage = "Advertencia";
            public const string InformationMessage = "Información adicional";

            //query errors
            public const string NoFoundItems = "No se encontraron registros";
        }
    }

}
