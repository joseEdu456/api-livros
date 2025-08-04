using api_livros.Application.Interfaces;
using api_livros.Application.Models.InputModels;
using api_livros.Application.Models.ViewModels;
using api_livros.Core.Interfaces;

namespace api_livros.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> DeleteUsuario(int id)
        {
            var user = await _repository.GetUsuarioById(id);

            if(user is null || user.IsDeleted)
            {
                return ResultViewModel.Error("Usuário não existe");
            }

            user.SetAsDeleted();

            await _repository.DeleteUsuario(user);

            return ResultViewModel.Sucess();
        }

        public async Task<ResultViewModel<UsuarioViewModel>> GetUsuarioById(int id)
        {
            var user = await _repository.GetUsuarioById(id);

            if(user is null)
            {
                return ResultViewModel<UsuarioViewModel>.Error("Usuário não existe");
            }

            var model = UsuarioViewModel.FromEntity(user);

            return ResultViewModel<UsuarioViewModel>.Sucess(model);
        }

        public async Task<ResultViewModel<List<UsuarioViewModel>>> GetUsuarios()
        {
            var users = await _repository.GetUsuario();

            if (!users.Any())
            {
                return ResultViewModel<List<UsuarioViewModel>>.Error("Nenhum usuário cadastrado ainda");
            }

            var model = users.Select(o => UsuarioViewModel.FromEntity(o)).ToList();

            return ResultViewModel<List<UsuarioViewModel>>.Sucess(model);
        }

        public async Task<ResultViewModel<UsuarioViewModel>> PostUsuario(UsuarioInputModel model)
        {
            var user = model.ToEntity();

            await _repository.PostUsuario(user);

            var viewModel = UsuarioViewModel.FromEntity(user);

            return ResultViewModel<UsuarioViewModel>.Sucess(viewModel);
        }

        public async Task<ResultViewModel> PutUsuario(AlteracaoUsuarioInputModel model)
        {
            var user = await _repository.GetUsuarioById(model.Id);

            if(user is null || user.IsDeleted)
            {
                return ResultViewModel.Error("Usuário não existe");
            }

            user.AlterarDados(model);

            await _repository.PutUsuario(user);

            return ResultViewModel.Sucess();
        }
    }
}
