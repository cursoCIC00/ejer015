using ejer15.Models;
using ejer15.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejer15.Repository
{
    public class EntradasRepository : IEntradasRepository
    {
        public Entrada Create(Entrada entrada)
        {


            return ApplicationDbContext.applicationDbContext.Entradas.Add(entrada);

        }
    }
}