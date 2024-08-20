using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly SignalRContext _context;

        public GenericRepository(SignalRContext context)
        {
            _context = context;
        }
        //Dependency injection kolaylıkla uygulamam için yapıcı method kurdum Dependency injection bu da bana bağlılıkları azaltacak 
        // Farklı bir ORM aracına geçersem bana süper kolaylık sğlamaktadır 
        
        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
			_context.SaveChanges();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id); 

        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
    // Repository katmanı şuanlık bu şekilde eğer ileride ekstra bir method tanımlamak istersem önce gidip genericdal içerisinde yazacağım 
    // daha sonra gecericRepository içerisinde gelip dolduracağım
}
