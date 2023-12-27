using Nest;
using Shared.Data.Abstract;
using Shared.Entities.Abstract;
using System.Linq.Expressions;

namespace Shared.Data.Concrete.Elasticsearch
{
    public class EsEntityRepositoryBase<T> : IEntityRepository<T> where T : class, IDBEntity, new()
    {
        private readonly IElasticClient _elasticClient;
        private readonly string _indexName;

        public EsEntityRepositoryBase(IElasticClient elasticClient, string indexName)
        {
            _elasticClient = elasticClient;
            _indexName = indexName.ToLower();
        }

        public async Task<T> AddAsync(T entity)
        {
            var response = await _elasticClient.IndexDocumentAsync(entity);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            var response = await _elasticClient.CountAsync<T>(c => c.Query(q => q.Bool(b => b.Must(Query<T>.QueryString(qs => qs.Query(predicate.ToString()))))));
            return response.Count > 0;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            var response = await _elasticClient.CountAsync<T>(c => c.Query(q => q.Bool(b => b.Must(Query<T>.QueryString(qs => qs.Query(predicate.ToString()))))));
            return (int)response.Count;
        }

        public async Task DeleteAsync(T entity)
        {
            var response = await _elasticClient.DeleteAsync<T>(entity);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            var searchResponse = await _elasticClient.SearchAsync<T>(s => s
                .Index(_indexName)
                .Query(q => predicate == null ? q.MatchAll() : q.QueryString(qs => qs.Query(predicate.ToString()))));
            return searchResponse.Documents.ToList();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var searchResponse = await _elasticClient.SearchAsync<T>(s => s
                .Index(_indexName)
                .Query(q => q.QueryString(qs => qs.Query(predicate.ToString()))));
            return searchResponse.Documents.FirstOrDefault();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var searchResponse = await _elasticClient.SearchAsync<T>(s => s
                .Index(_indexName)
                .Query(q => q.QueryString(qs => qs.Query(predicate.ToString()))));
            return searchResponse.Documents.FirstOrDefault();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var response = await _elasticClient.UpdateAsync<T>(DocumentPath<T>.Id(new Id(entity)), u => u.Doc(entity));
            return entity;
        }
    }
}