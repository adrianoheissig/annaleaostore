using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnnaLeaoStore.Repository
{
    public class GradesREP
    {
        private DBContext db = new DBContext();
		public List<Grades> GetAll()
        {
            try
            {
                return db.GradesMOD.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public Grades GetById(int id)
        {
			try
			{
                return db.GradesMOD.Find(id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
        }
    }
}
