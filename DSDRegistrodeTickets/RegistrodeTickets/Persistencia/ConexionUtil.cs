﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrodeTickets.Persistencia
{
    public class ConexionUtil
    {
           public static string ObtenerCadena()
        {
            return "Data Source=localhost;Initial Catalog=RegistroTickets;Integrated Security=True;";
            //return "Data Source = chio - hp; Initial Catalog = BD_Empleados; Integrated Security = True;";
        }
    }
}