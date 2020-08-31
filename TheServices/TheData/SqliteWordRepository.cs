using System;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TheData.Exceptions;

namespace TheData
{
    public class SqliteWordRepository : IWordRepository
    {
        private readonly string DB_FILE = $"{Environment.CurrentDirectory}\\Thesaurus.sqlite";

        public SqliteWordRepository()
        {
            using(var connection = CreateConnection())
            {
                connection.Open();
                connection.Execute(
                    @"
                        CREATE TABLE IF NOT EXISTS Words (
                            Base TEXT PRIMARY KEY,
                            Data TEXT
                        );
                    ");
            }
        }
        
        public async Task Create(WordEntity word)
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    await connection.ExecuteAsync(
                        @"insert into Words(Base, Data) values(@Base, @Data)",
                        word
                    );
                }
                catch (SQLiteException ex)
                {
                    if (ex.Message.Contains("UNIQUE constraint failed"))
                    {   
                        throw new WordAlreadyExistsException
                        {
                            WordBase = word.Base
                        };
                    }
                }
            }
        }

        public async Task<WordEntity> Get(string @base)
        {
            using(var connection = CreateConnection())
            {
                var wordEntity = await connection
                    .QuerySingleOrDefaultAsync<WordEntity>(
                        "select * from Words where base = @base",
                        new { Base = @base }
                );
                if (wordEntity == default(WordEntity))
                {
                    throw new WordNotFoundException
                    {
                        WordBase = @base
                    };
                }

                return wordEntity;
            }
        }

        public async Task<WordEntity[]> GetAll()
        {
            using (var connection = CreateConnection())
            {
                var words = await connection
                    .QueryAsync<WordEntity>(
                        "select * from Words"
                    );
                return words.ToArray();
            }
        }

        public Task Edit(WordEntity wordEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string @base)
        {
            throw new System.NotImplementedException();
        }
        
        private SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection($"Data Source={DB_FILE};");
        }
    }
}