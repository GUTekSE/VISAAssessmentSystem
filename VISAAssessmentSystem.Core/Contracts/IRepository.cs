using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VISAAssessmentSystem.Core.Models;

namespace VISAAssessmentSystem.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();

        void Commit();

        void DeleteStringId(string Id);

        T FindStringId(string Id);

        void Insert(T t);

        void Update(T t);

        string FindMaxClientID();

        T FindIntId(int Id);

        int FindClientContractNo(string Id);

        void DeleteIntId(int Id);

        int FindMaxCountryId();

        int FindMaxSchoolId();

        int FindMaxCourseId();

        int FindMaxJobId();

        int FindMaxProfessionId();

        int FindMaxProgramId();

        int FindMaxContractNo();
    }
}
