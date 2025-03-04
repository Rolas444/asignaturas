using System.Data;
using Dapper;
using Microsoft.Extensions.Caching.Memory;


public class AsignaturaService{

    private readonly IDbConnection _dbConnection;
    private readonly IMemoryCache _cache;

    public AsignaturaService(IDbConnection dbConnection, IMemoryCache cache)
    {
        _dbConnection = dbConnection;
        _cache = cache;
    }

    public async Task<IEnumerable<Asignaturas>> GetAsignaturas()
    {
        const string cacheKey = "AsignaturasCache";
        if(!_cache.TryGetValue(cacheKey, out IEnumerable<Asignaturas> asignaturas))
        {

            asignaturas = await _dbConnection.QueryAsync<Asignaturas>(
            @"SELECT  a.IdAsignatura, a.CodAsignatura, a.IdTipoAsignatura, a.ECTS, a.Asignatura, a.EsPersonalizable, a.Horas
            FROM  TAsignaturas a
            INNER JOIN TProgramasAsignaturas ta ON a.IdAsignatura = ta.IdAsignatura
            WHERE ta.IdPrograma = 1 
            ");

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30));

            _cache.Set(cacheKey, asignaturas, cacheEntryOptions);    
        }

        return asignaturas;
    }

}