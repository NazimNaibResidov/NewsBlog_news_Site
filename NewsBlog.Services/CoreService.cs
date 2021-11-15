using AutoMapper;
using NewsBlog.Base.BaseRepositories;
using NewsBlog.Base.BaseUnitOfWork;
using NewsBlog.Interfaces.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsBlog.Services
{
    public class CoreService<T> : ICoreService<T> where T : class
    {
        #region .:: FIELDS ::.

        private readonly IMapper _mapper;
        public readonly ICrudGenericRepository<T> _repository;

        #endregion .:: FIELDS ::.

        #region .:: CTOR ::.

        public CoreService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = unitOfWork.Repository<T>();
        }

        #endregion .:: CTOR ::.

        #region .::Methods ::.

        #region .:: Query , Filter ::.

        public IQueryable<T> Filter(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            int page, int pageSize)
        {
            var query = _repository.Query();

            if (filter != null) query = query.Where(filter);

            if (orderBy != null) query = orderBy(query);

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            return query;
        }

        public IQueryable<T> GetAll()
        {
            return _repository.Query();
        }

        #endregion .:: Query , Filter ::.

        #region .:: Find methods ::.

        public async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> match)
        {
            return await _repository.FindByAsync(match);
        }

        public async Task<ICollection<TDto>> FindByMappedAsync<TDto>(Expression<Func<T, bool>> match)
        {
            var entities = await _repository.FindByAsync(match);

            return CreateDtoInstance<TDto>(entities);
        }

        public virtual bool FindAny(Expression<Func<T, bool>> match)
        {
            return _repository.FindAny(match);
        }

        public virtual async Task<bool> FindAnyAsync(Expression<Func<T, bool>> match)
        {
            return await _repository.FindAnyAsync(match);
        }

        public virtual async Task<T> FindByIdAsync(object id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public virtual async Task<K> FindByIdAsync<K>(object id)
        {
            var entity = await _repository.FindByIdAsync(id);

            if (entity == null) return default;

            return CreateDtoInstance<K>(entity);
        }

        public virtual async Task<T> FindFirstAsync(Expression<Func<T, bool>> match)
        {
            return await _repository.FindFirstAsync(match);
        }

        public virtual async Task<K> FindFirstAsync<K>(Expression<Func<T, bool>> match)
        {
            var entity = await _repository.FindFirstAsync(match);

            if (entity == null) return default;

            return CreateDtoInstance<K>(entity);
        }

        #endregion .:: Find methods ::.

        #region .:: CRUD ::.

        #region add

        public virtual T Add<K>(K dto, bool isUnCommitted = false)
        {
            var entity = CreateEntityInstance(dto);

            _repository.Add(entity, isUnCommitted);

            return entity;
        }

        public virtual T Add(T entity, bool isUnCommitted = false)
        {
            _repository.Add(entity, isUnCommitted);

            return entity;
        }

        public virtual async Task<T> AddAsync<K>(K dto, bool isUnCommitted = false)
        {
            var entity = CreateEntityInstance(dto);

            await _repository.AddAsync(entity, isUnCommitted);

            return entity;
        }

        public virtual async Task<T> AddAsync(T entity, bool isUnCommitted = false)
        {
            await _repository.AddAsync(entity, isUnCommitted);

            return entity;
        }

        public virtual async Task<K> AddMappedAsync<K>(K dto)
        {
            var entity = CreateEntityInstance(dto);

            await _repository.AddAsync(entity, true);

            Map(entity, dto);

            return dto;
        }

        public virtual async Task AddRangeAsync(ICollection<T> entities, bool isUnCommitted = false)
        {
            await _repository.AddRangeAsync(entities, isUnCommitted);
        }

        #endregion add

        #region update

        public virtual async Task UpdateAsync<K>(K dto, bool isUnCommitted = false)
        {
            var id = typeof(K).GetProperty("Id").GetValue(dto);

            var entity = await _repository.FindByIdAsync(id);

            if (entity == null) throw new ArgumentNullException($"On Update {typeof(T).FullName} is null.");

            Map(dto, entity);

            await _repository.UpdateAsync(entity, isUnCommitted);
        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities, bool isUnCommitted = false)
        {
            await _repository.UpdateRangeAsync(entities, isUnCommitted);
        }

        #endregion update

        #region delete

        public virtual async Task DeleteAsync(object id, bool isUnCommitted = false)
        {
            var entity = _repository.FindById(id);

            if (entity == null) throw new ArgumentNullException($"On Delete {typeof(T).FullName} is null.");

            await _repository.DeleteAsync(entity, isUnCommitted);
        }

        public virtual async Task DeleteRangeAsync(ICollection<T> entities, bool isUnCommitted = false)
        {
            await _repository.DeleteRangeAsync(entities, isUnCommitted);
        }

        #endregion delete

        #endregion .:: CRUD ::.

        #endregion .::Methods ::.

        #region .::Mapper ::.

        protected TL Map<TK, TL>(TK source, TL destination)
        {
            _mapper.Map(source, destination);

            return destination;
        }

        protected T CreateEntityInstance<TK>(TK source)
        {
            var destination = Activator.CreateInstance<T>();

            _mapper.Map(source, destination);

            return destination;
        }

        protected TK CreateDtoInstance<TK>(T source)
        {
            var destination = Activator.CreateInstance<TK>();

            _mapper.Map(source, destination);

            return destination;
        }

        protected ICollection<T> CreateEntityInstance<TDto>(ICollection<TDto> source)
        {
            ICollection<T> destination = Activator.CreateInstance<List<T>>();
            _mapper.Map(source, destination);

            return destination;
        }

        protected ICollection<TDto> CreateDtoInstance<TDto>(ICollection<T> source)
        {
            ICollection<TDto> destination = Activator.CreateInstance<List<TDto>>();

            _mapper.Map(source, destination);

            return destination;
        }

        #endregion .::Mapper ::.
    }
}