using SchoolAgain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAgain.Controllers.Api
{
    public class TeacherController : ApiController
    {
        // GET: api/Teacher
        string connectionString = "Data Source=.;Initial Catalog=School;Integrated Security=True;Pooling=False";
        List<Teacher> TeachersList = new List<Teacher>();
        public IHttpActionResult Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            try
            {

                connection.Open();
                string query = @"SELECT * FROM Teacher";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader dataFromDb = command.ExecuteReader();
                if (dataFromDb.HasRows)
                {
                    while (dataFromDb.Read())
                    {
                        //TeachersList.Add(new Teacher());
                        TeachersList.Add(new Teacher(dataFromDb.GetInt32(0), dataFromDb.GetString(1), dataFromDb.GetString(2), dataFromDb.GetInt32(3), dataFromDb.GetDateTime(4)));
                    }
                    connection.Close();
                }
                return Ok(new { TeachersList });
            }
            catch (SqlException)
            {

                throw;
            }
                catch (Exception)
                {

                    throw;
                }

        }

        // GET: api/Teacher/5
        public IHttpActionResult Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                connection.Open();
                string query = $@"SELECT * FROM Teacher WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader dataFromDb = command.ExecuteReader();
                if (dataFromDb.HasRows)
                {
                    while (dataFromDb.Read())
                    {
                        Teacher TheTeacher = new Teacher(dataFromDb.GetInt32(0), dataFromDb.GetString(1), dataFromDb.GetString(2), dataFromDb.GetInt32(3), dataFromDb.GetDateTime(4));
                        connection.Close();
                        return Ok(new { TheTeacher });

                    }
                }

            return Ok("good Job");
                }
                catch (SqlException)
                {

                    throw;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        // POST: api/Teacher
        public IHttpActionResult Post([FromBody] Teacher value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                connection.Open();
                string query = $@"INSERT INTO Teacher (fName,lName,salary,birthDate) VALUES ('{value.FName}','{value.LName}','{value.Salary}','{value.BirthDate}')";
                SqlCommand command = new SqlCommand(query, connection);
                int dataFromDB = command.ExecuteNonQuery();
                connection.Close();
                }
                catch (SqlException)
                {

                    throw;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Ok("the teacher was add");
        }

        // PUT: api/Teacher/5
        public IHttpActionResult Put(int id, [FromBody] Teacher value)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                connection.Open();
                string query = $@"UPDATE Teacher SET  fName = '{value.FName}', lName = '{value.LName}', salary = '{value.Salary}',birthDate = '{value.BirthDate}' WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query,connection);
                int dataFromDB = command.ExecuteNonQuery();
                connection.Close();
                return Ok(Get());
                }
                catch (SqlException)
                {

                    throw;
                }
                catch (Exception)
                {

                    throw;
                }
            };
            return Ok("good job");
        }

        // DELETE: api/Teacher/5
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                connection.Open();
                string query = $@"DELETE FROM Teacher WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                int dataFromDB = command.ExecuteNonQuery();
                connection.Close();
                return Ok(Get());
                }
                catch (SqlException)
                {

                    throw;
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return Ok(Get());
        }
    }
}
