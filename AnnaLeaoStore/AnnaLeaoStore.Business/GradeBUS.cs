using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;

namespace AnnaLeaoStore.Business
{
    public class GradeBUS
    {
		private GradeREP _gradeREP = new GradeREP();

		public List<GradeMOD> GetAll()
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

		public GradeMOD GetPorId(int id)
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
