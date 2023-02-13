using MGQSBreakfast.Context;
using MGQSBreakfast.Contracts.Repositories;
using MGQSBreakfast.Entities;

namespace MGQSBreakfast.Implementation.Repositories
{
    public class BreakfastRepository : IBreakfastRepository
    {
        private readonly ApplicationDbContext  _context;
        public BreakfastRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public bool BreakfastExist(int id)
        {
            return _context.Breakfasts.Any(bf => bf.Id == id);
        }

        public bool BreakfastExist(string name)
        {
            return _context.Breakfasts.Any(bf => bf.Name == name);
        }

        public Breakfast Create(Breakfast breakfast)
        {
            _context.Breakfasts.Add(breakfast);
            _context.SaveChanges();
            return breakfast;
        }

        public bool Delete(int id)
        {
            var breakfast = GetById(id);
            _context.Breakfasts.Remove(breakfast);
            _context.SaveChanges();
            return true;
        }

        public List<Breakfast> GetAll()
        {
            var breakfasts = _context.Breakfasts.Select(bf => new Breakfast
            {
                Id = bf.Id,
                Name = bf.Name,
                Description = bf.Description
            }).ToList();
            return breakfasts;
        }

        public Breakfast GetById(int id)
        {
            var breakfast = _context.Breakfasts.SingleOrDefault(bf => bf.Id == id);
            return breakfast;
        }

        public Breakfast Update(int id)
        {
            var breakfast = GetById(id);
            _context.Breakfasts.Update(breakfast);
            _context.SaveChanges();
            
            return breakfast;
        }
    }
}