using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VISAAssessmentSystem.Core.Contracts;
using VISAAssessmentSystem.Core.Models;

namespace VISAAssessmentSystem.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;

        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }


        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void DeleteStringId(string Id)
        {
            var t = FindStringId(Id);
            if (context.Entry(t).State == EntityState.Detached)
                dbSet.Attach(t);

            dbSet.Remove(t);
        }

        public void DeleteIntId(int Id)
        {
            var t = FindIntId(Id);
            if (context.Entry(t).State == EntityState.Detached)
                dbSet.Attach(t);

            dbSet.Remove(t);
        }

        public T FindStringId(string Id)
        {
            return dbSet.Find(Id);
        }


        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }

        public T FindIntId(int Id)
        {
            return dbSet.Find(Id);
        }

        public String FindMaxClientID()
        {

            string id = context.Clients.Max(u => (string)u.Id);
            if (id == null) { id = "0"; }
            id = string.Format("{0:D6}", Int32.Parse(id) + 1);
            return id;
        }

        public int FindMaxCountryId()
        {
            int id = context.Countries.Where(p => p != null)
                 .Select(p => p.CountryId)
                 .DefaultIfEmpty()
                 .Max();
            
            id += 1;
            return id;
        }

        public int FindMaxSchoolId()
        {
            int id = context.Schools.Where(p => p != null)
                 .Select(p => p.SchoolId)
                 .DefaultIfEmpty()
                 .Max();

            id += 1;
            return id;
        }

        public int FindMaxCourseId()
        {
            int id = context.Courses.Where(p => p != null)
                 .Select(p => p.CourseId)
                 .DefaultIfEmpty()
                 .Max();
            
            id += 1;
            return id;
        }

        public int FindMaxJobId()
        {
            int id = context.Jobs.Where(p => p != null)
                 .Select(p => p.JobId)
                 .DefaultIfEmpty()
                 .Max();

            id += 1;
            return id;
        }
        public int FindMaxProfessionId()
        {
            int id = context.Professions.Where(p => p != null)
                 .Select(p => p.ProfessionId)
                 .DefaultIfEmpty()
                 .Max();

            id += 1;
            return id;
        }

        public int FindMaxProgramId()
        {
            int id = context.Programs.Where(p => p != null)
                 .Select(p => p.ProgramId)
                 .DefaultIfEmpty()
                 .Max();

            id += 1;
            return id;
        }

        public int FindMaxContractNo()
        {
            int id = context.Contracts.Where(p => p != null)
                 .Select(p => p.ContractNo)
                 .DefaultIfEmpty()
                 .Max();

            id += 1;
            return id;
        }

        public int FindClientContractNo(string Id)
        {

            var contract = (from u in context.Contracts
                        where u.Id == Id
                        select u).FirstOrDefault();
            if (contract == null) 
            {
                return 0;
            }
            else
            {
                return contract.ContractNo;
            }

            
        }
    }
}
