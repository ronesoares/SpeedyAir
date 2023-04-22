using Newtonsoft.Json;
using System.Reflection;

namespace Infra.Repository
{
    public class BaseRepository<TEntity>
        where TEntity : class
    {
        protected static ICollection<TEntity> data = new List<TEntity>();

        protected BaseRepository()
        {
        }

        protected void Load(string resourceName)
        {
            if (data.Count == 0)
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                using (var streamReader = new StreamReader(stream))
                {
                    var streamData = streamReader.ReadToEnd();
                    var list = JsonConvert.DeserializeObject<dynamic>(streamData);

                    Mapping(list);
                }
            }
        }

        protected virtual void Mapping(dynamic list)
        {
        }

        public IQueryable<TEntity> GetAll() => data.AsQueryable();
    }
}
