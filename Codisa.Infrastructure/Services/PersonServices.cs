using Dapper;
using HugoApp.Core.Entities;
using HugoApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HugoApp.Infrastructure.Services
{
    public class PersonServices : IPersonServices
    {
        #region ATTRIBUTES
        private readonly string _conn;
        #endregion

        #region CONSTRUCTOR
        public PersonServices(string dbConnection)
        {
            _conn = dbConnection;
        }
        #endregion

        #region METHODS
        public async Task<List<Person>> GetAllPerson()
        {
            var persons = new List<Person>();

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"SELECT 
                                        Id,
                                        Name,
                                        Surname
                                    FROM Person;";

                    persons = (await _db.QueryAsync<Person>(_query)).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return persons;
        }

        public async Task<int> CreatePerson(Person person)
        {
            int rowsAffected = 0;

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"INSERT 
                                        INTO 
                                    Person (
                                        Name,
                                        Surname
                                    ) 
                                    VALUES (
                                        @Name,
                                        @Surname
                                    );";

                    rowsAffected = await _db.ExecuteAsync(_query, person);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }

        public async Task<int> UpdatePerson(Person person)
        {
            int rowsAffected = 0;

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"UPDATE
                                     Person SET
                                        Name = @Name,
                                        Surname = @Surname
                                     WHERE Id = @Id;";

                    rowsAffected = await _db.ExecuteAsync(_query, person);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }

        public async Task<int> DeletePerson(int id)
        {
            int rowsAffected = 0;

            try
            {
                using (var _db = new SqlConnection(_conn))
                {
                    string _query = @"DELETE
                                     Person
                                     WHERE Id = @Id;";

                    rowsAffected = await _db.ExecuteAsync(_query, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }
        #endregion
    }
}
