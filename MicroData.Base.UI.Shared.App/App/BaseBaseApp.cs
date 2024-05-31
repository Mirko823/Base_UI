using AutoMapper;
using MicroData.Common.Application.Interface;
using MicroData.Common.Domain.Interface;
using MicroData.Common.UI.Shared.Interface;
using MicroData.Common.UI.Shared.ViewModel.Interface;

namespace MicroData.Base.UI.Shared.App.App
{
    public abstract class BaseBaseApp<T, M> : IBaseApi<T> where T : IBaseViewModel where M : IBaseModel
    {
        private readonly IBaseService<M> _baseService;
        private readonly IMapper _mapper;
        public BaseBaseApp(IBaseService<M> baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }

        #region Get
        public async Task<IEnumerable<T>> GetAllAsync(string accessToken)
        {
            var resultModel = await _baseService.GetAllAsync();
            var resultViewModel = _mapper.Map<IEnumerable<T>>(resultModel);

            return resultViewModel;
        }

        public IEnumerable<T> GetAll(string accessToken)
        {
            var resultModel = _baseService.GetAll();
            var resultViewModel = _mapper.Map<IEnumerable<T>>(resultModel);

            return resultViewModel;
        }
        public virtual T Get(object id, string accessToken)
        {
            var resultModel = _baseService.Get(id);
            var resultViewModel = _mapper.Map<T>(resultModel);

            resultViewModel.IsNew = false;
            resultViewModel.IsReadOnly = false;

            return resultViewModel;
        }

        public async Task<T> GetAsync(object id, string accessToken)
        {
            var resultModel = await _baseService.GetAsync(id);
            var resultViewModel = _mapper.Map<T>(resultModel);

            resultViewModel.IsNew = false;
            resultViewModel.IsReadOnly = false;

            return resultViewModel;
        }

        public T GetPreview(object id, string accessToken)
        {
            var resultModel = _baseService.GetPreview(id);
            var resultViewModel = _mapper.Map<T>(resultModel);

            resultViewModel.IsReadOnly = true;

            return resultViewModel;
        }

        public async Task<T> GetPreviewAsync(object id, string accessToken)
        {
            var resultModel = await _baseService.GetPreviewAsync(id);
            var resultViewModel = _mapper.Map<T>(resultModel);

            resultViewModel.IsReadOnly = true;

            return resultViewModel;

        }
        #endregion

        #region Add new
        public T GetNew(string accessToken)
        {
            var resultModel = _baseService.GetNew();
            var resultViewModel = _mapper.Map<T>(resultModel);

            resultViewModel.IsNew = true;
            resultViewModel.IsReadOnly = false;

            return resultViewModel;
        }

        public T CreateNew(T viewModel, string accessToken)
        {
            var model = _mapper.Map<M>(viewModel);

            var resultModel = _baseService.CreateNew(model);

            var resultViewModel = _mapper.Map<T>(resultModel);

            return resultViewModel;
        }

        public async Task<T> CreateNewAsync(T viewModel, string accessToken)
        {
            var model = _mapper.Map<M>(viewModel);


            var resultModel = _baseService.CreateNew(model);

            var resultViewModel = _mapper.Map<T>(resultModel);

            return resultViewModel;
        }

        public T ValidateCreateNew(T model)
        {
            return model;
        }
        #endregion

        #region Edit Existing
        public T EditExisting(T viewModel, string accessToken)
        {
            var model = _mapper.Map<M>(viewModel);

            M resultModel = _baseService.EditExisting(model);

            var resultViewModel = _mapper.Map<T>(resultModel);

            return resultViewModel;
        }

        public async Task<T> EditExistingAsync(T viewModel, string accessToken)
        {
            var model = _mapper.Map<M>(viewModel);

            var resultModel = _baseService.EditExisting(model);

            var resultViewModel = _mapper.Map<T>(resultModel);

            return resultViewModel;
        }

        public T ValidateEditExisting(T model)
        {
            return model;
        }

        #endregion

        #region Delete Existing
        public bool DeleteExisting(object id, string accessToken)
        {

            var resultModel = _baseService.DeleteExisting(id);

            return resultModel;

        }

        public async Task<bool> DeleteExistingAsync(object id, string accessToken)
        {
            var resultModel = _baseService.DeleteExisting(id);

            return resultModel;
        }


        public T ValidateDeleteExisting(T model)
        {
            return model;
        }

        #endregion
    }
}
