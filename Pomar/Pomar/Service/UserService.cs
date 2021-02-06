using System;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Pomar.Interfaces.Repositories;
using Pomar.Interfaces.Services;
using Pomar.Models;

namespace Pomar.Service
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _userRepository = repository;
        }

        public async Task<User> Get(string usuario, string senha)
        {
            return await _userRepository.Get(usuario);
        }

        public override async Task Add(User user)
        {
            var hashPassword = new HashService(SHA512.Create());

            var newUser = new User(
                usuario: user.Usuario,
                senha: hashPassword.EncryptPassword(user.Senha),
                cargo: user.Cargo
            );

            await _repository.Add(newUser);
        }
    }
}