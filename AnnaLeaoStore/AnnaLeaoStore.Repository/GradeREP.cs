using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using AnnaLeaoStore.Repository.Extensions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Repository
{
    public class GradeREP
    {
		private ADO _ado = new ADO();

		public List<Grade> GetAll()
        {
            try
            {
                string storedProcedure = "LISTARGRADE";
                List<Grade> grades = new List<Grade>();

                DataTable registros = _ado.RetornarTabela(storedProcedure, CommandType.StoredProcedure);

				foreach (DataRow item in registros.Rows)
				{
					grades.Add(new Grade
					{
						ID = item.GetValue<int>("ID"),
						Descricao = item.GetText("DESCRICAO"),
						Tam1 = item.GetText("TAM1"),
						Tam2 = item.GetText("TAM2"),
						Tam3 = item.GetText("TAM3"),
						Tam4 = item.GetText("TAM4"),
						Tam5 = item.GetText("TAM5"),
						Tam6 = item.GetText("TAM6"),
						Tam7 = item.GetText("TAM7"),
						Tam8 = item.GetText("TAM8"),
						Tam9 = item.GetText("TAM9"),
						Tam10 = item.GetText("TAM10")
					});
                }
                return grades;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public Grade GetPorId(int id)
        {
			try
			{
				string storedProcedure = "LISTARGRADEPORID";
                Grade grade = new Grade();

                DataTable registros = _ado.RetornarTabela(storedProcedure, CommandType.StoredProcedure, "@ID", id);

                foreach (DataRow item in registros.Rows)
                {
                    grade.Descricao = item.GetText("DESCRICAO");
					grade.Tam1 = item.GetText("TAM1");
					grade.Tam2 = item.GetText("TAM2");
					grade.Tam3 = item.GetText("TAM3");
					grade.Tam4 = item.GetText("TAM4");
					grade.Tam5 = item.GetText("TAM5");
					grade.Tam6 = item.GetText("TAM6");
					grade.Tam7 = item.GetText("TAM7");
					grade.Tam8 = item.GetText("TAM8");
					grade.Tam9 = item.GetText("TAM9");
					grade.Tam10 = item.GetText("TAM10");
                }

				if (grade.Descricao == null)
				{
					throw new Exception("Não Encontrado");
				}

				return grade;

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
        }
    }
}
