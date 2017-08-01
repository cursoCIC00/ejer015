using ejer15.Models;
using ejer15.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejer15.Servicios
{
    public class EntradasService : IEntradasService
    {


        private IEntradasRepository entradasRepository;
        public EntradasService(IEntradasRepository _entradasRepository)
        {
            this.entradasRepository = _entradasRepository;
        }

        public Entrada Create(Entrada entrada)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entrada = entradasRepository.Create(entrada);

                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transacción", e);
                    }
                }
            }
            return entrada;
        }
    }
}