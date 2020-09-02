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
        
        public async Task Save(WordEntity word)
        {
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(
                    @"insert into Words(Base, Data) values(@Base, @Data)
                          on conflict(Base) do update set Data = @Data",
                    word
                );
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

        public async Task<string[]> GetAll()
        {
            using (var connection = CreateConnection())
            {
                var words = await connection
                    .QueryAsync<string>(
                        "select base from Words"
                    );
                return words.ToArray();
            }
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