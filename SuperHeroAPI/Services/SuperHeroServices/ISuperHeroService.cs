﻿namespace SuperHeroAPI.Services.SuperHeroServices
{
    public interface ISuperHeroServiceAsync
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero>? GetSingleHero(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>>? UpdateHero(int id, SuperHero request);
        Task<List<SuperHero>>? DeleteHero(int id);
    }
}
