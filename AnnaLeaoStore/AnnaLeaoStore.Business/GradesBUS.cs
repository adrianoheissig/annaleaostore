using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;

namespace AnnaLeaoStore.Business
{
    public class GradesBUS
    {
		private GradesREP _gradeREP = new GradesREP();

		public List<Grades> GetAll()
        {
            try
            {
				return _gradeREP.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

		public Grades GetPorId(int id)
        {
			try
			{
				return _gradeREP.GetPorId(id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

        }
    }
}
