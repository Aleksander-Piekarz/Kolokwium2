using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Kolokwium.DAL;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM;
using System.Linq.Expressions;
using Kolokwium.Model.DataModels;

namespace Kolokwium.Services.ConcreteServices;

public class KsiazkaService : BaseService, IKsiazkaService
{
    public KsiazkaService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger)
    {
    }

    public IEnumerable<KsiazkiVm> GetKsiazki(Expression<Func<KsiazkiVm, bool>>? filter = null)
    {
        var query = DbContext.Ksiazki.Include(k => k.Autor).AsQueryable();

        var mapped = Mapper.ProjectTo<KsiazkiVm>(query);

        if (filter != null)
        {
            mapped = mapped.Where(filter);
        }

        return mapped.ToList();
    }

     public KsiazkiVm AddKsiazka(AddKsiazkaVm addKsiazkaVm)
    {
        // Mapuj AddKsiazkaVm do encji Ksiazka
        var ksiazka = Mapper.Map<Ksiazka>(addKsiazkaVm);
        DbContext.Ksiazki.Add(ksiazka);
        DbContext.SaveChanges();

        // Mapuj z powrotem do KsiazkiVm jeśli chcesz zwrócić ViewModel
        return Mapper.Map<KsiazkiVm>(ksiazka);
    }
    public KsiazkiVm DeleteKsiazka(int id)
    {
        var ksiazka = DbContext.Ksiazki.Find(id);
        if (ksiazka != null)
        {
            DbContext.Ksiazki.Remove(ksiazka);
            DbContext.SaveChanges();
        }
        else
        {
            Logger.LogWarning($"Książka o ID {id} nie została znaleziona.");
        }
        return Mapper.Map<KsiazkiVm>(ksiazka);
    }
}





